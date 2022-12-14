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
    public string Name { get; protected set; }
    public List<User> Users { get; protected set; }
    public List<Loan> Loans { get; protected set; }

    public Bank(string name)
    {
        this.Name = name;
        User testUser1 = new User("Pippo", "Franco", "PPOFNC50P98F158Q");
        User testUser2 = new User("Lollobrigida", "Gina", "LBRGNA50P98F158Q");
        User testUser3 = new User("Verne", "Giulio", "VRNGLI50P98F158Q");
        this.Users = new List<User> {testUser1, testUser2, testUser3};
        Loan testLoan1 = new Loan(testUser1, 10000, 300);
        Loan testLoan2 = new Loan(testUser2, 20000, 650);
        Loan testLoan3 = new Loan(testUser1, 15000, 300, DateTime.Now.ToString(), "30-10-2026");
        Loan testLoan4 = new Loan(testUser2, 15000, 300, "15-06-2019", "30-10-2022");
        Loan testLoan5 = new Loan(testUser1, 25000, 350, "10-08-2018", "21-09-2022");
        Loan testLoan6 = new Loan(testUser1, 50000, 750, "23-09-2021");
        this.Loans = new List<Loan> { testLoan1, testLoan2, testLoan3, testLoan4, testLoan5, testLoan6 };
    }

    public User GetUserBy(int id)
    {
        foreach (User user in this.Users)
        {
            if(user.Id == id)
            {
                return user;
            }
        }
        return null;
    }

    public void AddNewUser(User user)
    {
        if(user != null)
        {
            this.Users.Add(user);
        }
    }

    public void ModifyUserData(int id, string name = "", string surname = "", string fiscalCode = "", int salary = -1)
    {
        User searchResult = this.GetUserBy(id);

        if(searchResult != null)
        {
            searchResult.Name = name != "" ? name : searchResult.Name;
            searchResult.Surname = surname != "" ? surname : searchResult.Surname;
            searchResult.FiscalCode = fiscalCode != "" ? fiscalCode : searchResult.FiscalCode;
            searchResult.Salary = salary != -1 ? salary : searchResult.Salary;
        }
    }

    public void AddNewLoan(Loan loan)
    {
        this.Loans.Add(loan);
    }

    public List<Loan> FindLoansBy(string fiscalCode)
    {
        List<Loan> userLoans = new List<Loan>();
        if(fiscalCode != "")
        {
            foreach(Loan loan in this.Loans)
            {
                if (loan.User.FiscalCode == fiscalCode)
                {
                    userLoans.Add(loan);
                }
            }
        }
        return userLoans;
    }

    public int CountUserLoans(string fiscalCode)
    {
        return this.FindLoansBy(fiscalCode).Count();
    }

    public List<int> CounterRemainingInstallment(string fiscalCode)
    {
        List<Loan> theseLoans = this.FindLoansBy(fiscalCode);
        List<int> installmentsCounter = new List<int>();

        //Il conteggio tiene conto anche del giorno del mese, ovvero se la scadenza della rata è ogni 30 del mese ed oggi siamo al 21 viene considerata come restante anche la scadenza del corrente mese
        
        foreach (Loan loan in theseLoans)
        {
            int totRemaingInstallment = 0;
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            int currentDay = DateTime.Now.Day;
            int endMonth = loan.EndDate.Month;
            int endYear = loan.EndDate.Year;
            int endDay = loan.EndDate.Day;

            if(currentYear < endYear)
            {
                int yearsDiff = endYear - currentYear;
                int months = 12 * yearsDiff;
                int monthsDiff = endMonth - currentMonth;
                int dayDiff = currentDay < endDay ? 1 : 0;
                months = months + monthsDiff + dayDiff;
                totRemaingInstallment += months;
            } else if (currentYear == endYear && currentMonth != endMonth)
            {
                int monthsDiff = endMonth - currentMonth;
                int dayDiff = currentDay < endDay ? 1 : 0;
                totRemaingInstallment += monthsDiff + dayDiff;
            } else if (currentYear == endYear && 
                currentMonth == endMonth && 
                currentDay < endDay)
            {
                totRemaingInstallment += 1;
            }

            installmentsCounter.Add(totRemaingInstallment);
        }

        return installmentsCounter;
    }
}
