using System;
using System.Threading.Tasks;
using Pasty.Core;

namespace Pasty.Api.Services
{
    public class PasteService : IPasteService
    {
        private readonly ITableService<PasteEntity> tableService;

        public PasteService(ITableService<PasteEntity> tableService)
        {
            this.tableService = tableService;

        }
        public async Task<string> GetPasteAsync(Guid Id)
        {
            var entity = await this.tableService.GetAsync(nameof(PasteEntity), Id.ToString());
            return entity.Content;
        }

        public async Task<string> StorePaste(PasteDto dto)
        {
            var entity = new PasteEntity(dto);
            await this.tableService.InsertAsync(entity);
            return entity.RowKey;
        }
    }
}