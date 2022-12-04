using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto_Wallet.Classes.Wallets
{
    public class BitcoinWallet : Wallet
    {
        public BitcoinWallet(bool isCreatedByUser, List<Asset>? defaultFungibleAssets)
        {
            Adress = Guid.NewGuid();
            WalletType = Enums.WalletType.BTC;
            IsCreatedByUser = isCreatedByUser;

            if(defaultFungibleAssets is not null)
                for(int i = 0; i < defaultFungibleAssets.Count(); i++)
                    FungibleAssets.Add(defaultFungibleAssets[i].Adress, 1);
        }
    }
}
