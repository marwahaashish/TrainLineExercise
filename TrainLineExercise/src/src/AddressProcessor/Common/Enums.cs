using System;

namespace AddressProcessing.Common
{
    public class Enums
    {
        [Flags]
        public enum Mode { Read = 1, Write = 2, Invalid = 3 };

    }
}
