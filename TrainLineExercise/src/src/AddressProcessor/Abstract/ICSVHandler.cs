using System;
using System.IO;
using Enums = AddressProcessing.Common.Enums;

namespace AddressProcessing.Abstract
{
    public interface ICSVHandler
    {
        TextReader Reader { get; }
        TextWriter Writer { get; }
        void Open(string fileName, Enums.Mode mode);
        void Close();
    }
}
