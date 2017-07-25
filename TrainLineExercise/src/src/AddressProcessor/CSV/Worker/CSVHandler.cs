using System;
using System.IO;
using AddressProcessing.Abstract;
using AddressProcessing.Common;

namespace AddressProcessing.CSV
{
    // This class will only be responsible for open and close of file operation.
    public class CSVHandler : ICSVHandler
    {
        private TextReader _readerStream;
        private TextWriter _writerStream;

        public TextReader Reader
        {
            get
            {
                return _readerStream;
            }
        }

        public TextWriter Writer
        {
            get
            {
                return _writerStream;
            }
        }

        public CSVHandler(TextReader readerStream, TextWriter writerStream)
        {
            _readerStream = readerStream;
            _writerStream = writerStream;
        }

        public void Open(string fileName, Enums.Mode mode)
        {
            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }
            switch (mode)
            {
                case Enums.Mode.Read:
                    _readerStream = File.OpenText(fileName);
                    break;
                case Enums.Mode.Write:
                    FileInfo fileInfo = new FileInfo(fileName);
                    _writerStream = fileInfo.CreateText();
                    break;
                default:
                    throw new Exception("Unknown file mode for {fileName}");
            }
        }

        public void Close()
        {
            if (_writerStream != null)
            {
                _writerStream.Close();

            }

            if (_readerStream != null)
            {
                _readerStream.Close();
            }
        }
    }
}
