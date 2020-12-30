using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.BitConverter;

namespace mancala
{

    public struct PositionKey
    {
        public long BoardState0 { get; }
        public long BoardState1 { get; }

        public PositionKey(long boardState0, long boardState1)
        {
            BoardState0 = boardState0;
            BoardState1 = boardState1;
        }
        public byte[] ToLeBytes()
        {
            return (byte[])GetBytes(BoardState0).Concat(GetBytes(BoardState1)).ToArray().Clone();
        }

        public override bool Equals(object obj)
        {
            return obj is PositionKey key &&
                   BoardState0 == key.BoardState0 &&
                   BoardState1 == key.BoardState1;
        }

        public override int GetHashCode()
        {
            var hashCode = -1877348453;
            hashCode = hashCode * -1521134295 + BoardState0.GetHashCode();
            hashCode = hashCode * -1521134295 + BoardState1.GetHashCode();
            return hashCode;
        }

        public PositionKey(byte[] vs) : this(ToInt64(vs, 0), ToInt64(vs, 8)) { }

    }

    public struct PositionValue
    {
        public int Value { get;}
        public int Visit { get;}

        public PositionValue(int value, int visit)
        {
            Value = value;
            Visit = visit;
        }

        public byte[] ToLeBytes()
        {
            return (byte[])GetBytes(Value).Concat(GetBytes(Visit)).ToArray().Clone();
        }

        public PositionValue(byte[] vs) : this(ToInt32(vs, 0), ToInt32(vs, 4)) { } 

    }

    public struct PositionFileHeader
    {
        public uint Version { get; }
        public uint RecordNum { get;}

        public PositionFileHeader(uint version, uint recordNum)
        {
            Version = version;
            RecordNum = recordNum;
        }

        public byte[] ToLeBytes()
        {
            return (byte[])GetBytes(Version).Concat(GetBytes(RecordNum)).ToArray().Clone();
        }

        public PositionFileHeader(byte[] vs) :this(ToUInt32(vs, 0), ToUInt32(vs, 4)) { } 

    }

    public class PositionMap
    {
        private Dictionary<PositionKey,PositionValue> PositionMapTable { get; set; }
        public PositionMap()
        {
            this.PositionMapTable = new Dictionary<PositionKey, PositionValue>();
        }

        public void Load(string filePath)
        {          
            using (FileStream fs = new System.IO.FileStream(filePath, FileMode.Open))
            {
                int idx = 0;
                int readByte = 8;

                byte[] data = new byte[readByte];
                fs.Read(data, idx, readByte);
                PositionFileHeader header = new PositionFileHeader(data);

                PositionMapTable.Clear();

                for (int i = 0; i < header.RecordNum; i++)
                {
                    data = new byte[readByte * 3];
                    fs.Read(data, idx, readByte);
                    PositionKey key = new PositionKey(data.Take(16).ToArray());
                    PositionValue value = new PositionValue(data.Skip(16).Take(8).ToArray());
                    PositionMapTable.Add(key, value);
                    idx += readByte * 3;
                }
            }
        }

        public void Save(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                var header = new PositionFileHeader(1, (uint)PositionMapTable.Count);
                int idx = 0;

                var headerBytes = header.ToLeBytes();
                fs.Write(headerBytes,idx,headerBytes.Length);
                //idx += headerBytes.Length;

                foreach (var positionMap in PositionMapTable)
                {
                    var positionMapKeyBytes = positionMap.Key.ToLeBytes();
                    var positionMapValueBytes = positionMap.Value.ToLeBytes();
                    fs.Write(positionMapKeyBytes,idx,positionMapKeyBytes.Length);
                    //idx += positionMapKeyBytes.Length;
                    fs.Write(positionMapValueBytes,idx,positionMapValueBytes.Length);
                    //idx += positionMapValueBytes.Length;
                }
            }
        }

        public int GetLength()
        {
            return PositionMapTable.Count;
        }

        public PositionValue? GetPositionValue(BoardState boardState)
        {
            var turn = boardState.Turn;
            var opponent = boardState.GetOpponentTurn();
            var key = new PositionKey(boardState.Seed_states[(int)turn], boardState.Seed_states[(int)opponent]) ;

            if (PositionMapTable.ContainsKey(key))
            {
                PositionValue positionValue = (PositionValue)PositionMapTable[key];
                return new PositionValue
                    (
                          positionValue.Value + ((boardState.Stores[(int)turn] - boardState.Stores[(int)opponent]) * EvaluatorConst.VALUE_PER_SEED)
                        , positionValue.Visit
                    );
            }
            else
            {
                return null;
            }
        }

        public void Add(BoardState boardState,int value)
        {
            var turn = boardState.Turn;
            var opponent = boardState.GetOpponentTurn();
            var key = new PositionKey(boardState.Seed_states[(int)turn], boardState.Seed_states[(int)opponent]);
            var positionValue = GetPositionValue(boardState);

            int visit = 0;
            if (positionValue != null) visit = positionValue.Value.Visit;

            var newPositionValue = new PositionValue
                (value - (boardState.Stores[(int)turn] - boardState.Stores[(int)opponent]) * EvaluatorConst.VALUE_PER_SEED, visit += 1);

            PositionMapTable.Add(key, newPositionValue);
        }

    }
    
}
