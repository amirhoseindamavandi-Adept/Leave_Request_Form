using Leave_Request_Form.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Leave_Request_Form.Controllers
{
    public class BossAdminController : Controller
    {
        private readonly Leave_Request_FormContext _context;

        public BossAdminController(Leave_Request_FormContext context)
        {
            _context = context;
        }
        public IActionResult Pending()
        {
            var pending = new EmployeeLeaveViewModel();

            pending.LeaveRequests = _context.LeaveRequest
                .Include(x => x.Employee)
                .Where(x => x.Status == LeaveRequestStatus.pending)
                .ToList();

            pending.Employee = new Employee();

            ViewData["EmployeeID"] =
                new SelectList(_context.Employee, "EmployeeID", "EmployeeID");

            return View(pending);
        }
        public IActionResult PendingRequest(int? employeeId)
        {
            var viewModel = new EmployeeLeaveViewModel();

            viewModel.Employee = new Employee();

            viewModel.LeaveRequests = _context.LeaveRequest
                .Include(x => x.Employee)
                .Where(x => !employeeId.HasValue || x.EmployeeID == employeeId.Value)
                .ToList();

            ViewBag.EmployeeID = new SelectList(_context.Employee, "EmployeeID", "Name", employeeId);

            return View(viewModel);
        }


        //public IActionResult Pending()
        //{
        //    var pending = new EmployeeLeaveViewModel();
        //    pending = _context.LeaveRequest.Include(x => x.Employee).Where(x => x.Status == LeaveRequestStatus.pending)
        //        .ToList();
        //    return View(pending);
        //}

        public IActionResult Approved()
        {
            var approved = _context.LeaveRequest.Where(x => x.Status == LeaveRequestStatus.Approved).ToList();
            return View(approved);
        }

        public IActionResult Rejected()
        {
            var Rejected = _context.LeaveRequest.Where(x => x.Status == LeaveRequestStatus.Rejected).ToList();
            return View(Rejected);
        }
    }
}
