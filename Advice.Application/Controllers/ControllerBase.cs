using Advice.Application.Dtos;
using Advice.Data.Model;

namespace Advice.Application.Controllers
{
    public class ControllerBase<TEntity, TEntityDto, CreateDto, EditDto, ItemMainListDto, FilterSortPagedListDto> where TEntity : EntityBase where TEntityDto : EntityBaseDto where EditDto : EntityBaseDto where FilterSortPagedListDto : FilterSortPagedListInputDto
    {
        
    }
}
