using AutoMapper;
using BookStore.BL.Interfaces;
using CakeShop.Models;
using CakeShop.Models.Requests;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerService customerService, IMapper mapper)
    {
        _customerService = customerService;
        _mapper = mapper;
    }

    [HttpGet("GetAllCustomers")]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _customerService.GetAllCustomers();
        return Ok(customers);
    }

    [HttpGet("GetCustomerById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var customer = await _customerService.GetCustomerById(id);
        if (customer != null)
            return Ok(customer);
        return NotFound();
    }

    [HttpPost("AddCustomer")]
    public async Task<IActionResult> Add([FromBody] CustomerRequest customerRequest)
    {
        var customer = _mapper.Map<Customer>(customerRequest);
        await _customerService.AddCustomer(customer);
        return Ok();
    }

    [HttpPost("UpdateCustomer")]
    public async Task<IActionResult> Update([FromBody] CustomerRequest customerRequest)
    {
        var customer = _mapper.Map<Customer>(customerRequest);
        await _customerService.UpdateCustomer(customer);
        return Ok();
    }

    [HttpDelete("DeleteCustomer")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _customerService.DeleteCustomer(id);
        return Ok();
    }
}