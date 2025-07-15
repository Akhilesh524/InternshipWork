using EmployeeLeavesManagement.Dto;
using EmployeeLeavesManagement.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeavesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class leaverequestsController : ControllerBase
    {

        private readonly ILeaveRequestsManager _leaveRequestsManager;

        public leaverequestsController (ILeaveRequestsManager leaveRequestsManager)
        {
            _leaveRequestsManager = leaveRequestsManager;
        }

        [HttpPost]
        public IActionResult CreateLeaves([FromBody] LeaveRequests leaveRequests)
        {
            _leaveRequestsManager.createLeaveRequests(leaveRequests);

            return Ok("Leave request Created");
        }

        [HttpGet()]
        public IActionResult getLeaveRequest()
        {

           var allLeaveRequests = _leaveRequestsManager.getAllLeaveRequests();
            return Ok(allLeaveRequests);
        }

        [HttpGet("{id}")]
        public IActionResult getLeaveRequestById(int id)
        {
           var leaverequestsFindbyId = _leaveRequestsManager.getLeaveRequestsById(id);
            return Ok(leaverequestsFindbyId);
        }

        [HttpPut("{id}")]
        public IActionResult updateLeaveRequest(int id, LeaveRequests requests)
        {
            _leaveRequestsManager.updateLeaveRequestsById(id,requests);
            return Ok("update leave successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult deleteLeaveRequest(int id)
        {
            _leaveRequestsManager.deleteLeaveRequestsById(id);
            return Ok("delete leave successfully");

        }
    }
    }
