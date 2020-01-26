using System;
using System.Collections.Generic;
using System.Text;

namespace EncryptDecryptApp
{
    public struct AesResult
    {
        public string IV;
        public string Key;

        public AesResult(string iV, string key)
        {
            IV = iV;
            Key = key;
        }
    }
}
