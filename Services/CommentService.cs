using api.Dtos.Comment;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using api.Repositories;

namespace api.Services
{
    public class CommentService(ICommentRepository commentRepository) : ICommentService
    {
        private readonly ICommentRepository _commentRepository = commentRepository;
        public async Task<GetCommentDto> AddCommentAsync(CommentDto commentDto)
        {
            var comment = await _commentRepository.CreateCommentAsync(commentDto);
            return comment.ToGetCommentDto();          
        }

        public async Task<GetCommentDto?> DetailCommentByIdAsync(int id)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return null;
            }
            return comment.ToGetCommentDto();
        }

        public async Task<GetCommentDto?> EditCommentAsync(int id, CommentDto commentDto)
        {
            var comment = await _commentRepository.UpdateCommentAsync(id, commentDto);
            if (comment == null)
            {
                return null;
            }
            return comment.ToGetCommentDto();
        }

        public async Task<IEnumerable<GetCommentDto>> ListAllCommentsAsync(CommentQueryObject query)
        {
            var comments = await _commentRepository.GetAllCommentAsync(query);
            return comments.Select(comment => comment.ToGetCommentDto());
        }

        public async Task<bool?> RemoveCommentAsync(int id)
        {
            return await _commentRepository.DeleteCommentAsync(id);
        }
    }
}