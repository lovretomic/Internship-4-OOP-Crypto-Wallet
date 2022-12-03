using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet.Classes.Assets
{
    public class NonFungibleAsset : Asset
    {
        public string ValueAdress;
        public NonFungibleAsset(string name, double value)
        {
            Adress = Guid.NewGuid();
            Name = name;
            ValueUSD = value;
            ValueAdress = "0"; // GENERIRANJE?
        }
    }
}
