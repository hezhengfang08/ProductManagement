using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace ProductManagement.Categories
{
    public interface ICategoriesService: IApplicationService
    {
        Task<PagedResultDto<CategoryLookupDto>> GetListAsync(PagedAndSortedResultRequestDto input);
    }
}
