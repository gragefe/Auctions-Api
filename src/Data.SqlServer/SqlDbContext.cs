﻿namespace Data.SqlServer;

using Microsoft.EntityFrameworkCore;

public class SqlDbContext : DbContext
{
    public DbSet<Domain.Model.Entities.Auction> Auctions { get; set; }

    public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}