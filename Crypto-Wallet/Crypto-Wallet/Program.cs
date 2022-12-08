using Crypto_Wallet.Classes;
using Crypto_Wallet.Classes.Assets;
using Crypto_Wallet.Classes.Transactions;
using Crypto_Wallet.Classes.Wallets;
using Crypto_Wallet.Enums;
using System.ComponentModel;

var assets = new List<Asset>()
{
    new FungibleAsset("Cardano", 83.1, "ADA"),
    new FungibleAsset("Polygon", 102.6, "MATIC"),
    new FungibleAsset("Bitcoin", 103.4, "BTC"),
    new FungibleAsset("Dogecoin", 35.5, "DOGE"),
    new FungibleAsset("Ethereum", 68.6, "ETH"),
    new FungibleAsset("Solana", 42.8, "SOL"),
    new FungibleAsset("Avalanche", 107.4, "AVAX"),
    new FungibleAsset("XRP", 61.8, "XRP"),
    new FungibleAsset("Tether", 49.3, "USDT"),
    new FungibleAsset("BNB", 84.5, "BNB"),

    new NonFungibleAsset("Red Monkey", 43.5),
    new NonFungibleAsset("Blue Monkey", 26.2),
    new NonFungibleAsset("Orange Monkey", 12.5),
    new NonFungibleAsset("Green Monkey", 80.4),
    new NonFungibleAsset("Yellow Monkey", 75.8),
    new NonFungibleAsset("Pixel Mona Lisa", 44.4),
    new NonFungibleAsset("Angry Pizza Slice", 69.6),
    new NonFungibleAsset("Funny Koala", 62.0),
    new NonFungibleAsset("Swag Beethoven", 96.8),
    new NonFungibleAsset("Nyan Cat", 78.4),
    new NonFungibleAsset("3d Sneakers", 58.7),
    new NonFungibleAsset("Pac-man", 106.3),
    new NonFungibleAsset("Color Blob", 16.3),
    new NonFungibleAsset("Formal Penguin", 97.8),
    new NonFungibleAsset("Abstract Art", 22.9),
    new NonFungibleAsset("Fanart 1", 32.9),
    new NonFungibleAsset("Fanart 2", 10.4),
    new NonFungibleAsset("Fanart 3", 71.9),
    new NonFungibleAsset("Pink Fluffy Unicorn", 34.9),
    new NonFungibleAsset("George Washington", 2.1)

};

var wallets = new List<Wallet>()
{
    new BitcoinWallet(false, new List<Asset>(){assets[0]}),
    new BitcoinWallet(false, new List<Asset>(){assets[5]}),
    new BitcoinWallet(true, new List<Asset>(){assets[3]}),

    new EthereumWallet(false, new List<Asset>(){assets[4]}, new List<Asset>(){assets[10]}),
    new EthereumWallet(false, new List<Asset>(){assets[5]}, new List<Asset>(){assets[15]}),
    new EthereumWallet(true, new List<Asset>(){assets[1]}, new List<Asset>(){assets[13]}),

    new SolanaWallet(false, new List<Asset>(){assets[0]}, new List<Asset>(){assets[17]}),
    new SolanaWallet(false, new List<Asset>(){assets[3]}, new List<Asset>(){assets[16]}),
    new SolanaWallet(true, new List<Asset>(){assets[2]}, new List<Asset>(){assets[11], assets[12]})
};

var transactions = new List<Transaction>();

void setSupportedAssets()
{
    foreach (var wallet in wallets)
    {
        if (wallet.WalletType is WalletType.BTC) wallet.SupportedAssets = assets.GetRange(0, 10);
        else wallet.SupportedAssets = assets;
    }
}

setSupportedAssets();

int getInt()
{
    while(true)
    {
        var input = Console.ReadLine();
        if (int.TryParse(input, out var action))
            return action;
        Console.WriteLine("## Pogresan unos! Unesi novu vrijednost.");
    }
}

void returnToMainMenu(bool askForReturn)
{
    if (askForReturn)
    {
        Console.WriteLine("Unesi bilo koji znak za povratak na glavni izbornik");
        var input = Console.ReadLine();
        MainMenu();
    }
    else MainMenu();
}
void MainMenu()
{
    Console.Clear();
    Console.WriteLine("--- Glavni izbornik ---");
    Console.WriteLine("1 - Kreiraj wallet");
    Console.WriteLine("2 - Pristupi walletu");
    Console.WriteLine("0 - Izlaz iz aplikacije");
    switch (getInt())
    {
        case 1:
            createWallet();
            break;
        case 2:
            accessWallet();
            break;
        case 0:
            return;
        default:
            Console.WriteLine("## Pogresan unos! Unos mora biti neka od navedenih opcija.");
            returnToMainMenu(true);
            break;
    }
}

