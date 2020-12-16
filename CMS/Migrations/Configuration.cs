namespace CMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CMS.Models;
    using Utils;

    internal sealed class Configuration : DbMigrationsConfiguration<CMS.Models.CMSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CMS.Models.CMSDbContext context)
        {

            #region UserRole

            context.UserRole.AddOrUpdate(i => i.Id,
                new UserRole
                {
                    Id = 1,
                    Name = "Administrator",
                    IsAdmin = true
                },
                new UserRole
                {
                    Id = 2,
                    Name = "Seller",
                    IsAdmin = false
                }
            );

            #endregion

            #region Users

            context.UserSys.AddOrUpdate(i => i.Id,
                new UserSys
                {
                    Id = 1,
                    Login = "Administrator",
                    Email = "admin@app.com",
                    UserRoleId = 1,
                    Password = Security.EncryptWithMD5Hash("admin@123")
                },
                new UserSys
                {
                    Id = 2,
                    Login = "Seller1",
                    Email = "seller1@app.com",
                    UserRoleId = 2,
                    Password = Security.EncryptWithMD5Hash("seller@1")
                },
                new UserSys
                {
                    Id = 3,
                    Login = "Seller2",
                    Email = "seller2@app.com",
                    UserRoleId = 2,
                    Password = Security.EncryptWithMD5Hash("seller@2")
                }
            );

            #endregion

            #region Regions

            context.Region.AddOrUpdate(i => i.Id,
                new Region
                {
                    Id = 1,
                    Name = "Rio Grande do Sul"
                },
                new Region
                {
                    Id = 2,
                    Name = "São Paulo"
                },
                new Region
                {
                    Id = 3,
                    Name = "Curitiba"
                }
            );

            #endregion

            #region Cities

            context.City.AddOrUpdate(i => i.Id,
                new City
                {
                    Id = 1,
                    Name = "Porto Alegre",
                    RegionId = 1
                },
                new City
                {
                    Id = 2,
                    Name = "Cotia",
                    RegionId = 2
                },
                new City
                {
                    Id = 3,
                    Name = "São Paulo",
                    RegionId = 2
                },
                new City
                {
                    Id = 4,
                    Name = "Curitiba",
                    RegionId = 3
                }
            );

            #endregion

            #region Classification

            context.Classification.AddOrUpdate(i => i.Id,
                new Classification
                {
                    Id = 1,
                    Name = "VIP"
                },
                new Classification
                {
                    Id = 2,
                    Name = "Regular"
                },
                new Classification
                {
                    Id = 3,
                    Name = "Sporadic"
                }
            );

            #endregion

            #region Gender

            context.Gender.AddOrUpdate(i => i.Id,
                new Gender
                {
                    Id = 1,
                    Name = "Masculine"
                },
                new Gender
                {
                    Id = 2,
                    Name = "Feminine"
                }
            );

            #endregion

            #region Customers

            context.Customer.AddOrUpdate(i => i.Id,
                new Customer
                {
                    Id = 1,
                    Name = "Maurício",
                    Phone = "(11) 95429999",
                    GenderId = 1,
                    CityId = 1,
                    RegionId = 1,
                    LastPurchase = new DateTime(2016, 09, 10),
                    ClassificationId = 1,
                    UserId = 3
                },
                new Customer
                {
                    Id = 2,
                    Name = "Carla",
                    Phone = "(53) 94569999",
                    GenderId = 2,
                    CityId = 1,
                    RegionId = 1,
                    LastPurchase = new DateTime(2015, 10, 10),
                    ClassificationId = 1,
                    UserId = 2
                },
                new Customer
                {
                    Id = 3,
                    Name = "Maria",
                    Phone = "(64) 94518888",
                    GenderId = 2,
                    CityId = 1,
                    RegionId = 1,
                    LastPurchase = new DateTime(2013, 10, 12),
                    ClassificationId = 3,
                    UserId = 2
                },
                new Customer
                {
                    Id = 4,
                    Name = "Douglas",
                    Phone = "(51) 12455555",
                    GenderId = 1,
                    CityId = 1,
                    RegionId = 1,
                    LastPurchase = new DateTime(2016, 5, 5),
                    ClassificationId = 2,
                    UserId = 2
                },
                new Customer
                {
                    Id = 5,
                    Name = "Marta",
                    Phone = "(51) 45788888",
                    GenderId = 2,
                    CityId = 1,
                    RegionId = 1,
                    LastPurchase = new DateTime(2016, 8, 8),
                    ClassificationId = 2,
                    UserId = 3
                },
                new Customer
                {
                    Id = 6,
                    Name = "Jose",
                    Phone = "(11) 873625555",
                    GenderId = 1,
                    CityId = 3,
                    RegionId = 2,
                    LastPurchase = new DateTime(2019, 5, 5),
                    ClassificationId = 2,
                    UserId = 2
                },
                new Customer
                {
                    Id = 7,
                    Name = "Paulo",
                    Phone = "(41) 973625559",
                    GenderId = 1,
                    CityId = 4,
                    RegionId = 3,
                    LastPurchase = new DateTime(2020, 6, 15),
                    ClassificationId = 3,
                    UserId = 2
                },
                new Customer
                {
                    Id = 8,
                    Name = "Edu Borges",
                    Phone = "(41) 873625551",
                    GenderId = 1,
                    CityId = 4,
                    RegionId = 3,
                    LastPurchase = new DateTime(2020, 6, 5),
                    ClassificationId = 1,
                    UserId = 2
                },
                new Customer
                {
                    Id = 9,
                    Name = "Mari",
                    Phone = "(11) 873625551",
                    GenderId = 2,
                    CityId = 3,
                    RegionId = 2,
                    LastPurchase = new DateTime(2019, 10, 22),
                    ClassificationId = 1,
                    UserId = 3
                },
                new Customer
                {
                    Id = 10,
                    Name = "Edna",
                    Phone = "(11) 97867-7281",
                    GenderId = 2,
                    CityId = 2,
                    RegionId = 2,
                    LastPurchase = new DateTime(2020, 10, 25),
                    ClassificationId = 1,
                    UserId = 2
                }
            );

            #endregion

        }
    }
}
