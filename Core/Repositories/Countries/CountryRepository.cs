﻿using Core.Models;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Countries {
    public class CountryRepository : RepositoryBase<State>, ICountryRepository {
        public IQueryable<State> Index() {
            var lista = from p in base.FindAll() select p;
            return lista;
        }

        public State Show(State model, int id) {
            return base.Find(id);
        }

        public State Store(State model) {
            return base.Save(model);
        }

        public State Update(State model) {
            return base.Edit(model);
        }
    }
}
