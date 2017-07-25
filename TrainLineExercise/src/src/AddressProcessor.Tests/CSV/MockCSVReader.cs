using System;
using System.IO;
using AddressProcessing.Abstract;
using AddressProcessing.Common;

namespace AddressProcessing.Tests.CSV
{
    public class MockCSVReader : ICSVReader
    {
        public bool Read(out string column1, out string column2)
        {
            column1 = "Hello";
            column2 = "World";
            return true;
        }

        public bool Read(string column1, string column2)
        {
            return Read(column1, column2);
        }
    }
}
