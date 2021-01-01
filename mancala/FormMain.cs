﻿using System;
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
    public partial class FormMain : Form
    {
        const string EVALUATION_FILE_PATH  = "eval.dat";
        const string POSITION_FILE_PATH = "position.dat";
        const string ENDING_FILE_PATH = "ending.dat";
        const int DEPTH = 12;

        private Evaluator evaluator;
        private PositionMap positionMap;
        private PositionMap ending;

        private Com com;
        private Board board;
        private Move bestMove;
        private readonly Button[,] pits;
        private Boolean isReverse = false;
        private BindingList<DataHistory> dataHistories;
        private BindingList<DataHistory> dataCandidates;

        public FormMain()
        {
            InitializeComponent();
            board = new Board();
            com = new Com();
            evaluator = new Evaluator();
            positionMap = new PositionMap();
            ending = new PositionMap();

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

            evaluator.Load(EVALUATION_FILE_PATH);
            positionMap.Load(POSITION_FILE_PATH);
            ending.Load(ENDING_FILE_PATH);

            bestMove = com.FindBestMove(board, DEPTH, evaluator, positionMap, ending, false).bestMove;
            DisplayBoard();

        }

        private void Pits_Click(object sender, EventArgs e)
        {
            Turn thisTurn = board.GetTurn();
            int pitIdx = GetPitIdx((System.Windows.Forms.Button)sender);

            Boolean result = board.Play(pitIdx);
            
            if (result)
            {
                bestMove = com.FindBestMove(board, DEPTH, evaluator, positionMap, ending, false).bestMove;
                DisplayBoard();
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
            }
            else
            {
                labelS.Text = "後手";
                labelN.Text = "先手";
                storeS.Text = board.GetStore(Turn.Second).ToString();
                storeN.Text = board.GetStore(Turn.First).ToString();
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
            bestMove = com.FindBestMove(board, DEPTH, evaluator, positionMap, ending, false).bestMove;
            DisplayBoard();
            dataHistories.Clear();
        }

        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            Boolean result = board.Undo();
            if (result)
            {
                bestMove = com.FindBestMove(board, DEPTH, evaluator, positionMap, ending, false).bestMove;
                DisplayBoard();
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

        private void ButtonMakeEndingFile_Click(object sender, EventArgs e)
        {
            MakeEndingFile(10,ENDING_FILE_PATH);
        }

        private void MakeEndingFile(int seedNum,string filepath)
        {
            Board newBoard = board;
            PositionMap newEnding = new PositionMap();
            int[] seeds = new int[PIT_NUM * 2];

            for (int max = 2; max < seedNum + 1; max++)
            {
                int i = 0;
                int remain = max;
                Boolean isOver = false;
                while (!isOver)
                {
                    i++;
                    if (remain == 0 | i == seeds.Length - 1)
                    {
                        seeds[i] = remain;
                        var firstSeeds = seeds.Take(PIT_NUM).ToArray();
                        var secondSeeds = seeds.Skip(PIT_NUM).Take(PIT_NUM).ToArray();
                        if (firstSeeds.Sum() > 0 && secondSeeds.Sum() > 0)
                        {
                            newBoard.ResetWithSeeds(firstSeeds,secondSeeds);
                            int value = com.FindBestMove(newBoard,1000,evaluator, new PositionMap(), newEnding, false).bestMove.Value;
                            newEnding.Add(newBoard.State, value);
                        }
                        seeds[i] = 0;
                        while (true)
                        {
                            if (i == 0)
                            {
                                isOver = true;
                                break;
                            }
                            i--;
                            if (remain > 0)
                            {
                                remain--;
                                seeds[i]++;
                                break;
                            }
                            else
                            {
                                remain += seeds[i];
                                seeds[i] = 0;
                            }
                        }
                    }
                }            
            }
            newEnding.Save(ENDING_FILE_PATH);
        }

        private void ButtonShowEndingFile_Click(object sender, EventArgs e)
        {
            FormEndingFile formEndingFile = new FormEndingFile(ending);
            formEndingFile.Show(this);
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
        public string Hand { get; set; }
        public int FirstStore { get; set; }
        public int SecondStore { get; set; }
        public string FirstBoardState { get; set; }
        public string SecondBoardState { get; set; }

        public DataHistory(int no, Turn thisTurn, int pidIdx, BoardState boardState)
        {
            No = no;
            Turn = thisTurn == Constant.Turn.First ? "先手" : "後手";
            Hand = "(" + (pidIdx+1).ToString() + ")";
            FirstStore = boardState.Stores[(int)Constant.Turn.First];
            SecondStore = boardState.Stores[(int)Constant.Turn.Second];
            FirstBoardState = String.Join(" ", BitConverter.GetBytes(boardState.Seed_states[(int)Constant.Turn.First]).Take(PIT_NUM));
            SecondBoardState = String.Join(" ", BitConverter.GetBytes(boardState.Seed_states[(int)Constant.Turn.Second]).Take(PIT_NUM));
        }
    }

    public class DataCandidate
    {
        public string Hand { get; set; }
        public int Values { get; set; }

        public DataCandidate(string hand, int values)
        {
            Hand = hand;
            this.Values = values;
        }
    }
}
