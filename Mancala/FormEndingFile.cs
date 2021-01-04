using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Common.Constant;
using MancalaEngine;

namespace Mancala
{
    public partial class FormEndingFile : Form
    {
        private BindingList<DataEndingFile> dataEndingFiles;


        public FormEndingFile(PositionMap positionMap)
        {
            InitializeComponent();

            dataEndingFiles = new BindingList<DataEndingFile>();

            textBoxVer.Text = positionMap.Header.Version.ToString();
            textBoxCount.Text = positionMap.Header.RecordNum.ToString();

            int i = 0;
            foreach (KeyValuePair<PositionKey,PositionValue> item in positionMap.PositionMapTable)
            {
                i++;
                dataEndingFiles.Add(new DataEndingFile(i,item));
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

        public DataEndingFile(int i,KeyValuePair<PositionKey, PositionValue> item)
        {
            No = i;
            FirstBoardState = String.Join(" ", BitConverter.GetBytes(item.Key.BoardState0).Take(BoardInfo.PIT_NUM));
            SecondBoardState = String.Join(" ", BitConverter.GetBytes(item.Key.BoardState1).Take(BoardInfo.PIT_NUM));
            Value = item.Value.Value;
            Visit = item.Value.Visit;
        }
    }
}
