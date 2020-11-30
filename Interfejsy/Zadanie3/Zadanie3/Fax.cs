using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    class Fax : IFax
    {
        public static Fax CreateInstance()
        {
            return new Fax();
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
       
        public void FaxSend(in IDocument doc1)
        {
            Console.WriteLine(DateTime.Now + " Send Fax: " + doc1.GetFileName());
        }
    }
}
