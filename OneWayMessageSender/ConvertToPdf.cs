using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using SelectPdf;

namespace OneWayMessageSender
{
    class ConvertToPdf
    {
        public ConvertToPdf(string str)
        {
            string filename = @"C:/Users/arnom/Desktop/TestHTML/test";
            Program p = new Program();
            string findBase64 = @"[^a-zA-Z0-9\+\/=]";
            Regex rgx64 = new Regex(findBase64);
            HtmlToPdf converter = new HtmlToPdf();
            PdfDocument doc;

                var html = toHTML(str);
                File.WriteAllText(filename + ".html", html.ToString());
                //HtmlToPdf.RenderHtmlAsPdf(html).SaveAs(filename + (i + 1) + ".pdf");
                doc = converter.ConvertHtmlString(html, filename + ".pdf");
                doc.Save(filename + ".pdf");
                doc.Close();
                //HtmlToPdf.ConvertUrl(filename + (i + 1) + ".html", pdfname + (i + 1) + ".pdf");

        }
        public string toHTML(string content)
        {
            #region Dictionary
            Dictionary<string, int> esposDictionary = new Dictionary<string, int>();
            esposDictionary.Add("10-04", 2);
            esposDictionary.Add("10-05", 2);
            esposDictionary.Add("10-14", 2);
            esposDictionary.Add("1B-0C", 1);
            esposDictionary.Add("1B-20", 2);
            esposDictionary.Add("1B-21", 2);
            esposDictionary.Add("1B-24", 3);
            esposDictionary.Add("1B-25", 2);
            esposDictionary.Add("1B-2D", 2);
            esposDictionary.Add("1B-32", 1);
            esposDictionary.Add("1B-33", 2);
            esposDictionary.Add("1B-3D", 2);
            esposDictionary.Add("1B-3F", 2);
            esposDictionary.Add("1B-40", 1);
            esposDictionary.Add("1B-45", 2);
            esposDictionary.Add("1B-47", 2);
            esposDictionary.Add("1B-4A", 2);
            esposDictionary.Add("1B-4C", 2);
            esposDictionary.Add("1B-4D", 2);
            esposDictionary.Add("1B-53", 1);
            esposDictionary.Add("1B-54", 2);
            esposDictionary.Add("1B-56", 2);
            esposDictionary.Add("1B-57", 9);
            esposDictionary.Add("1B-5C", 3);
            esposDictionary.Add("1B-61", 2);
            esposDictionary.Add("1B-63-33", 3);
            esposDictionary.Add("1B-63-34", 3);
            esposDictionary.Add("1B-63-35", 3);
            esposDictionary.Add("1B-64", 2);
            esposDictionary.Add("1B-70", 4);
            esposDictionary.Add("1B-74", 2);
            esposDictionary.Add("1B-76", 1);
            esposDictionary.Add("1B-7B", 2);
            esposDictionary.Add("1C-67-32", 9);
            esposDictionary.Add("1C-70", 3);
            esposDictionary.Add("1D-21", 2);
            esposDictionary.Add("1D-24", 3);
            esposDictionary.Add("1D-28-41", 6);
            esposDictionary.Add("1D-28-4B", 6);
            esposDictionary.Add("1D-28-4C", 6);
            esposDictionary.Add("1D-38-4B", 8);
            esposDictionary.Add("1D-28-4E", 6);
            esposDictionary.Add("1D-2F", 2);
            esposDictionary.Add("1D-3A", 1);
            esposDictionary.Add("1D-42", 2);
            esposDictionary.Add("1D-43-30", 4);
            esposDictionary.Add("1D-43-31", 8);
            esposDictionary.Add("1D-43-32", 4);
            esposDictionary.Add("1D-43-3B", 12);
            esposDictionary.Add("1D-45", 2);
            esposDictionary.Add("1D-48", 2);
            esposDictionary.Add("1D-49", 2);
            esposDictionary.Add("1D-4C", 3);
            esposDictionary.Add("1D-50", 3);
            esposDictionary.Add("1D-54", 2);
            esposDictionary.Add("1D-57", 3);
            esposDictionary.Add("1D-5C", 3);
            esposDictionary.Add("1D-5E", 4);
            esposDictionary.Add("1D-62", 2);
            esposDictionary.Add("1D-63", 1);
            esposDictionary.Add("1D-66", 2);
            esposDictionary.Add("1D-68", 2);
            esposDictionary.Add("1D-72", 2);
            esposDictionary.Add("1C-21", 2);
            esposDictionary.Add("1C-2D", 2);
            esposDictionary.Add("1C-2E", 1);
            esposDictionary.Add("1C-43", 2);
            esposDictionary.Add("1C-53", 3);
            esposDictionary.Add("1C-57", 2);
            esposDictionary.Add("1D-0C", 1);
            esposDictionary.Add("1D-28-46", 8);
            esposDictionary.Add("1D-28-4D", 6);
            esposDictionary.Add("1D-3C", 1);
            esposDictionary.Add("1D-56", 3);
            esposDictionary.Add("1B-1D-74", 3);
            esposDictionary.Add("1B-1D-23", 2);
            esposDictionary.Add("1B-72", 10);
            esposDictionary.Add("1B-1E-46", 3);
            esposDictionary.Add("1B-1E-43", 3);
            esposDictionary.Add("1B-1E-4C", 3);
            esposDictionary.Add("1B-1D-03", 5);
            esposDictionary.Add("1B-16-30", 3);
            esposDictionary.Add("1B-16-31", 3);
            esposDictionary.Add("1B-16-33", 3);
            esposDictionary.Add("1B-16-34", 3);
            esposDictionary.Add("1B-1D-1A-11", 6);
            esposDictionary.Add("1B-1D-1A-12", 6);
            esposDictionary.Add("1B-1D-1A-13", 6);
            esposDictionary.Add("1B-1D-2F-57", 3);
            esposDictionary.Add("1B-1D-2F-43", 3);
            esposDictionary.Add("1B-1D-2F-31", 4);
            esposDictionary.Add("1B-1D-2F-32", 4);
            esposDictionary.Add("1B-1D-2F-35", 4);
            esposDictionary.Add("1B-1D-2F-36", 4);
            esposDictionary.Add("1B-1D-07", 5);
            esposDictionary.Add("1B-1D-19-11", 6);
            esposDictionary.Add("1B-1D-19-12", 6);
            esposDictionary.Add("1B-1D-78-50", 3);
            esposDictionary.Add("1B-1D-78-49", 3);
            esposDictionary.Add("1B-1D-67-30", 5);
            esposDictionary.Add("1B-1D-67-31", 5);
            esposDictionary.Add("1B-1D-79-53-30", 5);
            esposDictionary.Add("1B-1D-79-53-31", 5);
            esposDictionary.Add("1B-1D-79-53-32", 5);
            esposDictionary.Add("1B-1D-79-50", 3);
            esposDictionary.Add("1B-1D-79-49", 3);
            esposDictionary.Add("1B-1D-68-30", 6);
            esposDictionary.Add("1B-1D-68-31", 6);
            esposDictionary.Add("1B-1D-63", 4);
            esposDictionary.Add("1B-1D-29-42", 5);
            esposDictionary.Add("1B-1D-29-49", 8);
            esposDictionary.Add("1B-1D-29-4C", 8);
            esposDictionary.Add("1B-1D-73-4F", 12);
            esposDictionary.Add("1B-1D-73-50", 3);
            esposDictionary.Add("1B-1D-73-54", 5);

            #endregion

            string findQRregex = @"(http){1}(.+)(39\|)([A-Z]{3})", findBase64 = @"[^a-zA-Z0-9\+\/=]";
            Regex rgxQR = new Regex(findQRregex), rgxNOT64 = new Regex(findBase64);
            StringBuilder html = new StringBuilder();
            byte[] bytes;
            int lineCount = 0;//line count to stop PDF from cutting off abruptly
            if (!rgxNOT64.IsMatch(content))
            {
                bytes = Convert.FromBase64String(content);
            }
            else
            {
                bytes = Encoding.ASCII.GetBytes(content);
            }

            html.Append("<!DOCTYPE html SYSTEM \"html\"><html><head><META http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\"><meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">");
            html.Append("<style type=\"text/css\" media=\"screen\">body {	background-color: #ffffff;}.receipt_body {	font-family: \"Lucida Console\", Monaco, monospace;	font-size: 12pt;	white-space: pre-wrap;}.shadow {	background-color: white; border: 1px solid black;	width: 412px; 	margin: 20px;	padding: 20px; box-shadow: 3px 3px 20px rgba(50, 50, 50, 0.5);}div</style>");
            html.Append("</head><body><div><div class=\"shadow\"><div class=\"receipt_body\">");

            var line = string.Empty;

            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] > 31)
                {
                    line += Convert.ToChar(bytes[i]);
                }
                else
                {
                    if (bytes[i] == 10)//Handle LineFeed
                    {
                        if (!rgxQR.IsMatch(line))
                        {
                            lineCount++;
                            html.Append(string.Format("<span class=\"lines\">{0}</span><br>", line));
                            //if (lineCount == 20)
                            //{
                            //    html.Append(string.Format("<div style=\"page-break-after:always;\"></div>"));
                            //    lineCount = 0;
                            //}
                        }
                        line = string.Empty;
                    }
                    else if (i < bytes.Length - 1)
                    {
                        var hex2 = string.Format("{0:X}-{1:X}", Convert.ToInt32(bytes[i]), Convert.ToInt32(bytes[i + 1]));
                        i += ControlCharacterParamsIncrement(hex2, esposDictionary);
                        if (i + 1 < bytes.Length - 1)
                        {
                            var hex3 = string.Format("{0:X}-{1:X}-{2:X}", Convert.ToInt32(bytes[i]), Convert.ToInt32(bytes[i + 1]), Convert.ToInt32(bytes[i + 2]));
                            i += ControlCharacterParamsIncrement(hex3, esposDictionary);
                            if (i + 2 < bytes.Length - 1)
                            {
                                var hex4 = String.Format("{0:X}-{1:X}-{2:X}-{3:X}", Convert.ToInt32(bytes[i]), Convert.ToInt32(bytes[i + 1]), Convert.ToInt32(bytes[i + 2]), Convert.ToInt32(bytes[i + 3]));
                                i += ControlCharacterParamsIncrement(hex4, esposDictionary);
                                if (i + 3 < bytes.Length - 1)
                                {
                                    var hex5 = String.Format("{0:X}-{1:X}-{2:X}-{3:X}-{4:X}", Convert.ToInt32(bytes[i]), Convert.ToInt32(bytes[i + 1]), Convert.ToInt32(bytes[i + 2]), Convert.ToInt32(bytes[i + 3]), Convert.ToInt32(bytes[i + 4]));
                                    i += ControlCharacterParamsIncrement(hex5, esposDictionary);
                                }
                            }
                        }
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(line))
            {
                if (!rgxQR.IsMatch(line))
                {
                    html.Append(string.Format("<span class=\"lines\">{0}</span><br>", line));
                }
            }

            html.Append("</div></div></div></br></body></html>");
            return html.ToString();
        }
            public int ControlCharacterParamsIncrement(string hex, Dictionary<string, int> dictionary)
            {
                int inc;
                if (dictionary.TryGetValue(hex, out inc))
                {
                    return inc;
                }
                return 0;
            }
    }
}
