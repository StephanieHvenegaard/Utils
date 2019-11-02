using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHUtils.Collections
{
    //-------------------------------------
    // NOTE TO SELF! : YOU ADD; DONT REMOVE
    //-------------------------------------

    public static class FileDialogFilter
    { 
        public static string AllImageTypes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(JPG);
                sb.Append(Spliter);
                sb.Append(GIF);
                sb.Append(Spliter);
                sb.Append(PNG);
                sb.Append(Spliter);
                sb.Append(BMP);
                sb.Append(Spliter);
                sb.Append(TGA);
                sb.Append(Spliter);
                sb.Append(AllFiles);
                return sb.ToString();
            }
        }
        public static string AllWordTypes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(DOCAll);
                sb.Append(Spliter);
                sb.Append(DOCX);
                sb.Append(Spliter);
                sb.Append(DOC);
                sb.Append(Spliter);
                sb.Append(AllFiles);
                return sb.ToString();
            }
        }
        public static string AllExcelTypes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(XLSAll);
                sb.Append(Spliter);
                sb.Append(XLSX);
                sb.Append(Spliter);
                sb.Append(XLS);
                sb.Append(Spliter);
                sb.Append(AllFiles);
                return sb.ToString();
            }
        }
        public static string AllPwrPointTypes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(PPTAll);
                sb.Append(Spliter);
                sb.Append(PPTX);
                sb.Append(Spliter);
                sb.Append(PPT);
                sb.Append(Spliter);
                sb.Append(AllFiles);
                return sb.ToString();
            }
        }
        public static string AllCompresedTypes
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(ZIP);
                sb.Append(Spliter);
                sb.Append(RAR);
                sb.Append(Spliter);
                sb.Append(AllFiles);
                return sb.ToString();
            }
        }
        private static string Spliter { get { return "|"; } }
        public static string TXT { get { return "txt files (*.txt)|*.txt"; } }
        public static string AllFiles { get { return "All files (*.*)|*.*"; } }
        public static string GIF { get { return "GIF files (*.gif)|*.gif"; } }
        public static string PNG { get { return "PNG files (*.png)|*.png"; } }
        public static string BMP { get { return "Bitmap files (*.BMP)|*.BMP"; } }
        public static string JPG { get { return "JPEG files (*.jpg)|*.jpg"; } }
        public static string TGA { get { return "Raw Targa files (*.tga)|*.tga"; } }
        public static string SLN { get { return "Visual Studios File (*.sln)|*.sln"; } }
        public static string ZIP { get { return "Zip Compressed file (*.zip)|*.zip"; } }
        public static string RAR { get { return "Rar Compressed file (*.rar)|*.rar"; } }
        public static string XML { get { return "XML file (*.xml)|*.xml"; } }
        public static string DOC { get { return "Word Document 97-2003 (*.doc)|*.doc"; } }
        public static string DOCX { get { return "Word Document (*.docx)|*.docx"; } }
        public static string DOCAll { get { return "All Word Document Formats (*.doc*)|*.doc*"; } }
        public static string XLS { get { return "Excel 97-2003 (*.xls)|*.xls"; } }
        public static string XLSX { get { return "Excel (*.xlsx)|*.xlsx"; } }
        public static string XLSAll { get { return "All Excel Formats (*.xls*)|*.xls*"; } }
        public static string PPT { get { return "PowerPoint 97-2003 (*.ppt*)|*.ppt"; } }
        public static string PPTX { get { return "PowerPoint  (*.pplx)|*.pplx"; } }
        public static string PPTAll { get { return "All PowerPoint Formats (*.ppt*)|*.ppt*"; } }
    }
}
