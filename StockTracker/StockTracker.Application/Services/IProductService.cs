using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Application.Services
{
    public interface IProductService
    {
        Task ActivateProduct(Guid productId);



        //Her yeni Product use case'i bu interface'e fonksiyon olarak eklenir.
        //Her yeni use case için sınıf yazsak?


    }
}
