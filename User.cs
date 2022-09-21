// See https://aka.ms/new-console-template for more information


public class User
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Fiscalcode { get; set; }
    public int Salary { get; }

    public User(string name, string surname, string fiscalcode, int salary)
    {
        Name = name;
        Surname = surname;
        Fiscalcode = fiscalcode;
        Salary = salary;
    }

    public static string GetUserData(User userObject)
    {
        return $"Nome utente: {userObject.Name}" +
            $"Cognome utente: {userObject.Surname};" +
            $"Codice fiscale: {userObject.Fiscalcode};" +
            $"Salario annuale lordo: {userObject.Salary}";
    }
}
