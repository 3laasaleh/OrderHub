

using OrderHub.Domain.Models;


namespace OrderHub.Application.Repositoreis.Interfaces
{
    public interface ISchoolRepository
    {
        public Task<School?> GetByIdAsync(int id, CancellationToken ct);    
    }
 
}
