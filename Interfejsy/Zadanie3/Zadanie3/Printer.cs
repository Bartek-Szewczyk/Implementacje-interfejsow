using System;
using System.Collections.Generic;
using System.Text;

namespace Zadanie3
{
    public class Printer : IPrinter
    {
        public static Printer CreateInstance()
        {
            return new Printer();
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



        public int Counter { get; set; } =0;
        public void Print(in IDocument doc1)
        {
            Console.WriteLine(DateTime.Now + " Print: " + doc1.GetFileName());
            

        }


    }
}
