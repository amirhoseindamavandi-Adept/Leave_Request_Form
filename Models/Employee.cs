using System.Reflection.Metadata.Ecma335;

namespace Leave_Request_Form.Models
{
    public class Employee
    {
        public Employee()
        {
        }

        public Employee( string name,string family,string description )
        {
            this.Name = name;
            this.Family = family;
            this.Description = description;
            CreationDate=DateTime.Now;
            
        }


        public int EmployeeID { get; set; }
        public  string  Name { get; set; }
        public string Family { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int  BossID { get; set; }
        public bool IsRemoved { get; set; }
    }

}
