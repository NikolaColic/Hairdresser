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
    public class UserService : IUserService
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

        public async Task<User> Authenticate(string username, string password)
        {
            var user = await _db.User.SingleOrDefaultAsync((u) => u.Username == username && u.Password == password);
            if(user == null)
            {
                return null;
            }
            user.ReservationsHistory = await _db.Reservation.Where((res) => res.User.UserId == user.UserId).Include(el => el.Hairdresser).ToListAsync();
            user.FavouritesHairdresser = await _db.FavouriteHairdresser.Where((res) => res.User.UserId == user.UserId).Include(el => el.Hairdresser).ToListAsync();
            user.HairdressersOwner = _db.Hairdresser.Where((hairdresser) => hairdresser.Owner.UserId == user.UserId).ToList();

            return user;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _db.User.SingleOrDefaultAsync((user) => user.UserId == id);
            if (user is null)
            {
                return false;
            }
            _db.Reservation.Where((res) => res.User.UserId == user.UserId)
                .ToList().ForEach((res) => _db.Entry(res).State = EntityState.Deleted);

            _db.FavouriteHairdresser.Where((res) => res.User.UserId == user.UserId)
                .ToList().ForEach((res) => _db.Entry(res).State = EntityState.Deleted);

            _db.Entry(user).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _db.User.ToListAsync();
            foreach(var user in users)
            {
                 user.ReservationsHistory = _db.Reservation.Where((res) => res.User.UserId == user.UserId).ToList();
                 user.FavouritesHairdresser = _db.FavouriteHairdresser.Where((res) => res.User.UserId == user.UserId).ToList();
                 user.HairdressersOwner = _db.Hairdresser.Where((hairdresser) => hairdresser.Owner.UserId == user.UserId).ToList();
            }
            return users;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _db.User.SingleOrDefaultAsync((u) => u.UserId == id);
            if(user == null)
            {
                return user;
            }
            user.ReservationsHistory = await _db.Reservation.Where((res) => res.User.UserId == id).ToListAsync();
            user.FavouritesHairdresser = await _db.FavouriteHairdresser.Where((res) => res.User.UserId == id).ToListAsync();
            return user;
        }

        public async Task<bool> Update(User obj)
        {
            var userOld = await _db.User.SingleOrDefaultAsync((u) => u.UserId == obj.UserId);
            if (userOld is null) return false;
            var userNew = new User()
            {
                Date = obj.Date,
                Email = obj.Email,
                ImageUrl = obj.ImageUrl,
                Name = obj.Name,
                UserId = obj.UserId,
                Number = obj.Number,
                Password = obj.Password,
                Username = obj.Username
            };
            _db.Entry(userOld).State = EntityState.Detached;
            _db.Update(userNew);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
