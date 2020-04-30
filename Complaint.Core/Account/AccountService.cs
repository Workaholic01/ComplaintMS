using Complaint.Data;
using Complaint.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Complaint.Core.Account
{
    public class AccountService : IAccountService
    {
        private readonly RepositoryContext _repositoryContext;

        public AccountService(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        public bool Login(User user)
        {
            User userFound = _repositoryContext.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
            if (userFound == null)
                return false;

            return true;
        }
    }
}
