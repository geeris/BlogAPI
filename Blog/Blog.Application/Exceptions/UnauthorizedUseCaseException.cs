using Blog.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase, IApplicationActor actor)
            : base($"Actor witg an id {actor.Id} - {actor.Identity} tried to execute {useCase.Name}") //natklasi prosledjuje poruku
        {
        }
    }
}
