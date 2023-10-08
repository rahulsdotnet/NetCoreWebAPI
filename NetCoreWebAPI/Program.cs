using NetCoreWebAPI.Middleware;
using NetCoreWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

var allowedOrigin = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("myAppCors", policy =>
    {
        policy.WithOrigins(allowedOrigin)
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

//Step2 
builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();

builder.Services.AddControllers();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Step3 

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

#region Built in Exception Middleware example to handle the global exception
//app.UseExceptionHandler(options =>
//{
//    options.Run(async (context) =>
//    {
//        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
//        context.Response.ContentType = Text.Plain;
//        var exceptionHandlerPathFeature =
//                context.Features.Get<IExceptionHandlerPathFeature>();
//        await context.Response.WriteAsync("Error occured while proccessing the request");
//    });
//});
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("myAppCors");
app.UseAuthorization();

#region Use, Map and MapWhen Extension method example for configuring the middleware
//4. MapWhen (predicate function if that is true then the associated middleware exec)

//app.MapWhen(context => context.Request.Query.ContainsKey("channel"), HandleMapWhen);

//static void HandleMapWhen(IApplicationBuilder app)
//{
//    app.Run(async (context) =>
//    {
//        var channel = context.Request.Query["channel"];
//        await context.Response.WriteAsync($"Channel is : {channel}");
//    });
//}

////3. Map(Branch the request pipeline based on match of the given request path

//app.Map("/test1", HandleMap);

//static void HandleMap(IApplicationBuilder app)
//{
//    app.Run(async (context) => await context.Response.WriteAsync("Test1 from Map Middleware"));
//}

////2. Use
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("This is from Middleware1");
//    await next.Invoke();
//});

////1. Run (Terminal)

//app.Run(async (context) => await context.Response.WriteAsync("This is a Terminal middleware"));

#endregion


app.MapControllers();
app.Run();

//https://tools.ietf.org/html/rfc7231#section-6.6.1