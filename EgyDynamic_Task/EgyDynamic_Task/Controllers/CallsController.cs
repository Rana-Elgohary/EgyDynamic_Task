using AutoMapper;
using EgyDynamic_Task.DTO;
using EgyDynamic_Task.Models;
using EgyDynamic_Task.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EgyDynamic_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallsController : ControllerBase
    {
        UOW unit;
        private readonly IMapper mapper;

        public CallsController(UOW unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 4)
        {
            try
            {
                List<مكالمه_العميل> Calls = unit.CallsRepo.SelectAllInclude(pageNumber, pageSize, c => c.ادخال_بواسطهNavigation, c => c.اخر_تعديلNavigation, c=>c.الموظفNavigation, c=>c.العميلNavigation);
                if (Calls == null || !Calls.Any())
                    return NotFound("No Data");

                List<CallsGetDTO> CallsDTO = mapper.Map<List<CallsGetDTO>>(Calls);

                var totalItems = unit.CallsRepo.CountAll();

                var paginatedResult = new PaginatedResult<CallsGetDTO>
                {
                    TotalItems = totalItems,
                    Items = CallsDTO,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                return Ok(paginatedResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred while retrieving calls.");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            try
            {
                مكالمه_العميل existingCall = unit.CallsRepo.SelectByIDInclude(id, "كود_مكالمه_العميل", c => c.ادخال_بواسطهNavigation, c => c.اخر_تعديلNavigation, c => c.الموظفNavigation, c => c.العميلNavigation);
                if (existingCall == null)
                    return NotFound("No Data");
                CallsPutDTO callsDTO = mapper.Map<CallsPutDTO>(existingCall);
                return Ok(callsDTO);
            }
            catch
            {
                return StatusCode(500, "An unexpected error occurred while retrieving Calls.");
            }
        }

        [HttpPost]
        public ActionResult AddCall (CallsPostDTO callDTO)
        {
            try
            {
                if (callDTO == null)
                    return BadRequest("Call data is null");

                مكالمه_العميل call = mapper.Map<مكالمه_العميل>(callDTO);
                unit.CallsRepo.add(call);
                unit.SaveChanges();
                return Ok(new { message = "Successfully added" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public ActionResult EditCall(CallsPutDTO callDTO)
        {
            if (callDTO == null)
                return BadRequest("Call data is null");

            مكالمه_العميل existingCall = unit.CallsRepo.SelectByIDInclude(callDTO.كود_مكالمه_العميل, "كود_مكالمه_العميل", c => c.ادخال_بواسطهNavigation, c => c.اخر_تعديلNavigation, c => c.الموظفNavigation, c => c.العميلNavigation);
            if (existingCall == null)
                return NotFound("There is no call");
            else
            {
                mapper.Map(callDTO, existingCall);
                try
                {
                    unit.CallsRepo.update(existingCall);
                    unit.SaveChanges();
                    return Ok(new { message = "Successfully Updated" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, $"Internal server error: {ex.Message}");
                }
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteCall(int id)
        {
            try
            {
                if (id == null)
                    return BadRequest("data is null");

                مكالمه_العميل existingCall = unit.CallsRepo.SelectByIDInclude(id, "كود_مكالمه_العميل", c => c.ادخال_بواسطهNavigation, c => c.اخر_تعديلNavigation, c => c.الموظفNavigation, c => c.العميلNavigation);

                if (existingCall == null)
                    return NotFound("No Data to delete");

                unit.CallsRepo.delete(id);
                unit.SaveChanges();
                return Ok(new { message = "Successfully deleted" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
