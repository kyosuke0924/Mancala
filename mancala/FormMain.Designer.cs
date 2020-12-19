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
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(617, 267);
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
            this.buttonS_4.TabIndex = 12;
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
            this.buttonS_3.TabIndex = 11;
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
            this.buttonS_2.TabIndex = 10;
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
            this.buttonS_1.TabIndex = 9;
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
            this.buttonS_0.TabIndex = 8;
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
            this.buttonN_0.TabIndex = 7;
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
            this.buttonN_1.TabIndex = 4;
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
            this.buttonN_3.TabIndex = 0;
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
            this.buttonS_5.TabIndex = 13;
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
            this.buttonN_2.TabIndex = 3;
            this.buttonN_2.Text = "0";
            this.buttonN_2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.buttonQuit);
            this.panel2.Controls.Add(this.buttonUndo);
            this.panel2.Controls.Add(this.buttonReset);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(617, 60);
            this.panel2.TabIndex = 2;
            // 
            // buttonQuit
            // 
            this.buttonQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonQuit.Location = new System.Drawing.Point(495, 12);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(106, 39);
            this.buttonQuit.TabIndex = 2;
            this.buttonQuit.Text = "終了";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.ButtonQuit_Click);
            // 
            // buttonUndo
            // 
            this.buttonUndo.Location = new System.Drawing.Point(128, 12);
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 327);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "マンカラ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
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
    }
}