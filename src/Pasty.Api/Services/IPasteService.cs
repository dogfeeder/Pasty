using System;
using System.Threading.Tasks;
using Pasty.Core;

namespace Pasty.Api.Services
{
    public interface IPasteService
    {
        Task<string> StorePaste(PasteDto dto);

        Task<string> GetPasteAsync(Guid Id);
    }
}