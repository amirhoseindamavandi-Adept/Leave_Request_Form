using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Leave_Request_Form.Models;

namespace Leave_Request_Form.Controllers
{
    public class LeaveRequestsController : Controller
    {
        private readonly Leave_Request_FormContext _context;

        public LeaveRequestsController(Leave_Request_FormContext context)
        {
            _context = context;
        }

        // GET: LeaveRequests
        public async Task<IActionResult> Index()
        {
            var leave_Request_FormContext = _context.LeaveRequest.Include(l => l.Employee);
            return View(await leave_Request_FormContext.ToListAsync());

            //var request = _context.LeaveRequest.Include(x => x.EmployeeID).ToListAsync();
            //return View(request);

        }

        // GET: LeaveRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequest
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            return View(leaveRequest);
        }

        // GET: LeaveRequests/Create
        public IActionResult Create()
        {
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID");
            return View();
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LeaveRequest leaveRequest) 
        {
            if (!ModelState.IsValid)
            {
              
                leaveRequest.CreatedAt = DateTime.Now;
                leaveRequest.Status = LeaveRequestStatus.pending;
                _context.Add(leaveRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", leaveRequest.EmployeeID);
            return View(leaveRequest);
        }

        public IActionResult Approved(int id)
        {
            var leave = _context.LeaveRequest.Find(id);
            if (leave != null)
            {
                leave.Status = LeaveRequestStatus.Approved;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        public IActionResult Rejected(int id)
        {
            var leave = _context.LeaveRequest.Find(id);
            if (leave!=null)
            {
                leave.Status= LeaveRequestStatus.Rejected;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
            

        }
        // GET: LeaveRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequest.FindAsync(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", leaveRequest.EmployeeID);
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,EmployeeID,FromDate,ToDate,Description,Status")] LeaveRequest leaveRequest)
        {
            if (id != leaveRequest.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveRequestExists(leaveRequest.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeID"] = new SelectList(_context.Employee, "EmployeeID", "EmployeeID", leaveRequest.EmployeeID);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveRequest = await _context.LeaveRequest
                .Include(l => l.Employee)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            return View(leaveRequest);
        }

        // POST: LeaveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveRequest = await _context.LeaveRequest.FindAsync(id);
            if (leaveRequest != null)
            {
                _context.LeaveRequest.Remove(leaveRequest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveRequestExists(int id)
        {
            return _context.LeaveRequest.Any(e => e.ID == id);
        }
    }
}
