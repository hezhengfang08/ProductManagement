using ProductManagement.Categorys;
using ProductManagement.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace ProductManagement.Categories
{
    internal class CategoriesService : ProductManagementAppService, ICategoriesService
    {
        private readonly IRepository<Category, Guid> _categoryRepository;
       public CategoriesService(IRepository<Category, Guid> categoryRepository)
        {
            _categoryRepository = categoryRepository;   
        }


        public async Task<PagedResultDto<CategoryLookupDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var queryable = await _categoryRepository.WithDetailsAsync();
            queryable = queryable
               .Skip(input.SkipCount)
               .Take(input.MaxResultCount)
               .OrderBy(input.Sorting ?? nameof(Product.Name));
            var categories = await AsyncExecuter.ToListAsync(queryable);
            var count = await _categoryRepository.GetCountAsync();
            return new PagedResultDto<CategoryLookupDto>(
            count,
            ObjectMapper.Map<List<Category>, List<CategoryLookupDto>>
           (categories)
            );
        }
    }
}
