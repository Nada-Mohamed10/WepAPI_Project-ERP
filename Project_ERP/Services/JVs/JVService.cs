using AutoMapper;
using Project_ERP.DTOs.JV;
using Project_ERP.Models;
using Project_ERP.UnitOfWorks;

namespace Project_ERP.Services.JVs
{
    public class JVService : IJVService
    {
        UnitOfWork unit;
        IMapper map;
        public JVService(UnitOfWork unit , IMapper map) 
        { 
          this.unit = unit;
            this.map = map;
        }
        public async Task<ReadJVDto> AddAsync(CreateJVDto jvDto)
        {
            var jv = map.Map<JV>(jvDto);
            await unit.JVRepositry.AddAsync(jv);
            await unit.CompleteAsync();
            return map.Map<ReadJVDto>(jv);
        }

        public async Task<bool> DeleteAsync(int id)
        {
          var jv = await unit.JVRepositry.GetByIdAsync(id);
            if (jv == null)
                return false;
            unit.JVRepositry.Delete(jv);
            await unit.CompleteAsync();
            return true;
        }

        public async Task<IEnumerable<ReadJVDto>> GetAllAsync()
        {
            var jvs= await unit.JVRepositry.GetAll();
            return map.Map<IEnumerable<ReadJVDto>>(jvs);
        }

        public async Task<ReadJVDto> GetByIdAsync(int id)
        {
            var jv= await unit.JVRepositry.GetByIdAsync(id);
            if (jv == null) return null;
            return map.Map<ReadJVDto>(jv);
        }

        public async Task<ReadJVDto> UpdateAsync(int id, UpdateJVDto jvDto)
        {
            var jv = await unit.JVRepositry.GetByIdAsync(id);
            if (jv == null) return null;
            map.Map(jvDto, jv);
            unit.JVRepositry.Update(jv);
            unit.CompleteAsync();
            return map.Map<ReadJVDto>(jv);

        }
    }
}
