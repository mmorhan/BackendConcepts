
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using services.Business;
using services.Business.Cars.Commmands;
using services.Business.Cars.Queries;

namespace webapi.Controllers;


[ApiController]
[Route("[controller]/[action]")]
public class HomeController:ControllerBase{
    private readonly IMediator _mediator;

    public HomeController(IMediator mediator)
    {
        _mediator=mediator;
        
    }

    [HttpGet(Name="Index")]

    // public async Task<IEnumerable<Car>> Index([FromBody] GetAllCarQuery query)=> await _mediator.Send(query);
    public async Task<IEnumerable<Car>> Index()=> await _mediator.Send(new GetAllCarQuery());
   

   [HttpPost(Name="CreateCar")]
   public async Task<Response<Car>> CreateCar()=> await _mediator.Send(new CreateCarCommand());

    [HttpGet(Name="HelloPerson")]
    public IActionResult HelloPerson(){
        return Ok("Hello you !");
    }
    [HttpGet(Name="HelloWord")]
    public IActionResult HelloWord(){
        return Ok("HelloWord");
    }
}
