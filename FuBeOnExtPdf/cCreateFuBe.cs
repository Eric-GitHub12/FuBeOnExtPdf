using iText.Forms;
using iText.Forms.Fields;
using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using iText.Kernel.Pdf.Annot;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuBeOnExtPdf
{
    class cCreateFuBe
    {
        // ********************************************************************
        // Fct:     ParseDoc
        //
        // Descr:   - 
        //          
        // Owner:   erst
        // ********************************************************************
        public static void ParseDoc(String src, String dest)
        {

            try
            {

                PdfDocument ScrPdf = new PdfDocument(new PdfReader(src));
                // PdfDocument DestPdf = new PdfDocument(new PdfWriter(dest));

                PdfPage page = ScrPdf.GetFirstPage();

                // Collects all comment annotations in the document
                Collection<PdfAnnotation> annotations = new Collection<PdfAnnotation>(page.GetAnnotations());

                foreach (PdfAnnotation annot in annotations)
                {
                    if (annot.GetType().Equals((typeof(iText.Kernel.Pdf.Annot.PdfTextAnnotation))))
                    {
                        PdfDictionary annotDictionary = annot.GetPdfObject();

                        //Rect is the annotation rectangle defining the location of the annotation on the page
                        PdfArray Arr = annotDictionary.GetAsArray(PdfName.Rect);

                        int x = Arr.GetAsNumber(0).IntValue();
                        int y = Arr.GetAsNumber(1).IntValue();

                        Rectangle rect = annotDictionary.GetAsRectangle(PdfName.Rect);
                        float recX = rect.GetX();
                        float recY = rect.GetY();

                        //Read the content
                        String content = annotDictionary.Get(PdfName.Contents).ToString();
                        string output = content;
                    }
                }

                //  DestPdf.Close();
                ScrPdf.Close();
            }
            catch (Exception ex)
            {


                throw ex;
            }
            finally
            {

            }
        }


        // ********************************************************************
        // Fct:     CreateAnnot
        //
        // Descr:   - 
        //          
        // Owner:   erst
        // ********************************************************************
        public static void CreateAnnot(String src, String dest)
        {

            try
            {

                // Initialize PDF document
                PdfDocument ScrPdf = new PdfDocument(new PdfReader(src));
                PdfPage SrcPage = null;


                PdfDocument destPdf = new PdfDocument(new PdfWriter(dest));
                PageSize ps = PageSize.A4;
                destPdf.SetDefaultPageSize(ps);

                string idx = String.Empty;


                for (int i = 1; i <= 3; i++)
                {
                    idx = i.ToString();
                    // Add a page from Source PDF
                    SrcPage = ScrPdf.GetPage(i);
                    destPdf.AddPage(SrcPage.CopyTo(destPdf));
                    // Add empty page
                    //destPdf.AddNewPage(PageSize.A4);

                    PdfPage page = destPdf.GetPage(i);

                    // add title
                    PdfFont fontHelvetica = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                    PdfCanvas canvas = new PdfCanvas(page);
                    canvas.BeginText().SetFontAndSize(fontHelvetica, 8).MoveText(420, 770).ShowText("My Title " + idx).EndText();

                    //Add acroform
                    PdfAcroForm form = PdfAcroForm.GetAcroForm(destPdf, true);
                    //Create text field
                    PdfTextFormField title = PdfTextFormField.CreateText(destPdf, new Rectangle(420, 750, 60, 10), idx + "_Title", idx + ".Page", fontHelvetica, 6);
                    PdfTextFormField user1 = PdfTextFormField.CreateText(destPdf, new Rectangle(420, 740, 60, 10), idx + "_User", "enter User", fontHelvetica, 6);
                    PdfTextFormField date1 = PdfTextFormField.CreateText(destPdf, new Rectangle(420, 730, 60, 10), idx + "_Date", "enter date" + idx, fontHelvetica, 6);
                    form.AddField(title);
                    form.AddField(user1);
                    form.AddField(date1);

                    //// Create Button Check

                    PdfButtonFormField button = PdfFormField.CreatePushButton(destPdf, new Rectangle(420, 720, 19, 10), idx + "_BtnOK", "OK");
                    //button.SetAction(PdfAction.CreateResetForm(new String[] { "name", "language", "experience1", "experience2", "experience3", "shift", "info" }, 0));
                    PdfAction action = new PdfAction();
                    PdfAction date = PdfAction.CreateJavaScript("AFDate_FormatEx(\"yyyy-mm-dd\");");

                    //PdfAction date = PdfAction.CreateNamed
                    //action.Put(button.GetFormType(), PdfName.F);

                    button.SetAction(date);
                    form.AddField(button);

                }


                ScrPdf.Close();
                destPdf.Close();

            }
            catch (Exception ex)
            {


                throw ex;
            }
            finally
            {

            }
        }


        // ********************************************************************
        // Fct:     ReadAnnot
        //
        // Descr:   - 
        //          
        // Owner:   erst
        // ********************************************************************
        public static void ReadAnnot(String src, String dest)
        {

            try
            {

                PdfDocument ScrPdf = new PdfDocument(new PdfReader(src));
                //PdfDocument DestPdf = new PdfDocument(new PdfWriter(dest));

                PdfPage page = ScrPdf.GetFirstPage();

                PdfAcroForm form = PdfAcroForm.GetAcroForm(ScrPdf, true);

                IDictionary<String, PdfFormField> fields = form.GetFormFields();

                foreach (var field in fields)
                {
                    string str = field.Key;  // ist der name des Feldes
                    PdfFormField PdfField = field.Value;
                    string str2 = PdfField.GetValueAsString();   // ist der Inhalt des Feldes

                }


                // DestPdf.Close();
                ScrPdf.Close();
            }
            catch (Exception ex)
            {


                throw ex;
            }
            finally
            {

            }
        }


        // ********************************************************************
        // Fct:     AddTestFields
        //
        // Descr:   - 
        //          
        // Owner:   erst
        // ********************************************************************
        public static void AddTestFields(String src, String dest)
        {
            float XKoord = 0;
            float YKoord = 0;
            string CommentContent = String.Empty;
            PdfFont fontHelvetica = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            try
            {

                PdfDocument scrPdf = new PdfDocument(new PdfReader(src));
                PdfDocument destPdf = new PdfDocument(new PdfWriter(dest));
                PageSize ps = PageSize.A4;
                destPdf.SetDefaultPageSize(ps);

                int lastPageNo = scrPdf.GetPageNumber(scrPdf.GetLastPage());
                lastPageNo = 3;

                PdfPage srcPage = scrPdf.GetFirstPage();
                PdfPage destPage = null;
                int annotNo = 0;


                for (int i = 1; i <= lastPageNo; i++)
                {
                    srcPage = scrPdf.GetPage(i);
                    annotNo = 1;

                    // copy page
                    destPdf.AddPage(srcPage.CopyTo(destPdf));
                    destPage = destPdf.GetPage(i);

                    while (GetNextPdfComment(destPage, ref XKoord, ref YKoord, ref CommentContent, ref annotNo))
                    {
                        PdfCanvas canvas = new PdfCanvas(destPage);
                        canvas.BeginText().SetFontAndSize(fontHelvetica, 8).MoveText(XKoord, YKoord).ShowText(CommentContent).EndText();

                        //Add acroform
                        PdfAcroForm form = PdfAcroForm.GetAcroForm(destPdf, true);
                        //Create text field                        
                        PdfTextFormField user1 = PdfTextFormField.CreateText(destPdf, new Rectangle(XKoord, YKoord - 10, 60, 8), CommentContent + "_User", "enter User", fontHelvetica, 6);
                        PdfTextFormField date1 = PdfTextFormField.CreateText(destPdf, new Rectangle(XKoord, YKoord - 20, 60, 8), CommentContent + "_Date", "enter date", fontHelvetica, 6);
                        form.AddField(user1);
                        form.AddField(date1);
                    }
                }

                scrPdf.Close();
                destPdf.Close();

            }
            catch (Exception ex)
            {


                throw ex;
            }
            finally
            {

            }
        }


        // ********************************************************************
        // Fct:     GetNextPdfComment
        //
        // Descr:   - 
        //          
        // Owner:   erst
        // ********************************************************************
        private static bool GetNextPdfComment(PdfPage page, ref float x, ref float y, ref string content, ref int annotNo)
        {
            // Collects all comment annotations in the document
            Collection<PdfAnnotation> annotations = new Collection<PdfAnnotation>(page.GetAnnotations());

            while (annotNo <= annotations.Count)
            {
                PdfAnnotation annot = annotations[annotNo - 1];   // Array starts with index 0, annotNo starts with 1
                if (annot.GetType().Equals((typeof(iText.Kernel.Pdf.Annot.PdfTextAnnotation))))
                {
                    PdfDictionary annotDictionary = annot.GetPdfObject();

                    //Rect is the annotation rectangle defining the location of the annotation on the page
                    PdfArray Arr = annotDictionary.GetAsArray(PdfName.Rect);

                    //int x = Arr.GetAsNumber(0).IntValue();
                    //int y = Arr.GetAsNumber(1).IntValue();

                    Rectangle rect = annotDictionary.GetAsRectangle(PdfName.Rect);
                    x = rect.GetX();
                    y = rect.GetY();

                    //Read the content
                    content = annotDictionary.Get(PdfName.Contents).ToString();

                    annotNo++;
                    return true;
                }
                else
                    annotNo++;
            }

            return false;
        }




        // ********************************************************************
        // Fct:     AddTestFieldsByChapter
        //
        // Descr:   - 
        //          
        // Owner:   erst
        // ********************************************************************
        public static void AddTestFieldsByChapter(String src, String dest)
        {
            float XKoord = 0;
            float YKoord = 0;
            string CommentContent = String.Empty;
            PdfFont fontHelvetica = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            try
            {

                PdfDocument scrPdf = new PdfDocument(new PdfReader(src));
                PdfDocument destPdf = new PdfDocument(new PdfWriter(dest));
                PageSize ps = PageSize.A4;
                destPdf.SetDefaultPageSize(ps);

                int lastPageNo = scrPdf.GetPageNumber(scrPdf.GetLastPage());
                lastPageNo = 8;  // for testing only the first pages

                int startPage = 5; // Page after the directory (Inhaltsverzeichnis)
                int NbrChapters = 0;
                string chapterName = String.Empty;
                string chapterId = String.Empty;

                PdfPage srcPage = scrPdf.GetFirstPage();
                PdfPage destPage = null;
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();

                for (int i = startPage; i <= lastPageNo; i++)
                {
                    srcPage = scrPdf.GetPage(i);

                    // copy page
                    destPdf.AddPage(srcPage.CopyTo(destPdf));
                    destPage = destPdf.GetPage(i);

                    string textPage = PdfTextExtractor.GetTextFromPage(destPage, strategy);
                    string[] textLines = textPage.Split('\n');
                    foreach (var oneLine in textLines)
                    {

                        if (GetChapterId(oneLine, ref chapterId))
                        {

                        }


                    }


                    //while (GetNextPdfComment(destPage, ref XKoord, ref YKoord, ref CommentContent, ref annotNo))
                    //{
                    //    PdfCanvas canvas = new PdfCanvas(destPage);
                    //    canvas.BeginText().SetFontAndSize(fontHelvetica, 8).MoveText(XKoord, YKoord).ShowText(CommentContent).EndText();

                    //    //Add acroform
                    //    PdfAcroForm form = PdfAcroForm.GetAcroForm(destPdf, true);
                    //    //Create text field                        
                    //    PdfTextFormField user1 = PdfTextFormField.CreateText(destPdf, new Rectangle(XKoord, YKoord - 10, 60, 8), CommentContent + "_User", "enter User", fontHelvetica, 6);
                    //    PdfTextFormField date1 = PdfTextFormField.CreateText(destPdf, new Rectangle(XKoord, YKoord - 20, 60, 8), CommentContent + "_Date", "enter date", fontHelvetica, 6);
                    //    form.AddField(user1);
                    //    form.AddField(date1);
                    //}
                }

                scrPdf.Close();
                destPdf.Close();

            }
            catch (Exception ex)
            {


                throw ex;
            }
            finally
            {

            }
        }




        // ********************************************************************
        // Fct:     GetChapterId
        //
        // Descr:   -
        //          
        // Owner:   erst
        // ********************************************************************
        private static bool GetChapterId(string oneLine, ref string chapterNo)
        {
            try
            {


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
            return false;
        }




        // ********************************************************************
        // Fct:     ReadTestFields
        //
        // Descr:   Reads the test fields an returns the content to the Infobox
        //          
        // Owner:   erst
        // ********************************************************************
        public static void ReadTestFields(Form1 frm, String src)
        {
            try
            {
                PdfDocument scrPdf = new PdfDocument(new PdfReader(src));
                PdfAcroForm form = PdfAcroForm.GetAcroForm(scrPdf, true);
                IDictionary<String, PdfFormField> fields = form.GetFormFields();

                foreach (var field in fields)
                {
                    frm.InfoText = "Key: " + field.Key;  // ist der Name des Feldes
                    PdfFormField PdfField = field.Value;
                    frm.InfoText = ";       Value: " + PdfField.GetValueAsString() + Environment.NewLine;   // ist der Inhalt des Feldes

                    scrPdf.Close();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }
    }
}
