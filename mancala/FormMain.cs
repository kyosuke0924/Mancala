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
            Display();
        }

        private void Pits_Click(object sender, EventArgs e)
        {
            board.Play(GetPitIdx((System.Windows.Forms.Button)sender));
            Display();
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
  
       public void Display()
        {
            if (!isReverse)
            {
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



            }
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            board.Reset();
            Display();
        }

        private void ButtonUndo_Click(object sender, EventArgs e)
        {
            board.Undo();
            Display();
        }

        private void ButtonQuit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}
