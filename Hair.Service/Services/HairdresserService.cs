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
    public class HairdresserService : IGeneric<Hairdresser>
    {
        private readonly HairdresserDbContext _db;
        public HairdresserService(HairdresserDbContext db)
        {
            this._db = db;
        }
        public async Task<bool> Add(Hairdresser obj)
        {
            var owner = await _db.User.SingleOrDefaultAsync((user) => user.UserId == obj.Owner.UserId); 
            if(owner is null)
            {
                return false;
            }
            var municipality = await _db.Municipality.SingleOrDefaultAsync((mun) => mun.MunicipalityId == obj.Municipality.MunicipalityId); 
            if(municipality is null)
            {
                return false;
            }
            obj.Owner = owner;
            obj.Municipality = municipality;

            await _db.AddAsync(obj);

            var addedObj = await _db.Hairdresser.SingleOrDefaultAsync((hair) => hair.TaxId == obj.TaxId);
            if(addedObj is null)
            {
                return false; 
            }
            if(obj.Images != null && obj.Images.Any())
            {
                obj.Images.ToList().ForEach(async (image) =>
                {
                    image.Hairdresser = addedObj;
                    await _db.AddAsync(image);
                });
            }
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var hairdresser = await _db.Hairdresser.SingleOrDefaultAsync((hair) => hair.HairdresserId == id); 
            if(hairdresser is null)
            {
                return false;
            }
            _db.Reservation.Where((res) => res.Hairdresser.HairdresserId == hairdresser.HairdresserId)
                .ToList().ForEach((res) => _db.Entry(res).State = EntityState.Deleted);
            _db.HairdresserImage.Where((res) => res.Hairdresser.HairdresserId == hairdresser.HairdresserId)
                .ToList().ForEach((res) => _db.Entry(res).State = EntityState.Deleted);
            _db.SocialHairdresser.Where((res) => res.Hairdresser.HairdresserId == hairdresser.HairdresserId)
                .ToList().ForEach((res) => _db.Entry(res).State = EntityState.Deleted);

            _db.Entry(hairdresser).State = EntityState.Deleted;
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Hairdresser>> GetAll()
        {
            var hairdressers = await  _db.Hairdresser
                .Include((el) => el.Owner)
                .Include((el) => el.Municipality)
                .ToListAsync();

            Parallel.ForEach(hairdressers, hairdresser =>
            {
                hairdresser.Reservations =  _db.Reservation.Where((res) => res.Hairdresser.HairdresserId == hairdresser.HairdresserId);
                hairdresser.Images =  _db.HairdresserImage.Where((res) => res.Hairdresser.HairdresserId == hairdresser.HairdresserId);
                hairdresser.SocialNetworks = _db.SocialHairdresser.Where((res) => res.Hairdresser.HairdresserId == hairdresser.HairdresserId);

            });

            return hairdressers;

        }

        public async Task<Hairdresser> GetById(int id)
        {
            var hairdresser = await _db.Hairdresser.SingleOrDefaultAsync((hair) => hair.HairdresserId == id);
            if (hairdresser is null) return hairdresser;
            hairdresser.Reservations = _db.Reservation.Where((res) => res.Hairdresser.HairdresserId == hairdresser.HairdresserId);
            hairdresser.Images = _db.HairdresserImage.Where((res) => res.Hairdresser.HairdresserId == hairdresser.HairdresserId);
            hairdresser.SocialNetworks = _db.SocialHairdresser.Where((res) => res.Hairdresser.HairdresserId == hairdresser.HairdresserId);
            return hairdresser;
        }

        public Task<bool> Update(Hairdresser obj)
        {
            throw new NotImplementedException();
        }
    }
}
