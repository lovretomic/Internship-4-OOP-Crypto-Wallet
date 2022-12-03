using Crypto_Wallet.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet.Classes
{
    public abstract class Wallet
    {
        public Guid Adress;
        public Dictionary<string, int> fungibleAssetsBalances;
        public List<string> Transactions;
        public WalletType WalletType;

        public void printData()
        {
            Console.WriteLine("");
            Console.WriteLine($"   TIP : {WalletType}");
            Console.WriteLine($"ADRESA : {Adress}");
        }
    }
}
