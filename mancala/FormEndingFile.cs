using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static mancala.Constant;

namespace mancala
{
    public partial class FormEndingFile : Form
    {
        private BindingList<DataEndingFile> dataEndingFile;


        public FormEndingFile(PositionMap positionMap)
        {
            InitializeComponent();

            dataEndingFile = new BindingList<DataEndingFile>();

            textBoxVer.Text = positionMap.Header.Version.ToString();
            textBoxCount.Text = positionMap.Header.RecordNum.ToString();

            int i = 0;
            foreach (KeyValuePair<PositionKey,PositionValue> item in positionMap.PositionMapTable)
            {
                i++;
                dataEndingFile.Add(new DataEndingFile(i,item));
            }

            dataGridViewEndingFile.DataSource = dataEndingFile;

        }

    }

    public class DataEndingFile
    {
        public int No { get; set; }
        public string FirstBoardState { get; set; }
        public string SecondBoardState { get; set; }
        public int Value { get; set; }
        public int Visit { get; set; }

        public DataEndingFile(int i,KeyValuePair<PositionKey, PositionValue> item)
        {
            No = i;
            FirstBoardState = String.Join(" ", BitConverter.GetBytes(item.Key.BoardState0).Take(PIT_NUM));
            SecondBoardState = String.Join(" ", BitConverter.GetBytes(item.Key.BoardState1).Take(PIT_NUM));
            Value = item.Value.Value;
            Visit = item.Value.Visit;
        }
    }
}
