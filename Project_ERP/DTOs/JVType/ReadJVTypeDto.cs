using System.ComponentModel.DataAnnotations;

namespace Project_ERP.DTOs.JVType
{
    public class ReadJVTypeDto
    {
        public int JVTypeID { get; set; }
        public string JVTypeNameAr { get; set; }
        public string JVTypeNameEn { get; set; }
        public string? BranchNameEn { get; set; }
        public string? BranchNameAr { get; set; }

    }
}
