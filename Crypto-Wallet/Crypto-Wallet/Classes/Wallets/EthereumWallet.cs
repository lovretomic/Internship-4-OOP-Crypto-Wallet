using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet.Classes.Wallets
{
    public class EthereumWallet : Wallet
    {
        public List<Guid> NonFungibleAssets;
        public EthereumWallet(bool isCreatedByUser) 
        {
            Adress = Guid.NewGuid();
            WalletType = Enums.WalletType.ETH;
            IsCreatedByUser = isCreatedByUser;
        }
    }
}
