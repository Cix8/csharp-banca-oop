//I clienti sono caratterizzati da
//nome,
//cognome,
//codice fiscale
//stipendio

public class User
{
    public int Id { get; protected set; }
    public string Name { get; internal set; }
    public string Surname { get; internal set; }
    public string FiscalCode { get; internal set; }
    public int Salary { get; internal set; }

    public User(string name, string surname, string fiscalCode)
    {
        Bank.currentUserId++;
        this.Id = Bank.currentUserId;
        this.Name = name;
        this.Surname = surname;
        this.FiscalCode = fiscalCode;
        this.Salary = 3000;
    }
}
