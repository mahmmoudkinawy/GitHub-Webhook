namespace API.DbContexts;
public class WebhookDbContext : DbContext
{
    public WebhookDbContext(DbContextOptions<WebhookDbContext> options) : base(options)
    { }

    public DbSet<CommentEntity> Comments { get; set; }
}
