public class ClaimViewModel
{
    public int Id { get; set; }
    public string LecturerName { get; set; }
    public double HoursWorked { get; set; }
    public double HourlyRate { get; set; }
    public string Status { get; set; }

    public string Display => $"Claim ID: {Id}, Lecturer: {LecturerName}, Hours: {HoursWorked}, Rate: {HourlyRate:C}, Status: {Status}";
}
