using System;
using NUnit.Framework;
using AddressProcessing.Abstract;
using AddressProcessing.Common;
using AddressProcessing.CSV;

namespace AddressProcessing.Tests.CSV
{
    [TestFixture]
    public class MockProcessorTest
    {
        private CSVProcessor _csvProcessor = new CSVProcessor(new MockCSVHandler(), new MockCSVReader(), new MockCSVWriter());
      
        [Test]
        public void OpenForRead()
        {
            _csvProcessor.Open(string.Empty, Enums.Mode.Read);
            Assert.AreEqual("Read", TestPad.FileOpenMode);
        }

        [Test]
        public void OpenForWrite()
        {
            _csvProcessor.Open(string.Empty, Enums.Mode.Write);
            Assert.AreEqual("Write", TestPad.FileOpenMode);
        }

        [Test]
        public void OpenInvalidMode()
        {
            _csvProcessor.Open(string.Empty, Enums.Mode.Invalid);
            Assert.AreEqual("Invalid", TestPad.FileOpenMode);
        }

        [Test]
        public void Read()
        {
            string col1, col2;
            _csvProcessor.Read(out col1, out col2);
            Assert.AreEqual("Hello", col1);
            Assert.AreEqual("World", col2);
        }

        [Test]
        public void Write()
        {
            string[] columns = { "Hello", "World" };
            _csvProcessor.Write(columns);
            Assert.AreEqual(columns, TestPad.ContentToWrite);
        }
    }
}
