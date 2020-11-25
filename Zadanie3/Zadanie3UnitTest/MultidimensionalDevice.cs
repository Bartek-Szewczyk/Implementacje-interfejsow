using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadanie3;
using System;
using System.IO;
using zadanie1UnitTests;


namespace zadanie2UnitTests
{



    [TestClass]
    public class UnitTestMultifunctonalDevice
    {
        [TestMethod]
        public void MultifunctionDevice_GetState_StateOff()
        {
            var multifunctionDevice = MultidimensionalDevice.CreateInstance();
            multifunctionDevice.PowerOff();

            Assert.AreEqual(IDevice.State.off, multifunctionDevice.GetState());
        }

        [TestMethod]
        public void MultifunctionDevice_GetState_StateOn()
        {
            var multifunctionDevice = MultidimensionalDevice.CreateInstance();
            multifunctionDevice.PowerOn();

            Assert.AreEqual(IDevice.State.on, multifunctionDevice.GetState());
        }


        // weryfikacja, czy po wywołaniu metody `Print` i włączonej kopiarce w napisie pojawia się słowo `Print`
        // wymagane przekierowanie konsoli do strumienia StringWriter
        [TestMethod]
        public void MultifunctionDevice_Print_DeviceOn()
        {
            var multifunctionDevice = MultidimensionalDevice.CreateInstance();
            multifunctionDevice.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                multifunctionDevice.Print(in doc1);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        // weryfikacja, czy po wywołaniu metody `Print` i wyłączonej kopiarce w napisie NIE pojawia się słowo `Print`
        // wymagane przekierowanie konsoli do strumienia StringWriter
        [TestMethod]
        public void MultifunctionDevice_Print_DeviceOff()
        {
            var multifunctionDevice = MultidimensionalDevice.CreateInstance();
            multifunctionDevice.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                multifunctionDevice.Print(in doc1);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        // weryfikacja, czy po wywołaniu metody `Scan` i wyłączonej kopiarce w napisie NIE pojawia się słowo `Scan`
        // wymagane przekierowanie konsoli do strumienia StringWriter
        [TestMethod]
        public void MultifunctionDevice_Scan_DeviceOff()
        {
            var multifunctionDevice = MultidimensionalDevice.CreateInstance();
            multifunctionDevice.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1;
                multifunctionDevice.Scan(out doc1);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Scan"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        // weryfikacja, czy po wywołaniu metody `Scan` i wyłączonej kopiarce w napisie pojawia się słowo `Scan`
        // wymagane przekierowanie konsoli do strumienia StringWriter
        [TestMethod]
        public void MultifunctionDevice_Scan_DeviceOn()
        {
            var multifunctionDevice = MultidimensionalDevice.CreateInstance();
            multifunctionDevice.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1;
                multifunctionDevice.Scan(out doc1);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        // weryfikacja, czy wywołanie metody `Scan` z parametrem określającym format dokumentu
        // zawiera odpowiednie rozszerzenie (`.jpg`, `.txt`, `.pdf`)
        [TestMethod]
        public void MultifunctionDevice_Scan_FormatTypeDocument()
        {
            var multifunctionDevice = MultidimensionalDevice.CreateInstance();
            multifunctionDevice.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1;
                multifunctionDevice.Scan(out doc1, formatType: IDocument.FormatType.JPG);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".jpg"));

                multifunctionDevice.Scan(out doc1, formatType: IDocument.FormatType.TXT);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".txt"));

                multifunctionDevice.Scan(out doc1, formatType: IDocument.FormatType.PDF);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains(".pdf"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }


        // weryfikacja, czy po wywołaniu metody `ScanAndPrint` i wyłączonej kopiarce w napisie pojawiają się słowa `Print`
        // oraz `Scan`
        // wymagane przekierowanie konsoli do strumienia StringWriter
        [TestMethod]
        public void MultifunctionDevice_ScanAndPrint_DeviceOn()
        {
            var multifunctionDevice = MultidimensionalDevice.CreateInstance();
            multifunctionDevice.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                multifunctionDevice.ScanAndPrint();
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        // weryfikacja, czy po wywołaniu metody `ScanAndPrint` i wyłączonej kopiarce w napisie NIE pojawia się słowo `Print`
        // ani słowo `Scan`
        // wymagane przekierowanie konsoli do strumienia StringWriter
        [TestMethod]
        public void mMltifunctionDevice_ScanAndPrint_DeviceOff()
        {
            var multifunctionDevice = MultidimensionalDevice.CreateInstance();
            multifunctionDevice.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                multifunctionDevice.ScanAndPrint();
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Scan"));
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Print"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        [TestMethod]
        public void MultifunctionDevice_PrintCounter()
        {
            var multifunctionDevice = MultidimensionalDevice.CreateInstance();
            multifunctionDevice.PowerOn();

            IDocument doc1 = new PDFDocument("aaa.pdf");
            multifunctionDevice.Print(in doc1);
            IDocument doc2 = new TextDocument("aaa.txt");
            multifunctionDevice.Print(in doc2);
            IDocument doc3 = new ImageDocument("aaa.jpg");
            multifunctionDevice.Print(in doc3);

            multifunctionDevice.PowerOff();
            multifunctionDevice.Print(in doc3);
            multifunctionDevice.Scan(out doc1);
            multifunctionDevice.PowerOn();

            multifunctionDevice.ScanAndPrint();
            multifunctionDevice.ScanAndPrint();

            // 5 wydruków, gdy urządzenie włączone
            Assert.AreEqual(5, multifunctionDevice.PrintCounter);
        }

        [TestMethod]
        public void MultifunctionDevice_ScanCounter()
        {
            var multifunctionDevice = MultidimensionalDevice.CreateInstance();
            multifunctionDevice.PowerOn();

            IDocument doc1;
            multifunctionDevice.Scan(out doc1);
            IDocument doc2;
            multifunctionDevice.Scan(out doc2);

            IDocument doc3 = new ImageDocument("aaa.jpg");
            multifunctionDevice.Print(in doc3);

            multifunctionDevice.PowerOff();
            multifunctionDevice.Print(in doc3);
            multifunctionDevice.Scan(out doc1);
            multifunctionDevice.PowerOn();

            multifunctionDevice.ScanAndPrint();
            multifunctionDevice.ScanAndPrint();

            // 4 skany, gdy urządzenie włączone
            Assert.AreEqual(4, multifunctionDevice.ScanCounter);
        }

        [TestMethod]
        public void MultifunctionDevice_PowerOnCounter()
        {
            var multifunctionDevice = MultidimensionalDevice.CreateInstance();
            multifunctionDevice.PowerOn();
            multifunctionDevice.PowerOn();
            multifunctionDevice.PowerOn();

            IDocument doc1;
            multifunctionDevice.Scan(out doc1);
            IDocument doc2;
            multifunctionDevice.Scan(out doc2);

            multifunctionDevice.PowerOff();
            multifunctionDevice.PowerOff();
            multifunctionDevice.PowerOff();
            multifunctionDevice.PowerOn();

            IDocument doc3 = new ImageDocument("aaa.jpg");
            multifunctionDevice.Print(in doc3);

            multifunctionDevice.PowerOff();
            multifunctionDevice.Print(in doc3);
            multifunctionDevice.Scan(out doc1);
            multifunctionDevice.PowerOn();

            multifunctionDevice.ScanAndPrint();
            multifunctionDevice.ScanAndPrint();

            // 3 włączenia
            Assert.AreEqual(3, multifunctionDevice.Counter);
        }
        [TestMethod]
        public void MultifunctionDevice_FaxCounter()
        {
            var multifunctionDevice = MultidimensionalDevice.CreateInstance();
            multifunctionDevice.PowerOn();

            IDocument doc1;
            multifunctionDevice.Scan(out doc1);
            IDocument doc2;
            multifunctionDevice.Scan(out doc2);
            multifunctionDevice.FaxSend(doc2);
            IDocument doc3 = new ImageDocument("aaa.jpg");
            multifunctionDevice.Print(in doc3);

            multifunctionDevice.PowerOff();
            multifunctionDevice.Print(in doc3);
            multifunctionDevice.Scan(out doc1);
            multifunctionDevice.PowerOn();

            multifunctionDevice.FaxSend(doc3);

            multifunctionDevice.ScanAndPrint();
            multifunctionDevice.ScanAndPrint();

            // 2 faksy, gdy urządzenie włączone
            Assert.AreEqual(2, multifunctionDevice.FaxCounter);
        }

        [TestMethod]
        public void MultifunctionDevice_Fax_DeviceOn()
        {
            var multifunctionDevice = MultidimensionalDevice.CreateInstance();
            multifunctionDevice.PowerOn();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                multifunctionDevice.FaxSend(in doc1);
                Assert.IsTrue(consoleOutput.GetOutput().Contains("Fax"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

        // weryfikacja, czy po wywołaniu metody `Print` i wyłączonej kopiarce w napisie NIE pojawia się słowo `Print`
        // wymagane przekierowanie konsoli do strumienia StringWriter
        [TestMethod]
        public void MultifunctionDevice_Fax_DeviceOff()
        {
            var multifunctionDevice = MultidimensionalDevice.CreateInstance();
            multifunctionDevice.PowerOff();

            var currentConsoleOut = Console.Out;
            currentConsoleOut.Flush();
            using (var consoleOutput = new ConsoleRedirectionToStringWriter())
            {
                IDocument doc1 = new PDFDocument("aaa.pdf");
                multifunctionDevice.FaxSend(in doc1);
                Assert.IsFalse(consoleOutput.GetOutput().Contains("Fax"));
            }
            Assert.AreEqual(currentConsoleOut, Console.Out);
        }

    }

}
