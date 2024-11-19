using Blog.Abstractions;
using Blog.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Blog;

/// <summary>
/// <see cref="IBlogRepository"/> implementation.
/// </summary>
public class BlogRepository : IBlogRepository
{
    private readonly MyDbContext _dbContext;

    public BlogRepository(MyDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(null, nameof(_dbContext));
    }

    /// <inheritdoc/>
    public Task<List<CommentsPerUser>> GetNumberOfCommentsPerUserAsync()
    {
        return _dbContext.BlogComments
            .GroupBy(x => x.UserName)
            .Select(x => new CommentsPerUser(x.Key, x.Count()))
            .ToListAsync();
    }

    /// <inheritdoc/>
    public Task<List<PostByLastComment>> GetOrderedPostsByLastCommentAsync()
    {
        return _dbContext.BlogPosts
            .Include(x => x.Comments)
            .Select(post => new
            {
                post.Title,
                LatestComment = post.Comments.OrderByDescending(com => com.CreatedDate).FirstOrDefault()
            })
            .OrderByDescending(post => post.LatestComment.CreatedDate)
            .Select(x => new PostByLastComment(x.Title, x.LatestComment.CreatedDate, x.LatestComment.Text))
            .ToListAsync();
    }

    /// <inheritdoc/>
    public Task<List<CommentsPerUser>> GetNumberOfLastCommentsPerUserAsync()
    {
        return _dbContext.BlogPosts
            .GroupBy(post => post.Comments.OrderByDescending(com => com.CreatedDate).FirstOrDefault().UserName)
            .Select(x => new CommentsPerUser(x.Key, x.Count()))
            .ToListAsync();
    }
}