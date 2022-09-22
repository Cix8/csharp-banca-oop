//I prestiti sono caratterizzati da
//ID
//intestatario del prestito (il cliente),
//un ammontare,
//una rata,
//una data inizio,
//una data fine.
public class Loan
{
    public int Id { get; protected set; }
    public User User { get; protected set; }
    public int Amount { get; protected set; }
    public int Installment { get; protected set; }
    public DateTime StartDate { get; protected set; }
    public DateTime EndDate { get; protected set; }

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

    public Loan(User user, int amount, int installment, string startDate)
    {
        Bank.currentLoanId++;
        this.Id = Bank.currentLoanId;
        this.User = user;
        this.Amount = amount;
        this.Installment = installment;
        this.StartDate = DateTime.Parse(startDate);
        this.EndDate = CalculateEndDate(this.StartDate);
    }

    private DateTime CalculateEndDate(DateTime startDate)
    {
        int totMonths = (int)this.Amount / this.Installment;
        return this.StartDate.AddMonths(totMonths);
    }
}