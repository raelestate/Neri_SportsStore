using Microsoft.AspNetCore.Mvc;
using Neri_SportsStore.Models;
using Neri_SportsStore.Models.ViewModels;

namespace Neri_SportsStore.Controllers
{
	public class HomeController : Controller
	{
		private IStoreRepository repository;
		public int PageSize = 4;

		public HomeController(IStoreRepository repository)
		{
			this.repository = repository;
		}
		public ViewResult Index(int productPage = 1)
			=> View(new ProductsListViewModel { 
				Products = repository.Products
				.OrderBy(p => p.ProductID)
				.Skip((productPage - 1)* PageSize)
				.Take(PageSize),
				PagingInfo = new PagingInfo
				{
					CurrentPage = productPage,
					ItemsPerPage = PageSize,
					TotalItems = repository.Products.Count()
				}
			});
	}
}
