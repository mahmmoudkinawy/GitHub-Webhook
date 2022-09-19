namespace API.Services;
public class GitHubWebhookService : WebhookEventProcessor
{
    private readonly WebhookDbContext _context;
    private readonly ILogger<GitHubWebhookService> _logger;

    public GitHubWebhookService(
        WebhookDbContext context,
        ILogger<GitHubWebhookService> logger)
    {
        _context = context;
        _logger = logger;
    }

    protected override async Task ProcessIssueCommentWebhookAsync(
        WebhookHeaders headers,
        IssueCommentEvent issueCommentEvent,
        IssueCommentAction action)
    {
        _logger.LogInformation($"Comment on the Issue: {issueCommentEvent.Comment.Body}");

        var comment = new CommentEntity
        {
            Content = issueCommentEvent.Comment.Body
        };

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        base.ProcessIssueCommentWebhookAsync(headers, issueCommentEvent, action);
    }
}
