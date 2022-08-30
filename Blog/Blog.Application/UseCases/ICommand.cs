using Blog.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application
{
    //inserti update delete
    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest request);
    }
    //public class UserDto
    //{
    //    //first name
    //       // last name

    //}
    //public class CreateUserCommand : ICommand<UserDto>
    //{
    //    public void Execute(UserDto request)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    //public interface IDeleteUserCommand : ICommand<int>
    //{

    //}
}
