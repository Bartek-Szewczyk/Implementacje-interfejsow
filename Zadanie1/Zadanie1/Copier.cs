using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1
{
    public class Copier : BaseDevice, IPrinter, IScanner
    {

        public static Copier CreateInstance()
        {
            return new Copier();
        }

        public int PrintCounter { get; set; }
        public int ScanCounter { get; set; }


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

                Console.WriteLine(DateTime.Now + " Scan: " + formatType + ScanCounter);
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
                Console.WriteLine(DateTime.Now + " Scan: " + +ScanCounter);
                ScanCounter++;
            }

        }
    }
}
