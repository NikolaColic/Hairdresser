using Hair.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hair.Service.Interface
{
    public interface IUserService : IGeneric<User>
    {
        public Task<User> Authenticate(string username, string password);
    }
}
