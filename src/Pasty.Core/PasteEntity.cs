namespace Pasty.Core
{
    using System;
    using Microsoft.WindowsAzure.Storage.Table;

    public class PasteEntity : TableEntity
    {
        public PasteEntity(PasteDto dto)
        {
            this.PartitionKey = nameof(PasteEntity);
            this.RowKey = Guid.NewGuid().ToString();
            this.Created = DateTime.Now;
            this.Content = dto.Content;
        }

        public string Content { get; set; }
        public DateTime Created { get; private set; }
    }
}