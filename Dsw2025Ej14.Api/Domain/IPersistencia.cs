using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dsw2025Ej14.Api.Domain
{
    public interface IPersistencia
    {
        Task LoadProductsAsync();
        Product? GetBySku(string sku);
        IEnumerable<Product> GetActiveProducts();
        IReadOnlyList<Product> Products { get; }
    }
}