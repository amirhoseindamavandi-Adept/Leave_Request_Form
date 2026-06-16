namespace Leave_Request_Form.Models
{
    public class EmployeeLeaveViewModel
    {
        public Employee Employee { get; set; }
        public List<LeaveRequest> LeaveRequests { get; set; }
    }
}
