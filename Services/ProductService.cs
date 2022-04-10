using System.Collections.Generic;
namespace App.Models
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[] {
                new ProductModel() {Id=1, Name = "Iphone 12", Price=1200},
                new ProductModel() {Id=2, Name = "Samsung S22", Price=1234},
                new ProductModel() {Id=3, Name = "Oneplus 10", Price=1000},
                new ProductModel() {Id=4, Name = "Oppo find x5", Price=1350},
            });
        }
    }
}