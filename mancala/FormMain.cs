using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using common;
using static common.Constant;
using mancalaEngine;

namespace Mancala
{
    public partial class FormMain : Form
    {

        const int DEPTH = 12;

        private MancalaEngine mancalaEngine;
        private Board board;
        private Move bestMove;
        private readonly Button[,] pits;
        private bool isReverse = false;

        public FormMain()
        {
            InitializeComponent();
            board = new Board();
            mancalaEngine = new MancalaEngine();
            mancalaEngine.LoadFiles();

            //ピットボタンの配列を作成
            pits = new Button[PLAYER_NUM,PIT_NUM] { {buttonS_0, buttonS_1, buttonS_2, buttonS_3, buttonS_4, buttonS_5 } ,
                                                    {buttonN_0, buttonN_1, buttonN_2, buttonN_3, buttonN_4, buttonN_5 } };

            //イベントハンドラに関連付け
            for (int i = 0; i < this.pits.GetLength(0); i++)
            {
                for (int j = 0; j < this.pits.GetLength(1); j++)
                {
                    pits[i, j].Click += new EventHandler(Pits_Click);
                }             
            }
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            dataGridViewHistory.Columns[3].HeaderCell.Style.WrapMode = DataGridViewTriState.True;
            dataGridViewHistory.Columns[4].HeaderCell.Style.WrapMode = DataGridViewTriState.True;
            SetMovesValues(mancalaEngine.FindBestMove(board, DEPTH,  false));
            DisplayBoard();
        }

        private void Pits_Click(object sender, EventArgs e)
        {
            Turn thisTurn = board.GetTurn();
            int pitIdx = GetPitIdx((System.Windows.Forms.Button)sender);

            if (board.CanPlay(pitIdx))
            {
                string value = ((DataCandidate)dataCandidateBindingSource[pitIdx]).Values;
                board.Play(pitIdx);
                SetMovesValues(mancalaEngine.FindBestMove(board, DEPTH, false));
                DisplayBoard();
                dataHistoryBindingSource.Add(new DataHistory(dataHistoryBindingSource.Count + 1, thisTurn, pitIdx, board.State, value));               
                dataGridViewHistory.Rows[dataGridViewHistory.Rows.Count - 1].Selected = true;
                dataGridViewHistory.FirstDisplayedScrollingRowIndex = dataGridViewHistory.Rows.Count - 1;
            }
        }

        private void SetMovesValues((Move bestMove, int?[] values) p)
        {
            bestMove = p.bestMove;
            dataCandidateBindingSource.Clear();
            for (int i = 0; i < p.values.Length; i++)
            {
                dataCandidateBindingSource.Add(new DataCandidate(board.GetTurn(), i, p.values[i]));
            }
            if (bestMove.Pit != null) { dataGridViewCandidates.Rows[(int)bestMove.Pit].Selected = true; }
        }

        private int GetPitIdx(System.Windows.Forms.Button button)
        {
            for (int i = 0; i < this.pits.GetLength(0); i++)
            {
                for (int j = 0; j < this.pits.GetLength(1); j++)
                {
                    if (pits[i, j].Equals(button)) return j;
                }
            }
            return -1;
        }
  
       private void DisplayBoard()
        {
            if (!isReverse)
            {
                labelS.Text = "先手";
                labelN.Text = "後手";
                storeS.Text = board.GetStore(Constant.Turn.First).ToString();
                storeN.Text = board.GetStore(Constant.Turn.Second).ToString();
            }
            else
            {
                labelS.Text = "後手";
                labelN.Text = "先手";
                storeS.Text = board.GetStore(Constant.Turn.Second).ToString();
                storeN.Text = board.GetStore(Constant.Turn.First).ToString();
            }

            for (int i = 0; i < this.pits.GetLength(0); i++)
            {
                for (int j = 0; j < this.pits.GetLength(1); j++)
                {
                    int seedNum = board.GetSeed((Turn)Enum.ToObject(typeof(Turn), i), j);
                    pits[i ^ Convert.ToInt32(isReverse), j].Text = seedNum > 0 ? seedNum.ToString() : "";
                    pits[i ^ Convert.ToInt32(isReverse), j].Enabled = (i == (int)board.GetTurn() ? true : false);
                    if (i == (int)board.GetTurn() && bestMove.Pit == j)
                    {
                        pits[i ^ Convert.ToInt32(isReverse), j].BackColor = SystemColors.Highlight;
                    }
                    else
                    {
                        pits[i ^ Convert.ToInt32(isReverse), j].BackColor = SystemColors.Control;
                        pits[i ^ Convert.ToInt32(isReverse), j].UseVisualStyleBackColor = true;
                    }
                }
            }
        }


        private void ButtonReset_Click(object sender, EventArgs e)
        {
            board.Reset();
            SetMovesValues(mancalaEngine.FindBestMove(board, DEPTH,  false));
            DisplayBoard();
            dataHistoryBindingSource.Clear();        
        }

        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            Boolean result = board.Undo();
            if (result)
            {
                SetMovesValues(mancalaEngine.FindBestMove(board, DEPTH,  false));
                DisplayBoard();
                dataHistoryBindingSource.RemoveAt(dataHistoryBindingSource.Count - 1);
                if (dataGridViewHistory.Rows.Count > 0)
                {
                    dataGridViewHistory.Rows[dataGridViewHistory.Rows.Count - 1].Selected = true;
                    dataGridViewHistory.FirstDisplayedScrollingRowIndex = dataGridViewHistory.Rows.Count - 1;
                }
            }
        }

        private void ButtonInversion_Click(object sender, EventArgs e)
        {
            isReverse = !isReverse;
            DisplayBoard();
        }

        private void ButtonMakeEndingFile_Click(object sender, EventArgs e)
        {
            mancalaEngine.MakeEndingFile(10);
        }

        private void ButtonShowEndingFile_Click(object sender, EventArgs e)
        {
            FormEndingFile formEndingFile = new FormEndingFile(mancalaEngine.EndingMap);
            formEndingFile.Show(this);
        }

        private void ButtonQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DatahistoryBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            chart1.DataBind();
        }

        public class DataHistory
        {
            public int No { get; set; }
            public string Turn { get; set; }
            public string Hand { get; set; }
            public int FirstStore { get; set; }
            public int SecondStore { get; set; }
            public string FirstBoardState { get; set; }
            public string SecondBoardState { get; set; }
            public int Value { get; set; }

            public DataHistory(int no, Turn thisTurn, int pidIdx, BoardState boardState, string value)
            {
                No = no;
                Turn = thisTurn == Constant.Turn.First ? "先手" : "後手";
                Hand = "(" + (pidIdx + 1).ToString() + ")";
                FirstStore = boardState.Stores[(int)Constant.Turn.First];
                SecondStore = boardState.Stores[(int)Constant.Turn.Second];
                FirstBoardState = String.Join(" ", BitConverter.GetBytes(boardState.Seed_states[(int)Constant.Turn.First]).Take(PIT_NUM));
                SecondBoardState = String.Join(" ", BitConverter.GetBytes(boardState.Seed_states[(int)Constant.Turn.Second]).Take(PIT_NUM));
                Value = Convert.ToInt32(value);
            }
        }

        public class DataCandidate
        {
            public string Hand { get; set; }
            public string Values { get; set; }

            public DataCandidate(Turn thisTurn, int pidIdx, int? v)
            {
                Hand = "(" + (pidIdx + 1).ToString() + ")";
                Values = v == null ? "*****" : thisTurn == Constant.Turn.First ? v.ToString() : (-v).ToString();
            }
        }

    }

}
