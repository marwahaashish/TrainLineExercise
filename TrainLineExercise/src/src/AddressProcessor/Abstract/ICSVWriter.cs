using System;

namespace AddressProcessing.Abstract
{
    public interface ICSVWriter
    {
        void Write(params string[] columns);
    }
}
