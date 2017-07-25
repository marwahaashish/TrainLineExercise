using System;
using System.IO;
using AddressProcessing.Abstract;
using AddressProcessing.Common;

namespace AddressProcessing.Tests.CSV
{
    public class MockCSVWriter : ICSVWriter
    {
        public void Write(params string[] columns)
        {
            TestPad.ContentToWrite = columns;
        }
    }
}
