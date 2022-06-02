using System;
using System.Collections.Generic;

namespace IsbnLib.Interfaces
{
    public interface IIsbnProcessor
    {
        bool TryValidate(string isbn);
        bool TryValidate(Int64 isbn);
        string CreateBookUrl(string baseUrl, string isbn);
        string TryConvert(string isbn);
        string TryConvert(Int64 isbn);
    }
}
