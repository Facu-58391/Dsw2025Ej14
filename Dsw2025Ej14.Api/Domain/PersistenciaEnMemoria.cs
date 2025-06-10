using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dsw2025Ej14.Api.Domain
{
    public class PersistenciaEnMemoria : IPersistencia
    {
        private List<Product> _products = new();

        public IReadOnlyList<Product> Products => _products;

        public async Task LoadProductsAsync()
        {
            var jsonPath = "Data\\products.json";
            if (!File.Exists(jsonPath))
                return;

            var json = await File.ReadAllTextAsync(jsonPath);
            var products = JsonSerializer.Deserialize<List<Product>>(json);
            if (products != null)
                _products = products;
        }

        public Product? GetBySku(string sku) =>
            _products.Find(p => p.Sku == sku);

        public IEnumerable<Product> GetActiveProducts() =>
            _products.FindAll(p => p.IsActive);
    }
}