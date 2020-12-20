namespace mancala
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelN = new System.Windows.Forms.Label();
            this.labelS = new System.Windows.Forms.Label();
            this.storeS = new System.Windows.Forms.Label();
            this.storeN = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.buttonUndo = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonInversion = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1132, 436);
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
            this.labelS.Location = new System.Drawing.Point(286, 217);
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
            this.storeS.Location = new System.Drawing.Point(535, 49);
            this.storeS.Name = "storeS";
            this.storeS.Size = new System.Drawing.Size(69, 153);
            this.storeS.TabIndex = 4;
            this.storeS.Text = "0";
            this.storeS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // storeN
            // 
            this.storeN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.storeN.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.storeN.Location = new System.Drawing.Point(11, 49);
            this.storeN.Name = "storeN";
            this.storeN.Size = new System.Drawing.Size(69, 153);
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
            this.tableLayoutPanel1.Controls.Add(this.buttonS_4, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonS_3, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonS_2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonS_1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonS_0, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonN_0, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonN_1, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonN_4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonN_5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonN_3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonS_5, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonN_2, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(86, 49);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(446, 153);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // buttonS_4
            // 
            this.buttonS_4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonS_4.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonS_4.Location = new System.Drawing.Point(296, 76);
            this.buttonS_4.Margin = new System.Windows.Forms.Padding(0);
            this.buttonS_4.Name = "buttonS_4";
            this.buttonS_4.Size = new System.Drawing.Size(74, 77);
            this.buttonS_4.TabIndex = 11;
            this.buttonS_4.Text = "0";
            this.buttonS_4.UseVisualStyleBackColor = true;
            // 
            // buttonS_3
            // 
            this.buttonS_3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonS_3.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonS_3.Location = new System.Drawing.Point(222, 76);
            this.buttonS_3.Margin = new System.Windows.Forms.Padding(0);
            this.buttonS_3.Name = "buttonS_3";
            this.buttonS_3.Size = new System.Drawing.Size(74, 77);
            this.buttonS_3.TabIndex = 10;
            this.buttonS_3.Text = "0";
            this.buttonS_3.UseVisualStyleBackColor = true;
            // 
            // buttonS_2
            // 
            this.buttonS_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonS_2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonS_2.Location = new System.Drawing.Point(148, 76);
            this.buttonS_2.Margin = new System.Windows.Forms.Padding(0);
            this.buttonS_2.Name = "buttonS_2";
            this.buttonS_2.Size = new System.Drawing.Size(74, 77);
            this.buttonS_2.TabIndex = 9;
            this.buttonS_2.Text = "0";
            this.buttonS_2.UseVisualStyleBackColor = true;
            // 
            // buttonS_1
            // 
            this.buttonS_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonS_1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonS_1.Location = new System.Drawing.Point(74, 76);
            this.buttonS_1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonS_1.Name = "buttonS_1";
            this.buttonS_1.Size = new System.Drawing.Size(74, 77);
            this.buttonS_1.TabIndex = 8;
            this.buttonS_1.Text = "0";
            this.buttonS_1.UseVisualStyleBackColor = true;
            // 
            // buttonS_0
            // 
            this.buttonS_0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonS_0.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonS_0.Location = new System.Drawing.Point(0, 76);
            this.buttonS_0.Margin = new System.Windows.Forms.Padding(0);
            this.buttonS_0.Name = "buttonS_0";
            this.buttonS_0.Size = new System.Drawing.Size(74, 77);
            this.buttonS_0.TabIndex = 7;
            this.buttonS_0.Text = "0";
            this.buttonS_0.UseVisualStyleBackColor = true;
            // 
            // buttonN_0
            // 
            this.buttonN_0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonN_0.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonN_0.Location = new System.Drawing.Point(370, 0);
            this.buttonN_0.Margin = new System.Windows.Forms.Padding(0);
            this.buttonN_0.Name = "buttonN_0";
            this.buttonN_0.Size = new System.Drawing.Size(76, 76);
            this.buttonN_0.TabIndex = 6;
            this.buttonN_0.Text = "0";
            this.buttonN_0.UseVisualStyleBackColor = true;
            // 
            // buttonN_1
            // 
            this.buttonN_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonN_1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonN_1.Location = new System.Drawing.Point(296, 0);
            this.buttonN_1.Margin = new System.Windows.Forms.Padding(0);
            this.buttonN_1.Name = "buttonN_1";
            this.buttonN_1.Size = new System.Drawing.Size(74, 76);
            this.buttonN_1.TabIndex = 5;
            this.buttonN_1.Text = "0";
            this.buttonN_1.UseVisualStyleBackColor = true;
            // 
            // buttonN_4
            // 
            this.buttonN_4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonN_4.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonN_4.Location = new System.Drawing.Point(74, 0);
            this.buttonN_4.Margin = new System.Windows.Forms.Padding(0);
            this.buttonN_4.Name = "buttonN_4";
            this.buttonN_4.Size = new System.Drawing.Size(74, 76);
            this.buttonN_4.TabIndex = 2;
            this.buttonN_4.Text = "0";
            this.buttonN_4.UseVisualStyleBackColor = true;
            // 
            // buttonN_5
            // 
            this.buttonN_5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonN_5.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonN_5.Location = new System.Drawing.Point(0, 0);
            this.buttonN_5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonN_5.Name = "buttonN_5";
            this.buttonN_5.Size = new System.Drawing.Size(74, 76);
            this.buttonN_5.TabIndex = 1;
            this.buttonN_5.Text = "0";
            this.buttonN_5.UseVisualStyleBackColor = true;
            // 
            // buttonN_3
            // 
            this.buttonN_3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonN_3.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonN_3.Location = new System.Drawing.Point(148, 0);
            this.buttonN_3.Margin = new System.Windows.Forms.Padding(0);
            this.buttonN_3.Name = "buttonN_3";
            this.buttonN_3.Size = new System.Drawing.Size(74, 76);
            this.buttonN_3.TabIndex = 3;
            this.buttonN_3.Text = "0";
            this.buttonN_3.UseVisualStyleBackColor = true;
            // 
            // buttonS_5
            // 
            this.buttonS_5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonS_5.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonS_5.Location = new System.Drawing.Point(370, 76);
            this.buttonS_5.Margin = new System.Windows.Forms.Padding(0);
            this.buttonS_5.Name = "buttonS_5";
            this.buttonS_5.Size = new System.Drawing.Size(76, 77);
            this.buttonS_5.TabIndex = 12;
            this.buttonS_5.Text = "0";
            this.buttonS_5.UseVisualStyleBackColor = true;
            // 
            // buttonN_2
            // 
            this.buttonN_2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonN_2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonN_2.Location = new System.Drawing.Point(222, 0);
            this.buttonN_2.Margin = new System.Windows.Forms.Padding(0);
            this.buttonN_2.Name = "buttonN_2";
            this.buttonN_2.Size = new System.Drawing.Size(74, 76);
            this.buttonN_2.TabIndex = 4;
            this.buttonN_2.Text = "0";
            this.buttonN_2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.panel3.Location = new System.Drawing.Point(675, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(457, 436);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dataGridViewHistory);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 34);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(453, 398);
            this.panel4.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(453, 34);
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
            this.dataGridViewHistory.Size = new System.Drawing.Size(453, 398);
            this.dataGridViewHistory.TabIndex = 1;
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
            this.dataGridViewTextBoxColumn4.HeaderText = "先手スコア";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "SecondStore";
            this.dataGridViewTextBoxColumn5.HeaderText = "後手スコア";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 70;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FirstBoardState";
            this.dataGridViewTextBoxColumn6.HeaderText = "先手盤面";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "SecondBoardState";
            this.dataGridViewTextBoxColumn7.HeaderText = "後手盤面";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataHistoryBindingSource
            // 
            this.dataHistoryBindingSource.DataSource = typeof(mancala.DataHistory);
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 496);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "マンカラ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataHistoryBindingSource)).EndInit();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn handDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstStoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondStoreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstBoardStateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondBoardStateDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dataHistoryBindingSource;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonInversion;
    }
}