using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_ERP.DTOs.JV
{
    public class ReadJVDto
    {
        public int JVID { get; set; }
        public string JVNo { get; set; }
        public DateTime JVDate { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal TotalCredit { get; set; }
        public string ReceiptNo { get; set; }
        public string Notes { get; set; }
        public string? JVTypeNameEn { get; set; }
        public string? JVTypeNameAr { get; set; }
        public string? BranchNameEn { get; set; }
        public string? BranchNameAr { get; set; }




    }
}
