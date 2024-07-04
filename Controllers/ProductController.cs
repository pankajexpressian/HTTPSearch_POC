using HTTPSearch_POC.Models;
using HTTPSearch_POC.Services.Services;
using Microsoft.AspNetCore.Mvc;
using HTTPSearch_POC.Attributes;

namespace HTTPSearch_POC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _productService.GetAll();
        }

        // Search as query string
        [HttpSearch("search")]
        public IEnumerable<Product> Search()
        {
            return _productService.GetAll();
        }

        // IT WILL NOT ALLOW US TO GENERATE SWAGGER SINCE SEARCH IS NOT A STANDARD METHOD
        // IT WILL NOT WORK IN BROWSER, NEEDS AN HTTP VERB SEARCH
        // POSTMAN WILL NOT HAVE SEARCH AS A VERB BY DEFAULT, TYPE IT AND IT WILL WORK
        //DOTNET DOESN'T HAVE HTTHPSEARCH METHOD BUIT IN. YOU NEED TO DEVELOP A CUSTOM ATTRIBUTE AND USE IT

        // Search as query string
        [HttpSearch("{query}")]
        public IEnumerable<Product> SearchQuery([FromQuery] string query)
        {
            return _productService.Search(query);
        }

        // Search as query string
        [HttpSearch("SearchBody")]
        public IEnumerable<Product> SearchBody([FromBody] SearchRequest query)
        {
            return _productService.Search(query.Query);
        }
    }
}
