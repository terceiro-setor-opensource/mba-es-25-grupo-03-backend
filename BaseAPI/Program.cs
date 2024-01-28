using Business;
using Business.Model;
using Data.Core;
using Data.Repository;
using Data.Repository.Model;
using Infra;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

#region Repository

#region Usuário

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

#endregion

#region Curso

builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<ICategoriaCursoRepository, CategoriaCursoRepository>();
builder.Services.AddScoped<IConteudoCursoRepository, ConteudoCursoRepository>();
builder.Services.AddScoped<IMatriculaCursoRepository, MatriculaCursoRepository>();

#endregion

#region Notificacao

builder.Services.AddScoped<INotificacaoCursoRepository, NotificacaoCursoRepository>();
builder.Services.AddScoped<INotificacaoMatriculaRepository, NotificacaoMatriculaRepository>();

#endregion

#region Mensagem

builder.Services.AddScoped<IMensagemRepository, MensagemRepository>();

#endregion

#endregion

#region Business

builder.Services.AddScoped<ILoginBusiness, LoginBusiness>();

#region Usuário

builder.Services.AddScoped<IUsuarioBusiness, UsuarioBusiness>();

#endregion

#region Curso

builder.Services.AddScoped<ICursoBusiness, CursoBusiness>();
builder.Services.AddScoped<ICategoriaCursoBusiness, CategoriaCursoBusiness>();
builder.Services.AddScoped<IConteudoCursoBusiness, ConteudoCursoBusiness>();

#endregion

#region Notificacao

builder.Services.AddScoped<INotificacaoBusiness, NotificacaoBusiness>();

#endregion

#region Mensagem

builder.Services.AddScoped<IMensagemBusiness, MensagemBusiness>();

#endregion

#endregion

builder.Services.AddDbContext<IContext, Context>();

builder.Services.AddMemoryCache();

Swagger.RegisterServices(builder.Services);

JwtServices.RegisterServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.Use((context, next) =>
{
    context.Request.EnableBuffering();
    return next();
}); 

app.UseExceptionHandler(a => a.Run(context =>
{
    IExceptionHandlerPathFeature exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
    Exception exception = exceptionHandlerPathFeature.Error;

    return Task.CompletedTask;
}));

Swagger.Configure(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials());

app.MapControllerRoute(name: "default", pattern: "api/{controller}/{id?}");

app.MapControllers();

app.Run();