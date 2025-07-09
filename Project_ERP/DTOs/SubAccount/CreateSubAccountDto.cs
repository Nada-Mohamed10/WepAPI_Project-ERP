using System.ComponentModel.DataAnnotations;

namespace Project_ERP.DTOs.SubAccount
{
    public class CreateSubAccountDto
    {
        public string SubAccountNumber { get; set; }
        public string SubAccountNameAr { get; set; }
        public string SubAccountNameEn { get; set; }
        public int? ParentID { get; set; }
        public bool IsMain { get; set; }
        public int LevelID { get; set; }
        public int? SubAccountTypeID { get; set; }
        public int? BranchID { get; set; }
    }
}
