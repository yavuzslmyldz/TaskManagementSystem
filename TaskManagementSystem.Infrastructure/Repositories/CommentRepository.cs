using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Interfaces.Repository;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Infrastructure.Persistence.Repositories
{
    public class CommentRepository : ICommentReposityory
    {
        private readonly ApplicationDbContext dbContext;

        public CommentRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public Task<int> CreateAsync(Comment entity)
        {

            object[] parameters = new object[] {
                new NpgsqlParameter("@TaskId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.TaskId
                },
                new NpgsqlParameter("@CommentText", SqlDbType.Text)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.CommentText
                },
                new NpgsqlParameter("@CommentType", SqlDbType.Text)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.CommentType
                },
                new NpgsqlParameter("@RemainderDate", SqlDbType.DateTime)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.RemainderDate
                },

            };

            return dbContext.Database.ExecuteSqlRawAsync("INSERT INTO public.\"Comments\" (task_id,comment_text,comment_type,remainder_date" +
                ") VALUES(@TaskId,@CommentText,@CommentType,@RemainderDate)", parameters);
        }

        public Task<int> DeleteAsync(int id)
        {
            return dbContext.Database.ExecuteSqlRawAsync("DELETE FROM public.\"Comments\" WHERE id = {0}", id);
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await dbContext.Comments.FromSqlRaw("SELECT * FROM public.\"Comments\"").ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetAllByTaskAsync(int taskId)
        {
            return await dbContext.Comments.FromSqlRaw("SELECT * FROM public.\"Comments\" WHERE task_id = {0}", taskId).ToListAsync();
        }

        public async Task<Comment> GetAsync(int id)
        {
            return await dbContext.Comments.FromSqlRaw("SELECT * FROM public.\"Comments\" WHERE id = {0}", id).FirstOrDefaultAsync();
        }

        public Task<int> UpdateAsync(Comment entity)
        {
            object[] parameters = new object[] {
                 new NpgsqlParameter("@ID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.Id
                },
                new NpgsqlParameter("@CommentText", SqlDbType.Text)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.CommentText
                },
                new NpgsqlParameter("@CommentType", SqlDbType.Text)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.CommentType
                },
                new NpgsqlParameter("@RemainderDate", SqlDbType.DateTime)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.RemainderDate
                },

            };
            return dbContext.Database.ExecuteSqlRawAsync("UPDATE public.\"Comments\" SET comment_text = @CommentText, comment_type = @CommentType, remainder_date = @RemainderDate WHERE id = @ID ", parameters);
        }

    }
}

