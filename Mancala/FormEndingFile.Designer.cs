namespace Mancala
{
    partial class FormEndingFile
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
            this.dataGridViewEndingFile = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.textBoxVer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.noDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstBoardStateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.secondBoardStateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.visitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataEndingFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEndingFile)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEndingFileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewEndingFile
            // 
            this.dataGridViewEndingFile.AllowUserToAddRows = false;
            this.dataGridViewEndingFile.AllowUserToDeleteRows = false;
            this.dataGridViewEndingFile.AllowUserToResizeColumns = false;
            this.dataGridViewEndingFile.AllowUserToResizeRows = false;
            this.dataGridViewEndingFile.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewEndingFile.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewEndingFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewEndingFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noDataGridViewTextBoxColumn,
            this.firstBoardStateDataGridViewTextBoxColumn,
            this.secondBoardStateDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.visitDataGridViewTextBoxColumn});
            this.dataGridViewEndingFile.DataSource = this.dataEndingFileBindingSource;
            this.dataGridViewEndingFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEndingFile.EnableHeadersVisualStyles = false;
            this.dataGridViewEndingFile.Location = new System.Drawing.Point(0, 41);
            this.dataGridViewEndingFile.Name = "dataGridViewEndingFile";
            this.dataGridViewEndingFile.ReadOnly = true;
            this.dataGridViewEndingFile.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewEndingFile.RowTemplate.Height = 21;
            this.dataGridViewEndingFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewEndingFile.Size = new System.Drawing.Size(446, 516);
            this.dataGridViewEndingFile.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxCount);
            this.panel1.Controls.Add(this.textBoxVer);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 41);
            this.panel1.TabIndex = 3;
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(150, 11);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.ReadOnly = true;
            this.textBoxCount.Size = new System.Drawing.Size(105, 19);
            this.textBoxCount.TabIndex = 12;
            this.textBoxCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBoxVer
            // 
            this.textBoxVer.Location = new System.Drawing.Point(48, 11);
            this.textBoxVer.Name = "textBoxVer";
            this.textBoxVer.ReadOnly = true;
            this.textBoxVer.Size = new System.Drawing.Size(44, 19);
            this.textBoxVer.TabIndex = 11;
            this.textBoxVer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(111, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "件数";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Ver.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // noDataGridViewTextBoxColumn
            // 
            this.noDataGridViewTextBoxColumn.DataPropertyName = "No";
            this.noDataGridViewTextBoxColumn.HeaderText = "#";
            this.noDataGridViewTextBoxColumn.Name = "noDataGridViewTextBoxColumn";
            this.noDataGridViewTextBoxColumn.ReadOnly = true;
            this.noDataGridViewTextBoxColumn.Width = 50;
            // 
            // firstBoardStateDataGridViewTextBoxColumn
            // 
            this.firstBoardStateDataGridViewTextBoxColumn.DataPropertyName = "FirstBoardState";
            this.firstBoardStateDataGridViewTextBoxColumn.HeaderText = "盤面1";
            this.firstBoardStateDataGridViewTextBoxColumn.Name = "firstBoardStateDataGridViewTextBoxColumn";
            this.firstBoardStateDataGridViewTextBoxColumn.ReadOnly = true;
            this.firstBoardStateDataGridViewTextBoxColumn.Width = 80;
            // 
            // secondBoardStateDataGridViewTextBoxColumn
            // 
            this.secondBoardStateDataGridViewTextBoxColumn.DataPropertyName = "SecondBoardState";
            this.secondBoardStateDataGridViewTextBoxColumn.HeaderText = "盤面2";
            this.secondBoardStateDataGridViewTextBoxColumn.Name = "secondBoardStateDataGridViewTextBoxColumn";
            this.secondBoardStateDataGridViewTextBoxColumn.ReadOnly = true;
            this.secondBoardStateDataGridViewTextBoxColumn.Width = 80;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "評価値";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            this.valueDataGridViewTextBoxColumn.ReadOnly = true;
            this.valueDataGridViewTextBoxColumn.Width = 80;
            // 
            // visitDataGridViewTextBoxColumn
            // 
            this.visitDataGridViewTextBoxColumn.DataPropertyName = "Visit";
            this.visitDataGridViewTextBoxColumn.HeaderText = "訪問数";
            this.visitDataGridViewTextBoxColumn.Name = "visitDataGridViewTextBoxColumn";
            this.visitDataGridViewTextBoxColumn.ReadOnly = true;
            this.visitDataGridViewTextBoxColumn.Width = 80;
            // 
            // dataEndingFileBindingSource
            // 
            this.dataEndingFileBindingSource.DataSource = typeof(Mancala.DataEndingFile);
            // 
            // FormEndingFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 557);
            this.Controls.Add(this.dataGridViewEndingFile);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEndingFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormEndingFile";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEndingFile)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataEndingFileBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewEndingFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.TextBox textBoxVer;
        private System.Windows.Forms.BindingSource dataEndingFileBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn noDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstBoardStateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn secondBoardStateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn visitDataGridViewTextBoxColumn;
    }
}