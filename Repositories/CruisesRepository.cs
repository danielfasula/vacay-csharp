using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using vacay_csharp.Models;

namespace vacay_csharp.Repositories
{
    public class CruisesRepository
    {
        private readonly IDbConnection _db;

        public CruisesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Cruise> Get()
        {
            string sql = @"SELECT * FROM cruises;";
            return _db.Query<Cruise>(sql);
        }

        internal Cruise Create(Cruise newCruise)
        {
            string sql = @"
            INSERT INTO cruises
            (id, price, days, startDestination, category)
            Values
            (@Id, @Price, @Days, @StartDestination, @Category);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, newCruise);
            newCruise.Id = id;
            return newCruise;
        }

        internal Cruise GetById(int id)
        {
            string sql = @"
            SELECT * FROM cruises WHERE id = @Id;
            ";
            return _db.QueryFirstOrDefault<Cruise>(sql, new { id });
        }

        internal Cruise Edit(Cruise data)
        {
            string sql = @"
            UPDATE cruises
            SET
                price = @Price,
                days = @Days,
                startDestination = @StartDestination,
                category = @Category
            WHERE id = @Id;
            SELECT * FROM cruises WHERE id = @Id;
            ";
            Cruise editedCruise = _db.QueryFirstOrDefault<Cruise>(sql, data);
            return editedCruise;
        }

        internal void Delete(int id)
        {
            string sql = @"DELETE FROM cruises WHERE id = @Id;";
            _db.Execute(sql, new { id });
        }
    }
}