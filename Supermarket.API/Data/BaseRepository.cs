namespace Supermarket.API.Data
{
    public abstract class BaseRepository
    {
        protected readonly SupermarketDbContext _context;

        public BaseRepository(SupermarketDbContext context)
        {
            _context = context;
        }
    }
}
