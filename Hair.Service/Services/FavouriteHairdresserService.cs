using Hair.Data.Context;
using Hair.Data.Entities;
using Hair.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hair.Service.Services
{
    public class FavouriteHairdresserService : IGeneric<FavouriteHairdresser>
    {
        private readonly HairdresserDbContext _db;
        public FavouriteHairdresserService(HairdresserDbContext db)
        {
            this._db = db;
        }
        public async Task<bool> Add(FavouriteHairdresser obj)
        {
            var user = await _db.User.SingleOrDefaultAsync((u) => u.UserId == obj.User.UserId); 
            if(user is null)
            {
                return false;
            }
            var hairdresser = await _db.Hairdresser.SingleOrDefaultAsync((u) => u.HairdresserId == obj.Hairdresser.HairdresserId); 
            if(hairdresser is null)
            {
                return false;
            }

            obj.User = user;
            obj.Hairdresser = hairdresser;
            await _db.AddAsync(obj);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var fav = await _db.FavouriteHairdresser.SingleOrDefaultAsync((f) => f.FavouriteHairdresserId == id); 
            if(fav is null)
            {
                return false;
            }
            _db.Entry(fav).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
            return true;
        }

        public Task<IEnumerable<FavouriteHairdresser>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<FavouriteHairdresser> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(FavouriteHairdresser obj)
        {
            throw new NotImplementedException();
        }
    }
}
