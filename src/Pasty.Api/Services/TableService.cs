namespace Pasty.Api.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    using Pasty.Core;

    public class TableService<T> : ITableService<T> where T : ITableEntity
    {
        private string tableName = "PastyPastes";

        private CloudTable pasteTable;

        public TableService(string connectionString)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
            pasteTable.CreateIfNotExistsAsync();
            this.pasteTable = tableClient.GetTableReference(tableName);
        }

        public async Task<T> GetAsync(string partitionKey, string rowKey)
        {
            TableOperation retrieve = TableOperation.Retrieve(partitionKey, rowKey);
            var result = await this.pasteTable.ExecuteAsync(retrieve);
            return (T)result.Result;
        }

        public async Task InsertAsync(T entity)
        {
            TableOperation insert = TableOperation.Insert(entity);
            await pasteTable.ExecuteAsync(insert);
        }
    }
}