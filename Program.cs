// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Globalization;
using System.Xml.Linq;

Console.WriteLine("Hello, World!");

Bank dudiBank = new Bank("Dudi Bank");

Console.WriteLine($"Benvenuto a {dudiBank.Name}");
startApplication();

void startApplication()
{

    Console.WriteLine("Azioni sugli utenti [1], Azioni sui prestiti[2], Esci dall'applicazione[3]");
    string input1 = Console.ReadLine().ToLower();

    while(input1 != "1" && input1 != "2" && input1 != "3")
    {
        Console.WriteLine("Azioni sugli utenti [1], Azioni sui prestiti[2]");
        input1 = Console.ReadLine().ToLower();
    }

    if (input1.Contains("1"))
    {
        Console.WriteLine("Cercare utente[1], Modificare utente[2], Aggiungere nuovo uetnte[3]");
        string input2 = Console.ReadLine().ToLower();
        while (input2 != "1" && input2 != "2" && input2 != "3"){
            Console.WriteLine("Cercare utente[1], Modificare utente[2], Aggiungere nuovo uetnte[3]");
            input2 = Console.ReadLine().ToLower();
        }
        //qui richiamo la funzione di gestione users
        userAction(input2);


    }
    else if (input1.Contains("2"))
    {
        Console.WriteLine("Cercare prestito[1], Creare nuovo prestito[2]");
        string input2 = Console.ReadLine().ToLower();
        while (input2 != "1" && input2 != "2")
        {
            Console.WriteLine("Cercare utente[1], Modificare utente[2], Aggiungere nuovo uetnte[3]");
            input2 = Console.ReadLine().ToLower();
        }

        loanAction(input2);
    }
    else
    {
        Console.WriteLine("Grazie per aver utilizzato dudiBank service!");
    }
}



//FUNZIONE DI GESTIONE UTENTE
void userAction(string userInput)
{
    if (userInput.Contains("1"))
    {
        Console.WriteLine("Inserisci il codice fiscale dell'utente");
        string userFiscalCode = Console.ReadLine();
        string response = dudiBank.FindUser(userFiscalCode);
        Console.WriteLine(response);
        restartOption();
    }
    else if (userInput.Contains("2"))
    {
        string[] data = { "Name", "Surname", "Fiscalcode", "Salary" };
        List<string> list = new List<string>();
        Console.WriteLine("Inserisci il codice fiscale dell'utente");
        string userFiscalCode = Console.ReadLine();
        foreach(string item in data)
        {
            Console.WriteLine($"Vuoi modificare {item} ? [y/n]");
            string r = Console.ReadLine().ToLower();
            while(r != "y" && r != "n")
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
        string output = dudiBank.SetModifyUser(list, userFiscalCode);
        Console.WriteLine(output);
        restartOption();


    }
    else if (userInput.Contains("3"))
    {
        Console.WriteLine("Inserisci il Nome Utente:");
        string name = Console.ReadLine();
        Console.WriteLine("Inserisci il Cognome Utente:");
        string surname = Console.ReadLine();
        Console.WriteLine("Inserisci il Codice fiscale:");
        string fiscalcode = Console.ReadLine();
        Console.WriteLine("Inserisci il Salario Mensile:");
        int salary = Convert.ToInt32(Console.ReadLine());
        string response = dudiBank.SetNewUser(name, surname, fiscalcode, salary);
        Console.WriteLine(response);
        restartOption();
    }
}

// Funzione gestione prestiti

void loanAction(string userInput)
{
    //ricerca di un prestito
    if (userInput.Contains("1"))
    {
        Console.WriteLine("Inserisci il codice fiscale dell'intestatario del/dei prestito");
        string userFiscalCode = Console.ReadLine();
        Console.WriteLine("Vuoi vedere tutti i prestiti attivi di questo cliente?[y / n]");
        string moreInfo = Console.ReadLine();
        while (moreInfo != "y" && moreInfo != "n")
        {
            Console.WriteLine("Vuoi vedere tutti i prestiti attivi di questo cliente?[y / n]");
            moreInfo = Console.ReadLine();
        }

        if (moreInfo.Contains("y"))
        {
            List<Loan> loans = dudiBank.GetAmmountUserLoan(userFiscalCode);
            foreach (Loan loan in loans)
            {
                Console.WriteLine(Loan.GetLoanData(loan));
                Console.WriteLine("Totale rate rimaneti");
                Console.WriteLine(dudiBank.GetPaymentNum(loan.LoanID));
            }
            restartOption();
        }
        else if(moreInfo.Contains("n"))
        {
            Console.WriteLine("Ecco i primi dati relativi ai prestiti di questo utente");
            string response = dudiBank.FindLoan(userFiscalCode);
            Console.WriteLine(response);
            restartOption();
        }

    }
}

//recall action 
void restartOption()
{
    Console.WriteLine("Vuoi eseguire altre operazioni?[y / n]");
    string response = Console.ReadLine().ToLower();
    while (response != "y" && response != "n")
    {
        Console.WriteLine("Vuoi eseguire altre operazioni?[y / n]");
        response = Console.ReadLine().ToLower();
    }
    if (response.Contains("y"))
    {
        startApplication();
    }
    else
    {
        Console.WriteLine("Grazie per aver utilizzato dudiBank service!");
    }
}
