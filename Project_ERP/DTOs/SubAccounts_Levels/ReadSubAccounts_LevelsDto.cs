using System.ComponentModel.DataAnnotations;

namespace Project_ERP.DTOs.SubAccounts_Levels
{
    public class ReadSubAccounts_LevelsDto
    {
        public int LevelID { get; set; }
        public int Width { get; set; }
        public int? BranchID { get; set; }
      
    }
}
