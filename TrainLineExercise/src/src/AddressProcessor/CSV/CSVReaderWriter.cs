using System;
using System.IO;
using Enums = AddressProcessing.Common.Enums;

namespace AddressProcessing.CSV
{
    /*
        2) Refactor this class into clean, elegant, rock-solid & well performing code, without over-engineering.
           Assume this code is in production and backwards compatibility must be maintained.
    */
    
    public class CSVReaderWriter : IDisposable 
    {
        private static StreamReader _readerStream = null;
        private static StreamWriter _writerStream = null;
        private CSVProcessor _csvProcessor = new CSVProcessor(new CSVHandler(_readerStream, _writerStream), 
                                                              new CSVReader(_readerStream), 
                                                              new CSVWriter(_writerStream));
        [Flags]
        //TradeOff: Cannot do away with this enum since it is being referred by client code - results in duplication with Common.Enums.Mode
        public enum Mode { Read = 1, Write = 2 };

        public void Open(string fileName, Mode mode)
        {
            try
            {
                _csvProcessor.Open(fileName, mode == Mode.Read ? Enums.Mode.Read : Enums.Mode.Write);
            }
            catch (Exception)
            {

                Dispose();
            }
            
        }

        public void Write(params string[] columns)
        {
            try
            {
                _csvProcessor.Write(columns);
            }
            catch (Exception)
            {

                Dispose();
                
            }
            
        }

        // Not removing this reduntant method as this code is running in production and we have to maintain the backwards compatibility.
        public bool Read(string column1, string column2)
        {
            try
            {
                return _csvProcessor.Read(column1, column2);
            }
            catch (Exception)
            {
                
                Dispose();
                return false;
            }
            
        }

        public bool Read(out string column1, out string column2)
        {
            try
            {
                return _csvProcessor.Read(out column1, out column2);
            }
            catch (Exception)
            {
                
                Dispose();
                column1 = null;
                column2 = null;
                return false;
            }
            
        }

        public void Close()
        {
            try
            {
                _csvProcessor.Close();
            }
            catch (Exception)
            {

                Dispose();
            }
            
        }
        /// <summary>
        /// This will dispose all the IO resources
        /// </summary>
        public void Dispose()
        {
            _readerStream.Dispose();
            _writerStream.Dispose();
        }
    }
}
