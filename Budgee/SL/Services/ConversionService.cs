using Enums;
using ExcelDataReader;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SL.Services.Extensions;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace SL.Services
{
    /// <summary>
    /// Se encarga de cualquier conversión de un tipo de dato a otro, o inclusive de transformación de elementos en
    /// memoria a archivos planos (e.g.: DataTable a PDF).
    /// </summary>
    public static class ConversionService
    {
        #region List
        public static DataTable List_to_DataTable<T>(List<T> list, bool IncludeFields = false, bool IncludeProperties = true)
        {
            //Solo va a tomar fields o properties publicas

            DataTable dataTable = new DataTable();

            FieldInfo[] Fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            if (IncludeFields)
                foreach (var field in Fields)
                    dataTable.Columns.Add(field.Name);

            if (IncludeProperties)
                foreach (var prop in Props)
                    dataTable.Columns.Add(prop.Name);

            int fields_length = (IncludeFields) ? Fields.Length : 0;
            int props_length = (IncludeProperties) ? Props.Length : 0;

            if (fields_length + props_length == 0) return dataTable;

            foreach (T item in list)
            {
                var temp_values = new object[fields_length + props_length];

                for (int i = 0; i < fields_length; i++)
                    temp_values[i] = Fields[i].GetValue(item);

                for (int i = fields_length; i < fields_length + props_length; i++)
                    temp_values[i] = Props[i - fields_length].GetValue(item, null);

                dataTable.Rows.Add(temp_values);
            }

            return dataTable;
        }
        public static List<T> DataTable_To_List<T>(DataTable dt)
        {
            //La asignacion va a ser por atributos/propiedades publicas
            //T debe tener un constructor publico sin parametros

            var fields = typeof(T).GetFields();
            var properties = typeof(T).GetProperties();

            List<T> lst = new List<T>();

            foreach (DataRow dataRow in dt.Rows)
            {
                // Create the object of T
                var ob = Activator.CreateInstance<T>();

                foreach (DataColumn dataColumn in dt.Columns)
                {
                    bool found = false;
                    foreach (var fieldInfo in fields)
                    {
                        // Matching the columns with fields
                        if (fieldInfo.Name == dataColumn.ColumnName)
                        {
                            // Get the value from the datatable cell
                            object value = dataRow[dataColumn.ColumnName];

                            // Set the value into the object
                            fieldInfo.SetValue(ob, value);
                            found = true;
                            break;
                        }
                    }

                    if (found) continue;

                    foreach (var propertyInfo in properties)
                    {
                        // Matching the columns with fields
                        if (propertyInfo.Name == dataColumn.ColumnName)
                        {
                            // Get the value from the datatable cell
                            object value = dataRow[dataColumn.ColumnName];

                            // Set the value into the object
                            propertyInfo.SetValue(ob, value);
                            break;
                        }
                    }
                }

                lst.Add(ob);
            }

            return lst;
        }
        #endregion

        #region DataTable
        public static void DataTable_to_XLSX(DataTable dt, string path)
        {
            try
            {
                Directory.CreateDirectory(GetDirectory(path));
                SLDocument doc = new SLDocument();
                doc.ImportDataTable(1, 1, dt, true);
                doc.SaveAs(Path.Combine(GetDirectory(path), GetFilename(path)));
            }
            catch(Exception ex)
            {
                ex.Handle(typeof(ConversionService));
                throw;
            }
        }
        public static void DataTable_to_XLSX_WithHeaders(DataTable dt, string path, string[] headers, bool boldColumnHeaders = true)
        {
            try
            {
                SLDocument doc = new SLDocument();

                //Agrego titulos
                for (int i = 1; i <= headers.Length; i++)
                {
                    doc.SetCellValue(i, 1, headers[i - 1]);
                }
                //Importo DataTable
                doc.ImportDataTable(headers.Length + 1, 1, dt, true);
                //Headers en negrita
                if (boldColumnHeaders == true)
                {
                    SLStyle HeaderStyle = new SLStyle();
                    HeaderStyle.Font.Bold = true;
                    doc.SetRowStyle(headers.Length + 1, HeaderStyle);
                }
                //Guardo archivo
                Directory.CreateDirectory(GetDirectory(path));
                doc.SaveAs(Path.Combine(GetDirectory(path), GetFilename(path)));
            }
            catch (Exception ex)
            {
                ex.Handle(typeof(ConversionService));
                throw;
            }
        }
        public static void DataTable_to_CSV(DataTable dt, string path, char separator = ';')
        {
            try
            {
                DataTable_to_CSV_WithHeaders(dt, path, new string[] { }, separator);
            }
            catch (Exception ex)
            {
                ex.Handle(typeof(ConversionService));
                throw;
            }
        }
        public static void DataTable_to_CSV_WithHeaders(DataTable dt, string path, string[] headers, char separator = ';')
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                foreach (var header in headers)
                {
                    sb.AppendLine(header);
                }

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sb.Append(dt.Columns[i]);
                    if (i < dt.Columns.Count - 1)
                        sb.Append(separator);
                }
                sb.AppendLine();


                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sb.Append(dr[i].ToString());

                        if (i < dt.Columns.Count - 1)
                            sb.Append(separator);
                    }
                    sb.AppendLine();
                }

                File.WriteAllText(Path.Combine(GetDirectory(path), GetFilename(path)), sb.ToString());
            }
            catch (Exception ex)
            {
                ex.Handle(typeof(ConversionService));
                throw;
            }
        }
        public static HttpResponseMessage DataTable_to_PDF(DataTable dt, string path, string title = null, bool centered_title = true, string[] headers = null, bool centered_columns = false)
        {
            try
            {
                float[] widths = get_row_avg_sizes(get_maxs(dt), get_column_sizes(dt));

                Document document;
                double sum = widths.Sum();
                if (sum > 6 && dt.Columns.Count <= 12)
                    document = new Document(PageSize.A4.Rotate(), 15f, 15f, 15f, 45f);
                else if (sum > 6 && dt.Columns.Count > 12)
                    document = new Document(PageSize.A3.Rotate(), 15f, 15f, 15f, 45f);
                else
                    document = new Document(PageSize.A4, 25f, 25f, 25f, 45f);

                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
                writer.PageEvent = new TextEvent();

                document.Open();

                iTextSharp.text.Font font_row = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 10);
                iTextSharp.text.Font font_column = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                iTextSharp.text.Font font_title = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22);
                iTextSharp.text.Font font_headers = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

                if (title != null)
                {
                    /*var pdfTitle = new TextEvent().getHeader(title);
                    if (centered_title) pdfTitle.HorizontalAlignment = 1;
                    document.Add(pdfTitle);*/
                    document.Add(new Paragraph(title, font_title) { Alignment = (centered_title) ? Element.ALIGN_CENTER : Element.ALIGN_LEFT });
                    document.Add(Chunk.NEWLINE);
                }
                if (headers != null)
                {
                    foreach (var t in headers)
                    {
                        document.Add(new Paragraph(t, font_headers));
                        document.Add(Chunk.NEWLINE);
                    }
                }

                PdfPTable table = new PdfPTable(dt.Columns.Count);
                table.HeaderRows = 1;

                table.SetWidths(widths);

                table.WidthPercentage = 100;
                table.DefaultCell.Border = 0;

                PdfPCell cell = new PdfPCell(new Phrase("items"));

                cell.Colspan = dt.Columns.Count;

                foreach (DataColumn c in dt.Columns)
                {
                    PdfPCell _cell = new PdfPCell(new Phrase((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(c.ColumnName).Replace('_', ' '))/*c.ColumnName.ToUpper().Replace('_', ' ')*/, font_column));

                    _cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    _cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    _cell.BorderWidthRight = 0;
                    _cell.BorderWidthTop = 0;
                    _cell.BorderWidthLeft = 0;
                    table.AddCell(_cell);
                }


                foreach (DataRow r in dt.Rows)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int cic = 0; cic < dt.Columns.Count; cic++)
                        {
                            PdfPCell pdfCell = new PdfPCell(new Phrase(r[cic].ToString(), font_row));

                            if (centered_columns)
                                pdfCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            else
                            {
                                try
                                {
                                    Convert.ToDouble(dt.Rows[0][cic]);
                                    pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                                }
                                catch
                                {
                                    pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                                }
                            }

                            pdfCell.Border = 0;
                            table.AddCell(pdfCell);
                        }
                    }
                }

                //agrego tabla al pdf y cierro doc
                document.Add(table);

                document.Add(Chunk.NEWLINE);

                //evento pie de pagina
                //writer.PageEvent = new HeaderFooter();

                document.Close();

                //----response----
                HttpResponseMessage response = new HttpResponseMessage();
                byte[] buffer = System.IO.File.ReadAllBytes(path);

                var contentLength = buffer.Length;

                response.StatusCode = HttpStatusCode.OK;
                response.Content = new StreamContent(new MemoryStream(buffer));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                response.Content.Headers.ContentLength = contentLength;
                ContentDispositionHeaderValue contentDisposition = null;

                if (ContentDispositionHeaderValue.TryParse("inline; filename=" + GetFilename(path), out contentDisposition))
                {
                    response.Content.Headers.ContentDisposition = contentDisposition;
                }
                return response;
            }
            catch (Exception ex)
            {
                ex.Handle(typeof(ConversionService));
                throw;
            }
        }
        public static DataGridView DataTable_to_DataGridView(DataTable dt)
        {
            throw new NotImplementedException();
        }

        public static DataTable XLSX_to_DataTable(string path, bool remove_titles)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);

                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(fs);

                DataSet result;

                if (remove_titles)
                {
                    result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                }
                else
                    result = excelReader.AsDataSet();

                DataTable dt = result.Tables[0];

                fs.Close();

                return dt;
            }
            catch (Exception ex)
            {
                ex.Handle(typeof(ConversionService));
                throw;
            }
        }
        public static DataTable CSV_to_DataTable(string path, char separator, int titleCount = 0, bool hasColumnHeaders = true)
        {
            try
            {
                DataTable dt = new DataTable();

                using (StreamReader sr = new StreamReader(path))
                {
                    string line = null;
                    int count = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitted = line.Split(separator);

                        if (count >= titleCount)
                        {
                            if (count == titleCount)
                            {
                                if (hasColumnHeaders)
                                    foreach (var cell in splitted)
                                        dt.Columns.Add(cell);
                                else
                                {
                                    for (int i = 0; i < splitted.Length; i++)
                                        dt.Columns.Add($"Column{i + 1}");

                                    dt.Rows.Add(splitted);
                                }
                            }
                            else
                                dt.Rows.Add(splitted);
                        }

                        count++;
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                ex.Handle(typeof(ConversionService));
                throw;
            }
        }
        public static DataTable DataGridView_ToDataTable(DataGridView dgv, bool IgnoreHideColumns = false)
        {
            try
            {
                if (dgv.ColumnCount == 0) return null;
                DataTable dt = new DataTable();

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (IgnoreHideColumns & !col.Visible) continue;
                    if (col.HeaderText == string.Empty) continue;
                    dt.Columns.Add(col.HeaderText, col.ValueType);
                    dt.Columns[col.HeaderText].Caption = col.Name;
                }

                if (dt.Columns.Count == 0) return null;

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    DataRow drNewRow = dt.NewRow();

                    foreach (DataColumn col in dt.Columns)
                        drNewRow[col.ColumnName] = row.Cells[col.Caption].Value;

                    dt.Rows.Add(drNewRow);
                }

                return dt;
            }
            catch { return null; }
        }
        #endregion

        #region Image
        public static HttpResponseMessage Image_to_PDF(System.Drawing.Image img, string path, string title = null, bool centered_title = true, string[] headers = null)
        {
            try
            {
                float doc_height = img.Height + 100;
                if (title != null) doc_height = doc_height + 50;
                if (headers != null) doc_height = doc_height + 30 * headers.Length;
                Document document = new Document(new iTextSharp.text.Rectangle(img.Width * 1.1f, doc_height), img.Width / 20, img.Width / 20, img.Height / 20, img.Height / 20);

                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
                writer.PageEvent = new TextEvent();

                document.Open();

                iTextSharp.text.Font font_row = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 10);
                iTextSharp.text.Font font_title = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22);
                iTextSharp.text.Font font_headers = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

                if (title != null)
                {
                    /*var pdfTitle = new TextEvent().getHeader(title);
                    if (centered_title) pdfTitle.HorizontalAlignment = 1;
                    document.Add(pdfTitle);*/
                    document.Add(new Paragraph(title, font_title) { Alignment = (centered_title) ? Element.ALIGN_CENTER : Element.ALIGN_LEFT });
                    document.Add(Chunk.NEWLINE);
                }
                if (headers != null)
                {
                    foreach (var t in headers)
                    {
                        document.Add(new Paragraph(t, font_headers));
                        document.Add(Chunk.NEWLINE);
                    }
                }

                var doc_img = iTextSharp.text.Image.GetInstance(img, BaseColor.WHITE);
                document.Add(doc_img);

                //evento pie de pagina
                //writer.PageEvent = new HeaderFooter();

                document.Close();

                //----response----
                HttpResponseMessage response = new HttpResponseMessage();
                byte[] buffer = System.IO.File.ReadAllBytes(path);

                var contentLength = buffer.Length;

                response.StatusCode = HttpStatusCode.OK;
                response.Content = new StreamContent(new MemoryStream(buffer));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                response.Content.Headers.ContentLength = contentLength;
                ContentDispositionHeaderValue contentDisposition = null;

                if (ContentDispositionHeaderValue.TryParse("inline; filename=" + GetFilename(path), out contentDisposition))
                {
                    response.Content.Headers.ContentDisposition = contentDisposition;
                }
                return response;
            }
            catch (Exception ex)
            {
                ex.Handle(typeof(ConversionService));
                throw;
            }
        }
        #endregion

        #region Color
        private static Dictionary<ColorBasico, string> coloresBasicos = new Dictionary<ColorBasico, string>()
        {
            { ColorBasico.Rojo, "#D02D21" },
            { ColorBasico.Naranja, "#D97418" },
            { ColorBasico.Amarillo, "#D9B018" },
            { ColorBasico.Verde, "#3DBF39" },
            { ColorBasico.Celeste, "#26C5C8" },
            { ColorBasico.Azul, "#2652C8" },
            { ColorBasico.Violeta, "#CE53E6" },
            { ColorBasico.Rosa, "#E653AD" },
            { ColorBasico.Marron, "#964D2C" },
            { ColorBasico.Negro, "#1A1A1A" },
            { ColorBasico.Gris_Oscuro, "#414141" },
            { ColorBasico.Gris_Medio, "#737373" },
            { ColorBasico.Gris_Claro, "#B4B4B4" },
            { ColorBasico.Blanco, "#DFDFDF" }
        };

        public static string ToHexColor(this Color color)
        {
            return ColorTranslator.ToHtml(color);
        }
        public static string ToHexColor(this ColorBasico color_basico)
        {
            return coloresBasicos[color_basico];
        }

        public static Color ColorFromHexColor(string hex_color)
        {
            return ColorTranslator.FromHtml(hex_color);
        }
        public static ColorBasico? ColorBasicoFromHexColor(string hex_color)
        {
            var coloresEncontrados = coloresBasicos.Where(x => x.Value == hex_color);
            if (coloresEncontrados.Count() > 0) return coloresEncontrados.First().Key;
            else return null;
        }

        public static Color ToColor(this ColorBasico color_basico)
        {
            return ColorFromHexColor(color_basico.ToHexColor());
        }
        public static ColorBasico? ToColorBasico(this Color color)
        {
            return ColorBasicoFromHexColor(color.ToHexColor());
        }
        #endregion

        #region Tiempo
        public static List<(int Year, int Month)> GetDatesGroupedByYearMonth(IEnumerable<DateTime> dates)
        {
            var result = from d in dates
                         group d by new
                         {
                             d.Year,
                             d.Month
                         }
                into g
                         select new
                         {
                             Año = g.Key.Year,
                             Mes = g.Key.Month
                         };

            return result.Select(x => (x.Año, x.Mes)).ToList();
        }
        public static List<(int Year, int Month)> GetDatesGroupedByYearMonth(DateTime date_from, DateTime date_to)
        {
            List<(int año, int mes)> año_mes = new List<(int año, int mes)>();

            DateTime temp_date = date_from;

            while (temp_date.Year * 100 + temp_date.Month <= date_to.Year * 100 + date_to.Month)
            {
                año_mes.Add((temp_date.Year, temp_date.Month));
                temp_date = temp_date.AddMonths(1);
            }

            return año_mes;
        }
        #endregion

        #region Herramientas Locales
        public class TextEvent : PdfPageEventHelper
        {
            // This is the contentbyte object of the writer
            PdfContentByte cb, cbl;
            // we will put the final number of pages in a template
            PdfTemplate /*headerTemplate,*/ footerTemplate, footerTemplateL;
            // this is the BaseFont we are going to use for the header / footer
            BaseFont bf = null;
            // This keeps track of the creation time
            DateTime PrintTime = DateTime.Now;

            #region Fields
            private string _header;
            #endregion
            #region Properties
            public string Header
            {
                get { return _header; }
                set { _header = value; }
            }
            #endregion

            public override void OnOpenDocument(PdfWriter writer, Document document)
            {
                try
                {
                    PrintTime = DateTime.Now;
                    bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    cb = writer.DirectContent;
                    cbl = writer.DirectContent;
                    //headerTemplate = cb.CreateTemplate(100, 100);
                    footerTemplate = cb.CreateTemplate(50, 50);
                    footerTemplateL = cbl.CreateTemplate(50, 50);


                }
                catch (DocumentException)
                {
                }
                catch (System.IO.IOException)
                {
                }
            }
            public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
            {
                //base.OnEndPage(writer, document);
                //iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
                //iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
                //Phrase p1Header = new Phrase("Sample Header Here", baseFontNormal);

                ////Create PdfTable object
                //PdfPTable pdfTab = new PdfPTable(3);

                ////We will have to create separate cells to include image logo and 2 separate strings
                ////Row 1
                //PdfPCell pdfCell1 = new PdfPCell();
                //PdfPCell pdfCell2 = new PdfPCell(p1Header);
                //PdfPCell pdfCell3 = new PdfPCell();
                string fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm") /*+ DateTime.Now.Hour.ToString("HH:mm")*/;
                String numPagina = /*fecha + $" - */$"{"Página".Translate()} {writer.PageNumber} {"de".Translate()} "/* + " de "*/  /*+ OnCloseDocument2(writer,document)*/;
                String copyright = "© Budgee";
                //Add paging to header
                //{
                //    cb.BeginText();
                //    cb.SetFontAndSize(bf, 12);
                //    cb.SetTextMatrix(document.PageSize.GetRight(200), document.PageSize.GetTop(45));
                //    cb.ShowText(text);
                //    cb.EndText();
                //    float len = bf.GetWidthPoint(text, 12);
                //    //Adds "12" in Page 1 of 12
                //    cb.AddTemplate(headerTemplate, document.PageSize.GetRight(200) + len, document.PageSize.GetTop(45));
                //}
                //Add paging to footer
                {
                    cb.BeginText();
                    cb.SetFontAndSize(bf, 9);
                    cb.SetTextMatrix(document.PageSize.GetRight(100), document.PageSize.GetBottom(29));
                    cb.ShowText(numPagina);
                    cb.EndText();

                    float len = bf.GetWidthPoint(numPagina, 9);
                    cb.AddTemplate(footerTemplate, document.PageSize.GetRight(100) + len, document.PageSize.GetBottom(30));

                    cbl.BeginText();
                    cbl.SetFontAndSize(bf, 10);
                    cbl.SetTextMatrix(document.PageSize.GetLeft(50), document.PageSize.GetBottom(29));
                    cbl.ShowText(copyright);
                    cbl.EndText();

                    float lenl = bf.GetWidthPoint(copyright, 10);
                    cbl.AddTemplate(footerTemplateL, document.PageSize.GetLeft(180) + lenl, document.PageSize.GetBottom(29));
                }

                //Row 2
                // PdfPCell pdfCell4 = new PdfPCell(new Phrase("Sub Header Description", baseFontNormal));

                //pdfCell1.Border = 0;
                //pdfCell2.Border = 0;
                //pdfCell3.Border = 0;
                //pdfCell4.Border = 0;
                //pdfCell5.Border = 0;
                //pdfCell6.Border = 0;
                //pdfCell7.Border = 0;

                ////add all three cells into PdfTable
                //pdfTab.AddCell(pdfCell1);
                //pdfTab.AddCell(pdfCell2);
                //pdfTab.AddCell(pdfCell3);
                //pdfTab.AddCell(pdfCell4);
                //pdfTab.AddCell(pdfCell5);
                //pdfTab.AddCell(pdfCell6);
                //pdfTab.AddCell(pdfCell7);

                //pdfTab.TotalWidth = document.PageSize.Width - 80f;
                //pdfTab.WidthPercentage = 70;
                //pdfTab.HorizontalAlignment = Element.ALIGN_CENTER;    

                //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
                //first param is start row. -1 indicates there is no end row and all the rows to be included to write
                //Third and fourth param is x and y position to start writing
                //pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent);
                //set pdfContent value

                //Move the pointer and draw line to separate header section from rest of page
                //cb.MoveTo(40, document.PageSize.Height - 100);
                //cb.LineTo(document.PageSize.Width - 40, document.PageSize.Height - 100);
                //cb.Stroke();

                //Move the pointer and draw line to separate footer section from rest of page
                //cb.MoveTo(40, document.PageSize.GetBottom(50));
                //cb.LineTo(document.PageSize.Width - 40, document.PageSize.GetBottom(50));
                //cb.Stroke();
            }
            public override void OnCloseDocument(PdfWriter writer, Document document)
            {
                base.OnCloseDocument(writer, document);

                //headerTemplate.BeginText();
                //headerTemplate.SetFontAndSize(bf, 12);
                //headerTemplate.SetTextMatrix(0, 0);
                //headerTemplate.ShowText((writer.PageNumber - 1).ToString());
                //headerTemplate.EndText();

                footerTemplate.BeginText();
                footerTemplate.SetFontAndSize(bf, 9);
                footerTemplate.SetTextMatrix(0, -1);
                footerTemplate.ShowText((writer.PageNumber).ToString());
                footerTemplate.EndText();

            }
            public PdfPTable getHeader(string titulo)
            {
                iTextSharp.text.Font font1 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 15);
                iTextSharp.text.Font font2 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 20);

                PdfPTable tableTitulo = new PdfPTable(2);

                float[] widthsTitulo = new float[] { 10f, 3f };
                tableTitulo.SetWidths(widthsTitulo);
                tableTitulo.WidthPercentage = 100;
                tableTitulo.DefaultCell.Border = 0;

                PdfPCell tilde = new PdfPCell(new Phrase("✓"));
                tilde.HorizontalAlignment = Element.ALIGN_RIGHT;
                tilde.FixedHeight = 40f;
                tilde.Border = 0;

                tableTitulo.AddCell(new Paragraph(titulo, font2));
                tableTitulo.AddCell(tilde);
                return tableTitulo;
            }
        }
        static double[] get_maxs(DataTable dt)
        {
            int rows_quantity = dt.Rows.Count < 50 ? dt.Rows.Count : 50;

            int[,] char_quantity = new int[rows_quantity, dt.Columns.Count];

            for (int cic1 = 0; cic1 < dt.Columns.Count; cic1++)
                for (int cic2 = 0; cic2 < rows_quantity; cic2++)
                    char_quantity[cic2, cic1] = Convert.ToInt32(dt.Rows[cic2][cic1].ToString().Length);

            double[] max_char_quantity = new double[dt.Columns.Count];

            for (int cic1 = 0; cic1 < dt.Columns.Count; cic1++)
            {
                int temp_mayor = 0;
                for (int cic2 = 0; cic2 < rows_quantity; cic2++)
                {
                    if (char_quantity[cic2, cic1] > temp_mayor)
                        temp_mayor = char_quantity[cic2, cic1];
                }
                max_char_quantity[cic1] = temp_mayor;
            }

            return max_char_quantity;
        }
        static double[] get_column_sizes(DataTable dt)
        {
            double[] column_sizes = new double[dt.Columns.Count];

            for (int cic = 0; cic < dt.Columns.Count; cic++)
                column_sizes[cic] = dt.Columns[cic].ColumnName.Length;

            return column_sizes;
        }
        static float[] get_row_avg_sizes(double[] rowMaxs, double[] column_sizes)
        {
            float MaxPts = 1f; //0.9f, 0.7f, 0.7f, 1.5f, 0.8f, 0.8f, 1.2f, 1.2f = 7.8f
            float avgPts = MaxPts / rowMaxs.Length;

            float[] column_newSizes = new float[rowMaxs.Length];

            rowMaxs = resize_RowMaxs(rowMaxs);

            for (int cic = 0; cic < rowMaxs.Length; cic++)
            {
                if (rowMaxs[cic] > column_sizes[cic])
                    column_newSizes[cic] = ((float)rowMaxs[cic]) * avgPts;
                else
                    column_newSizes[cic] = ((float)column_sizes[cic]) * avgPts;
            }

            return column_newSizes;
        }
        static double[] resize_RowMaxs(double[] OLDrowMaxs)
        {
            double[] rowMaxs = OLDrowMaxs.ToArray();

            for (int cic = 0; cic < rowMaxs.Length; cic++)
            {
                if (rowMaxs[cic] > (rowMaxs.Sum() / rowMaxs.Length) * 1.4)
                {
                    rowMaxs[cic] = (rowMaxs.Sum() / rowMaxs.Length) * 1.4;
                }
            }
            return rowMaxs;
        }
        static string GetDirectory(string path)
        {
            return Path.GetDirectoryName(path);
        }
        static string GetFilename(string path)
        {
            return Path.GetFileName(path);
        }
        #endregion
    }
}
