// See https://aka.ms/new-console-template for more information



public class Loan
{
    public static int ID { get; set; }
    public string UserFiscalCode { get; set; }
    public int Ammount { get; set; }
    public int MonthlyPayment { get; set; }

    //da convertire poi in dateTime
    public string StartDate { get; set; }

    //da convertire in dateTime
    public string EndDate { get; set; }

    public Loan(string userFiscalCode, int ammount, int monthlyPayment, string startDate, string endDate)
    {
        UserFiscalCode = userFiscalCode;
        Ammount = ammount;
        MonthlyPayment = monthlyPayment;
        StartDate = startDate;
        EndDate = endDate;
    }

    public static string GetLoanData(Loan loanItem)
    {
        return $"Ammonatre prestito: {loanItem.Ammount};" +
            $"Rata mensile: {loanItem.MonthlyPayment};" +
            $"Data di inizio prestito: {loanItem.StartDate};" +
            $"Data di fine e chiusura: {loanItem.EndDate}";
    }
}