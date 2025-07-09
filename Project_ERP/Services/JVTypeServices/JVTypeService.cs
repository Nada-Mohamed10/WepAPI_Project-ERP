using AutoMapper;
using Project_ERP.DTOs.JVType;
using Project_ERP.Models;
using Project_ERP.UnitOfWorks;

namespace Project_ERP.Services.JVTypeServices
{
    public class JVTypeService : IJVTypeService
    {
        UnitOfWork unit;
        IMapper map;
        public JVTypeService(UnitOfWork unit, IMapper map)
        { 
            this.unit = unit;
            this.map = map;
        }
        public async Task<ReadJVTypeDto> AddAsync(CreateJVTypeDto jvTypeDto)
        {
           var jvType = map.Map<JVType>(jvTypeDto);
           unit.JVTypeRepositry.AddAsync(jvType);
          await  unit.CompleteAsync();
            return map.Map<ReadJVTypeDto>(jvType);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var jvType= await unit.JVTypeRepositry.GetByIdAsync(id);
            if (jvType == null)
                return false;
            unit.JVTypeRepositry.Delete(jvType);
            await unit.CompleteAsync();
            return true;
        }
          
           
        

        public async Task<IEnumerable<ReadJVTypeDto>> GetAllAsync()
        {
           var jvTypes = await unit.JVTypeRepositry.GetAll();
          return map.Map<IEnumerable<ReadJVTypeDto>>(jvTypes);
        }

        public async Task<ReadJVTypeDto> GetByIdAsync(int id)
        {
            var jvType = await unit.JVTypeRepositry.GetByIdAsync(id);
            if (jvType == null) return null;
            return map.Map<ReadJVTypeDto>(jvType);
        }

        public async Task<ReadJVTypeDto> UpdateAsync(int id, UpdateJVTypeDto jvTypeDto)
        {
            var jvType = await unit.JVTypeRepositry.GetByIdAsync(id);
            if(jvType == null) return null;
             map.Map(jvTypeDto, jvType);
            unit.JVTypeRepositry.Update(jvType);
            await unit.CompleteAsync();
            return map.Map<ReadJVTypeDto>(jvType);
        }
    }
}
