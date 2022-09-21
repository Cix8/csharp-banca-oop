//La banca è caratterizzata da
//un nome
//un insieme di clienti (una lista)
//un insieme di prestiti concessi ai clienti (una lista)
//Per la banca deve essere possibile:
//aggiungere, modificare e ricercare un cliente.
//aggiungere un prestito.
//effettuare delle ricerche sui prestiti concessi ad un cliente dato il codice fiscale
//sapere, dato il codice fiscale di un cliente, l’ammontare totale dei prestiti concessi.
//sapere, dato il codice fiscale di un cliente, quante rate rimangono da pagare alla data odierna.
//Per i clienti e per i prestiti si vuole stampare un prospetto riassuntivo con tutti i dati che li caratterizzano in un formato di tipo stringa a piacere.
//Bonus:
//visualizzare per ogni cliente, la situazione dei suoi prestiti in formato tabellare.

public class Bank
{

    public static int currentUserId = 0;

    public static int currentLoanId = 0;
    public string Name { get; set; }
    public List<User> Users { get; set; }
    public List<Loan> Loans { get; set; }

    public Bank(string name)
    {
        this.Name = name;
        User testUser1 = new User("Pippo", "Franco", "PPOFNC50P98F158Q");
        User testUser2 = new User("Lollobrigida", "Gina", "LBRGNA50P98F158Q");
        User testUser3 = new User("Verne", "Giulio", "VRNGLI50P98F158Q");
        this.Users = new List<User> {testUser1, testUser2, testUser3};
        Loan testLoan1 = new Loan(testUser1, 10000, 300);
        Loan testLoan2 = new Loan(testUser2, 20000, 650);
        this.Loans = new List<Loan> { testLoan1, testLoan2 };
    }
}
