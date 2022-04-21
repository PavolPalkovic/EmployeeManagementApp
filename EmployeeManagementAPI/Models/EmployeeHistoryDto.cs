namespace EmployeeManagementAPI.Models
{
    public class EmployeeHistoryDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public string PositionName { get; set; }
        public string StartingDate { get; set; }
        public double Salary { get; set; }
        public string DateOfDeletion { get; set; }
    }
}