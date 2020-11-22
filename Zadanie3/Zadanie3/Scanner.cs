using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    class Scanner : IScanner
    {
        public static Scanner CreateInstance()
        {
            return new Scanner();
        }
        protected IDevice.State state = IDevice.State.off;
        public IDevice.State GetState() => state;

        public void PowerOn()
        {
            state = IDevice.State.@on;
        }

        public void PowerOff()
        {
            state = IDevice.State.@off;
        }


        public int Counter { get; set; } = 0;
        public void Scan(out IDocument doc1, IDocument.FormatType formatType)
        {
            doc1 = null;
            switch (formatType)
            {
                case IDocument.FormatType.PDF:
                    doc1 = new PDFDocument("PDFScan" + Counter + ".pdf");
                    break;
                case IDocument.FormatType.JPG:
                    doc1 = new ImageDocument("ImageScan" + Counter + ".jpg");
                    break;
                case IDocument.FormatType.TXT:
                    doc1 = new ImageDocument("TextScan" + Counter + ".txt");
                    break;

            }
            Console.WriteLine(DateTime.Now + " Scan: " + doc1.GetFileName());
           

        }
        public void Scan(out IDocument doc1)
        {
            doc1 = null;
            doc1 = new PDFDocument("PDFScan" + Counter + ".pdf");
            Console.WriteLine(DateTime.Now + " Scan: " + doc1.GetFileName());
           

        }
    }
}
