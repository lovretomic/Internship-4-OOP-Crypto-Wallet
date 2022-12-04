using Crypto_Wallet.Classes;
using Crypto_Wallet.Classes.Assets;
using Crypto_Wallet.Classes.Wallets;
using Crypto_Wallet.Enums;

// GDJE SI STAO?
// Vjerojatno si uspio napisati kod za računanje ukupne vrijednosti svih asseta, ali da bi ga provjerio
// moraš za sve wallete inicijalizirati nekoliko asseta. Zadnje si pokušao s opcijom da je jedan argument
// pri stvaranju nekog walleta lista asseta koji će se postaviti na početku, ali ne znaš kako assete iz te
// liste razvrstati na Fungible i NonFungible. Mislio si da svaki asset dobije mebmera isFungible, ali to
// baš nema smisla. Možeš to pokušati, ali bila bi bolja neka alternativa.

var assets = new List<Asset>()
{
    new FungibleAsset("FA1", 83.1, "L1"),
    new FungibleAsset("FA2", 102.6, "L2"),
    new FungibleAsset("FA3", 103.4, "L3"),
    new FungibleAsset("FA4", 35.5, "L4"),
    new FungibleAsset("FA5", 68.6, "L5"),
    new FungibleAsset("FA6", 42.8, "L6"),
    new FungibleAsset("FA7", 107.4, "L7"),
    new FungibleAsset("FA8", 61.8, "L8"),
    new FungibleAsset("FA9", 49.3, "L9"),
    new FungibleAsset("FA10", 84.5, "L10"),

    new NonFungibleAsset("NFA1", 43.5),
    new NonFungibleAsset("NFA2", 26.2),
    new NonFungibleAsset("NFA3", 12.5),
    new NonFungibleAsset("NFA4", 80.4),
    new NonFungibleAsset("NFA5", 75.8),
    new NonFungibleAsset("NFA6", 44.4),
    new NonFungibleAsset("NFA7", 69.6),
    new NonFungibleAsset("NFA8", 62.0),
    new NonFungibleAsset("NFA9", 96.8),
    new NonFungibleAsset("NFA10", 78.4),
    new NonFungibleAsset("NFA11", 58.7),
    new NonFungibleAsset("NFA12", 106.3),
    new NonFungibleAsset("NFA13", 16.3),
    new NonFungibleAsset("NFA14", 97.8),
    new NonFungibleAsset("NFA15", 22.9),
    new NonFungibleAsset("NFA16", 32.9),
    new NonFungibleAsset("NFA17", 10.4),
    new NonFungibleAsset("NFA18", 71.9),
    new NonFungibleAsset("NFA19", 34.9),
    new NonFungibleAsset("NFA20", 2.1)

};

var wallets = new List<Wallet>()
{
    new BitcoinWallet(false, new List<Asset>(){assets[0]}),
    new BitcoinWallet(false, new List<Asset>(){assets[5]}),
    new BitcoinWallet(false, new List<Asset>(){assets[3]}),

    new EthereumWallet(false, new List<Asset>(){assets[4]}, new List<Asset>(){assets[10]}),
    new EthereumWallet(false, new List<Asset>(){assets[5]}, new List<Asset>(){assets[15]}),
    new EthereumWallet(false, new List<Asset>(){assets[1]}, new List<Asset>(){assets[13]}),

    new SolanaWallet(false, new List<Asset>(){assets[0]}, new List<Asset>(){assets[17]}),
    new SolanaWallet(false, new List<Asset>(){assets[3]}, new List<Asset>(){assets[16]}),
    new SolanaWallet(false, new List<Asset>(){assets[2]}, new List<Asset>(){assets[11]})
};

foreach(var wallet in wallets)
{
    if (wallet.WalletType is WalletType.BTC) wallet.SupportedAssets = assets.GetRange(0, 10);
    else wallet.SupportedAssets = assets;
}

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
    Console.WriteLine("--- GLAVNI IZBORNIK ---");
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
    Console.WriteLine("--- KREIRANJE WALLETA ---");
    Console.WriteLine("1 - Bitcoin wallet");
    Console.WriteLine("2 - Ethereum wallet");
    Console.WriteLine("3 - Solana wallet");
    Console.WriteLine("0 - Povratak na glavni izbornik");
    switch (getInt())
    {
        case 1:
            wallets.Add(new BitcoinWallet(true, null));
            Console.WriteLine("Uspjesno kreiran Bitcoin wallet!");
            returnToMainMenu(true);
            break;
        case 2:
            wallets.Add(new EthereumWallet(true, null, null));
            Console.WriteLine("Uspjesno kreiran Ethereum wallet!");
            returnToMainMenu(true);
            break;
        case 3:
            wallets.Add(new SolanaWallet(true, null, null));
            Console.WriteLine("Uspjesno kreiran Solana wallet!");
            returnToMainMenu(true);
            break;
        default:
            Console.WriteLine("## Pogresan unos! Unos mora biti neka od navedenih opcija.");
            returnToMainMenu(true);
            break;
    }
}

void accessWallet()
{
    Console.Clear();
    Console.WriteLine("--- PRISTUP WALLETU ---");
    if (wallets.Any())
        foreach (var wallet in wallets)
            wallet.printData();
    else
    {
        Console.WriteLine("Ne postoji niti jedan upisani wallet.");
        returnToMainMenu(true);
    }

    returnToMainMenu(true);
}