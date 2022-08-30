using Blog.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Application.Emails
{
    public interface IEmailSender
    {
        void Send(EmailSenderDto dto);
    }
}
