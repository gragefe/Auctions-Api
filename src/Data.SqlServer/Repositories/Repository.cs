namespace Data.SqlServer;

using Data.SqlServer.Queries;
using Domain.Model;
using Domain.Model.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Repository : IRepository
{
    private readonly SqlDbContext _context;

    public Repository(SqlDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateAsync(Domain.Model.Entities.Auction Auction)
    {
        await _context.AddAsync(Auction);
        await _context.SaveChangesAsync();

        return Auction.Id;
    }

    public async Task<Domain.Model.Entities.Auction> GetByIdAsync(Guid id)
    {
        return await _context.Auctions.FindAsync(id);
    }

    public async Task<List<Domain.Model.Entities.Auction>> SearchAsync(SearchContext searchContext)
    {
        return await SearchQueryBuilder.BuildSearchQuery(searchContext, _context).ToListAsync();
    }

    public async Task UpdateAsync(Domain.Model.Entities.Auction Auction)
    {
        _context.Auctions.Update(Auction);
    }
}