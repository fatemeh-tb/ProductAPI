using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductShop.Identity;

namespace ProductShop.models;

public class UserAuthDbContext: IdentityDbContext<ApplicationUser>
{
    public UserAuthDbContext(DbContextOptions<UserAuthDbContext> options): base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}