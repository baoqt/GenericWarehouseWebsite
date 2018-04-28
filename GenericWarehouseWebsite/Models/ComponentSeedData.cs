using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GenericWarehouseWebsite.Models
{
    public class ComponentSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ComponentContext(
                serviceProvider.GetRequiredService<DbContextOptions<ComponentContext>>()))
            {
                if (context.Component.Any())
                {
                    return;
                }

                context.Component.AddRange(
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
                    },

                    new Component
                    {
                        PartNumber = "42508-00",
                        Name = "LINEAR GUIDE",
                        Description = "LWLFC14C1R45BT1P",
                        Bin = "5C",
                        Quantity = 100,
                        Cost = 9.98M
                    },

                    new Component
                    {
                        PartNumber = "110005-01",
                        Name = "BODY",
                        Description = "LXY25-25-5",
                        Bin = "2B",
                        Quantity = 100,
                        Cost = 100M
                    },

                    new Component
                    {
                        PartNumber = "675019-00",
                        Name = "COOLING FAN",
                        Description = "MECHATRONICS #G4010E24B-RSR, 40mm x 40mm, BLACK, 24 V, 0.04 A, 0.96 W, 4800 RPM, 5 CFM, 17 grams",
                        Bin = "14F",
                        Quantity = 100,
                        Cost = 50M
                    }
                );
            }
        }
    }
}
