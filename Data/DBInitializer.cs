using trial1.Models;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using trial1.Data;

namespace trial1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TruckDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Trucks.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Truck[]
            {
            new Truck{ID=1,NoPol="B 9514 IJ",Tonase=15,Status=true},
            new Truck{ID=2,NoPol="B 9512 IJ",Tonase=15,Status=true},
            new Truck{ID=3,NoPol="B 9513 IJ",Tonase=15,Status=true},
            new Truck{ID=4,NoPol="B 9515 IJ",Tonase=15,Status=true},

            };
            foreach (Truck s in students)
            {
                context.Trucks.Add(s);
            }
            context.SaveChanges();

            var karyawans = new Karyawan[]
            {
            new Karyawan{ID="1117",Nama="Wahyu Supriyadi",Gender=Gender.Male},
            new Karyawan{ID="1118",Nama="Wahyu Supriyadi2",Gender=Gender.Male},
            new Karyawan{ID="1119",Nama="Wahyu Supriyadi3",Gender=Gender.Male}

            };
            foreach (Karyawan c in karyawans)
            {
                context.Karyawans.Add(c);
            }
            context.SaveChanges();

            var kirims = new Kirim[]
            {
            new Kirim{KirimID=1,TruckID=1,KaryawanNIK="1117"},
            new Kirim{KirimID=2,TruckID=2,KaryawanNIK="1118"},
            new Kirim{KirimID=3,TruckID=3,KaryawanNIK="1119"},
            new Kirim{KirimID=4,TruckID=1,KaryawanNIK="1117"},
            new Kirim{KirimID=5,TruckID=2,KaryawanNIK="1118"}

            };
            foreach (Kirim e in kirims)
            {
                context.Kirims.Add(e);
            }
            context.SaveChanges();
        }
    }
}