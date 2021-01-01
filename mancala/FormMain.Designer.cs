﻿namespace mancala
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelN = new System.Windows.Forms.Label();
            this.labelS = new System.Windows.Forms.Label();
            this.storeS = new System.Windows.Forms.Label();
            this.storeN = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonS_4 = new System.Windows.Forms.Button();
            this.buttonS_3 = new System.Windows.Forms.Button();
            this.buttonS_2 = new System.Windows.Forms.Button();
            this.buttonS_1 = new System.Windows.Forms.Button();
            this.buttonS_0 = new System.Windows.Forms.Button();
            this.buttonN_0 = new System.Windows.Forms.Button();
            this.buttonN_1 = new System.Windows.Forms.Button();
            this.buttonN_4 = new System.Windows.Forms.Button();
            this.buttonN_5 = new System.Windows.Forms.Button();
            this.buttonN_3 = new System.Windows.Forms.Button();
            this.buttonS_5 = new System.Windows.Forms.Button();
            this.buttonN_2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonShowEndingFile = new System.Windows.Forms.Button();
            this.buttonMakeEndingFile = new System.Windows.Forms.Button();
            this.buttonInversion = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dataGridViewCandidates = new System.Windows.Forms.DataGridView();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.dataCandidateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.handDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCandidates)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCandidateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataHistoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.labelN);
            this.panel1.Controls.Add(this.labelS);
            this.panel1.Controls.Add(this.storeS);
            this.panel1.Controls.Add(this.storeN);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 516);
            this.panel1.TabIndex = 1;
            // 
            // labelN
            // 
            this.labelN.AutoSize = true;
            this.labelN.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelN.Location = new System.Drawing.Point(286, 13);
            this.labelN.Name = "labelN";
            this.labelN.Size = new System.Drawing.Size(52, 21);
            this.labelN.TabIndex = 6;
            this.labelN.Text = "後手";
            this.labelN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelS
            // 
            this.labelS.AutoSize = true;
            this.labelS.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelS.Location = new System.Drawing.Point(286, 274);
            this.labelS.Name = "labelS";
            this.labelS.Size = new System.Drawing.Size(52, 21);
            this.labelS.TabIndex = 5;
            this.labelS.Text = "先手";
            this.labelS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // storeS
            // 
            this.storeS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.storeS.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.storeS.Location = new System.Drawing.Point(535, 86);
            this.storeS.Name = "storeS";
            this.storeS.Size = new System.Drawing.Size(69, 148);
            this.storeS.TabIndex = 4;
            this.storeS.Text = "0";
            this.storeS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // storeN
            // 
            this.storeN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.storeN.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.storeN.Location = new System.Drawing.Point(11, 86);
            this.storeN.Name = "storeN";
            this.storeN.Size = new System.Drawing.Size(69, 148);
            this.storeN.TabIndex = 2;
            this.storeN.Text = "0";
            this.storeN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.label13, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.label12, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label11, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonS_4, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonS_3, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonS_2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonS_1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonS_0, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonN_0, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonN_1, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonN_4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonN_5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonN_3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonS_5, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonN_2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(86, 49);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(446, 222);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label13.Location = new System.Drawing.Point(373, 183);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 39);
            this.label13.TabIndex = 24;
            this.label13.Text = "(6)";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label12.Location = new System.Drawing.Point(299, 183);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(68, 39);
            this.label12.TabIndex = 23;
            this.label12.Text = "(5)";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label11.Location = new System.Drawing.Point(225, 183);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 39);
            this.label11.TabIndex = 22;
            this.label11.Text = "(4)";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label10.Location = new System.Drawing.Point(151, 183);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 39);
            this.label10.TabIndex = 21;
            this.label10.Text = "(3)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label9.Location = new System.Drawing.Point(77, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 39);
            this.label9.TabIndex = 20;
            this.label9.Text = "(2)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label8.Location = new System.Drawing.Point(3, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 39);
            this.label8.TabIndex = 19;
            this.label8.Text = "(1)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label7.Location = new System.Drawing.Point(373, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 37);
            this.label7.TabIndex = 18;
            this.label7.Text = "(1)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label6.Location = new System.Drawing.Point(299, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 37);
            this.label6.TabIndex = 17;
            this.label6.Text = "(2)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label5.Location = new System.Drawing.Point(225, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 37);
            this.label5.TabIndex = 16;
            this.label5.Text = "(3)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label4.Location = new System.Drawing.Point(151, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 37);
            this.label4.TabIndex = 15;
            this.label4.Text = "(4)";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(77, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 37);
            this.label3.TabIndex = 14;
            this.label3.Text = "(5)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // buttonS_4
            // 
            this.buttonS_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonS_4.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonS_4.Location = new System.Drawing.Point(296, 110);
            this.buttonS_4.Margin = new System.Windows.Forms.Padding(0);
            this.buttonS_4.Name = "buttonS_4";
            this.buttonS_4.Size = new System.Drawing.Size(74, 73);
            this.buttonS_4.TabIndex = 11;
            this.buttonS_4.Text = "0";
            this.buttonS_4.UseVisualStyleBackColor = true;
            // 
            // buttonS_3
            // 
            this.buttonS_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonS_3.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonS_3.Location = new System.Drawing.Point(222, 110);
            this.buttonS_3.Margin = new System.Windows.Forms.Padding(0);
            this.buttonS_3.Name = "buttonS_3";
            this.buttonS_3.Size = new System.Drawing.Size(74, 73);
            this.buttonS_3.TabIndex = 10;
            this.buttonS_3.Text = "0";
            this.buttonS_3.UseVisualStyleBackColor = true;
            // 
            // buttonS_2
            // 
            this.buttonS_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonS_2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonS_2.Location = new System.Drawing.Point(148, 110);
            this.buttonS_2.Margin = new System.Windows.Forms.Padding(0);
            this.buttonS_2.Name = "buttonS_2";
            this.buttonS_2.Size = new System.Drawing.Size(74, 73);
            this.buttonS_2.TabIndex = 9;
            this.buttonS_2.Text = "0";
            this.buttonS_2.UseVisualStyleBackColor = true;
            // 
            // buttonS_1
            // 
            this.buttonS_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonS_1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonS_1.Location = new System.Drawing.Point(74, 110);
            this.buttonS_1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonS_1.Name = "buttonS_1";
            this.buttonS_1.Size = new System.Drawing.Size(74, 73);
            this.buttonS_1.TabIndex = 8;
            this.buttonS_1.Text = "0";
            this.buttonS_1.UseVisualStyleBackColor = true;
            // 
            // buttonS_0
            // 
            this.buttonS_0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonS_0.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonS_0.Location = new System.Drawing.Point(0, 110);
            this.buttonS_0.Margin = new System.Windows.Forms.Padding(0);
            this.buttonS_0.Name = "buttonS_0";
            this.buttonS_0.Size = new System.Drawing.Size(74, 73);
            this.buttonS_0.TabIndex = 7;
            this.buttonS_0.Text = "0";
            this.buttonS_0.UseVisualStyleBackColor = true;
            // 
            // buttonN_0
            // 
            this.buttonN_0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonN_0.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonN_0.Location = new System.Drawing.Point(370, 37);
            this.buttonN_0.Margin = new System.Windows.Forms.Padding(0);
            this.buttonN_0.Name = "buttonN_0";
            this.buttonN_0.Size = new System.Drawing.Size(76, 73);
            this.buttonN_0.TabIndex = 6;
            this.buttonN_0.Text = "0";
            this.buttonN_0.UseVisualStyleBackColor = true;
            // 
            // buttonN_1
            // 
            this.buttonN_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonN_1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonN_1.Location = new System.Drawing.Point(296, 37);
            this.buttonN_1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonN_1.Name = "buttonN_1";
            this.buttonN_1.Size = new System.Drawing.Size(74, 73);
            this.buttonN_1.TabIndex = 5;
            this.buttonN_1.Text = "0";
            this.buttonN_1.UseVisualStyleBackColor = true;
            // 
            // buttonN_4
            // 
            this.buttonN_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonN_4.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonN_4.Location = new System.Drawing.Point(74, 37);
            this.buttonN_4.Margin = new System.Windows.Forms.Padding(0);
            this.buttonN_4.Name = "buttonN_4";
            this.buttonN_4.Size = new System.Drawing.Size(74, 73);
            this.buttonN_4.TabIndex = 2;
            this.buttonN_4.Text = "0";
            this.buttonN_4.UseVisualStyleBackColor = true;
            // 
            // buttonN_5
            // 
            this.buttonN_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonN_5.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonN_5.Location = new System.Drawing.Point(0, 37);
            this.buttonN_5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonN_5.Name = "buttonN_5";
            this.buttonN_5.Size = new System.Drawing.Size(74, 73);
            this.buttonN_5.TabIndex = 1;
            this.buttonN_5.Text = "0";
            this.buttonN_5.UseVisualStyleBackColor = true;
            // 
            // buttonN_3
            // 
            this.buttonN_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonN_3.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonN_3.Location = new System.Drawing.Point(148, 37);
            this.buttonN_3.Margin = new System.Windows.Forms.Padding(0);
            this.buttonN_3.Name = "buttonN_3";
            this.buttonN_3.Size = new System.Drawing.Size(74, 73);
            this.buttonN_3.TabIndex = 3;
            this.buttonN_3.Text = "0";
            this.buttonN_3.UseVisualStyleBackColor = true;
            // 
            // buttonS_5
            // 
            this.buttonS_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonS_5.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonS_5.Location = new System.Drawing.Point(370, 110);
            this.buttonS_5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonS_5.Name = "buttonS_5";
            this.buttonS_5.Size = new System.Drawing.Size(76, 73);
            this.buttonS_5.TabIndex = 12;
            this.buttonS_5.Text = "0";
            this.buttonS_5.UseVisualStyleBackColor = true;
            // 
            // buttonN_2
            // 
            this.buttonN_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonN_2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonN_2.Location = new System.Drawing.Point(222, 37);
            this.buttonN_2.Margin = new System.Windows.Forms.Padding(0);
            this.buttonN_2.Name = "buttonN_2";
            this.buttonN_2.Size = new System.Drawing.Size(74, 73);
            this.buttonN_2.TabIndex = 4;
            this.buttonN_2.Text = "0";
            this.buttonN_2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 37);
            this.label2.TabIndex = 13;
            this.label2.Text = "(6)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.buttonShowEndingFile);
            this.panel2.Controls.Add(this.buttonMakeEndingFile);
            this.panel2.Controls.Add(this.buttonInversion);
            this.panel2.Controls.Add(this.buttonQuit);
            this.panel2.Controls.Add(this.buttonUndo);
            this.panel2.Controls.Add(this.buttonReset);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1132, 60);
            this.panel2.TabIndex = 2;
            // 
            // buttonShowEndingFile
            // 
            this.buttonShowEndingFile.Location = new System.Drawing.Point(786, 12);
            this.buttonShowEndingFile.Name = "buttonShowEndingFile";
            this.buttonShowEndingFile.Size = new System.Drawing.Size(106, 39);
            this.buttonShowEndingFile.TabIndex = 5;
            this.buttonShowEndingFile.Text = "endingファイル\r\nを表示";
            this.buttonShowEndingFile.UseVisualStyleBackColor = true;
            this.buttonShowEndingFile.Click += new System.EventHandler(this.ButtonShowEndingFile_Click);
            // 
            // buttonMakeEndingFile
            // 
            this.buttonMakeEndingFile.Location = new System.Drawing.Point(898, 12);
            this.buttonMakeEndingFile.Name = "buttonMakeEndingFile";
            this.buttonMakeEndingFile.Size = new System.Drawing.Size(106, 39);
            this.buttonMakeEndingFile.TabIndex = 4;
            this.buttonMakeEndingFile.Text = "endingファイル\r\nを作る";
            this.buttonMakeEndingFile.UseVisualStyleBackColor = true;
            this.buttonMakeEndingFile.Click += new System.EventHandler(this.ButtonMakeEndingFile_Click);
            // 
            // buttonInversion
            // 
            this.buttonInversion.Location = new System.Drawing.Point(236, 12);
            this.buttonInversion.Name = "buttonInversion";
            this.buttonInversion.Size = new System.Drawing.Size(106, 39);
            this.buttonInversion.TabIndex = 3;
            this.buttonInversion.Text = "盤面を反転する";
            this.buttonInversion.UseVisualStyleBackColor = true;
            this.buttonInversion.Click += new System.EventHandler(this.ButtonInversion_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuit.Location = new System.Drawing.Point(1010, 12);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(106, 39);
            this.buttonQuit.TabIndex = 2;
            this.buttonQuit.Text = "終了";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Location = new System.Drawing.Point(124, 12);
            this.buttonUndo.Name = "buttonUndo";
            this.buttonUndo.Size = new System.Drawing.Size(106, 39);
            this.buttonUndo.TabIndex = 1;
            this.buttonUndo.Text = "一手戻す";
            this.buttonUndo.UseVisualStyleBackColor = true;
            this.buttonUndo.Click += new System.EventHandler(this.ButtonUndo_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(12, 12);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(106, 39);
            this.buttonReset.TabIndex = 0;
            this.buttonReset.Text = "リセット";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(620, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(512, 516);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridViewHistory);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 34);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(508, 478);
            this.panel4.TabIndex = 8;
            // 
            // dataGridViewHistory
            // 
            this.dataGridViewHistory.AllowUserToAddRows = false;
            this.dataGridViewHistory.AllowUserToDeleteRows = false;
            this.dataGridViewHistory.AllowUserToResizeColumns = false;
            this.dataGridViewHistory.AllowUserToResizeRows = false;
            this.dataGridViewHistory.AutoGenerateColumns = false;
            this.dataGridViewHistory.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewHistory.ColumnHeadersHeight = 46;
            this.dataGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dataGridViewHistory.DataSource = this.dataHistoryBindingSource;
            this.dataGridViewHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHistory.EnableHeadersVisualStyles = false;
            this.dataGridViewHistory.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewHistory.MultiSelect = false;
            this.dataGridViewHistory.Name = "dataGridViewHistory";
            this.dataGridViewHistory.ReadOnly = true;
            this.dataGridViewHistory.RowHeadersVisible = false;
            this.dataGridViewHistory.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewHistory.RowTemplate.Height = 21;
            this.dataGridViewHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewHistory.Size = new System.Drawing.Size(508, 478);
            this.dataGridViewHistory.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(508, 34);
            this.panel5.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "履歴";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.dataGridViewCandidates);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 378);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(620, 198);
            this.panel6.TabIndex = 4;
            // 
            // dataGridViewCandidates
            // 
            this.dataGridViewCandidates.AllowUserToAddRows = false;
            this.dataGridViewCandidates.AllowUserToDeleteRows = false;
            this.dataGridViewCandidates.AllowUserToResizeColumns = false;
            this.dataGridViewCandidates.AllowUserToResizeRows = false;
            this.dataGridViewCandidates.AutoGenerateColumns = false;
            this.dataGridViewCandidates.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCandidates.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewCandidates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewCandidates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.handDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn8});
            this.dataGridViewCandidates.DataSource = this.dataCandidateBindingSource;
            this.dataGridViewCandidates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewCandidates.EnableHeadersVisualStyles = false;
            this.dataGridViewCandidates.Location = new System.Drawing.Point(0, 37);
            this.dataGridViewCandidates.MultiSelect = false;
            this.dataGridViewCandidates.Name = "dataGridViewCandidates";
            this.dataGridViewCandidates.ReadOnly = true;
            this.dataGridViewCandidates.RowHeadersVisible = false;
            this.dataGridViewCandidates.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewCandidates.RowTemplate.Height = 21;
            this.dataGridViewCandidates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCandidates.Size = new System.Drawing.Size(616, 157);
            this.dataGridViewCandidates.TabIndex = 11;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.label14);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(616, 37);
            this.panel7.TabIndex = 10;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.Location = new System.Drawing.Point(3, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "推奨着手";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 576);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1132, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // dataCandidateBindingSource
            // 
            this.dataCandidateBindingSource.DataSource = typeof(mancala.DataCandidate);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "No";
            this.dataGridViewTextBoxColumn1.HeaderText = "#";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 20;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Turn";
            this.dataGridViewTextBoxColumn2.HeaderText = "手番";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Hand";
            this.dataGridViewTextBoxColumn3.HeaderText = "手";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 30;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FirstStore";
            this.dataGridViewTextBoxColumn4.HeaderText = "先手　スコア";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "SecondStore";
            this.dataGridViewTextBoxColumn5.HeaderText = "後手　スコア";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 50;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FirstBoardState";
            this.dataGridViewTextBoxColumn6.HeaderText = "先手盤面";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "SecondBoardState";
            this.dataGridViewTextBoxColumn7.HeaderText = "後手盤面";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataHistoryBindingSource
            // 
            this.dataHistoryBindingSource.DataSource = typeof(mancala.DataHistory);
            // 
            // handDataGridViewTextBoxColumn
            // 
            this.handDataGridViewTextBoxColumn.DataPropertyName = "Hand";
            this.handDataGridViewTextBoxColumn.HeaderText = "手";
            this.handDataGridViewTextBoxColumn.Name = "handDataGridViewTextBoxColumn";
            this.handDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Values";
            this.dataGridViewTextBoxColumn8.HeaderText = "評価値";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 598);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "マンカラ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCandidates)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataCandidateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataHistoryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label storeN;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonS_4;
        private System.Windows.Forms.Button buttonS_3;
        private System.Windows.Forms.Button buttonS_2;
        private System.Windows.Forms.Button buttonS_1;
        private System.Windows.Forms.Button buttonS_0;
        private System.Windows.Forms.Button buttonN_0;
        private System.Windows.Forms.Button buttonN_1;
        private System.Windows.Forms.Button buttonN_4;
        private System.Windows.Forms.Button buttonN_5;
        private System.Windows.Forms.Button buttonN_3;
        private System.Windows.Forms.Button buttonS_5;
        private System.Windows.Forms.Button buttonN_2;
        private System.Windows.Forms.Label storeS;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonUndo;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Label labelS;
        private System.Windows.Forms.Label labelN;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.BindingSource dataHistoryBindingSource;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonInversion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Button buttonMakeEndingFile;
        private System.Windows.Forms.Button buttonShowEndingFile;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dataGridViewCandidates;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn valuesDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dataCandidateBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn handDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}