using api.Data;
using api.Dtos.Comment;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CommentRepository(ApplicationDBContext context): ICommentRepository
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<List<Comment>> GetAllCommentAsync(CommentQueryObject query)
        {
            var comments = _context.Comments.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Title))
                comments = comments.Where(c => c.Title.Contains(query.Title));
            else if (!string.IsNullOrWhiteSpace(query.Content))
                comments = comments.Where(c => c.Content.Contains(query.Content));
            return await comments.ToListAsync();
        }

        public async Task<Comment?> GetCommentByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment> CreateCommentAsync(CommentDto commentDto)
        {
            var comment = commentDto.ToComment();
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> UpdateCommentAsync(int id, CommentDto commentDto)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return null;
            }
            comment.Title = commentDto.Title;
            comment.Content = commentDto.Content;
            await _context.SaveChangesAsync();
            return comment;
        }
        public async Task<bool?> DeleteCommentAsync(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return null;
            }
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}