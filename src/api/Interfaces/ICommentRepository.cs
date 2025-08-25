using api.Dtos.Comments;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface ICommentRepository
    {   
        Task<List<Comment>> GetAllCommentAsync(CommentQueryObject query);
        Task<Comment?> GetCommentByIdAsync(int id);
        Task<Comment> CreateCommentAsync(CommentDto commentDto);
        Task<Comment?> UpdateCommentAsync(int id, CommentDto commentDto);
        Task<bool?> DeleteCommentAsync(int id);
    }
}