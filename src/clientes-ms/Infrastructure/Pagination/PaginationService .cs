using clientes_ms.Application.Records.Response;

namespace clientes_ms.Infrastructure.Services
{
    public interface IPaginationService
    {
        (int page, int pageSize, int skip) CalculatePagination(int page, int pageSize, int maxPageSize = 1000);
        PaginationResponse<T> CreatePaginationResponse<T>(
            IEnumerable<T> items, 
            int page, 
            int pageSize, 
            int totalItems, 
            string message = "Datos paginados correctamente");
    }

    public class PaginationService : IPaginationService
    {
        public (int page, int pageSize, int skip) CalculatePagination(int page, int pageSize, int maxPageSize = 1000)
        {
            var validPage = page <= 0 ? 1 : page;
            var validPageSize = pageSize <= 0 ? 50 : Math.Min(pageSize, maxPageSize);
            var skip = (validPage - 1) * validPageSize;

            return (validPage, validPageSize, skip);
        }

        public PaginationResponse<T> CreatePaginationResponse<T>(
            IEnumerable<T> items, 
            int page, 
            int pageSize, 
            int totalItems, 
            string message = "Datos paginados correctamente")
        {
            return new PaginationResponse<T>(
                items: items.ToList(),
                page: page,
                pageSize: pageSize,
                totalItems: totalItems,
                message: message
            );
        }
    }
}