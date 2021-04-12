using System;
using System.Collections.Generic;
using vacay_csharp.Models;
using vacay_csharp.Repositories;

namespace vacay_csharp.Services
{
    public class CruisesService
    {

        private readonly CruisesRepository _crepo;

        public CruisesService(CruisesRepository crepo)
        {
            _crepo = crepo;
        }

        internal IEnumerable<Cruise> Get()
        {
            return _crepo.Get();
        }

        internal Cruise Create(Cruise newCruise)
        {
            return _crepo.Create(newCruise);
        }

        internal Cruise GetById(int id)
        {
            Cruise data = _crepo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid ID");
            }
            return data;
        }

        internal Cruise Edit(Cruise updated)
        {
            Cruise data = GetById(updated.Id);
            data.Price = updated.Price != null ? updated.Price : data.Price;
            data.Days = updated.Days != null ? updated.Days : data.Days;
            data.StartDestination = updated.StartDestination != null ? updated.StartDestination : data.StartDestination;
            data.Category = updated.Category != null ? updated.Category : data.Category;

            return _crepo.Edit(data);
        }

        internal string Delete(int id)
        {
            GetById(id);
            _crepo.Delete(id);
            return "Cruise Deleted";
        }
    }
}