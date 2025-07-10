using AutoMapper;
using Project_ERP.DTOs.JVDetails;
using Project_ERP.Models;
using Project_ERP.Services.JVDetailsServices;
using Project_ERP.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Project_ERP.Services.JVDetails
{
    public class JVDetailsService : IJVDetailsService
    {
        UnitOfWork unit;
        IMapper map;
        public JVDetailsService(UnitOfWork unit , IMapper map) 
        {
            this.unit = unit;
            this.map = map;
        }
        public async Task<ReadJVDetailsDto> AddAsync(CreateJVDetailsDto jvDetailsDto)
        {
            var jvDetails = map.Map<JVDetail>(jvDetailsDto);
            await unit.JVDetailsRepositry.AddAsync(jvDetails); 
            await unit.CompleteAsync();
            return map.Map<ReadJVDetailsDto>(jvDetails);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var jvDetails = await unit.JVDetailsRepositry.GetByIdAsync(id);
            if (jvDetails == null)
                return false;
            unit.JVDetailsRepositry.Delete(jvDetails);
            await unit.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<ReadJVDetailsDto>> GetAllAsync()
        {
            var jvDetails = await unit.JVDetailsRepositry.GetAllWithAccount().ToListAsync();



            return map.Map<IEnumerable<ReadJVDetailsDto>>(jvDetails);
        }

        public async Task<ReadJVDetailsDto> GetByIdAsync(int id)
        {
           var jvDetails = await unit.JVDetailsRepositry.GetByIdAsync(id);
            if (jvDetails == null) return null;
            return map.Map<ReadJVDetailsDto>(jvDetails);
        }


        public async  Task<ReadJVDetailsDto> UpdateAsync(int id, UpdateJVDetailsDto jvDetailsDto)
        {
            var jvDetails = await unit.JVDetailsRepositry.GetByIdAsync(id);
            if (jvDetails == null) return null;
            map.Map(jvDetailsDto, jvDetails);
            unit.JVDetailsRepositry.Update(jvDetails);
            await unit.CompleteAsync();
            return map.Map<ReadJVDetailsDto>(jvDetails);
        }
    }
}
