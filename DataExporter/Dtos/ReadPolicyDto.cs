using DataExporter.Model;

namespace DataExporter.Dtos
{
    public class ReadPolicyDto
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; }
        public decimal Premium { get; set; }
        public DateTime StartDate { get; set; }


        public ReadPolicyDto(Policy policy)
        {
            Id = policy.Id;
            PolicyNumber = policy.PolicyNumber;
            Premium = policy.Premium;
            StartDate = policy.StartDate;
        }

        public ReadPolicyDto() { }
    }
}
