using Blog.Application.Emails;
using Blog.Application.UseCases.Commands;
using Blog.Application.UseCases.DTO;
using Blog.DataAccess;
using Blog.Domain;
using Blog.Implementation.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Implementation.UseCases.Commands
{
    public class EFUserRegistrationCommand : EFUseCase, IUserRegistrationCommand
    {
        //private readonly IEmailSender _sender;
        readonly UserRegistrationValidator _validator;

        public EFUserRegistrationCommand(BlogContext context, UserRegistrationValidator validator) : base(context)
        {
            //_sender = sender;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "Register User using EF";

        public void Execute(UserRegistrationDto request)
        {
            _validator.ValidateAndThrow(request);

            var user = new User
            {
                 Username = request.Username,
                 Name = request.Name,
                 Email = request.Email,
                 Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                 Image = request.Image,
                 RoleId = 2
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            //_sender.Send(new EmailSenderDto
            //{
            //    Content = "Successfull registration" + request.Username,
            //    SendTo = request.Email,
            //    Subject = "Registration"
            //});
        }
    }
}
