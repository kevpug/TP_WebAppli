using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TP_Web.Models
{
    public class ContexteIdentité : IdentityDbContext<IdentityUser>
    {
        public ContexteIdentité(DbContextOptions<ContexteIdentité> options)
            : base(options) { }
    }
}
