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
    public class UserService : IGeneric<User>
    {
        private readonly HairdresserDbContext _db;
        public UserService(HairdresserDbContext db)
        {
            this._db = db;
        }
        public async Task<bool> Add(User obj)
        {
            await _db.AddAsync(obj);
            await _db.SaveChangesAsync();
            return true;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _db.User.ToListAsync();
            Parallel.ForEach(users, user =>
             {
                 user.ReservationsHistory = _db.Reservation.Where((res) => res.User.UserId == user.UserId);
                 user.FavouritesHairdresser = _db.FavouriteHairdresser.Where((res) => res.User.UserId == user.UserId);
             });
            return users;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _db.User.SingleOrDefaultAsync((u) => u.UserId == id);
            user.ReservationsHistory = await _db.Reservation.Where((res) => res.User.UserId == id).ToListAsync();
            user.FavouritesHairdresser = await _db.FavouriteHairdresser.Where((res) => res.User.UserId == id).ToListAsync();
            return user;
        }

        public async Task<bool> Update(User obj)
        {
            var userOld = await _db.User.SingleOrDefaultAsync((u) => u.UserId == obj.UserId);
            if (userOld is null) return false;

            _db.Entry(obj).State = EntityState.Detached;
            _db.Update(obj);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
