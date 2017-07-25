using System;
using System.IO;
using AddressProcessing.Abstract;
using AddressProcessing.Common;

namespace AddressProcessing.CSV
{
    public class CSVProcessor 
    {
        private ICSVHandler _csvHandler;
        private ICSVReader _csvReader;
        private ICSVWriter _csvWriter;

        public CSVProcessor(ICSVHandler csvHandler, ICSVReader csvReader, ICSVWriter csvWriter)
        {
            _csvHandler = csvHandler;
            _csvReader = csvReader;
            _csvWriter = csvWriter;
        }

        public void Open(string fileName, Enums.Mode mode)
        {
            _csvHandler.Open(fileName, mode);  
        }

        public bool Read(out string column1, out string column2)
        {
            return _csvReader.Read(out column1, out column2);
        }

        public bool Read(string column1, string column2)
        {
            return _csvReader.Read(column1, column2);
        }

        public void Write(params string[] columns)
        {
            _csvWriter.Write(columns);
        }

        public void Close()
        {
            _csvHandler.Close();
        }
    }
}
