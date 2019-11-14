using IoC_DI.IRepository;
using System;

namespace IoC_DI.Repository
{
    public class UserRepository : IUserRepository
    {
        public UserRepository(Others others)
        { 

        }
        public string GetUserName()
        {
            return "你好，XXX！";
        }
    }
}