MainMenu();

void createWallet()
{
    Console.Clear();
    Console.WriteLine("--- Kreiranje walleta ---");
    Console.WriteLine("1 - Bitcoin wallet");
    Console.WriteLine("2 - Ethereum wallet");
    Console.WriteLine("3 - Solana wallet");
    Console.WriteLine("0 - Povratak na glavni izbornik");
    switch (getInt())
    {
        case 1:
            wallets.Add(new BitcoinWallet(true, null));
            setSupportedAssets();
            Console.WriteLine("Uspjesno kreiran Bitcoin wallet!");
            returnToMainMenu(true);
            break;
        case 2:
            wallets.Add(new EthereumWallet(true, null, null));
            setSupportedAssets();
            Console.WriteLine("Uspjesno kreiran Ethereum wallet!");
            returnToMainMenu(true);
            break;
        case 3:
            wallets.Add(new SolanaWallet(true, null, null));
            setSupportedAssets();
            Console.WriteLine("Uspjesno kreiran Solana wallet!");
            returnToMainMenu(true);
            break;
        case 0:
            returnToMainMenu(false);
            break;
        default:
            Console.WriteLine("## Pogresan unos! Unos mora biti neka od navedenih opcija. Unesi bilo koji znak za ponovni unos.");
            Console.ReadLine();
            createWallet();
            break;
    }
}

void accessWallet()
{
    Console.Clear();
    Console.WriteLine("--- Pristup walletu ---");

    int walletCount = 0;
    foreach (var wallet in wallets)
    {
        if (wallet.IsCreatedByUser == true)
        {
            wallet.printData();
            walletCount++;
        }
    }

    if (walletCount == 0)
    {
        Console.WriteLine("Ne postoji niti jedan upisani wallet.");
        returnToMainMenu(true);
    }

    bool walletFound;
    do
    {
        Console.WriteLine("Unesi adresu walleta kojem zelis pristupiti.");
        var adressInput = Console.ReadLine();

        walletFound = false;
        foreach (var wallet in wallets)
        {
            if (string.Compare(wallet.Adress.ToString(), adressInput) is 0)
            {
                walletFound = true;
                Console.Clear();
                Console.WriteLine("Wallet pronaden!\n");

                Console.WriteLine("- Funkcije -");
                Console.WriteLine("1 - Portfolio");
                Console.WriteLine("2 - Transfer");
                Console.WriteLine("3 - Povijest transakcija");
                Console.WriteLine("4 - Opozovi transakciju");
                Console.WriteLine("0 - Povratak na prikaz walleta");
                switch (getInt())
                {
                    case 1:
                        printWalletPortfolio(wallet);
                        break;
                    case 2:
                        transfer(wallet);
                        break;
                    case 3:
                        printTransactions(wallet);
                        break;
                    case 4:
                        revokeTransaction(wallet);
                        break;
                    case 0:
                        accessWallet();
                        break;
                    default:
                        Console.WriteLine("## Pogresan unos! Unos mora biti neka od navedenih opcija.");
                        returnToMainMenu(true);
                        break;
                }
                break;
            }
        }
        if (!walletFound)
        {
            Console.WriteLine("## Wallet nije pronaden. Zelis li ponovno unijeti adresu?");
            Console.WriteLine("1 - Da");
            Console.WriteLine("2 - Ne");
            switch (getInt())
            {
                case 1:
                    break;
                case 2:
                    returnToMainMenu(true);
                    break;
                default:
                    Console.WriteLine("## Pogresan unos! Unos mora biti neka od navedenih opcija.");
                    returnToMainMenu(true);
                    break;
            }
        }
    } while (!walletFound);
}

