using Microsoft.EntityFrameworkCore;

namespace VacineMais.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            var delete = context.Database.EnsureDeleted();

            if (delete)
            {
                //context.Database.EnsureCreated();

                context.Database.Migrate();
            }

        }
    }
}
