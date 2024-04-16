using DataExporter.Dtos;
using Microsoft.EntityFrameworkCore;


namespace DataExporter.Services
{
    public class PolicyService
    {
        private ExporterDbContext _dbContext;

        public PolicyService(ExporterDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }


        /// <summary>
        /// Creates a new policy from the DTO.
        /// </summary>
        /// <param name="policy"></param>
        /// <returns>Returns a ReadPolicyDto representing the new policy, if succeded. Returns null, otherwise.</returns>
        public async Task<ReadPolicyDto?> CreatePolicyAsync(CreatePolicyDto createPolicyDto)
        {
            var policy = createPolicyDto.ConvertToPolicy();

            await _dbContext.Policies.AddAsync(policy);
            await _dbContext.SaveChangesAsync();

            var response = new ReadPolicyDto(policy);

            return response;
        }


        /// <summary>
        /// Retrives all policies.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a list of ReadPoliciesDto.</returns>
        public async Task<IList<ReadPolicyDto>> ReadPoliciesAsync()
        {
            //can be use mapper
            var policies = await _dbContext.Policies.Select(p => new ReadPolicyDto(p)).ToListAsync();

            return policies;
        }


        /// <summary>
        /// Retrieves a policy by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a ReadPolicyDto.</returns>
        public async Task<ReadPolicyDto?> ReadPolicyAsync(int id)
        {
            //var policy = await _dbContext.Policies.SingleAsync(x => x.Id == id);
            var policy = await _dbContext.Policies.FirstOrDefaultAsync(x => x.Id == id);
            if (policy == null)
            {
                return null;
            }

            //We can use mapper or write converter from Policy to ReadPolicyDto inside DTO
            //var policyDto = new ReadPolicyDto()
            //{
            //    Id = policy.Id,
            //    PolicyNumber = policy.PolicyNumber,
            //    Premium = policy.Premium,
            //    StartDate = policy.StartDate
            //};

            var policyDto = new ReadPolicyDto(policy);

            return policyDto;
        }


        /// <summary>
        /// Retrives all policies and their notes between start date and end date
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>Returns a list of ExportDto.</returns>
        public async Task<IList<ExportDto>> ExportDataAsync(DateTime startDate, DateTime endDate)
        {
            var data = await _dbContext.Policies.Where(p => p.StartDate >= startDate && p.StartDate <= endDate)
                                                .Include(p=>p.Notes)
                                                .Select(p => new ExportDto(p)).ToListAsync();

            return data;
        }
    }
}