void printWalletPortfolio(Wallet wallet)
{
    Console.Clear();
    Console.WriteLine("--- Portfolio ---");
    Console.WriteLine($"UKUPNA VRIJEDNOST ASSETA : {wallet.TotalAssetValue} USD");
    Console.WriteLine($"FUNGIBLE ASSETI :");
    foreach(var fungibleAsset in wallet.FungibleAssets)
    {
        string assetName = "";
        string assetLabel = "";
        double assetSingleValueUSD = 0;

        foreach(var asset in assets)
            if(asset.Adress == fungibleAsset.Key)
            {
                assetName = asset.Name;
                assetLabel = asset.Label;
                assetSingleValueUSD = asset.ValueUSD;
            }

        Console.WriteLine($"╔ Adresa: {fungibleAsset.Key}");
        Console.WriteLine($"╠ Ime: {assetName}");
        Console.WriteLine($"╠ Oznaka: {assetLabel}");
        Console.WriteLine($"╠ Vrijednost asseta: {assetSingleValueUSD} USD");
        Console.WriteLine($"╠ Ukupna vrijednost: {assetSingleValueUSD * fungibleAsset.Value} USD");
        if (wallet.TimesAccessed != 0)
            Console.WriteLine($"╚ Promijenjena vrijednost asseta: {(wallet.TotalAssetValue - wallet.LastAccessedTotalAssetValue) / wallet.LastAccessedTotalAssetValue * 100}%");
        Console.WriteLine("");
        wallet.TimesAccessed++;
        wallet.LastAccessedTotalAssetValue = wallet.TotalAssetValue;
    }
    Console.WriteLine($"NON-FUNGIBLE ASSETI :");
    foreach (var nonFungibleAssetGuid in wallet.NonFungibleAssets)
    {
        string assetName = "";
        string assetLabel = "";
        double assetSingleValueUSD = 0;

        foreach (var asset in assets)
            if (asset.Adress == nonFungibleAssetGuid)
            {
                assetName = asset.Name;
                assetLabel = asset.Label;
                assetSingleValueUSD = asset.ValueUSD;
            }

        Console.WriteLine($"╔ Adresa: {nonFungibleAssetGuid}");
        Console.WriteLine($"╠ Ime: {assetName}");
        Console.WriteLine($"╠ Ukupna vrijednost: {assetSingleValueUSD} USD");
        if (wallet.TimesAccessed != 0)
            Console.WriteLine($"╚ Promijenjena vrijednost asseta: {(wallet.TotalAssetValue - wallet.LastAccessedTotalAssetValue) / wallet.LastAccessedTotalAssetValue * 100}%");
        Console.WriteLine("");
        wallet.TimesAccessed++;
        wallet.LastAccessedTotalAssetValue = wallet.TotalAssetValue;
    }
    returnToMainMenu(true);
}
void transfer(Wallet wallet)
{
    if(!(wallet.FungibleAssets.Any() || wallet.NonFungibleAssets.Any()))
    {
        Console.WriteLine("Ovaj wallet ne sadrzi niti jedan asset.");
        returnToMainMenu(true);
    }
    Wallet receiverWallet = null;
    Asset asset = null;
    int inputQuantity = 0;
    AssetType assetType = AssetType.FUNGIBLE;
    Guid assetAdress = Guid.NewGuid();

    Console.Clear();
    Console.WriteLine("--- Transfer ---");

    foreach(var singleWallet in wallets)
    {
        if(singleWallet.Adress != wallet.Adress)
        {
            Console.WriteLine("");
            Console.WriteLine($"╔ TIP : {singleWallet.WalletType}");
            Console.WriteLine($"╚ ADRESA : {singleWallet.Adress}");
        }
    }

    Console.WriteLine("\nUnesi adresu primatelja: ");
    var receiverAdress = Console.ReadLine();

    bool adressExists = false;

    do
    {
        foreach (var singleWallet in wallets)
            if (String.Equals(singleWallet.Adress.ToString(), receiverAdress))
            {
                adressExists = true;
                receiverWallet = singleWallet;
                break;
            }
        if (!adressExists)
        {
            Console.WriteLine("## Wallet s tom adresom nije pronaden. Unesi novu adresu ili unesi 0 za povratak na glavni izbornik.");
            receiverAdress = Console.ReadLine();
            if(String.Equals(receiverAdress, "0")) returnToMainMenu(false);
        }
    } while (!adressExists);

    Console.Clear();
    Console.WriteLine("--- Transfer ---");
    Console.WriteLine($"ADRESA PRIMATELJA: {receiverAdress}");

    Console.WriteLine("\nFUNGIBLE ASSETI:");
    foreach (var fungibleAsset in wallet.FungibleAssets)
    {
        foreach (var singleAsset in assets)
        {
            if(singleAsset.Adress == fungibleAsset.Key)
            {
                Console.WriteLine($"╔ IME : {singleAsset.Name}");
                Console.WriteLine($"╚ ADRESA : {singleAsset.Adress}");
                Console.WriteLine("");
            }
        }
    }

    if (wallet.WalletType != WalletType.BTC && receiverWallet.WalletType != WalletType.BTC)
    {
        Console.WriteLine("\nNON-FUNGIBLE ASSETI:");
        foreach (var nonFungibleAsset in wallet.NonFungibleAssets)
        {
            foreach (var singleAsset in assets)
            {
                if (singleAsset.Adress == nonFungibleAsset)
                {
                    Console.WriteLine($"╔ IME : {singleAsset.Name}");
                    Console.WriteLine($"╚ ADRESA : {singleAsset.Adress}");
                    Console.WriteLine("");
                }
            }
        }
    }


    Console.WriteLine("Unesi adresu asseta koji zelis poslati: ");
    var assetAdressInput = Console.ReadLine();

    adressExists = false;
    do
    {
        foreach (var singleAsset in assets)
            if (String.Equals(singleAsset.Adress.ToString(), assetAdressInput))
            {
                adressExists = true;
                asset = singleAsset;
                assetType = singleAsset.AssetType;
                assetAdress = singleAsset.Adress;
                break;
            }
        if (!adressExists)
        {
            Console.WriteLine("## Asset s tom adresom nije pronaden. Unesi novu adresu ili unesi 0 za povratak na glavni izbornik.");
            assetAdressInput = Console.ReadLine();
            if (String.Equals(assetAdressInput, "0")) returnToMainMenu(false);
        }
    } while (!adressExists);

    Console.Clear();
    Console.WriteLine("--- Transfer ---");
    Console.WriteLine($"ADRESA PRIMATELJA: {receiverAdress}");
    Console.WriteLine($"ADRESA ASSETA KOJI SE SALJE: {assetAdressInput}");
    
    if (assetType == AssetType.FUNGIBLE)
    {
        Console.WriteLine($"Unesi kolicinu asseta ili 0 za povratak na glavni izbornik: ");
        int totalQuantity = wallet.FungibleAssets[assetAdress];
        do
        {
            inputQuantity = int.Parse(Console.ReadLine());
            if (inputQuantity == 0) returnToMainMenu(false);
            if(inputQuantity > totalQuantity)
                Console.WriteLine("## Upisana kolicina veca je od dostupne kolicine tog asseta. Upisi novu kolicinu ili 0 za povratak na glavni izbornik:");
        } while (inputQuantity > totalQuantity);

        Console.Clear();
        Console.WriteLine("--- Transfer ---");
        Console.WriteLine($"ADRESA PRIMATELJA: {receiverAdress}");
        Console.WriteLine($"ADRESA ASSETA KOJI SE SALJE: {assetAdressInput}");
        Console.WriteLine($"KOLICINA ASSETA KOJI SE SALJE: {inputQuantity}");
    }

    Console.WriteLine("\nJesi li siguran da zelis izvrsiti ovaj transfer?");
    void confirmTransfer()
    {
        Console.WriteLine("1 - Da");
        Console.WriteLine("2 - Ne");
        switch (getInt())
        {
            case 1:
                Transaction transaction;
                if (asset.AssetType == AssetType.FUNGIBLE) transaction = new FungibleAssetTransaction(asset, wallet, receiverWallet, inputQuantity);
                else transaction = new NonFungibleAssetTransaction(asset, wallet, receiverWallet);

                transactions.Add(transaction);

                for (int i = 0; i < wallets.Count(); i++)
                {
                    if (wallet.Adress == wallets[i].Adress)
                    {
                        wallets[i].Transactions.Add(transaction.Id);
                        if(asset.AssetType == AssetType.FUNGIBLE)
                            wallets[i].FungibleAssets[asset.Adress] -= inputQuantity;
                        else wallets[i].NonFungibleAssets.Remove(asset.Adress);
                    }
             
                    if (receiverWallet.Adress == wallets[i].Adress)
                    {
                        wallets[i].Transactions.Add(transaction.Id);
                        if (asset.AssetType == AssetType.FUNGIBLE)
                            if (wallets[i].FungibleAssets.ContainsKey(asset.Adress))
                                wallets[i].FungibleAssets[asset.Adress] += inputQuantity;
                            else
                                wallets[i].FungibleAssets.Add(asset.Adress, inputQuantity);
                        else wallets[i].NonFungibleAssets.Add(asset.Adress);
                    }
                }
                Console.WriteLine("Transakcija je uspjesno provedena!");
                returnToMainMenu(true);
                break;
            case 2:
                returnToMainMenu(true);
                break;
            default:
                Console.WriteLine("## Pogresan unos! Ponovno unesi svoj izbor.");
                confirmTransfer();
                break;
        }
    }
    confirmTransfer();
}

