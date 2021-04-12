using System;
using System.Collections.Generic;
using vacay_csharp.Models;
using vacay_csharp.Repositories;

namespace vacay_csharp.Services
{
    public class TripsService
    {
        private readonly TripsRepository _trepo;

        public TripsService(TripsRepository trepo)
        {
            _trepo = trepo;
        }

        internal IEnumerable<Trip> Get()
        {
            return _trepo.Get();
        }

        internal Trip Create(Trip newTrip)
        {
            return _trepo.Create(newTrip);
        }

        internal Trip GetById(int id)
        {
            Trip data = _trepo.GetById(id);
            if (data == null)
            {
                throw new Exception("Invalid Id");
            }
            return data;
        }

        internal Trip Edit(Trip updated)
        {
            Trip data = GetById(updated.Id);
            data.Price = updated.Price != null ? updated.Price : data.Price;
            data.Days = updated.Days != null ? updated.Days : data.Days;
            data.EndDestination = updated.EndDestination != null ? updated.EndDestination : data.EndDestination;
            data.Category = updated.Category != null ? updated.Category : data.Category;


            return _trepo.Edit(data);
        }

        internal string Delete(int id)
        {
            GetById(id);
            _trepo.Delete(id);
            return "Trip Deleted";
        }
    }
}