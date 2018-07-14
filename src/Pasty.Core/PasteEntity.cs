namespace Pasty.Core
{
    using System;
    using Microsoft.WindowsAzure.Storage.Table;

    public class PasteEntity : TableEntity
    {
        public PasteEntity()
        {
            this.PartitionKey = nameof(PasteEntity);
            this.RowKey = Guid.NewGuid().ToString();
            this.Created = DateTime.Now;
        }

        public PasteEntity(PasteDto dto)
        : base()
        {
            this.Content = dto.Content;
        }

        public string Content { get; set; }
        public DateTime Created { get; private set; }
    }
}