using Mancala.Common.BoardState;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.BitConverter;

namespace Mancala.MancalaEngine
{

    public struct PositionKey
    {
        public long BoardState0 { get; }
        public long BoardState1 { get; }

        public override bool Equals(object obj)
        {
            return obj is PositionKey key &&
                   BoardState0 == key.BoardState0 &&
                   BoardState1 == key.BoardState1;
        }

        public override int GetHashCode()
        {
            int hashCode = -1877348453;
            hashCode = hashCode * -1521134295 + BoardState0.GetHashCode();
            hashCode = hashCode * -1521134295 + BoardState1.GetHashCode();
            return hashCode;
        }

        internal PositionKey(long boardState0, long boardState1)
        {
            BoardState0 = boardState0;
            BoardState1 = boardState1;
        }

        internal byte[] ToLeBytes()
        {
            return (byte[])GetBytes(BoardState0).Concat(GetBytes(BoardState1)).ToArray().Clone();
        }

        internal PositionKey(byte[] vs) : this(ToInt64(vs, 0), ToInt64(vs, 8)) { }
    }

    public struct PositionValue
    {
        public int Value { get; }
        public int Visit { get; }

        internal PositionValue(int value, int visit)
        {
            Value = value;
            Visit = visit;
        }

        internal byte[] ToLeBytes()
        {
            return (byte[])GetBytes(Value).Concat(GetBytes(Visit)).ToArray().Clone();
        }

        internal PositionValue(byte[] vs) : this(ToInt32(vs, 0), ToInt32(vs, 4)) { }
    }

    public struct PositionFileHeader
    {
        public uint Version { get; }
        public uint RecordNum { get; }

        internal PositionFileHeader(uint version, uint recordNum)
        {
            Version = version;
            RecordNum = recordNum;
        }

        internal byte[] ToLeBytes()
        {
            return (byte[])GetBytes(Version).Concat(GetBytes(RecordNum)).ToArray().Clone();
        }

        internal PositionFileHeader(byte[] vs) : this(ToUInt32(vs, 0), ToUInt32(vs, 4)) { }
    }

    public class PositionMap
    {
        public PositionFileHeader Header { get; private set; }
        public Dictionary<PositionKey, PositionValue> PositionMapTable { get; private set; }

        private readonly int valuePerSeed;

        internal PositionMap(int valuePerSeed)
        {
            this.valuePerSeed = valuePerSeed;
            PositionMapTable = new Dictionary<PositionKey, PositionValue>();
            Header = new PositionFileHeader();
        }

        internal void Load(string filePath)
        {
            using (FileStream fs = new System.IO.FileStream(filePath, FileMode.Open))
            {
                int idx = 0;
                int readByte = 8;

                byte[] data = new byte[readByte];
                fs.Read(data, idx, readByte);
                Header = new PositionFileHeader(data);

                PositionMapTable.Clear();

                for (int i = 0; i < Header.RecordNum; i++)
                {
                    data = new byte[readByte * 3];
                    fs.Read(data, idx, readByte * 3);
                    PositionKey key = new PositionKey(data.Take(16).ToArray());
                    PositionValue value = new PositionValue(data.Skip(16).Take(8).ToArray());
                    PositionMapTable.Add(key, value);
                }
            }
        }

        internal void Save(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                PositionFileHeader header = new PositionFileHeader(1, (uint)PositionMapTable.Count);
                int idx = 0;

                byte[] headerBytes = header.ToLeBytes();
                fs.Write(headerBytes, idx, headerBytes.Length);

                foreach (KeyValuePair<PositionKey, PositionValue> positionMap in PositionMapTable)
                {
                    byte[] positionMapKeyBytes = positionMap.Key.ToLeBytes();
                    byte[] positionMapValueBytes = positionMap.Value.ToLeBytes();
                    fs.Write(positionMapKeyBytes, idx, positionMapKeyBytes.Length);
                    fs.Write(positionMapValueBytes, idx, positionMapValueBytes.Length);
                }
            }
        }

        internal int GetLength()
        {
            return PositionMapTable.Count;
        }

        internal PositionValue? GetPositionValue(BoardState boardState)
        {
            Common.Constant.Turn turn = boardState.ThisTurn;
            Common.Constant.Turn opponent = boardState.GetOpponentTurn();
            PositionKey key = new PositionKey(boardState.Seed_states[(int)turn], boardState.Seed_states[(int)opponent]);

            if (PositionMapTable.ContainsKey(key))
            {
                PositionValue positionValue = PositionMapTable[key];
                return new PositionValue
                    (
                          positionValue.Value + ((boardState.Stores[(int)turn] - boardState.Stores[(int)opponent]) * valuePerSeed)
                        , positionValue.Visit
                    );
            }
            else
            {
                return null;
            }
        }

        internal void Add(BoardState boardState, int value)
        {
            Common.Constant.Turn turn = boardState.ThisTurn;
            Common.Constant.Turn opponent = boardState.GetOpponentTurn();
            PositionKey key = new PositionKey(boardState.Seed_states[(int)turn], boardState.Seed_states[(int)opponent]);
            PositionValue? positionValue = GetPositionValue(boardState);

            int visit = 0;
            if (positionValue != null)
            {
                visit = positionValue.Value.Visit;
            }

            PositionValue newPositionValue = new PositionValue
                (value - (boardState.Stores[(int)turn] - boardState.Stores[(int)opponent]) * valuePerSeed, visit += 1);

            PositionMapTable.Add(key, newPositionValue);
        }
    }
}
