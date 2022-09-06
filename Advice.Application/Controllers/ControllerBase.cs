using Advice.Application.Dtos;
using Advice.Data.Model;
using Advice.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Advice.Application.Controllers
{
    [Route("api/[controller]")]
    public class SchoolController : Controller
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        public async Task<IEnumerable<School>> Get()
        {
            return await _schoolService.GetAllAsync();
        }
    }
}
