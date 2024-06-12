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
    public class CustomerController : ControllerBase
    {
        UOW unit;
        private readonly IMapper mapper;

        public CustomerController(UOW unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 4)
        {
            try
            {
                List<العميل> customers = unit.CustomerRepo.SelectAllInclude(pageNumber, pageSize, c => c.ادخال_بواسطةNavigation, c => c.اخر_تعديلNavigation);
                if (customers == null || !customers.Any())
                    return NotFound("No Data");

                List<CustomerGetDTO> customersDTO = mapper.Map<List<CustomerGetDTO>>(customers);

                var totalItems = unit.CustomerRepo.CountAll();

                var paginatedResult = new PaginatedResult<CustomerGetDTO>
                {
                    TotalItems = totalItems,
                    Items = customersDTO,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };

                return Ok(paginatedResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred while retrieving customers.");
            }
        }

        [HttpGet("{id:int}")]
        public ActionResult GetById(int id)
        {
            try
            {
                العميل existingCustomer = unit.CustomerRepo.SelectByIDInclude(id, "كود_العميل", c => c.ادخال_بواسطةNavigation, c => c.اخر_تعديلNavigation);
                if (existingCustomer == null)
                    return NotFound("No Data");
                CustomerPutDTO customersDTO = mapper.Map<CustomerPutDTO>(existingCustomer);
                return Ok(customersDTO);
            }
            catch
            {
                return StatusCode(500, "An unexpected error occurred while retrieving customers.");
            }
        }

        [HttpPost]
        public ActionResult AddCustomer(CustomerPostDTO customerDTO)
        {
            try
            {
                if (customerDTO == null)
                    return BadRequest("Customer data is null");

                العميل customer = mapper.Map<العميل>(customerDTO);
                unit.CustomerRepo.add(customer);
                unit.SaveChanges();
                return Ok(new { message = "Successfully added" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        public ActionResult EditCustomer(CustomerPutDTO customerDTO)
        {
            if (customerDTO == null)
                return BadRequest("Customer data is null");

            العميل existingCustomer = unit.CustomerRepo.SelectByIDInclude(customerDTO.كود_العميل, "كود_العميل", c => c.ادخال_بواسطةNavigation, c => c.اخر_تعديلNavigation);
            if (existingCustomer == null)
                return NotFound("There is no customer");
            else
            {
                mapper.Map(customerDTO, existingCustomer);
                try
                {
                    unit.CustomerRepo.update(existingCustomer);
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
        public ActionResult DeleteCustomer(int id)
        {
            try
            {
                if (id == null)
                    return BadRequest("data is null");

                العميل existingCustomer = unit.CustomerRepo.SelectByIDInclude(id, "كود_العميل", c => c.ادخال_بواسطةNavigation, c => c.اخر_تعديلNavigation);

                if (existingCustomer == null)
                    return NotFound("No Data to delete");

                List<مكالمه_العميل> Calls = unit.CallsRepo.FindBy(c => c.العميل == id);
                unit.CallsRepo.DeleteEntities(Calls);

                unit.CustomerRepo.delete(id);
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
