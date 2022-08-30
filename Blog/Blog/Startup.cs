using Blog.Api;
using Blog.Api.Core;
using Blog.Application;
using Blog.Application.Emails;
using Blog.Application.Logging;
using Blog.Application.UseCases;
using Blog.Application.UseCases.Commands;
using Blog.Application.UseCases.Commands.CategoryCommands;
using Blog.Application.UseCases.Commands.CommentCommands;
using Blog.Application.UseCases.Commands.PostCommands;
using Blog.Application.UseCases.Commands.TagCommands;
using Blog.Application.UseCases.Commands.UserCommands;
using Blog.Application.UseCases.Queries;
using Blog.Application.UseCases.Queries.CategoryQueries;
using Blog.Application.UseCases.Queries.PostQueries;
using Blog.Application.UseCases.Queries.TagQueries;
using Blog.Application.UseCases.Queries.UserQueries;
using Blog.DataAccess;
using Blog.Implementation.Logging;
using Blog.Implementation.UseCases.Commands;
using Blog.Implementation.UseCases.Commands.CategoryCommands;
using Blog.Implementation.UseCases.Commands.CommentCommands;
using Blog.Implementation.UseCases.Commands.PostCommands;
using Blog.Implementation.UseCases.Commands.TagCommands;
using Blog.Implementation.UseCases.Commands.UserCommands;
using Blog.Implementation.UseCases.Queries;
using Blog.Implementation.UseCases.Queries.CategoryQueries;
using Blog.Implementation.UseCases.Queries.PostQueries;
using Blog.Implementation.UseCases.Queries.TagQueries;
using Blog.Implementation.UseCases.Queries.UserQueries;
using Blog.Implementation.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            //DbContext
            services.AddTransient<BlogContext>();
            services.AddHttpContextAccessor();

            var settings = new AppSettings();
            Configuration.Bind(settings);

            services.AddSingleton(settings);

            services.AddJwt(settings);

            services.AddApplicationUser();

            //Email
            //services.AddTransient<IEmailSender>(x => 
            //new SmtpEmailSender(settings.EmailOptions.FromEmail,
            //                    settings.EmailOptions.Password,
            //                    settings.EmailOptions.Port,
            //                    settings.EmailOptions.Host));


            //UserController
            services.AddTransient<IGetUsersQuery, EFGetUsersQuery>();
            services.AddTransient<IFindUserQuery, EFFindUserQuery>();
            services.AddTransient<IEditUserCommand, EFEditUserCommand>();
            services.AddTransient<IUserRegistrationCommand, EFUserRegistrationCommand>();
            services.AddTransient<IDeleteUserCommand, EFDeleteUserCommand>();

            //PostController
            services.AddTransient<IGetPostsQuery, EFGetPostsQuery>();
            services.AddTransient<IFindPostQuery, EFFindPostQuery>();
            services.AddTransient<ICreatePostCommand, EFCreatePostCommand>();
            services.AddTransient<IDeletePostCommand, EFDeletePostCommand>();

            //CommentController
            services.AddTransient<ICreateCommentCommand, EFCreateCommentCommand>();
            services.AddTransient<IDeleteCommentCommand, EFDeleteCommentCommand>();


            //CategoryController
            services.AddTransient<IGetCategoriesQuery, EFGetCategoriesQuery>();
            services.AddTransient<IFindCategoryQuery, EFFindCategoryQuery>();
            services.AddTransient<IEditCategoryCommand, EFEditCategoryCommand>();
            services.AddTransient<ICreateCategoryCommand, EFCreateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, EFDeleteCategoryCommand>();

            //TagController
            services.AddTransient<IGetTagsQuery, EFGetTagsQuery>();
            services.AddTransient<IFindTagQuery, EFFindTagQuery>();
            services.AddTransient<IEditTagCommand, EFEditTagCommand>();
            services.AddTransient<ICreateTagCommand, EFCreateTagCommand>();
            services.AddTransient<IDeleteTagCommand, EFDeleteTagCommand>();

            //ExceptionLogsController
            services.AddTransient<IFindExceptionLogQuery, EFFindExceptionLogQuery>();

            //UseCaseLogsController
            services.AddTransient<IGetUseCaseLogsQuery, EFGetUseCaseLogsQuery>();

            //Logger
            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();

            //Exception
            services.AddTransient<IExceptionLogger, DatabaseExceptionLogger>();

            services.AddTransient<UseCaseExecutor>();

            //Validators
            services.AddTransient<UserRegistrationValidator>();
            services.AddTransient<CreateTagValidator>();
            services.AddTransient<CreateCategoryValidator>();

            //services.AddTransient<IApplicationActor>();

            services.AddControllers();

            //Swagger
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //Swagger
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog"));
            }

            app.UseRouting();

            //E X C E P T I O N
            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           
        }
    }
}
