
using NetCoreWebAPI;

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

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddTransient<CustomMiddleware>();

var app = builder.Build();


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
