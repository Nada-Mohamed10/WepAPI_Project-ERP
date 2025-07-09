using AutoMapper;
using Project_ERP.DTOs.City;
using Project_ERP.Models;
using Project_ERP.UnitOfWorks;

namespace Project_ERP.Services.CityServices
{
    public class CityService : ICityService
    {
        UnitOfWork unit;
        IMapper map;
        public CityService(UnitOfWork unit, IMapper map) 
        {
            this.unit = unit;
            this.map = map;
        }

        public async Task<ReadCityDto> AddAsync(CreateCityDto cityDto)
        {
            var city= map.Map<City>(cityDto);
            await unit.CityRepositry.AddAsync(city);
            await unit.CompleteAsync();
            return map.Map<ReadCityDto>(city);
        }

        public async Task<bool> DeleteAsync(int id)
        {
           var city = await unit.CityRepositry.GetByIdAsync(id);
            if (city == null)
                return false;
            unit.CityRepositry.Delete(city);
            await unit.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<ReadCityDto>> GetAllAsync()
        {
            var cities = await unit.CityRepositry.GetAll();
            if (cities == null) return null;
            return map.Map<IEnumerable<ReadCityDto>>(cities);
        }

        public  async Task<ReadCityDto> GetByIdAsync(int id)
        {
            var city = await unit.CityRepositry.GetByIdAsync(id);
            if (city == null) return null;
            return map.Map<ReadCityDto>(city);
        }

        public async Task<ReadCityDto> UpdateAsync(int id, UpdateCityDto cityDto)
        {
            var account = await unit.CityRepositry.GetByIdAsync(id);
            if (account == null) return null;
            map.Map(cityDto, account);
           await  unit.CompleteAsync();
            return map.Map<ReadCityDto>(account);
        }
    }
}