void printTransactions(Wallet wallet)
{
    Console.Clear();
    Console.WriteLine("--- Povijest transakcija ---");
    int transactionCount = 0;
    foreach(var transaction in transactions)
    {
        if(transaction.SenderAdress == wallet.Adress || transaction.ReceiverAdress == wallet.Adress)
        {
            transactionCount++;
            Console.WriteLine($"ID : {transaction.Id}");
            Console.WriteLine($"VRIJEME : {transaction.Date}");
            Console.WriteLine($"ADRESA POSILJATELJA : {transaction.SenderAdress}");
            Console.WriteLine($"ADRESA PRIMATELJA : {transaction.ReceiverAdress}");
            if(transaction.TransactionType == AssetType.FUNGIBLE)
            {
                Console.WriteLine($"KOLICINA ASSETA : {transaction.AssetQuantity}");
            }
            foreach (var asset in assets)
                if (asset.Adress == transaction.AssetAdress)
                    Console.WriteLine($"IME ASSETA : {asset.Name}");
            if (transaction.isRevoked) Console.WriteLine($"TRANSAKCIJA OPOZVANA");
            else Console.WriteLine($"TRANSAKCIJA NIJE OPOZVANA");
            Console.WriteLine("--------------------");
        }
    }
    if (transactionCount == 0) Console.WriteLine("Nije zabiljezena niti jedna transakcija.");
    returnToMainMenu(true);
}

