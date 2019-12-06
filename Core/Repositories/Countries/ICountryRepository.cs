﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Countries {
    public interface ICountryRepository {
        IQueryable<State> Index();
        State Show(State model, int id);
        State Store(State model);
        State Update(State model);
    }
}