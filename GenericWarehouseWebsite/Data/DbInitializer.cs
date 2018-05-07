using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericWarehouseWebsite.Models;

namespace GenericWarehouseWebsite.Data
{
    public class DbInitializer
    {
        public static void AccountInitialize(AccountContext context)
        {
            context.Database.EnsureCreated();

            if (context.Account.Any())
            {
                return;
            }

            var accounts = new Account[]
            {
                new Account
                {
                    EmployeeNumber = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    IsManager = true
                },
                new Account
                {
                    EmployeeNumber = 2,
                    FirstName = "Jane",
                    LastName = "Doe",
                    IsManager = true
                },
                new Account
                {
                    EmployeeNumber = 3,
                    FirstName = "Bob",
                    LastName = "Ryan",
                    IsManager = false
                },
                new Account
                {
                    EmployeeNumber = 4,
                    FirstName = "Kelly",
                    LastName = "John",
                    IsManager = false
                }
            };
            foreach (Account s in accounts)
            {
                context.Account.Add(s);
            }
            context.SaveChanges();
        }
        public static void Initialize(WarehouseContext context)
        {
            context.Database.EnsureCreated();

            if (context.Components.Any() && context.Tools.Any())// Check to see if both the tools and componets table have data
            {
                return; //DB has been seeded
            }
            #region Seeding Component Table
            var components = new Component[]
            {
                new Component
                {
                    PartNumber = "240242-01",
                    Name = "MAGNET DEFUSER",
                    Description = "LCS50-150 MOD2263",
                    Bin = "14F",
                    Quantity = 100,
                    Cost = 50M
                },
                new Component
                {
                    PartNumber = "63589-02",
                    Name = "CROSS ROLLER GUIDE RAIL",
                    Description = "LRX 12 R100 BPS2",
                    Bin = "13F",
                    Quantity = 100,
                    Cost = 5.25M
                },
                new Component
                {
                    PartNumber = "53006-00",
                    Name = "SCREW, SHC, M2x12 LG.",
                    Description = "M2x0.4x12 LG",
                    Bin = "14F",
                    Quantity = 100,
                    Cost = 0.04M
                }
            };
            foreach (Component s in components)
            {
                context.Components.Add(s);
            }
            context.SaveChanges();
            #endregion

            #region Seeding Tools
            var tools = new Tool[]
            {
                new Tool
                {
                    PartNumber = "541354-04",
                    Name = "PScrewDriver",
                    Description = "Phillips Screw Driver Cross Pattern",
                    Bin = "45A",
                    Quantity = 100,
                    Cost = 2M
                },

                new Tool
                {
                    PartNumber = "34654-84",
                    Name = "EDrill A23",
                    Description = "Electric Drill With reverse mode",
                    Bin = "75F",
                    Quantity = 20,
                    Cost = 80M
                },

                new Tool
                {
                    PartNumber = "8745-88",
                    Name = "Magnetic Stripper",
                    Description = "Strips magnets",
                    Bin = "58A",
                    Quantity = 1000,
                    Cost = .05M
                }
            };

            foreach (Tool w in tools)
            {
                context.Tools.Add(w);
            }
            context.SaveChanges();

            #endregion
        }
    }
}