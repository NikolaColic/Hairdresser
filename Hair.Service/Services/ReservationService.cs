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
    public class ReservationService : IGeneric<Reservation>
    {
        private readonly HairdresserDbContext _db;
        public ReservationService(HairdresserDbContext db)
        {
            this._db = db;
        }
        public async Task<bool> Add(Reservation obj)
        {
            var user = await _db.User.SingleOrDefaultAsync((u) => u.UserId == obj.User.UserId);
            if (user is null) return false;

            var hair = await _db.Hairdresser.SingleOrDefaultAsync((u) => u.HairdresserId == obj.Hairdresser.HairdresserId);
            if (hair is null) return false;

            obj.User = user;
            obj.Hairdresser = hair;
            await _db.AddAsync(obj);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var reservation = await _db.Reservation.SingleOrDefaultAsync((u) => u.ReservationId == id);
            if (reservation is null) return false;

            _db.Entry(reservation).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Reservation>> GetAll()
        {
            var reservations = await _db.Reservation
                .Include((res) => res.User)
                .Include((res) => res.Hairdresser)
                .ToListAsync();
            return reservations;
        }

        public async Task<Reservation> GetById(int id)
        {
            var reservation = await _db.Reservation
                .Include((res) => res.Hairdresser)
                .Include((res) => res.User)
                .SingleOrDefaultAsync((el) => el.ReservationId == id);
            return reservation;
        }

        public async Task<bool> Update(Reservation obj)
        {
            var user = await _db.User.SingleOrDefaultAsync((u) => u.UserId == obj.User.UserId);
            if (user is null) return false;

            var hair = await _db.Hairdresser.SingleOrDefaultAsync((u) => u.HairdresserId == obj.Hairdresser.HairdresserId);
            if (hair is null) return false;

            obj.User = user;
            obj.Hairdresser = hair;
            _db.Entry(obj).State = EntityState.Detached;
            _db.Update(obj);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
