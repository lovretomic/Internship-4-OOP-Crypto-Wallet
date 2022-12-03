using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet.Classes.Wallets
{
    public class SolanaWallet : Wallet
    {
        public List<Guid> NonFungibleAssets;
        public SolanaWallet(bool isCreatedByUser) 
        {
            Adress = Guid.NewGuid();
            WalletType = Enums.WalletType.SOL;
            IsCreatedByUser = isCreatedByUser;
        }
    }
}
