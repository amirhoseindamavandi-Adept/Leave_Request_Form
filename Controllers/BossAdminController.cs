using Leave_Request_Form.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

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
            var pending = _context.LeaveRequest.Include(x=>x.Employee).Where(x => x.Status == LeaveRequestStatus.pending).ToList<LeaveRequest>();
            return View(pending);
        }

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
