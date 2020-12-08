using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie4
{
    public class Copier : IPrinter, IScanner
    {
        public static Copier CreateInstance()
        {
            return new Copier();
        }

        public int PrintCounter { get; private set; } = 0;
        public int ScanCounter { get; private set; } = 0;
        public int Counter { get; } = 0;

        private IPrinter _printer;
        private IScanner _scanner;
        private IDevice.State _printerState = IDevice.State.off;

        private IDevice.State _scannerState = IDevice.State.off;

        public Copier()
        {
            _printer = this;
            _scanner = this;
        }

        void IPrinter.SetState(IDevice.State state)
        {
            _printerState = state;

        }
        void IScanner.SetState(IDevice.State state)
        {
            _scannerState = state;
        }
        public IDevice.State GetState()
        {
            if (_scannerState == IDevice.State.on && _printerState == IDevice.State.on)
            {
                return IDevice.State.on;
            }
            else if (_scannerState == IDevice.State.standby && _printerState == IDevice.State.standby)
            {
                return IDevice.State.standby;
            }
            else
            {
                return IDevice.State.off;
            }
        }

        void IDevice.SetState(IDevice.State state)
        {
            _printer.SetState(state);
            _scanner.SetState(state);
        }

        public void TurnOn()
        {
            if (GetState() == IDevice.State.off)
            {
                _printer.StandbyOn();
                _scanner.StandbyOn();

            }
        }
        public void TurnOff()
        {
            if (GetState() != IDevice.State.off)
            {
                ((IDevice)this).PowerOff();
            }
        }
        public void TurnStandbyOn()
        {
            if (GetState() != IDevice.State.standby)
            {
                ((IDevice)this).StandbyOn();
            }
        }
        public void TurnStandbyOff()
        {
            if (GetState() == IDevice.State.standby)
            {
                ((IDevice)this).StandbyOff();
            }
        }

        public void Print(in IDocument doc1)
        {
            if (GetState() == IDevice.State.@on || GetState() == IDevice.State.standby)
            {
                Console.WriteLine(DateTime.Now + " Print: " + doc1.GetFileName());
                PrintCounter++;
                _printerState = IDevice.State.standby;
            }

        }
        public void Scan(out IDocument doc1, IDocument.FormatType formatType)
        {
            doc1 = null;
            if (GetState() == IDevice.State.@on || GetState() == IDevice.State.standby)
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
                _scannerState = IDevice.State.standby;
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
            if (GetState() == IDevice.State.@on)
            {
                doc1 = new PDFDocument("PDFScan" + ScanCounter + ".pdf");
                Console.WriteLine(DateTime.Now + " Scan: " + doc1.GetFileName());
                ScanCounter++;
            }


        }



    }
}
