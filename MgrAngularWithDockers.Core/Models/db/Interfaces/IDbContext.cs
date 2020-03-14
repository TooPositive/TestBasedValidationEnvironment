﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MgrAngularWithDockers.Core.Models.db.Interfaces
{
    public interface IDbContext
    {
        DbSet<T> Set<T>() where T : class;

    }
}
