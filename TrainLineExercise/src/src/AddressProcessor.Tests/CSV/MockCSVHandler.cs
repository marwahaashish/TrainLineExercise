using System;
using System.IO;
using AddressProcessing.Abstract;
using AddressProcessing.Common;

namespace AddressProcessing.Tests.CSV
{
    public class MockCSVHandler : ICSVHandler
    {
        public void Open(string fileName, Enums.Mode mode)
        {
            switch(mode)
            {
                case Enums.Mode.Read:
                    TestPad.FileOpenMode = "Read";
                    break;
                case Enums.Mode.Write:
                    TestPad.FileOpenMode = "Write";
                    break;
                default:
                    TestPad.FileOpenMode = "Invalid";
                    break;
            }
        }

        public void Close()
        {
            
        }

        public TextReader Reader
        {
            get { throw new NotImplementedException(); }
        }


        public TextWriter Writer
        {
            get { throw new NotImplementedException(); }
        }
    }
}