void revokeTransaction(Wallet wallet)
{
    Console.Clear();
    Console.WriteLine("--- Opozivanje transakcije ---");

    foreach(var transaction in transactions)
        foreach (var walletTransactionId in wallet.Transactions)
            if (String.Equals(transaction.Id, walletTransactionId))
            {
                Console.WriteLine("");
                Console.WriteLine($"TIP : {transaction.TransactionType}");
                Console.WriteLine($"DATUM : {transaction.Date}");
                Console.WriteLine($"ID : {transaction.Id}");
            }

    Console.WriteLine("\nUnesi adresu transakcije koju zelis opozvati ili 0 za povratak na glavni izbornik:");
    var isValidInput = false;
    string transactionAdressInput;
    do
    {
        transactionAdressInput = Console.ReadLine();
        if (String.Equals(transactionAdressInput, "0")) returnToMainMenu(false);
        foreach (var transaction in wallet.Transactions)
            if (String.Equals(transactionAdressInput, transaction.ToString()))
            {
                foreach(var singleTransaction in transactions)
                    if(singleTransaction.Id == transaction && singleTransaction.isRevoked == true)
                    {
                        Console.WriteLine("## Ta je transakcija vec opozvana. Unesi bilo koji znak za povratak na izbor walleta.");
                        Console.ReadLine();
                        accessWallet();
                    }
                isValidInput = true;
                break;
            }
        if(!isValidInput)
            Console.WriteLine("## Transakcija s tom adresom nije pronadena. Unesi novu adresu ili 0 za povratak na glavni izbornik.");
    } while (!isValidInput);
    
    foreach(var transaction in transactions)
    {
        if(String.Equals(transactionAdressInput, transaction.Id.ToString()) && (DateTime.Now - transaction.Date).TotalSeconds > 45)
        {
            Console.WriteLine("## Transakciju nije moguce opozvati. Provedena je prije vise od 45 sekundi! Unesi bilo koji znak za povratak na izbor walleta.");
            Console.ReadLine();
            accessWallet();
        }

        if (String.Equals(transaction.Id.ToString(), transactionAdressInput))
        {
            for (int i = 0; i < wallets.Count(); i++)
            {
                if (wallets[i].Adress == transaction.SenderAdress)
                {
                    foreach (var asset in assets)
                    {
                        if (asset.Adress == transaction.AssetAdress)
                        {
                            if (transaction.TransactionType == AssetType.FUNGIBLE)
                            {
                                if (wallets[i].FungibleAssets.ContainsKey(transaction.AssetAdress))
                                    wallets[i].FungibleAssets[transaction.AssetAdress] += transaction.AssetQuantity;
                                else
                                    wallets[i].FungibleAssets.Add(transaction.AssetAdress, transaction.AssetQuantity);
                            }
                            else
                                wallets[i].NonFungibleAssets.Add(transaction.AssetAdress);
                        }
                    }
                }

                if (wallets[i].Adress == transaction.ReceiverAdress)
                {
                    foreach (var asset in assets)
                    {
                        if (asset.Adress == transaction.AssetAdress)
                        {
                            if (transaction.TransactionType == AssetType.FUNGIBLE)
                                wallets[i].FungibleAssets[transaction.AssetAdress] -= transaction.AssetQuantity;
                            else
                                wallets[i].NonFungibleAssets.Remove(transaction.AssetAdress);
                        }
                    }
                }
            }
            transaction.isRevoked = true;
        }
    }

    Console.WriteLine("Transakcija uspjesno opozvana!");
    returnToMainMenu(true);
}