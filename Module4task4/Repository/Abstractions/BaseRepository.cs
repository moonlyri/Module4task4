using AutoMapper;

namespace Module4task4.Repository.Abstractions;

public abstract class BaseRepository
{
    protected BaseRepository(ApplicationDbContext dbContext, IMapper mapper)
    {
        DbContext = dbContext;
        Mapper = mapper;
    }

    protected ApplicationDbContext DbContext { get; set; }

    protected IMapper Mapper { get; set; }
}