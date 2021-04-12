using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using vacay_csharp.Models;

namespace vacay_csharp.Repositories
{
    public class TripsRepository
    {
        private readonly IDbConnection _db;

        public TripsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Trip> Get()
        {
            string sql = @"SELECT * FROM trips;";
            return _db.Query<Trip>(sql);
        }

        internal Trip Create(Trip newTrip)
        {
            string sql = @"
            INSERT INTO trips
            (id, price, days, endDestination, category)
            Values
            (@Id, @Price, @Days, @EndDestination, @Category);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newTrip);
            newTrip.Id = id;
            return newTrip;
        }

        internal Trip GetById(int id)
        {
            string sql = @"
            SELECT * FROM trips WHERE id = @Id;
            ";
            return _db.QueryFirstOrDefault<Trip>(sql, new { id });
        }

        internal Trip Edit(Trip data)
        {
            string sql = @"
            UPDATE trips
            SET
                price = @Price,
                days = @Days,
                endDestination = @EndDestination,
                category = @Category
            WHERE id = @Id;
            SELECT * FROM trips WHERE id = @Id;
            ";
            Trip editedTrip = _db.QueryFirstOrDefault<Trip>(sql, data);
            return editedTrip;
        }

        internal void Delete(int id)
        {
            string sql = @"DELETE FROM trips WHERE id = @Id";
            _db.Execute(sql, new { id });
        }
    }
}