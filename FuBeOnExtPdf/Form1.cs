using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FuBeOnExtPdf
{
    public partial class Form1 : Form
    {

        private delegate void MyDelegate(string scr, string dest);
        private delegate void MyDelegate2(Form1 frm, string scr);
        private static string LastDestPdfFile = String.Empty;

        public Form1()
        {
            InitializeComponent();

        }


        private void btnParseDoc_Click(object sender, EventArgs e)
        {
            MyDelegate MyFct = new MyDelegate(cCreateFuBe.ParseDoc);
            CallFct(MyFct, txtSrcFile.Text, txtDestFolder.Text);

        }

        private void btnCreateAnnot_Click(object sender, EventArgs e)
        {
            MyDelegate MyFct = new MyDelegate(cCreateFuBe.CreateAnnot);
            CallFct(MyFct, txtSrcFile.Text, txtDestFolder.Text);
        }


        private void btnReadAnnot_Click(object sender, EventArgs e)
        {
            MyDelegate MyFct = new MyDelegate(cCreateFuBe.ReadAnnot);
            CallFct(MyFct, txtSrcFile.Text, txtDestFolder.Text);
        }





        private void btnAddTestFields_Click(object sender, EventArgs e)
        {
            MyDelegate MyFct = new MyDelegate(cCreateFuBe.AddTestFields);
            CallFct(MyFct, txtSrcFile.Text, txtDestFolder.Text);
        }

        private void btnAddFieldByChapter_Click(object sender, EventArgs e)
        {
            MyDelegate MyFct = new MyDelegate(cCreateFuBe.AddTestFieldsByChapter);
            CallFct(MyFct, txtSrcFile.Text, txtDestFolder.Text);
        }

        private void btnReadTestFields_Click(object sender, EventArgs e)
        {
            txtInfo.Clear();
            MyDelegate2 MyFct = new MyDelegate2(cCreateFuBe.ReadTestFields);
            MyFct(this, txtSrcFile.Text);
           
        }



        private void CallFct(MyDelegate MyFct, string src, string destFolder)
        {

            try
            {
                txtInfo.Clear();
                txtInfo.AppendText("Start: " + DateTime.Now.ToLongTimeString() + Environment.NewLine);

                string destFile = destFolder + System.IO.Path.GetFileNameWithoutExtension(src) + "_" + DateTime.Now.ToString("yyMMdd_HHmmss") + System.IO.Path.GetExtension(src);
                LastDestPdfFile = destFile;
                MyFct(src, destFile);  // Call function via Delegate (Delegate ist ein Verweis auf die Funktion)

                if (cbOpenPdf.Checked)
                {
                    System.Diagnostics.Process p = new System.Diagnostics.Process();
                    p.StartInfo.FileName = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Application.ExecutablePath), destFile);
                    p.Start();
                }
            }
            catch (Exception ex)
            {
                txtInfo.Text = ex.Message + Environment.NewLine;
                return;
            }
            txtInfo.AppendText("Done: " + DateTime.Now.ToLongTimeString());
        }



        public string InfoText
        {
            get { return txtInfo.Text; }
            set { txtInfo.AppendText( value); }
        }

 
    }
}
