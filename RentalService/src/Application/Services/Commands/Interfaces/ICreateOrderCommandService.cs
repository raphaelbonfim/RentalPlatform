using Application.DTOs.Admin;

namespace Application.Services.Commands.Interfaces
{
    public interface ICreateOrderCommandService
    {
        Task<OutCreateOrderDTO> ProcessAsync(InCreateOrderDTO dto, CancellationToken cancellation);
    }
}
