﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using evoWatch.Database.Models;

namespace evoWatch.Database.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<List<User>> GetUsersAsync();
    }
}
