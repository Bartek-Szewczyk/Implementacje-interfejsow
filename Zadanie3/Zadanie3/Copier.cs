using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    public class Copier : BaseDevice
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
                var printer = Printer.CreateInstance();
                printer.PowerOn();
                printer.Print(doc1);
                printer.PowerOff();
                printer.Counter = PrintCounter;
                PrintCounter++;
            }

        }
        public void Scan(out IDocument doc1, IDocument.FormatType formatType)
        {
            doc1 = null;
            if (state == IDevice.State.@on)
            {
                var scann = Scanner.CreateInstance();
                scann.PowerOn();
                scann.Scan(out doc1, formatType);
                scann.PowerOff();
                scann.Counter = ScanCounter;
                ScanCounter++;
            }
        }
        public void Scan(out IDocument doc1)
        {
            doc1 = null;
            if (state == IDevice.State.@on)
            {
                var scann = Scanner.CreateInstance();
                scann.PowerOn();
                scann.Scan(out doc1);
                scann.PowerOff();
                scann.Counter = ScanCounter;
                ScanCounter++;
            }


        }
        public void ScanAndPrint()
        {
            Scan(out IDocument doc1);
            Print(in doc1);

        }


    }
}
