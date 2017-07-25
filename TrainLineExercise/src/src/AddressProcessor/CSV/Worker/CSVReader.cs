using System;
using System.IO;
using AddressProcessing.Abstract;

namespace AddressProcessing.CSV
{
    // This class will only be responsible for reading from file.
    public class CSVReader : ICSVReader
    {
        const int FIRST_COLUMN = 0;
        const int SECOND_COLUMN = 1;

        private TextReader _readerStream;

        public CSVReader(TextReader readerStream)
        {
            _readerStream = readerStream;            
        }

        public bool Read(out string column1, out string column2)
        {
            
            string line;
            string[] columns;

            char[] separator = { '\t' };

            line = ReadLine();
            if (line == null)
            {
                column1 = null;
                column2 = null;

                return false;
            }
            columns = line.Split(separator);

            if (columns.Length == 0)
            {
                column1 = null;
                column2 = null;

                return false;
            }
            else
            {
                column1 = columns[FIRST_COLUMN];
                column2 = columns[SECOND_COLUMN];

                return true;
            }
        }

        public bool Read(string column1, string column2)
        {
            return Read(column1, column2);
        }

        private string ReadLine()
        {
            return _readerStream.ReadLine();
        }
    }
}
