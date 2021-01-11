using Mancala.Common.Constant;
using Mancala.MancalaEngine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Mancala.Mancala
{
    public partial class FormEndingFile : Form
    {
        private readonly BindingList<DataEndingFile> dataEndingFiles;


        public FormEndingFile(PositionMap positionMap)
        {
            InitializeComponent();

            dataEndingFiles = new BindingList<DataEndingFile>();

            textBoxVer.Text = positionMap.Header.Version.ToString();
            textBoxCount.Text = positionMap.Header.RecordNum.ToString();

            int i = 0;
            foreach (KeyValuePair<PositionKey, PositionValue> item in positionMap.PositionMapTable)
            {
                i++;
                dataEndingFiles.Add(new DataEndingFile(i, item));
            }

            dataGridViewEndingFile.DataSource = dataEndingFiles;

        }

    }

    public class DataEndingFile
    {
        public int No { get; set; }
        public string FirstBoardState { get; set; }
        public string SecondBoardState { get; set; }
        public int Value { get; set; }
        public int Visit { get; set; }

        public DataEndingFile(int i, KeyValuePair<PositionKey, PositionValue> item)
        {
            No = i;
            FirstBoardState = string.Join(" ", BitConverter.GetBytes(item.Key.BoardState0).Take(BoardInfo.PIT_NUM));
            SecondBoardState = string.Join(" ", BitConverter.GetBytes(item.Key.BoardState1).Take(BoardInfo.PIT_NUM));
            Value = item.Value.Value;
            Visit = item.Value.Visit;
        }
    }
}
