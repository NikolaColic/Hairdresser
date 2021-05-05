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
    public class SocialNetworkService : IGeneric<SocialNetwork>
    {
        private readonly HairdresserDbContext _db;
        public SocialNetworkService(HairdresserDbContext db)
        {
            this._db = db;
        }
        public Task<bool> Add(SocialNetwork obj)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SocialNetwork>> GetAll()
        {
            var networks = await _db.SocialNetwork.ToListAsync();
            return networks;
        }

        public Task<SocialNetwork> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(SocialNetwork obj)
        {
            throw new NotImplementedException();
        }
    }
}
