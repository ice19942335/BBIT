using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBIT.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Services.Data.DefaultDataInitialization
{
    public class TestDbDataInitialization
    {
        private readonly BBITContext _dbContext;



        public TestDbDataInitialization(BBITContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Initialize()
        {
            if(_dbContext.Houses.Any())
                return;

            //Call order is important
            await AddHouses();
            await AddFlatsToTheHouses();
            await AddTenantToFlats();
        }

        private async Task AddHouses()
        {
            var houses = new List<BBIT.Domain.Entities.House.House>
            {
                new BBIT.Domain.Entities.House.House
                {
                    Id = Guid.NewGuid(),
                    HouseNumber = "1",
                    StreetName = "High Street",
                    City = "London",
                    Country = "United Kingdom",
                    PostCode = "E1 7AD"
                },
                new BBIT.Domain.Entities.House.House
                {
                    Id = Guid.NewGuid(),
                    HouseNumber = "2",
                    StreetName = "High Street",
                    City = "London",
                    Country = "United Kingdom",
                    PostCode = "E1 7AD"
                },
                new BBIT.Domain.Entities.House.House
                {
                    Id = Guid.NewGuid(),
                    HouseNumber = "3",
                    StreetName = "High Street",
                    City = "London",
                    Country = "United Kingdom",
                    PostCode = "E1 7AD"
                },
            };

            await _dbContext.Houses.AddRangeAsync(houses);
            await _dbContext.SaveChangesAsync();
        }

        private async Task AddFlatsToTheHouses()
        {
            var flats = new List<BBIT.Domain.Entities.Flat.Flat>()
            {
                //House"1"flats
                new BBIT.Domain.Entities.Flat.Flat
                {
                    Id = Guid.NewGuid(),
                    FlatNumber = "1",
                    Floor = 1,
                    AmountOfRooms = 5,
                    AmountOfTenants = 1,
                    TotalArea = 300,
                    HouseRoom = 400,
                    House = _dbContext.Houses.First(x => x.HouseNumber == "1")
                },
                new BBIT.Domain.Entities.Flat.Flat
                {
                    Id = Guid.NewGuid(),
                    FlatNumber = "2",
                    Floor = 1,
                    AmountOfRooms = 5,
                    AmountOfTenants = 1,
                    TotalArea = 300,
                    HouseRoom = 400,
                    House = _dbContext.Houses.First(x => x.HouseNumber == "1")
                },
                new BBIT.Domain.Entities.Flat.Flat
                {
                    Id = Guid.NewGuid(),
                    FlatNumber = "3",
                    Floor = 1,
                    AmountOfRooms = 5,
                    AmountOfTenants = 1,
                    TotalArea = 300,
                    HouseRoom = 400,
                    House = _dbContext.Houses.First(x => x.HouseNumber == "1")
                },
                //House"2"flats
                new BBIT.Domain.Entities.Flat.Flat
                {
                    Id = Guid.NewGuid(),
                    FlatNumber = "1",
                    Floor = 1,
                    AmountOfRooms = 5,
                    AmountOfTenants = 1,
                    TotalArea = 300,
                    HouseRoom = 400,
                    House = _dbContext.Houses.First(x => x.HouseNumber == "2")
                },
                new BBIT.Domain.Entities.Flat.Flat
                {
                    Id = Guid.NewGuid(),
                    FlatNumber = "2",
                    Floor = 1,
                    AmountOfRooms = 5,
                    AmountOfTenants = 1,
                    TotalArea = 300,
                    HouseRoom = 400,
                    House = _dbContext.Houses.First(x => x.HouseNumber == "2")
                },
                new BBIT.Domain.Entities.Flat.Flat
                {
                    Id = Guid.NewGuid(),
                    FlatNumber = "3",
                    Floor = 1,
                    AmountOfRooms = 5,
                    AmountOfTenants = 1,
                    TotalArea = 300,
                    HouseRoom = 400,
                    House = _dbContext.Houses.First(x => x.HouseNumber == "2")
                },
                //House 3 flats
                new BBIT.Domain.Entities.Flat.Flat
                {
                    Id = Guid.NewGuid(),
                    FlatNumber = "1",
                    Floor = 1,
                    AmountOfRooms = 5,
                    AmountOfTenants = 1,
                    TotalArea = 300,
                    HouseRoom = 400,
                    House = _dbContext.Houses.First(x => x.HouseNumber == "3")
                },
                new BBIT.Domain.Entities.Flat.Flat
                {
                    Id = Guid.NewGuid(),
                    FlatNumber = "2",
                    Floor = 1,
                    AmountOfRooms = 5,
                    AmountOfTenants = 1,
                    TotalArea = 300,
                    HouseRoom = 400,
                    House = _dbContext.Houses.First(x => x.HouseNumber == "3")
                },
                new BBIT.Domain.Entities.Flat.Flat
                {
                    Id = Guid.NewGuid(),
                    FlatNumber = "3",
                    Floor = 1,
                    AmountOfRooms = 5,
                    AmountOfTenants = 1,
                    TotalArea = 300,
                    HouseRoom = 400,
                    House = _dbContext.Houses.First(x => x.HouseNumber == "3")
                },
            };

            await _dbContext.Flats.AddRangeAsync(flats);
            await _dbContext.SaveChangesAsync();
        }

        private async Task AddTenantToFlats()
        {
            var tenants = new List<BBIT.Domain.Entities.Tenant.Tenant>()
            {
                new BBIT.Domain.Entities.Tenant.Tenant
                {
                    Id = Guid.NewGuid(),
                    Name = "Tenant1",
                    Surname = "Surname",
                    PersonalCode = "12345",
                    DateOfBirth = DateTime.Today,
                    PhoneNumber = "+37112345678",
                    Email = "email@mail.com",
                    Flat = _dbContext.Flats
                        .Include(x => x.House)
                        .First(x => x.House.HouseNumber == "1" && x.FlatNumber == "1")
                },
                new BBIT.Domain.Entities.Tenant.Tenant
                {
                    Id = Guid.NewGuid(),
                    Name = "Tenant2",
                    Surname = "Surname",
                    PersonalCode = "12345",
                    DateOfBirth = DateTime.Today,
                    PhoneNumber = "+37112345678",
                    Email = "email@mail.com",
                    Flat = _dbContext.Flats
                        .Include(x => x.House)
                        .First(x => x.House.HouseNumber == "1" && x.FlatNumber == "2")
                },
                new BBIT.Domain.Entities.Tenant.Tenant
                {
                    Id = Guid.NewGuid(),
                    Name = "Tenant3",
                    Surname = "Surname",
                    PersonalCode = "12345",
                    DateOfBirth = DateTime.Today,
                    PhoneNumber = "+37112345678",
                    Email = "email@mail.com",
                    Flat = _dbContext.Flats
                        .Include(x => x.House)
                        .First(x => x.House.HouseNumber == "1" && x.FlatNumber == "3")
                },
                new BBIT.Domain.Entities.Tenant.Tenant
                {
                    Id = Guid.NewGuid(),
                    Name = "Tenant4",
                    Surname = "Surname",
                    PersonalCode = "12345",
                    DateOfBirth = DateTime.Today,
                    PhoneNumber = "+37112345678",
                    Email = "email@mail.com",
                    Flat = _dbContext.Flats
                        .Include(x => x.House)
                        .First(x => x.House.HouseNumber =="2"&& x.FlatNumber == "2")
                },
                new BBIT.Domain.Entities.Tenant.Tenant
                {
                    Id = Guid.NewGuid(),
                    Name = "Tenant5",
                    Surname = "Surname",
                    PersonalCode = "12345",
                    DateOfBirth = DateTime.Today,
                    PhoneNumber = "+37112345678",
                    Email = "email@mail.com",
                    Flat = _dbContext.Flats
                        .Include(x => x.House)
                        .First(x => x.House.HouseNumber =="2"&& x.FlatNumber == "2")
                },
                new BBIT.Domain.Entities.Tenant.Tenant
                {
                    Id = Guid.NewGuid(),
                    Name = "Tenant6",
                    Surname = "Surname",
                    PersonalCode = "12345",
                    DateOfBirth = DateTime.Today,
                    PhoneNumber = "+37112345678",
                    Email = "email@mail.com",
                    Flat = _dbContext.Flats
                        .Include(x => x.House)
                        .First(x => x.House.HouseNumber =="2"&& x.FlatNumber == "3")
                },
                new BBIT.Domain.Entities.Tenant.Tenant
                {
                    Id = Guid.NewGuid(),
                    Name = "Tenant7",
                    Surname = "Surname",
                    PersonalCode = "12345",
                    DateOfBirth = DateTime.Today,
                    PhoneNumber = "+37112345678",
                    Email = "email@mail.com",
                    Flat = _dbContext.Flats
                        .Include(x => x.House)
                        .First(x => x.House.HouseNumber == "3" && x.FlatNumber == "1")
                },
                new BBIT.Domain.Entities.Tenant.Tenant
                {
                    Id = Guid.NewGuid(),
                    Name = "Tenant8",
                    Surname = "Surname",
                    PersonalCode = "12345",
                    DateOfBirth = DateTime.Today,
                    PhoneNumber = "+37112345678",
                    Email = "email@mail.com",
                    Flat = _dbContext.Flats
                        .Include(x => x.House)
                        .First(x => x.House.HouseNumber == "3" && x.FlatNumber == "2")
                },
                new BBIT.Domain.Entities.Tenant.Tenant
                {
                    Id = Guid.NewGuid(),
                    Name = "Tenant9",
                    Surname = "Surname",
                    PersonalCode = "12345",
                    DateOfBirth = DateTime.Today,
                    PhoneNumber = "+37112345678",
                    Email = "email@mail.com",
                    Flat = _dbContext.Flats
                        .Include(x => x.House)
                        .First(x => x.House.HouseNumber == "3" && x.FlatNumber == "3")
                },
            };

            await _dbContext.Tenants.AddRangeAsync(tenants);
            await _dbContext.SaveChangesAsync();
        }
    }
}