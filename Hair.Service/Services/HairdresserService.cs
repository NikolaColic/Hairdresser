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

            var socialNetworks = obj.SocialNetworks;
            obj.SocialNetworks = new List<SocialHairdresser>();
            await _db.AddAsync(obj);
            await _db.SaveChangesAsync();
            //Vratiti deo da se tek posle dodaje za socialnetwork


            //var addedObj = await _db.Hairdresser.SingleOrDefaultAsync((hair) => hair.TaxId == obj.TaxId);
            //if (addedObj is null)
            //{
            //    return false;
            //}

            //socialNetworks.ToList().ForEach(async (social) =>
            //{
            //    social.Hairdresser = addedObj;
            //    var socialNetwork = await _db.SocialNetwork.SingleOrDefaultAsync((el) => el.SocialNetworkId == social.SocialNetwork.SocialNetworkId);
            //    social.SocialNetwork = socialNetwork;
            //    await _db.AddAsync(social);
            //});
            //await _db.SaveChangesAsync();
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

            _db.FavouriteHairdresser.Where((res) => res.Hairdresser.HairdresserId == hairdresser.HairdresserId)
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

            foreach(var hairdresser in hairdressers)
            {
                hairdresser.Reservations = _db.Reservation.Where((res) => res.Hairdresser.HairdresserId == hairdresser.HairdresserId).Include((el)=> el.User).ToList() ;
                hairdresser.Images =   _db.HairdresserImage.Where((res) => res.Hairdresser.HairdresserId == hairdresser.HairdresserId).ToList();
                hairdresser.SocialNetworks =  _db.SocialHairdresser.Where((res) => res.Hairdresser.HairdresserId == hairdresser.HairdresserId).Include((el)=> el.SocialNetwork).ToList();
            }
            return hairdressers;

        }

        public async Task<Hairdresser> GetById(int id)
        {
            var hairdresser = await _db.Hairdresser
                .Include((hair) => hair.Owner)
                .Include((hair) => hair.Municipality)
                .SingleOrDefaultAsync((hair) => hair.HairdresserId == id);
            if (hairdresser is null) return hairdresser;

            hairdresser.Reservations = _db.Reservation.Where((res) => res.Hairdresser.HairdresserId == hairdresser.HairdresserId).ToList();
           
            hairdresser.Images = _db.HairdresserImage.Where((res) => res.Hairdresser.HairdresserId == hairdresser.HairdresserId).ToList();
            
            hairdresser.SocialNetworks = _db.SocialHairdresser.Where((res) => res.Hairdresser.HairdresserId == hairdresser.HairdresserId).ToList();
            
            return hairdresser;
        }

        public async Task<bool> Update(Hairdresser obj)
        {
            var oldObj = await _db.Hairdresser.SingleOrDefaultAsync((el) => el.HairdresserId == obj.HairdresserId);
            if(oldObj is null)
            {
                return false;
            }
            var owner = await _db.User.SingleOrDefaultAsync((user) => user.UserId == obj.Owner.UserId);
            if (owner is null)
            {
                return false;
            }
            var municipality = await _db.Municipality.SingleOrDefaultAsync((mun) => mun.MunicipalityId == obj.Municipality.MunicipalityId);
            if (municipality is null)
            {
                return false;
            }
            obj.Owner = owner;
            obj.Municipality = municipality;

            _db.Entry(oldObj).State = EntityState.Detached;
            _db.Update(obj);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
