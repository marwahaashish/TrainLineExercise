﻿using System;

namespace AddressProcessing.Abstract
{
    public interface ICSVReader
    {
        bool Read(string column1, string column2);
        bool Read(out string column1, out string column2);
    }
}
