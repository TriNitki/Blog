using Blog.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blog.Abstractions;

/// <summary>
/// Blog post repository.
/// </summary>
public interface IBlogRepository
{
    /// <summary>
    /// Gets the number of comments each user left.
    /// </summary>
    /// <returns>List of the number of comments per user</returns>
    Task<List<CommentsPerUser>> GetNumberOfCommentsPerUserAsync();

    /// <summary>
    /// Gets posts ordered by date of last comment.
    /// </summary>
    /// <returns>List of the ordered posts</returns>
    Task<List<PostByLastComment>> GetOrderedPostsByLastCommentAsync();

    /// <summary>
    /// Gets the number of last comments each user left.
    /// </summary>
    /// <returns>List of the number of last comments per user</returns>
    Task<List<CommentsPerUser>> GetNumberOfLastCommentsPerUserAsync();
}