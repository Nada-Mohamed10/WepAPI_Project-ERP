namespace Project_ERP.DTOs.SubAccountsClient
{
    public class UpdateSubAccountsClientDto
    {
        public string ClientNo { get; set; }
        public int SubAccountID { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? CityID { get; set; }
        public decimal? CreditLimit { get; set; }
        public bool IsDiscountTax { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public int? BranchID { get; set; }
    }
}
