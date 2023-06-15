using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CakeShop.Models;
using CakeShop.Models.Requests;
using CakeShop.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CakeShop.Models.Models;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    [HttpGet("GetAllOrders")]
    public async Task<IActionResult> GetAll()
    {
        var orders = await _orderService.GetAllOrders();
        return Ok(orders);
    }

    [HttpGet("GetOrderById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var order = await _orderService.GetOrderById(id);
        if (order != null)
            return Ok(order);
        return NotFound();
    }

    [HttpPost("PlaceOrder")]
    public async Task<IActionResult> PlaceOrder([FromBody] OrderRequest orderRequest)
    {
        var order = _mapper.Map<Order>(orderRequest);
        await _orderService.PlaceOrder(order);
        return Ok();
    }

    [HttpDelete("CancelOrder")]
    public async Task<IActionResult> Cancel(Guid id)
    {
        await _orderService.CancelOrder(id);
        return Ok();
    }
}