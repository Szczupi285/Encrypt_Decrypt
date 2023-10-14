using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt_Decrypt.VVM.ViewModel
{
    internal class Decrypt
    {

        private string DecryptionAlghoritm { get; set; }

        private string DecryptionKey { get; set; }

        public Decrypt(string algorithm, string key)
        {
            DecryptionAlghoritm = algorithm;
            DecryptionKey = key;
        }
    }
}
