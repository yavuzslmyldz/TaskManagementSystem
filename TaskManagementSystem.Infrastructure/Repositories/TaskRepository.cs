using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TaskManagementSystem.Application.Interfaces.Repository;
using TaskManagementSystem.Domain.Entities;

namespace TaskManagementSystem.Infrastructure.Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext dbContext;

        public TaskRepository(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public Task<int> CreateAsync(Duty entity)
        {
            object[] parameters = new object[] {               
                new NpgsqlParameter("@RequiredByDate", SqlDbType.DateTime)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.RequiredByDate
                },
                new NpgsqlParameter("@Description", SqlDbType.Text)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.Description
                },
                new NpgsqlParameter("@Status", SqlDbType.Text)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.Status
                },
                new NpgsqlParameter("@Type", SqlDbType.Text)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.Type
                },
                new NpgsqlParameter("@AssignedTo", SqlDbType.Text)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.Assigned
                },
                new NpgsqlParameter("@CreatedDate", SqlDbType.DateTime)
                {
                    Direction = ParameterDirection.Input,
                    Value = DateTime.Now
                },

            };

            return dbContext.Database.ExecuteSqlRawAsync("INSERT INTO public.\"Task\" (required_by_date,description,status,type,assigned_to,created_date" + ") VALUES(@RequiredByDate,@Description,@Status,@Type,@AssignedTo,@CreatedDate)", parameters);


        }

        public async Task<int> DeleteAsync(int id)
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {

                var result = await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM public.\"Task\" WHERE id = {0}", id);

                await dbContext.Database.ExecuteSqlRawAsync("DELETE FROM public.\"Comments\" WHERE task_id = {0}", id);

                transaction.Commit();
                return await Task.FromResult(result);
            }            
        }

        public async Task<IEnumerable<Duty>> GetAllAsync()
        {
            return await dbContext.Tasks.FromSqlRaw("SELECT * FROM public.\"Task\" order by created_date desc").ToListAsync();
        }

        public async Task<Duty> GetAsync(int id)
        {
            return await dbContext.Tasks.FromSqlRaw("SELECT * FROM public.\"Task\" WHERE id = {0}", id).FirstOrDefaultAsync();
        }

        public async Task<int> UpdateAsync(Duty entity)
        {
            object[] parameters = new object[] {
                new NpgsqlParameter("@ID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.Id
                },
                new NpgsqlParameter("@RequiredByDate", SqlDbType.DateTime)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.RequiredByDate
                },
                new NpgsqlParameter("@Description", SqlDbType.Text)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.Description
                },
                new NpgsqlParameter("@Status", SqlDbType.Text)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.Status
                },
                new NpgsqlParameter("@Type", SqlDbType.Text)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.Type
                },
                new NpgsqlParameter("@AssignedTo", SqlDbType.Text)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.Assigned
                },
                new NpgsqlParameter("@NextActionDate", SqlDbType.DateTime)
                {
                    Direction = ParameterDirection.Input,
                    Value = entity.NextActionDate.HasValue ? entity.NextActionDate.Value : DBNull.Value
                }
            };

            return await dbContext.Database.ExecuteSqlRawAsync("UPDATE public.\"Task\" SET required_by_date = @RequiredByDate, description = @Description, status = @Status, type = @Type, assigned_to = @AssignedTo, next_action_date = @NextActionDate WHERE id = @ID", parameters);

        }
    }
}
