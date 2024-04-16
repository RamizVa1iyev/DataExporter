using DataExporter.Dtos;
using DataExporter.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataExporter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PoliciesController : ControllerBase
    {
        private PolicyService _policyService;

        public PoliciesController(PolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpPost]
        public async Task<IActionResult> PostPolicies([FromBody] CreatePolicyDto createPolicyDto)
        {
            var result = await _policyService.CreatePolicyAsync(createPolicyDto);

            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetPolicies()
        {
            var result = await _policyService.ReadPoliciesAsync();

            return Ok(result);
        }

        //[HttpGet("{policyId}")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPolicy(int id)
        {
            var result = await _policyService.ReadPolicyAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpPost("export")]
        public async Task<IActionResult> ExportData([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var data = await _policyService.ExportDataAsync(startDate, endDate);

            return Ok(data);
        }
    }
}
