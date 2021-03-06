﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HLFApplication.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<HLFApplication.Models.Protein> Proteins { get; set; }

       

        public System.Data.Entity.DbSet<HLFApplication.Models.Multivitamin> Multivitamins { get; set; }

        public System.Data.Entity.DbSet<HLFApplication.Models.Accessory> Accessories { get; set; }

        public System.Data.Entity.DbSet<HLFApplication.Models.Rating> Ratings { get; set; }

        public System.Data.Entity.DbSet<HLFApplication.Models.BuyProtein> BuyProteins { get; set; }

        public System.Data.Entity.DbSet<HLFApplication.Models.Comment> Comments { get; set; }

        public System.Data.Entity.DbSet<HLFApplication.Models.RatingAccessory> RatingAccessories { get; set; }

        public System.Data.Entity.DbSet<HLFApplication.Models.CommentAccessory> CommentAccessories { get; set; }

        public System.Data.Entity.DbSet<HLFApplication.Models.BuyAccessory> BuyAccessories { get; set; }

        public System.Data.Entity.DbSet<HLFApplication.Models.BuyMultivitamin> BuyMultivitamins { get; set; }

        public System.Data.Entity.DbSet<HLFApplication.Models.CommentMultivitamin> CommentMultivitamins { get; set; }

        public System.Data.Entity.DbSet<HLFApplication.Models.RatingMultivitamin> RatingMultivitamins { get; set; }
    }
}