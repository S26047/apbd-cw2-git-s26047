public class Loan
{
    public int Id { get; set; }
    public Equipment Equipment { get; set; }
    public User  User { get; set; }
    
    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    
    public decimal Penalty { get; set; }
}