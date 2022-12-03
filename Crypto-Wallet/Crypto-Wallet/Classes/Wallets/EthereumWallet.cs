using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet.Classes.Wallets
{
    public class EthereumWallet : Wallet
    {
        public EthereumWallet() 
        {
            Adress = Guid.NewGuid();
        }
    }
}
