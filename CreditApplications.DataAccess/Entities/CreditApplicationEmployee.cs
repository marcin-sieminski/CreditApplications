namespace CreditApplications.DataAccess.Entities
{
    public class CreditApplicationEmployee
    {
        public int Id { get; set; }
        public int CreditApplicationId { get; set; }
        public CreditApplication CreditApplication { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime DateFrom { get; set; }
    }
}
