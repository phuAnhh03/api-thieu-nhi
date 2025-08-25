using api.Data;
using api.Dtos.Comments;
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
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            var comments = _context.Comments.AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Title))
                comments = comments.Where(c => c.Title.Contains(query.Title));
            else if (!string.IsNullOrWhiteSpace(query.Content))
                comments = comments.Where(c => c.Content.Contains(query.Content));
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                    comments = query.IsDescending ? comments.OrderByDescending(s => s.Title) : comments.OrderBy(s => s.Title);
                else if (query.SortBy.Equals("Content", StringComparison.OrdinalIgnoreCase)) 
                    comments = query.IsDescending ? comments.OrderByDescending(s => s.Content) : comments.OrderBy(s => s.Content) ;
            }
            return await comments.Skip(skipNumber).Take(query.PageSize).ToListAsync();
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