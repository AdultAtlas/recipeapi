using Microsoft.EntityFrameworkCore;
using RecipeSyncData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSyncData
{
    public class RecipeContext : DbContext
    {
        public RecipeContext() :base() { }
        public RecipeContext(DbContextOptions<RecipeContext> options) : base(options) { }

        public virtual DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipes");
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
