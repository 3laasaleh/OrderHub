using OrderHub.Application.Repositoreis.Interfaces;
using OrderHub.Domain.Models;
using OrderHub.Infrastructure.Persistence;


namespace OrderHub.Infrastructure.Repositories
{
    public class SchoolRepository : ISchoolRepository
    {

        private readonly OrderProcessorContext _context;
        public SchoolRepository(OrderProcessorContext context)
        {
            _context = context;
        }

        public async Task<School?> GetByIdAsync(int schoolId, CancellationToken ct)
        {
            var school = await _context.Schools.FindAsync(schoolId, ct);
            return school;
        }
    }
}
