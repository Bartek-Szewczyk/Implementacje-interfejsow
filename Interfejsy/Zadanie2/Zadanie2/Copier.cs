using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie2
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {

        public static Copier CreateInstance()
        {
            return new Copier();
        }

        public int PrintCounter { get; private set; } = 0;
        public int ScanCounter { get; private set; } = 0;


        public void Print(in IDocument doc1)
        {
            if (state == IDevice.State.@on)
            {
                Console.WriteLine(DateTime.Now + " Print: " + doc1.GetFileName());
                PrintCounter++;
            }

        }

        public void Scan(out IDocument doc1, IDocument.FormatType formatType)
        {
            doc1 = null;
            if (state == IDevice.State.@on)
            {
                switch (formatType)
                {
                    case IDocument.FormatType.PDF:
                        doc1 = new PDFDocument("PDFScan" + ScanCounter + ".pdf");
                        break;
                    case IDocument.FormatType.JPG:
                        doc1 = new ImageDocument("ImageScan" + ScanCounter + ".jpg");
                        break;
                    case IDocument.FormatType.TXT:
                        doc1 = new ImageDocument("TextScan" + ScanCounter + ".txt");
                        break;

                }

                Console.WriteLine(DateTime.Now + " Scan: " + doc1.GetFileName());
                ScanCounter++;
            }


        }

        public void ScanAndPrint()
        {
            Scan(out IDocument doc1);
            Print(in doc1);

        }



        public void Scan(out IDocument doc1)
        {
            doc1 = null;
            if (state == IDevice.State.@on)
            {
                doc1 = new PDFDocument("PDFScan" + ScanCounter + ".pdf");
                Console.WriteLine(DateTime.Now + " Scan: " + doc1.GetFileName());
                ScanCounter++;
            }


        }
    }
}
