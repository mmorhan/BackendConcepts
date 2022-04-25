using Domain.Models;
using MediatR;

namespace services.Business.Cars.Commmands{
    public class CreateCarCommand:IRequest<Response<Car>>{}
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Response<Car>>
    {
        public Task<Response<Car>> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            if(false){
               return Task.FromResult(Response.Fail<Car>("Already Exist"));
            }
            return Task.FromResult(Response.Ok<Car>(new Car{Name="Mazda"},"Car Created"));
        }
    }
}