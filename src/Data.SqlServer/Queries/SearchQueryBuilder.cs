namespace Data.SqlServer.Queries;

using Domain.Model;

internal static class SearchQueryBuilder
{
    internal static IQueryable<Domain.Model.Entities.Auction> BuildSearchQuery(SearchContext searchContext, SqlDbContext db)
    {
        IQueryable<Domain.Model.Entities.Auction> query = db.Auctions;

        //if (searchContext.Type != Domain.Model.Enum.Type.None)
        //{
        //    query = query.Where(c => c.Type == searchContext.Type);
        //}

        return query;
    }
}