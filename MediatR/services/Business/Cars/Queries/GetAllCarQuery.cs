using Domain.Models;
using MediatR;

namespace services.Business.Cars.Queries{
    public class GetAllCarQuery:BaseRequest,IRequest<IEnumerable<Car>>{}

    public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, IEnumerable<Car>>
    {

        public async Task<IEnumerable<Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            return new[] {
                new Car{Name=$"Honda{request.userId}"},
                new Car{Name=$"BMW{request.userId}"},
                new Car{Name=$"Mercedes{request.userId}"},
            };
                
                
        }
    }

}