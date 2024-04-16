using DataExporter.Model;

namespace DataExporter.Dtos
{
    public class ExportDto
    {
        public string? PolicyNumber { get; set; }
        public decimal Premium { get; set; }
        public DateTime StartDate { get; set; }

        // A list of the notes' text.
        public IList<string> Notes { get; set; }

        public ExportDto(Policy policy)
        {
            PolicyNumber=policy.PolicyNumber;
            Premium=policy.Premium;
            StartDate = policy.StartDate;

            Notes=policy.Notes?.Select(n=>n.Text).ToList();
        }

        public ExportDto()
        {
            
        }
    }
}
