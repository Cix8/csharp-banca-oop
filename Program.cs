//Esercizio
//Sviluppare un’applicazione orientata agli oggetti per gestire i prestiti che una banca concede ai propri clienti.
//La banca è caratterizzata da
//un nome
//un insieme di clienti (una lista)
//un insieme di prestiti concessi ai clienti (una lista)
//I clienti sono caratterizzati da
//nome,
//cognome,
//codice fiscale
//stipendio
//I prestiti sono caratterizzati da
//ID
//intestatario del prestito (il cliente),
//un ammontare,
//una rata,
//una data inizio,
//una data fine.
//Per la banca deve essere possibile:
//aggiungere, modificare e ricercare un cliente.
//aggiungere un prestito.
//effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale
//sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.
//sapere, dato il codice fiscale di un cliente, quante rate rimangono da pagare alla data odierna.
//Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti i dati che li caratterizzano in un formato di tipo stringa a piacere.
//Bonus:
//visualizzare per ogni cliente, la situazione dei suoi prestiti in formato tabellare.

Bank myBank = new Bank("La Banca dei poveri");

//myBank.ModifyUserData(1, "Ciccio");

List<Loan> userLoans = myBank.FindLoansBy("PPOFNC50P98F158Q");

int userLoansCounter = myBank.CountUserLoans("PPOFNC50P98F158Q");

List<int> totRemaingInstallments = myBank.CounterRemainingInstallment("PPOFNC50P98F158Q");

foreach(User user in myBank.Users)
{
    Console.WriteLine($"Sintesi dei prestiti collegati a {user.Name} {user.Surname}: (tot: {myBank.CountUserLoans(user.FiscalCode)})");
    Console.WriteLine();
    List<Loan> theseUserLoans = myBank.FindLoansBy(user.FiscalCode);
    List<int> remainingInstallments = myBank.CounterRemainingInstallment(user.FiscalCode);
    for (int i = 0; i < theseUserLoans.Count; i++)
    {
        Loan loan = theseUserLoans[i];
        if(loan != null)
        {
            Console.Write(" Totale ");
            Console.Write(" Tot Rate ");
            Console.Write("  Data Inizio ");
            Console.Write("   Data Fine ");
            Console.Write("   Rate Restanti ");
            Console.WriteLine();
            Console.Write(" " + loan.Amount + " ");
            Console.Write("   " + loan.Installment + " ");
            Console.Write("      " + loan.StartDate.ToString("dd/MM/yyyy") + " ");
            Console.Write("    " + loan.EndDate.ToString("dd/MM/yyyy") + " ");
            Console.Write("      " + remainingInstallments[i] + " ");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}