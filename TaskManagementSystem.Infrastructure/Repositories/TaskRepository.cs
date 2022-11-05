using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

            };

           return dbContext.Database.ExecuteSqlRawAsync("INSERT INTO public.\"Task\" (required_by_date,description,status,type,assigned_to" + ") VALUES(@RequiredByDate,@Description,@Status,@Type,@AssignedTo)", parameters);

       
        }

        public Task<int> DeleteAsync(int id)
        {       
            return dbContext.Database.ExecuteSqlRawAsync("DELETE FROM public.\"Task\" WHERE id = {0}", id);
        }

        public async Task<IEnumerable<Duty>> GetAllAsync()
        {
            return await dbContext.Tasks.FromSqlRaw("SELECT * FROM public.\"Task\"").ToListAsync();
        }

        public async Task<Duty> GetAsync(int id)
        {
            return await dbContext.Tasks.FromSqlRaw("SELECT * FROM public.\"Task\" WHERE id = {0}", id).FirstOrDefaultAsync();
        }

        public Task<int> UpdateAsync(Duty entity)
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

            };

          return dbContext.Database.ExecuteSqlRawAsync("UPDATE public.\"Task\" SET required_by_date = @RequiredByDate, description = @Description, status = @Status, type = @Type, assigned_to = @AssignedTo WHERE id = @ID", parameters);

        }
    }
}
