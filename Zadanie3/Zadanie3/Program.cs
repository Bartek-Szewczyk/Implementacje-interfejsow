using System;



namespace Zadanie3
{
    class Program
    {
        static void Main(string[] args)
        {
            var xerox = MultidimensionalDevice.CreateInstance();
            xerox.PowerOn();

            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Print(in doc1);

            IDocument doc2;
            xerox.Scan(out doc2);
            xerox.FaxSend(doc2);
            Console.WriteLine(xerox.Counter);
            Console.WriteLine(xerox.PrintCounter);
            Console.WriteLine(xerox.ScanCounter);



        }
    }
}
