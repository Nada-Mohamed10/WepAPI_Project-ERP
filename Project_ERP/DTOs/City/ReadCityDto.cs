﻿using System.ComponentModel.DataAnnotations;

namespace Project_ERP.DTOs.City
{
    public class ReadCityDto
    {
        public int CityID { get; set; }
        public string CityCode { get; set; }
        public string CityNameAr { get; set; }
        public string CityNameEn { get; set; }
        public string? BranchNameEn { get; set; }
        public string? BranchNameAr { get; set; }

    }
}
