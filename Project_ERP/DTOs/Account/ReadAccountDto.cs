using System.ComponentModel.DataAnnotations;

namespace Project_ERP.DTOs.Account
{
    public class ReadAccountDto
    {
        public int AccountID { get; set; }
        public string AccountNumber { get; set; }
        public string AccountNameAr { get; set; }
        public string AccountNameEn { get; set; }
        public string? BranchNameAr { get; set; }
        public string? BranchNameEn { get; set; }


    }
}
