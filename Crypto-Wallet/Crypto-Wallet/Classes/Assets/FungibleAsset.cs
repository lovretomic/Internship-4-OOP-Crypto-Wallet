using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet.Classes.Assets
{
    public class FungibleAsset : Asset
    {
        public string Label;
        public FungibleAsset(string name, double value, string label)
        {
            Adress = Guid.NewGuid();
            Name = name;
            ValueUSD = value;
            Label = label;
        }
    }
}
