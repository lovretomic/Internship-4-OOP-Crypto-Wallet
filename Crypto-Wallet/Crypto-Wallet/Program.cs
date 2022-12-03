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
            break;
        case 2:
            break;
        case 3:
            break;
        default:
            Console.WriteLine("## Pogresan unos! Unos mora biti neka od navedenih opcija.");
            returnToMainMenu(true);
            break;
    }
}

MainMenu();