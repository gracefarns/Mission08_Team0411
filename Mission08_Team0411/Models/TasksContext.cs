using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0411.Models;

public partial class TasksContext : DbContext
{
    public TasksContext()
    {
    }

    public TasksContext(DbContextOptions<TasksContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ToDo> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=tasks.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).ValueGeneratedNever();
        });

        modelBuilder.Entity<ToDo>(entity =>
        {
            entity.HasOne(d => d.Category).WithMany(p => p.Tasks).HasForeignKey(d => d.CategoryId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
