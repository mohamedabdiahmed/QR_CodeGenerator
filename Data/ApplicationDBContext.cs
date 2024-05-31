using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<QrCode> QrCodes { get; set; }
}

public class QrCode
{
    public int Id { get; set; }
    public string Data { get; set; }
    public string QrCodeImage { get; set; }
}
