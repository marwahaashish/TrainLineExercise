using System;
using System.IO;
using AddressProcessing.Abstract;

namespace AddressProcessing.CSV
{
    // This class will only be responsible for writing to file.
    public class CSVWriter : ICSVWriter
    {
        private TextWriter _writerStream;

        public CSVWriter(TextWriter writerStream)
        {
            _writerStream = writerStream;
        }

        public void Write(params string[] columns)
        {
            string outPut = string.Join("\t", columns);
            WriteLine(outPut);           
        }

        private void WriteLine(string line)
        {
            _writerStream.WriteLine(line);
        }
    }
}
