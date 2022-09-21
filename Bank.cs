// See https://aka.ms/new-console-template for more information
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
        return $"Utente aggiunto con successo";
        //implementare con aggiunta stampa in pagina dei dati nuovo utente
    }

    //funzione modifica utente
    public string SetModifyUser(List<string> newData, string userFiscalCode)
    {
        string response = "utente non trovato";
        int p = GetUser(userFiscalCode);
        if (p != -1)
        {
            Users[p].Name = newData[0] != "same" ? newData[0] : Users[p].Name;
            Users[p].Surname = newData[1] != "same" ? newData[1] : Users[p].Surname;
            Users[p].Fiscalcode = newData[2] != "same" ? newData[2] : Users[p].Fiscalcode;
            Users[p].Salary = newData[3] != "same" ? Convert.ToInt32(newData[3]) : Users[p].Salary;
            response = User.GetUserData(Users[p]);
        }
       
        return response;
    }

    //funzione di ricerca utente ritorna una string
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

    //funzione di ricerca utente, ritorna la posizione nell'array

    public int GetUser(string userFiscalCode)
    {
        int position = 0;
        int response = -1;
        for(int i =0; i< Users.Count; i++)
        {
            if (Users[i].Fiscalcode.Contains(userFiscalCode))
            {
                ;
                response = i;
                break;
            }
        }
        return response;
    }


    //ricerca di uno specifico prestito
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

    // funzione che ritorna i prestiti dell'utente
    public List<Loan> GetAmmountUserLoan(string userFiscalCode)
    {
        List<Loan> userLoans = new List<Loan>(); 
        foreach(Loan loan in Loans)
        {
            if (loan.UserFiscalCode.Contains(userFiscalCode))
            {
                userLoans.Add(loan);
            }
        }
        return userLoans;
    }

    // funzione che ritorna il totale dei prestiti dell'utente
    public static int GetLoanAmmonut(List<Loan> loanList)
    {
        int loanAmmount = 0;
        foreach(Loan loan in loanList)
        {
            loanAmmount+= loan.Ammount;
        }

        return (int)loanAmmount;
    }

    //funzione che ritorna il totale delle rate da pagare per un prestito
    public int GetPaymentNum(int loanID)
    {
        int paymentNum = 0;

        foreach(Loan loan in Loans)
        {
            if (loan.LoanID.Equals(loanID))
            {
                //momentaneo calcolatore faker dell'ammount.
                paymentNum = (loan.Ammount / loan.MonthlyPayment) - (loan.MonthlyPayment - 3);
               //per sapere quante rate, devo avere il totale, diviso l'ammount della rata e qunte rate sono passate
               // contare da li quanti mesi sono passati...
            }
        }
        return paymentNum;
    }
}


