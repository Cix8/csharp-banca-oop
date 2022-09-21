//I clienti sono caratterizzati da
//nome,
//cognome,
//codice fiscale
//stipendio

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FiscalCode { get; set; }
    public int Salary { get; set; }

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
