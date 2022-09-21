// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Globalization;

Console.WriteLine("Hello, World!");



Bank dudiBank = new Bank("Dudi Bank");

Console.WriteLine($"Benvenuto a {dudiBank.Name}");

Console.WriteLine("Azioni sugli utenti [1], Azioni sui prestiti[2]");
string input1 = Console.ReadLine().ToLower();

while(input1 != "1" || input1 != "2")
{
    Console.WriteLine("Azioni sugli utenti [1], Azioni sui prestiti[2]");
    input1 = Console.ReadLine().ToLower();
}

if (input1.Contains("1"))
{
    Console.WriteLine("Cercare utente[1], Modificare utente[2], Aggiungere nuovo uetnte[3]");
    string input2 = Console.ReadLine().ToLower();
    while (input2 != "1" || input2 != "2"|| input2 != "3"){
        Console.WriteLine("Cercare utente[1], Modificare utente[2], Aggiungere nuovo uetnte[3]");
        input2 = Console.ReadLine().ToLower();
    }
    userAction(input2);


}
else if (input1.Contains("2"))
{
    Console.WriteLine("Cercare prestito[1], Creare nuovo prestito[2]");
    string input2 = Console.ReadLine().ToLower();
}

void userAction(string userInput)
{
    if (userInput.Contains("1"))
    {
        Console.WriteLine("Inserisci il codice fiscale dell'utente");
        string userFiscalCode = Console.ReadLine().ToLower();
        string response = dudiBank.FindUser(userFiscalCode);
        Console.WriteLine(response);
    }
    else if (userInput.Contains("2"))
    {
        string[] data = { "Name", "Surname", "Fiscalcode", "Salary" };
        List<string> list = new List<string>();
        Console.WriteLine("Inserisci il codice fiscale dell'utente");
        string userFiscalCode = Console.ReadLine().ToLower();
        foreach(string item in data)
        {
            Console.WriteLine($"Vuoi modificare {item} ? [y/n]");
            string r = Console.ReadLine().ToLower();
            while(r != "y" || r != "n")
            {
                Console.WriteLine($"Vuoi modificare {item} ? [y/n]");
                r = Console.ReadLine().ToLower();
            }
            if (r.Contains("y"))
            {
                Console.WriteLine($"Inserisci il nuovo {item}");
                string newData = Console.ReadLine().ToLower();
                list.Add(newData);
            }
            else
            {
                list.Add("same");
            }
        }
        dudiBank.SetModifyUser(list, userFiscalCode);

    }
}
