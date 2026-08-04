using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Parkolóhely_foglaló.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Parkolóhely_foglaló.DB;

public class ParkingDBContext: DbContext
{
    public DbSet<ParkingSpot> Spots { get; set; }
    public DbSet<ParkingSpotReservation> Reservations { get; set; }

    public string DbPath { get; }

    public ParkingDBContext()
    {
        DbPath = @"..\..\..\parking.db";

        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}
