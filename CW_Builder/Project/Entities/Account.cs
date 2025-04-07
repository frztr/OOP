using System;
using System.Collections.Generic;

public class Account
{
    public int Id { get; set; }
    public int FamilyId { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    public string Currency { get; set; }

    // public Family Family { get; set; }
    // public ICollection<Income> Incomes { get; set; }
    // public ICollection<Expense> Expenses { get; set; }
    // public ICollection<Transfer> OutgoingTransfers { get; set; }
    // public ICollection<Transfer> IncomingTransfers { get; set; }
}