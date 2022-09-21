// See https://aka.ms/new-console-template for more information
using System.Globalization;

Console.WriteLine("Hello, World!");



Bank dudiBank = new Bank("Dudi Bank");

public class Bank{
    public string Name { get; set; }

    public List<User> Users { get; set; }

    public List<Loan> Loans { get; set; }

    public Bank(string name)
    {
        Users = new List<User>();
        Loans = new List<Loan>();
        Name = name;

        Users.Add(new User("Ugo", "Deughi", "UGODUG88P45A960P", 45000));
        Users.Add(new User("Sara", "Desari", "DUSDUI88P45A960U", 47000));

        Loans.Add(new Loan("UGODUG88P45A960P", 25000, 300, "12/07/21", "12/07/27"));
        Loans.Add(new Loan("UGODUG88P45A960P", 5000, 200, "10/12/21", "10/12/23"));
        Loans.Add(new Loan("DUSDUD88P45A960U", 5000, 190, "1/02/21", "01/03/23"));

    }

    //funzione di creazione e aggiunta nuovo utente alla lista 
    public string SetNewUser(string name, string surname, string fiscalcode, int salary)
    {
        Users.Add(new User(name, surname, fiscalcode, salary));

        return "Utente aggiunto con successo";
    }

    //funzione modifica utente
    public string SetModifyUser(User userObject)
    {
        string response = "utente non trovato";
        for(int i= 0; i< Users.Count; i++)
        {
            if (Users[i].Fiscalcode.Contains(userObject.Fiscalcode))
            {
                Users[i] = userObject;
                response = User.GetUserData(Users[i]);
                break;
            }
        }
        return response;
    }

    //funzione di ricerca utente
    public string FindUser(string userFiscalCode)
    {
        string response = "utente non trovato";
        foreach(User user in Users)
        {
            if (user.Fiscalcode.Contains(userFiscalCode))
            {
                response = User.GetUserData(user);
                break;
            }
        }
        return response;
    }

    public string FindLoan(string userFiscalCode)
    {
        string response = "Nessun prestito trovato";

        foreach(Loan loan in Loans)
        {
            if (loan.UserFiscalCode.Contains(userFiscalCode))
            {
                response = Loan.GetLoanData(loan);
                break;
            }
        }
        return response;
    }

    public int GetAmmountUserLoan(string userFiscalCode)
    {

    }
}


