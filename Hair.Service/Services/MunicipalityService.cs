using Hair.Data.Context;
using Hair.Data.Entities;
using Hair.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hair.Service.Services
{
    public class MunicipalityService : IGeneric<Municipality>
    {
        private readonly HairdresserDbContext _db;
        public MunicipalityService(HairdresserDbContext db)
        {
            this._db = db;
        }
        public Task<bool> Add(Municipality obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Municipality>> GetAll()
        {
            var municipalities = await _db.Municipality
                .ToListAsync();
            return municipalities;
        }

        public Task<Municipality> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Municipality obj)
        {
            throw new NotImplementedException();
        }
    }
}
