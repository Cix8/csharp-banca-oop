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
}