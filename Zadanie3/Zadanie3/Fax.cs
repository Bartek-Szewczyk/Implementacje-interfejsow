using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    class Fax :IFax
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
        public void Fax(in IDocument document)
        {
            throw new NotImplementedException();
        }
    }
}
