namespace Project_ERP.DTOs.JV
{
    public class UpdateJVDto
    {
        public string JVNo { get; set; }
        public DateTime JVDate { get; set; }
        public int? JVTypeID { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public string ReceiptNo { get; set; }
        public string Notes { get; set; }
        public int? BranchID { get; set; }
    }
}
