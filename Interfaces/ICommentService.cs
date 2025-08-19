using api.Dtos.Comments;
using api.Helpers;

namespace api.Interfaces
{
    public interface ICommentService
    {
        Task<IEnumerable<GetCommentDto>> ListAllCommentsAsync(CommentQueryObject query);
        Task<GetCommentDto?> DetailCommentByIdAsync(int id);
        Task<GetCommentDto> AddCommentAsync(CommentDto commentDto);
        Task<GetCommentDto?> EditCommentAsync(int id, CommentDto commentDto);
        Task<bool?> RemoveCommentAsync(int id);
    }
}