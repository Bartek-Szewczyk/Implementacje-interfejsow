using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie1
{
    public class Copier : IDevice
    {
        public void PowerOn()
        {
            throw new NotImplementedException();
        }

        public void PowerOff()
        {
            throw new NotImplementedException();
        }

        public IDevice.State GetState()
        {
            throw new NotImplementedException();
        }

        public int Counter { get; }
        public int PrintCounter { get; set; }
        public int ScanCounter { get; set; }

        public void Print(in IDocument doc1)
        {
            throw new NotImplementedException();
        }

        public void Scan(out IDocument doc1)
        {
            throw new NotImplementedException();
        }

        public void Scan(out IDocument doc1, IDocument.FormatType formatType)
        {
            throw new NotImplementedException();
        }

        public void ScanAndPrint()
        {
            throw new NotImplementedException();
        }
    }
}
