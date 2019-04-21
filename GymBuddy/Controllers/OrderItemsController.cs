using AutoMapper;
using GymBuddy.Data;
using GymBuddy.Data.Entities;
using GymBuddy.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GymBuddy.Controllers
{
    [Route("api/orders/{orderid}/items")]
    [Authorize(AuthenticationSchemes=JwtBearerDefaults.AuthenticationScheme)]
    public class OrderItemsController : Controller
    {
        private readonly IGymBuddyRepository _repository;
        private readonly IMapper _mapper;

        public OrderItemsController(IGymBuddyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int orderId)
        {
            var order = _repository.GetOrderById(User.Identity.Name, orderId);
            if (order != null) return Ok(_mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(order.Items));
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderItemViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrderItem = _mapper.Map<OrderItemViewModel, OrderItem>(model);

                    _repository.AddOrderItem(newOrderItem);

                    if (_repository.SaveAll())
                    {
                        return Created($"/api/orders/orderitems{newOrderItem.Id}", _mapper.Map<OrderItem, OrderItemViewModel>(newOrderItem));
                    }
                    else
                    {
                        return BadRequest(ModelState);
                    }
                }
            }
            catch
            {
                //
            }

            return BadRequest("could not create orderitem");
           
        }
    }
}
