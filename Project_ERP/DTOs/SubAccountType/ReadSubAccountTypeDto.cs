using System.ComponentModel.DataAnnotations;

namespace Project_ERP.DTOs.SubAccountType
{
    public class ReadSubAccountTypeDto
    {
        public int SubAccountTypeID { get; set; }
        public string SubAccountTypeNameAr { get; set; }
        public string SubAccountTypeNameEn { get; set; }
        public string? BranchNameEn { get; set; }
        public string? BranchNameAr { get; set; }

    }
}
