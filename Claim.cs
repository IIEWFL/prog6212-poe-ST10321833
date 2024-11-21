public class Claim
{
    public static int ClaimCounter = 0; 
    public int Id { get; private set; } 
    public string LecturerName { get; set; }
    public double HoursWorked { get; set; }
    public double HourlyRate { get; set; }
    public string Notes { get; set; }
    public string Status { get; set; } = "Pending";
    public decimal Amount { get; set; }
  
public Claim()
    {
        Id = ++ClaimCounter; 
    }

    public double TotalAmount => HoursWorked * HourlyRate;
}

