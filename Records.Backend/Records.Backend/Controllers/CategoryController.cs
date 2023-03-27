using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using Records.Appllication.Categories.Queries.GetCategoryList;
using Records.Appllication.Records.Commands.CreateRecord;
using Records.Appllication.Records.Queries.GetRecordList;
using Records.Appllication.Records.Queries.GetRecords;
using Records.WebApi.Models;

namespace Records.WebApi.Controllers
{
    [Route("api/[controller]")]
        public class CategoryController : BaseController
        {
            private readonly IMapper _mapper;
            public CategoryController(IMapper mapper)
            {
                _mapper = mapper;
            }
            [HttpGet]
            public async Task<ActionResult<CategoryListVm>> GetAll()
            {
                var query = new GetCategoryListQuery();
                var vm = await Mediator.Send(query);
                return Ok(vm);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<RecordVm>> Get(Guid id)
            {
                var query = new GetRecordQuery()
                {
                    Id = id
                };

                var vm = await Mediator.Send(query);
                return Ok(vm);
            }

            [HttpPost]
            public async Task<ActionResult<Guid>> Create([FromBody] CreateRecordDto createRecordDto)
            {
                var command = _mapper.Map<CreateRecordCommand>(createRecordDto);
                var recordId = await Mediator.Send(command);
                return Ok(recordId);
            }
        }
    }
