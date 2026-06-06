using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Leave_Request_Form.Models;

    public class Leave_Request_FormContext : DbContext
    {
        public Leave_Request_FormContext (DbContextOptions<Leave_Request_FormContext> options)
            : base(options)
        {
        }

        public DbSet<Leave_Request_Form.Models.Employee> Employee { get; set; } = default!;
    }
