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
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Loan(User user, int amount, int installment)
    {
        Bank.currentLoanId++;
        this.Id = Bank.currentLoanId;
        this.User = user;
        this.Amount = amount;
        this.Installment = installment;
        this.StartDate = DateTime.Parse("21-09-2022");
        this.EndDate = DateTime.Parse("30-11-2025");
    }

    public Loan(User user, int amount, int installment, string startDate, string endDate)
    {
        Bank.currentLoanId++;
        this.Id = Bank.currentLoanId;
        this.User = user;
        this.Amount = amount;
        this.Installment = installment;
        this.StartDate = DateTime.Parse(startDate);
        this.EndDate = DateTime.Parse(endDate);
    }
}