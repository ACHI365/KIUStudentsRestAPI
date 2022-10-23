using KIUStudentsAPI.Modules;
using Microsoft.EntityFrameworkCore;

namespace KIUStudentsAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options){}

    public DbSet<KIUStudent> KiuStudents { get; set; }
    
}