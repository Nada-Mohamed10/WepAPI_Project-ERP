namespace Project_ERP.DTOs.JVDetails
{
    public class CreateJVDetailsDto
    {
        public int JVID { get; set; }
        public int AccountID { get; set; }
        public int? SubAccountID { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public bool IsDocumented { get; set; }
        public string Notes { get; set; }
        public int? BranchID { get; set; }

    }
}
