using System;

namespace Blog.Contracts;

/// <summary>
/// Post by last comment.
/// </summary>
/// <param name="Title">Title of the post</param>
/// <param name="CommentCreatedDate">Comment creation date time</param>
/// <param name="CommentText">Comment text</param>
public sealed record PostByLastComment(string Title, DateTime CommentCreatedDate, string CommentText);