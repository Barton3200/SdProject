﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace DataAccess {
    public interface IUserRepository : IBaseRepository {
        User GetUser(int id);
    }
}