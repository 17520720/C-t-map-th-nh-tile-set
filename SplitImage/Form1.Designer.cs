namespace SplitImage
{
    partial class form_SplitImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_SplitImage));
            this.bt_ChooseFile = new System.Windows.Forms.Button();
            this.tb__CellSize = new System.Windows.Forms.TextBox();
            this.lb_CellSize = new System.Windows.Forms.Label();
            this.tb_numRows = new System.Windows.Forms.TextBox();
            this.lb_soHang = new System.Windows.Forms.Label();
            this.lb_textDuongdan = new System.Windows.Forms.Label();
            this.tb_Folder = new System.Windows.Forms.TextBox();
            this.gb_Infor = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_FileName = new System.Windows.Forms.TextBox();
            this.bt_ChooseFolder = new System.Windows.Forms.Button();
            this.bt_Export = new System.Windows.Forms.Button();
            this.lb_caution = new System.Windows.Forms.Label();
            this.gb_Infor.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_ChooseFile
            // 
            this.bt_ChooseFile.Location = new System.Drawing.Point(317, 42);
            this.bt_ChooseFile.Name = "bt_ChooseFile";
            this.bt_ChooseFile.Size = new System.Drawing.Size(75, 23);
            this.bt_ChooseFile.TabIndex = 0;
            this.bt_ChooseFile.Text = "Chọn File";
            this.bt_ChooseFile.UseVisualStyleBackColor = true;
            this.bt_ChooseFile.Click += new System.EventHandler(this.bt_ChooseFile_Click);
            // 
            // tb__CellSize
            // 
            this.tb__CellSize.Location = new System.Drawing.Point(186, 142);
            this.tb__CellSize.Name = "tb__CellSize";
            this.tb__CellSize.Size = new System.Drawing.Size(75, 20);
            this.tb__CellSize.TabIndex = 3;
            this.tb__CellSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb__CellSize_KeyPress);
            // 
            // lb_CellSize
            // 
            this.lb_CellSize.AutoSize = true;
            this.lb_CellSize.ForeColor = System.Drawing.Color.White;
            this.lb_CellSize.Location = new System.Drawing.Point(71, 145);
            this.lb_CellSize.Name = "lb_CellSize";
            this.lb_CellSize.Size = new System.Drawing.Size(80, 13);
            this.lb_CellSize.TabIndex = 3;
            this.lb_CellSize.Text = "Kích thước Cell";
            // 
            // tb_numRows
            // 
            this.tb_numRows.Location = new System.Drawing.Point(186, 168);
            this.tb_numRows.Name = "tb_numRows";
            this.tb_numRows.Size = new System.Drawing.Size(75, 20);
            this.tb_numRows.TabIndex = 4;
            this.tb_numRows.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_numRows_KeyPress);
            // 
            // lb_soHang
            // 
            this.lb_soHang.AutoSize = true;
            this.lb_soHang.ForeColor = System.Drawing.Color.White;
            this.lb_soHang.Location = new System.Drawing.Point(71, 171);
            this.lb_soHang.Name = "lb_soHang";
            this.lb_soHang.Size = new System.Drawing.Size(90, 13);
            this.lb_soHang.TabIndex = 5;
            this.lb_soHang.Text = "Số hàng của Grid";
            // 
            // lb_textDuongdan
            // 
            this.lb_textDuongdan.AutoSize = true;
            this.lb_textDuongdan.ForeColor = System.Drawing.Color.White;
            this.lb_textDuongdan.Location = new System.Drawing.Point(71, 88);
            this.lb_textDuongdan.Name = "lb_textDuongdan";
            this.lb_textDuongdan.Size = new System.Drawing.Size(99, 13);
            this.lb_textDuongdan.TabIndex = 6;
            this.lb_textDuongdan.Text = "Đường dẫn xuất file";
            // 
            // tb_Folder
            // 
            this.tb_Folder.Location = new System.Drawing.Point(6, 104);
            this.tb_Folder.Name = "tb_Folder";
            this.tb_Folder.ReadOnly = true;
            this.tb_Folder.Size = new System.Drawing.Size(297, 20);
            this.tb_Folder.TabIndex = 2;
            // 
            // gb_Infor
            // 
            this.gb_Infor.Controls.Add(this.label1);
            this.gb_Infor.Controls.Add(this.tb_FileName);
            this.gb_Infor.Controls.Add(this.tb_Folder);
            this.gb_Infor.Controls.Add(this.bt_ChooseFolder);
            this.gb_Infor.Controls.Add(this.lb_textDuongdan);
            this.gb_Infor.Controls.Add(this.lb_soHang);
            this.gb_Infor.Controls.Add(this.tb_numRows);
            this.gb_Infor.Controls.Add(this.lb_CellSize);
            this.gb_Infor.Controls.Add(this.tb__CellSize);
            this.gb_Infor.Controls.Add(this.bt_ChooseFile);
            this.gb_Infor.ForeColor = System.Drawing.Color.Black;
            this.gb_Infor.Location = new System.Drawing.Point(205, 103);
            this.gb_Infor.Name = "gb_Infor";
            this.gb_Infor.Size = new System.Drawing.Size(398, 214);
            this.gb_Infor.TabIndex = 9;
            this.gb_Infor.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(71, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "File ảnh cần cắt";
            // 
            // tb_FileName
            // 
            this.tb_FileName.Location = new System.Drawing.Point(6, 44);
            this.tb_FileName.Name = "tb_FileName";
            this.tb_FileName.ReadOnly = true;
            this.tb_FileName.Size = new System.Drawing.Size(297, 20);
            this.tb_FileName.TabIndex = 7;
            // 
            // bt_ChooseFolder
            // 
            this.bt_ChooseFolder.Location = new System.Drawing.Point(317, 102);
            this.bt_ChooseFolder.Name = "bt_ChooseFolder";
            this.bt_ChooseFolder.Size = new System.Drawing.Size(75, 23);
            this.bt_ChooseFolder.TabIndex = 1;
            this.bt_ChooseFolder.Text = "Duyệt";
            this.bt_ChooseFolder.UseVisualStyleBackColor = true;
            this.bt_ChooseFolder.Click += new System.EventHandler(this.bt_ChooseFolder_Click);
            // 
            // bt_Export
            // 
            this.bt_Export.Location = new System.Drawing.Point(378, 306);
            this.bt_Export.Name = "bt_Export";
            this.bt_Export.Size = new System.Drawing.Size(75, 23);
            this.bt_Export.TabIndex = 5;
            this.bt_Export.Text = "Xuất file";
            this.bt_Export.UseVisualStyleBackColor = true;
            this.bt_Export.Click += new System.EventHandler(this.bt_Export_Click);
            // 
            // lb_caution
            // 
            this.lb_caution.AutoSize = true;
            this.lb_caution.ForeColor = System.Drawing.Color.DarkRed;
            this.lb_caution.Location = new System.Drawing.Point(12, 428);
            this.lb_caution.Name = "lb_caution";
            this.lb_caution.Size = new System.Drawing.Size(0, 13);
            this.lb_caution.TabIndex = 10;
            // 
            // form_SplitImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lb_caution);
            this.Controls.Add(this.bt_Export);
            this.Controls.Add(this.gb_Infor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "form_SplitImage";
            this.Text = "Not Responding...";
            this.Load += new System.EventHandler(this.form_SplitImage_Load);
            this.gb_Infor.ResumeLayout(false);
            this.gb_Infor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button bt_ChooseFile;
        private System.Windows.Forms.TextBox tb__CellSize;
        private System.Windows.Forms.Label lb_CellSize;
        private System.Windows.Forms.TextBox tb_numRows;
        private System.Windows.Forms.Label lb_soHang;
        private System.Windows.Forms.Label lb_textDuongdan;
        private System.Windows.Forms.TextBox tb_Folder;
        private System.Windows.Forms.GroupBox gb_Infor;
        private System.Windows.Forms.Button bt_Export;
        private System.Windows.Forms.Button bt_ChooseFolder;
        private System.Windows.Forms.TextBox tb_FileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_caution;
    }
}

