namespace Pasty.Api.Services
{
    using System;
    using System.Threading.Tasks;

    public interface ITableService<T>
    {
        Task InsertAsync(T entity);

        Task<T> GetAsync(string partitionKey, string rowKey);
    }
}