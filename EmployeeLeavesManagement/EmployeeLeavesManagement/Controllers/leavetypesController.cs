using EmployeeLeavesManagement.Dto;
using EmployeeLeavesManagement.Manager;
using EmployeeLeavesManagement.Persistence.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLeavesManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class leavetypesController : ControllerBase
    {
        private readonly ILeaveTypesManager _leaveTypesManager;

        public leavetypesController(ILeaveTypesManager leaveTypesManager)
        {
            _leaveTypesManager = leaveTypesManager;
        }

        [HttpPost]
            public IActionResult CreateLeaveTypes([FromBody] LeaveTypes leavetypes)
            {

            _leaveTypesManager.createLeaveTypes(leavetypes);

            return Ok("create Leave");
            }
            [HttpGet]
            public IActionResult getallLeaveTypes()
            {
             var allLeaveTypes =_leaveTypesManager.getAllLeaveTypes();
                return Ok(allLeaveTypes);
            }

            [HttpGet("{id}")]
            public IActionResult getLeaveTypesById(int id)
            {
           var leaveTypeFindById = _leaveTypesManager.getLeaveTypesById(id);
                return Ok(leaveTypeFindById);
            }

            [HttpPut("{id}")]
            public IActionResult updateLeaveTypesById(int id , LeaveTypes types)
            {
            _leaveTypesManager.updateLeaveTypesById(id, types);
                return Ok("update Leave SuccessFully");
            }

            [HttpDelete("{id}")]
            public IActionResult deleteLeaveTypesById(int id)
            {
            _leaveTypesManager.deleteLeaveTypesById(id);
                return Ok("delete Leave Types");
            }

        }
    }
