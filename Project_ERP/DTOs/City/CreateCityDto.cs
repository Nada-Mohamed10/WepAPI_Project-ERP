namespace Project_ERP.DTOs.City
{
    public class CreateCityDto
    {
        public string CityCode { get; set; }
        public string CityNameAr { get; set; }
        public string CityNameEn { get; set; }
        public int? BranchID { get; set; }
    }
}
