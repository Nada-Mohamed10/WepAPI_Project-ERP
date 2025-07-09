using System.ComponentModel.DataAnnotations;

namespace Project_ERP.DTOs.Branch
{
    public class ReadBranchDto
    {
        public int BranchID { get; set; }
        public string BranchCode { get; set; }
        public string BranchNameAr { get; set; }
        public string BranchNameEn { get; set; }
        
    }
}
