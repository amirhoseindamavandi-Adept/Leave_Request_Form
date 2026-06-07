using System.Reflection.Metadata.Ecma335;

namespace Leave_Request_Form.Models
{
    public class Employee
    {
        public Employee()
        {
        }

        public void Removed(int id)
        {
            IsRemoved = true;
        }



        public int EmployeeID { get; set; }
        public  string  Name { get; set; }
        public string Family { get; set; }
        public string Description { get; set; }

        public DateTime CreationDate  { get; set; } = DateTime.Now;
        public int  BossID { get; set; }

        public bool IsRemoved  { get; set; } = false;
    }

}
