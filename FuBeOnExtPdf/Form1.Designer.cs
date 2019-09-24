namespace FuBeOnExtPdf
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSrcFile = new System.Windows.Forms.TextBox();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnParseDoc = new System.Windows.Forms.Button();
            this.txtDestFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbOpenPdf = new System.Windows.Forms.CheckBox();
            this.btnCreateAnnot = new System.Windows.Forms.Button();
            this.btnReadAnnot = new System.Windows.Forms.Button();
            this.btnAddTestFields = new System.Windows.Forms.Button();
            this.btnReadTestFields = new System.Windows.Forms.Button();
            this.btnAddFieldByChapter = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source File";
            // 
            // txtSrcFile
            // 
            this.txtSrcFile.Location = new System.Drawing.Point(103, 25);
            this.txtSrcFile.Name = "txtSrcFile";
            this.txtSrcFile.Size = new System.Drawing.Size(572, 20);
            this.txtSrcFile.TabIndex = 1;
            this.txtSrcFile.Text = "C:\\Users\\erst\\Documents\\Visual Studio 2017\\Projects\\TestData\\51-GBA-H13-BAH-G-BBS" +
    "-FUBE_HK_3641-A.pdf";
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(103, 81);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(463, 143);
            this.txtInfo.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Info:";
            // 
            // btnParseDoc
            // 
            this.btnParseDoc.Location = new System.Drawing.Point(572, 143);
            this.btnParseDoc.Name = "btnParseDoc";
            this.btnParseDoc.Size = new System.Drawing.Size(103, 23);
            this.btnParseDoc.TabIndex = 4;
            this.btnParseDoc.Text = "Parse Comments";
            this.btnParseDoc.UseVisualStyleBackColor = true;
            this.btnParseDoc.Click += new System.EventHandler(this.btnParseDoc_Click);
            // 
            // txtDestFolder
            // 
            this.txtDestFolder.Location = new System.Drawing.Point(103, 51);
            this.txtDestFolder.Name = "txtDestFolder";
            this.txtDestFolder.Size = new System.Drawing.Size(572, 20);
            this.txtDestFolder.TabIndex = 6;
            this.txtDestFolder.Text = "C:\\Users\\erst\\Documents\\Visual Studio 2017\\Projects\\TestData\\";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output Folder";
            // 
            // cbOpenPdf
            // 
            this.cbOpenPdf.AutoSize = true;
            this.cbOpenPdf.Checked = true;
            this.cbOpenPdf.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOpenPdf.Location = new System.Drawing.Point(604, 84);
            this.cbOpenPdf.Name = "cbOpenPdf";
            this.cbOpenPdf.Size = new System.Drawing.Size(71, 17);
            this.cbOpenPdf.TabIndex = 7;
            this.cbOpenPdf.Text = "Open Pdf";
            this.cbOpenPdf.UseVisualStyleBackColor = true;
            // 
            // btnCreateAnnot
            // 
            this.btnCreateAnnot.Location = new System.Drawing.Point(572, 172);
            this.btnCreateAnnot.Name = "btnCreateAnnot";
            this.btnCreateAnnot.Size = new System.Drawing.Size(103, 23);
            this.btnCreateAnnot.TabIndex = 8;
            this.btnCreateAnnot.Text = "Create Annot";
            this.btnCreateAnnot.UseVisualStyleBackColor = true;
            this.btnCreateAnnot.Click += new System.EventHandler(this.btnCreateAnnot_Click);
            // 
            // btnReadAnnot
            // 
            this.btnReadAnnot.Location = new System.Drawing.Point(572, 201);
            this.btnReadAnnot.Name = "btnReadAnnot";
            this.btnReadAnnot.Size = new System.Drawing.Size(103, 23);
            this.btnReadAnnot.TabIndex = 9;
            this.btnReadAnnot.Text = "Read Annot";
            this.btnReadAnnot.UseVisualStyleBackColor = true;
            this.btnReadAnnot.Click += new System.EventHandler(this.btnReadAnnot_Click);
            // 
            // btnAddTestFields
            // 
            this.btnAddTestFields.Location = new System.Drawing.Point(698, 143);
            this.btnAddTestFields.Name = "btnAddTestFields";
            this.btnAddTestFields.Size = new System.Drawing.Size(163, 23);
            this.btnAddTestFields.TabIndex = 10;
            this.btnAddTestFields.Text = "Add Test Fields by Comment";
            this.btnAddTestFields.UseVisualStyleBackColor = true;
            this.btnAddTestFields.Click += new System.EventHandler(this.btnAddTestFields_Click);
            // 
            // btnReadTestFields
            // 
            this.btnReadTestFields.Location = new System.Drawing.Point(698, 201);
            this.btnReadTestFields.Name = "btnReadTestFields";
            this.btnReadTestFields.Size = new System.Drawing.Size(163, 23);
            this.btnReadTestFields.TabIndex = 11;
            this.btnReadTestFields.Text = "Read Test Fields";
            this.btnReadTestFields.UseVisualStyleBackColor = true;
            this.btnReadTestFields.Click += new System.EventHandler(this.btnReadTestFields_Click);
            // 
            // btnAddFieldByChapter
            // 
            this.btnAddFieldByChapter.Location = new System.Drawing.Point(698, 172);
            this.btnAddFieldByChapter.Name = "btnAddFieldByChapter";
            this.btnAddFieldByChapter.Size = new System.Drawing.Size(163, 23);
            this.btnAddFieldByChapter.TabIndex = 12;
            this.btnAddFieldByChapter.Text = "Add Test Fields by Chapter";
            this.btnAddFieldByChapter.UseVisualStyleBackColor = true;
            this.btnAddFieldByChapter.Click += new System.EventHandler(this.btnAddFieldByChapter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 261);
            this.Controls.Add(this.btnAddFieldByChapter);
            this.Controls.Add(this.btnReadTestFields);
            this.Controls.Add(this.btnAddTestFields);
            this.Controls.Add(this.btnReadAnnot);
            this.Controls.Add(this.btnCreateAnnot);
            this.Controls.Add(this.cbOpenPdf);
            this.Controls.Add(this.txtDestFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnParseDoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.txtSrcFile);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSrcFile;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnParseDoc;
        private System.Windows.Forms.TextBox txtDestFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbOpenPdf;
        private System.Windows.Forms.Button btnCreateAnnot;
        private System.Windows.Forms.Button btnReadAnnot;
        private System.Windows.Forms.Button btnAddTestFields;
        private System.Windows.Forms.Button btnReadTestFields;
        private System.Windows.Forms.Button btnAddFieldByChapter;
    }
}

