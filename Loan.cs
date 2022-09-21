//I prestiti sono caratterizzati da
//ID
//intestatario del prestito (il cliente),
//un ammontare,
//una rata,
//una data inizio,
//una data fine.
public class Loan
{
    public int Id { get; set; }
    public User User { get; set; }
    public int Amount { get; set; }
    public int Installment { get; set; }
    public int StartDate { get; set; }
    public int EndDate { get; set; }

    public Loan(User user, int amount, int installment)
    {
        Bank.currentLoanId++;
        this.Id = Bank.currentLoanId;
        this.User = user;
        this.Amount = amount;
        this.Installment = installment;
        this.StartDate = 21092022;
        this.EndDate = 30112025;
    }
}