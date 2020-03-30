using System;
using System.Collections.Generic;
using System.Text;
using BBIT.DAL.Context;
using Interfaces.Sql.Resident;

namespace Services.Sql.Resident
{
    public class SqlResidentService : ISqlResidentService
    {
        private readonly BBITContext _dbContext;

        public SqlResidentService(BBITContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
