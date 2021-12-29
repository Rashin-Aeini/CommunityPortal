using Microsoft.EntityFrameworkCore;

namespace CommunityPortal.Models.Data
{
    public static class ContextInitializer
    {
        public static void Initialize(DbContext context)
        {
            context.Database.Migrate();
        }
    }
}
