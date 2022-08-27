using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using RestaurantAPI.Services;
using System.Security.Claims;

namespace RestaurantAPI.Controller
{
    [Route("api/restaurant")]
    [ApiController]
    [Authorize]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _restaurantService.Delete(id);

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody]UpdateRestaurantDto dto, [FromRoute] int id)
        {

            _restaurantService.Update(dto, id);

            return Ok();
        }

        [HttpGet]
        [Authorize(Policy = "CreatedAtleast2Restaurants")]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {

            var restaurantsDtos = _restaurantService.GetAll();

            return Ok(restaurantsDtos);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public ActionResult<RestaurantDto> Get([FromRoute]int id)
        {
            var restaurant = _restaurantService.GetById(id);

            return Ok(restaurant);
        }

        [HttpPost]
        [Authorize(Roles ="Admin,Manager")]
        public ActionResult CreateRestaurant([FromBody]CreateRestaurantDto dto)
        {
            var userId = int.Parse(User.FindFirst(c=>c.Type == ClaimTypes.NameIdentifier).Value);

            var id = _restaurantService.Create(dto);

            return Created($"/api/restaurant/{id}", null);
        }


    }

}
