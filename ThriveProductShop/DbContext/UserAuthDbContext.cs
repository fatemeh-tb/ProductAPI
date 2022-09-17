using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductShop.Entities;
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
	    builder.ApplyConfiguration(new RoleConfiguration());

    }

}