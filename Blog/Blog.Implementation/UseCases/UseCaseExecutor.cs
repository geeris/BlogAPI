using Blog.Application.Exceptions;
using Blog.Application.Logging;
using Blog.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blog.Application.UseCases
{
    public class UseCaseExecutor
    {
        readonly IApplicationActor actor;
        readonly IUseCaseLogger logger;

        public UseCaseExecutor(IUseCaseLogger logger, IApplicationActor actor)
        {
            this.logger = logger;
            this.actor = actor;
        }

        //uzeti referencu kroz konstruktor
        public void ExecuteCommand<TRequest>(ICommand<TRequest> command, TRequest request)
        {
            //Logging
            HandleLoggingAndAuthorization(command, request);

            //Authorization
            if (!actor.AllowedUseCases.Any(x => x == command.Id))
            {
                throw new UnauthorizedUseCaseException(command, actor);
            }

            command.Execute(request);

        }

        public TResult ExecuteQuery<TSearch, TResult>(IQuery<TSearch, TResult> query, TSearch search)
        {
            //Logging
            HandleLoggingAndAuthorization(query, search);

            //Authorization
            if (!actor.AllowedUseCases.Any(x => x == query.Id))
            {
                throw new UnauthorizedUseCaseException(query, actor);
            }

            return query.Execute(search);
        }

        private void HandleLoggingAndAuthorization<TRequest>(IUseCase useCase, TRequest data)
        {
            var isAuthorized = actor.AllowedUseCases.Contains(useCase.Id);

            var log = new UseCaseLog
            {
                Actor = actor.Identity,
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Name,
                Id = actor.Id,
                Data = JsonConvert.SerializeObject(data),
                IsAuthorized = isAuthorized
            };

            logger.Log(log);

            if (!isAuthorized)
            {
                throw new ForbiddenUseCaseExecutionException(useCase.Name, actor.Identity);
            }
        }
    }
}
