using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project_ERP.DTOs.JVDetails
{
    public class ReadJVDetailsDto
    {
        public int JVDetailID { get; set; }
       
        public string AccountNameAr { get; set; }
        public string AccountNameEn{ get; set; }
        public string? SubAccountNameAr { get; set; }
        public string? SubAccountNameEn { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public bool IsDocumented { get; set; }
        public string Notes { get; set; }
        public string? BranchName { get; set; }

        public int JVID { get; set; }

    }
}
