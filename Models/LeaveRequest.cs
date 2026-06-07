namespace Leave_Request_Form.Models
{
    public class LeaveRequest
    {
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Description { get; set; }
        public LeaveRequestStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
