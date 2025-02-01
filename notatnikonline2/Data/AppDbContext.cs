using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Note> Notes { get; set; }
}

public class Note
{
    [Key]
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Content { get; set; }
}
