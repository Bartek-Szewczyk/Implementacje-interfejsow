using System;



namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            var xerox = MultifunctionalDevice.CreateInstance();
            xerox.PowerOn();

            IDocument doc1 = new PDFDocument("aaa.pdf");
            xerox.Print(in doc1);
            xerox.Fax(doc1);
            IDocument doc2;
            xerox.Scan(out doc2);
            xerox.ScanAndPrint();
            xerox.Fax(doc2);
            Console.WriteLine(xerox.Counter);
            Console.WriteLine(xerox.PrintCounter);
            Console.WriteLine(xerox.ScanCounter);
            Console.WriteLine(xerox.FaxCounter);
            



        }
    }
}
