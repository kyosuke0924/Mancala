using Mancala.Common.Constant;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mancala.Mancala
{
    public partial class FormMain : Form
    {

        private const int PLAYER_NUM = 2;

        private readonly int depth = Properties.Settings.Default.Depth;
        private readonly int endingFileSeedNum = Properties.Settings.Default.EndingFileSeedNum;

        private readonly BoardManager boardManager;
        private readonly Button[,] pits;
        private readonly Label[] labelSrores;
        private readonly Label[] labelTurns;

        private bool isReverse = false;
        private int? bestMoveIdx;

        public FormMain()
        {
            InitializeComponent();
            boardManager = new BoardManager();

            //ピットボタンの配列を作成し、イベントハンドラに関連付け
            pits = new Button[PLAYER_NUM, BoardInfo.PIT_NUM] { {buttonS_0, buttonS_1, buttonS_2, buttonS_3, buttonS_4, buttonS_5 } ,
                                                    {buttonN_0, buttonN_1, buttonN_2, buttonN_3, buttonN_4, buttonN_5 } };
            foreach (Button button in pits)
            {
                button.Click += new EventHandler(Pits_Click);
            }

            labelSrores = new Label[PLAYER_NUM] { storeS, storeN };
            labelTurns = new Label[PLAYER_NUM] { labelS, labelN };
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            dataGridViewHistory.Columns[3].HeaderCell.Style.WrapMode = DataGridViewTriState.True;
            dataGridViewHistory.Columns[4].HeaderCell.Style.WrapMode = DataGridViewTriState.True;
            SetMovesValues(boardManager.FindBestMove(depth, false));
            DisplayBoard();
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            int r = Convert.ToInt32(isReverse);
            switch (e.KeyCode)
            {
                case Keys.R:
                    buttonReset.PerformClick();
                    break;
                case Keys.U:
                    buttonUndo.PerformClick();
                    break;
                case Keys.I:
                    buttonInversion.PerformClick();
                    break;
                case Keys.E:
                    buttonShowEndingFile.PerformClick();
                    break;
                case Keys.M:
                    buttonMakeEndingFile.PerformClick();
                    break;
                case Keys.Q:
                    buttonQuit.PerformClick();
                    break;
                case Keys i when (Keys.D1 <= i && i <= Keys.D6):
                    pits[(int)boardManager.GetTurn() ^ r, (int)i - (int)Keys.D1].PerformClick();
                    break;
                case Keys i when (Keys.NumPad1 <= i && i <= Keys.NumPad6):
                    pits[(int)boardManager.GetTurn() ^ r, (int)i - (int)Keys.NumPad1].PerformClick();
                    break;
            }

            e.Handled = true;
        }

        private void Pits_Click(object sender, EventArgs e)
        {
            Turn thisTurn = boardManager.GetTurn();
            int pitIdx = GetPitIdx((Button)sender);

            if (boardManager.CanPlay(pitIdx))
            {
                string value = ((DataCandidate)dataCandidateBindingSource[pitIdx]).Values;
                boardManager.Play(pitIdx);
                SetMovesValues(boardManager.FindBestMove(depth, false));
                DisplayBoard();
                dataHistoryBindingSource.Add(new DataHistory(dataHistoryBindingSource.Count + 1, thisTurn, pitIdx, boardManager, value));
                dataGridViewHistory.Rows[dataGridViewHistory.Rows.Count - 1].Selected = true;
                dataGridViewHistory.FirstDisplayedScrollingRowIndex = dataGridViewHistory.Rows.Count - 1;
            }

        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "リセットしますか？", "リセット", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                boardManager.Reset();
                SetMovesValues(boardManager.FindBestMove(depth, false));
                DisplayBoard();
                dataHistoryBindingSource.Clear();
            }

        }

        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            bool result = boardManager.Undo();
            if (result)
            {
                SetMovesValues(boardManager.FindBestMove(depth, false));
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
            boardManager.MakeEndingFile(endingFileSeedNum);
        }

        private void ButtonShowEndingFile_Click(object sender, EventArgs e)
        {
            FormEndingFile formEndingFile = new FormEndingFile(boardManager.GetEndingMap());
            formEndingFile.Show(this);
        }

        private void ButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "終了しますか？", "終了", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                Close();
            }

        }

        private void DatahistoryBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            chartSituation.DataBind();
        }

        private void DisplayBoard()
        {
            int r = Convert.ToInt32(isReverse);

            labelTurns[0 ^ r].Text = "先　手";
            labelTurns[1 ^ r].Text = "後　手";

            for (int i = 0; i < labelSrores.Length; i++)
            {
                labelSrores[i ^ r].Text = boardManager.GetStore((Turn)Enum.ToObject(typeof(Turn), i)).ToString();
            }

            for (int i = 0; i < pits.GetLength(0); i++)
            {
                for (int j = 0; j < pits.GetLength(1); j++)
                {
                    int seedNum = boardManager.GetSeed((Turn)Enum.ToObject(typeof(Turn), i), j);
                    pits[i ^ r, j].Text = seedNum > 0 ? seedNum.ToString() : "";
                    pits[i ^ r, j].Enabled = i == (int)boardManager.GetTurn();
                    if (i == (int)boardManager.GetTurn() && bestMoveIdx != null && bestMoveIdx == j)
                    {
                        pits[i ^ r, j].BackColor = SystemColors.Highlight;
                        pits[i ^ r, j].Focus();
                    }
                    else
                    {
                        pits[i ^ r, j].BackColor = SystemColors.Control;
                        pits[i ^ r, j].UseVisualStyleBackColor = true;
                    }
                }
            }
        }

        private void SetMovesValues((int? bestMoveIdx, int?[] values) p)
        {
            bestMoveIdx = p.bestMoveIdx;
            dataCandidateBindingSource.Clear();
            for (int i = 0; i < p.values.Length; i++)
            {
                dataCandidateBindingSource.Add(new DataCandidate(boardManager.GetTurn(), i, p.values[i]));
            }

            if (bestMoveIdx != null) { dataGridViewCandidates.Rows[(int)bestMoveIdx].Selected = true; }
        }

        private int GetPitIdx(Button button)
        {
            for (int i = 0; i < pits.GetLength(0); i++)
            {
                for (int j = 0; j < pits.GetLength(1); j++)
                {
                    if (pits[i, j].Equals(button))
                    {
                        return j;
                    }

                }

            }

            return -1;
        }

        private class DataHistory
        {
            public int No { get; set; }
            public string ThisTurn { get; set; }
            public string Hand { get; set; }
            public int FirstStore { get; set; }
            public int SecondStore { get; set; }
            public string FirstBoardState { get; set; }
            public string SecondBoardState { get; set; }
            public int Value { get; set; }

            public DataHistory(int no, Turn thisTurn, int pidIdx, BoardManager boardManager, string value)
            {
                No = no;
                ThisTurn = thisTurn == Turn.First ? "先手" : "後手";
                Hand = "(" + (pidIdx + 1).ToString() + ")";
                FirstStore = boardManager.GetStore(Turn.First);
                SecondStore = boardManager.GetStore(Turn.Second);
                FirstBoardState = string.Join(" ", boardManager.GetSeedArray(Turn.First));
                SecondBoardState = string.Join(" ", boardManager.GetSeedArray(Turn.Second));
                Value = Convert.ToInt32(value);
            }
        }

        private class DataCandidate
        {
            public string Hand { get; set; }
            public string Values { get; set; }

            public DataCandidate(Turn thisTurn, int pidIdx, int? v)
            {
                Hand = "(" + (pidIdx + 1).ToString() + ")";
                Values = v == null ? "*****" : thisTurn == Turn.First ? v.ToString() : (-v).ToString();
            }
        }

    }

}
