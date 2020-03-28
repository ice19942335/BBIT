using System;
using System.Collections.Generic;
using System.Text;
using BBIT.DAL.Context;
using Interfaces.Sql.Flat;

namespace Services.Sql.Flat
{
    public class SqlFlatService : ISqlFlatService
    {
        private readonly BBITContext _dbContext;

        public SqlFlatService(BBITContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
