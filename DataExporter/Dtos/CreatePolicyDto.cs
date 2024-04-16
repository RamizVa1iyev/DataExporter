using DataExporter.Model;

namespace DataExporter.Dtos
{
    public class CreatePolicyDto
    {
        public string PolicyNumber { get; set; }
        public decimal Premium { get; set; }
        public DateTime StartDate { get; set; }

        public Policy ConvertToPolicy()
        {
            return new Policy()
            {
                Id=0,
                PolicyNumber=PolicyNumber,
                Premium=Premium,
                StartDate=StartDate,
            };
        }
    }
}
