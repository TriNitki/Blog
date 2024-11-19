namespace Blog.Contracts;

/// <summary>
/// Comments per user.
/// </summary>
/// <param name="Name">Username</param>
/// <param name="Count">Number of comments</param>
public sealed record CommentsPerUser(string Name, int Count);