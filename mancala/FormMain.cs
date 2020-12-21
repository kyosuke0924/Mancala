using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static mancala.Construct;

namespace mancala
{
    public partial class FormMain : Form
    {
        private Board board;
        private readonly Button[,] pits;
        private Boolean isReverse = false;
        private BindingList<DataHistory> dataHistories;

        public FormMain()
        {
            InitializeComponent();
            board = new Board();

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

            dataHistories = new BindingList<DataHistory>();
            dataGridViewHistory.DataSource = dataHistories; 
            DisplayBoard();
        }

        private void Pits_Click(object sender, EventArgs e)
        {
            Turn thisTurn = board.GetTurn();
            int pitIdx = GetPitIdx((System.Windows.Forms.Button)sender);

            Boolean result = board.Play(pitIdx);
            DisplayBoard();
            if (result)
            {
                dataHistories.Add(new DataHistory(dataHistories.Count + 1, thisTurn, pitIdx, board.State));
                dataGridViewHistory.Rows[dataGridViewHistory.Rows.Count - 1].Selected = true;
                dataGridViewHistory.FirstDisplayedScrollingRowIndex = dataGridViewHistory.Rows.Count - 1;
            }
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
                storeS.Text = board.GetStore(Turn.First).ToString();
                storeN.Text = board.GetStore(Turn.Second).ToString();

                for (int i = 0; i < this.pits.GetLength(0); i++)
                {
                    for (int j = 0; j < this.pits.GetLength(1); j++)
                    {
                        int seedNum = board.GetSeed((Turn)Enum.ToObject(typeof(Turn), i), j);
                        pits[i, j].Text = seedNum > 0 ? seedNum.ToString() : "";
                        pits[i, j].Enabled = (i == (int)board.GetTurn() ? true : false);
                    }
                }
            }
            else
            {
                labelS.Text = "後手";
                labelN.Text = "先手";
                storeS.Text = board.GetStore(Turn.Second).ToString();
                storeN.Text = board.GetStore(Turn.First).ToString();

                for (int i = 0; i < pits.GetLength(0); i++)
                {
                    for (int j = 0; j < pits.GetLength(1); j++)
                    {
                        int seedNum = board.GetSeed((Turn)Enum.ToObject(typeof(Turn), i), j);
                        pits[pits.GetLength(0) -1 - i, j].Text = seedNum > 0 ? seedNum.ToString() : "";
                        pits[pits.GetLength(0) -1 - i, j].Enabled = (i == (int)board.GetTurn() ? true : false);
                    }
                }
            }
        }


        private void ButtonReset_Click(object sender, EventArgs e)
        {
            board.Reset();
            DisplayBoard();
            dataHistories.Clear();
        }

        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            Boolean result = board.Undo();
            DisplayBoard();
            if (result)
            {
                dataHistories.RemoveAt(dataHistories.Count - 1);
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

        private void ButtonQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }

    public class DataHistory
    {
        public int No { get; set; }
        public string Turn { get; set; }
        public int Hand { get; set; }
        public int FirstStore { get; set; }
        public int SecondStore { get; set; }
        public string FirstBoardState { get; set; }
        public string SecondBoardState { get; set; }

        public DataHistory(int no, Turn thisTurn, int pidIdx, BoardState boardState)
        {
            No = no;
            Turn = thisTurn == Construct.Turn.First ? "先手" : "後手";
            Hand = pidIdx;
            FirstStore = boardState.Stores[(int)Construct.Turn.First];
            SecondStore = boardState.Stores[(int)Construct.Turn.Second];
            FirstBoardState = String.Join(" ", BitConverter.GetBytes(boardState.Seed_states[(int)Construct.Turn.First]).Take(PIT_NUM));
            SecondBoardState = String.Join(" ", BitConverter.GetBytes(boardState.Seed_states[(int)Construct.Turn.Second]).Take(PIT_NUM));
        }
    }

}
