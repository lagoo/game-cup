using Application.Common.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Behaviours
{
    public class RequestExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {        
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (FluentValidation.ValidationException)
            {
                throw;
            }
            catch (WarningException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
