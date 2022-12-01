namespace Module4task4.Repository.Abstractions;

public abstract class BaseRepository
{
    protected ApplicationDbContext DbContext { get; set; }

    protected BaseRepository(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }
}