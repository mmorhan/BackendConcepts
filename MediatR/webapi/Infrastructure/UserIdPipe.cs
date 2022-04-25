using System.Security.Claims;
using Domain.Models;
using MediatR;
using services.Business;

namespace webapi.Infrastructure{
    public class UserIdPipe<TIn, TOut> : IPipelineBehavior<TIn, TOut>where TIn:IRequest<TOut>
    {
        private  HttpContext httpContext;

        public UserIdPipe(IHttpContextAccessor accessor )
        {
            httpContext=accessor.HttpContext;    
        }
        public  async Task<TOut> Handle(TIn request, CancellationToken cancellationToken, RequestHandlerDelegate<TOut> next)
        {

            // var userId=httpContext.User.Claims
            //     .FirstOrDefault(x=>x.Type.Equals(ClaimTypes.NameIdentifier))
            //     .Value;
            
            if(request is BaseRequest br){
                br.userId="orhan";
            }
            var result =await next();
            if(result is Response<Car> carResponse){
                carResponse.Data.Name="Check";
            }

            return result;

        }
    }


}