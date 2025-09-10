using S4Labour.TechTest.Server.Components;
using S4Labour.TechTest.Services;
using S4Labour.TechTest.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddServices();
builder.Services.AddOptions(builder.Configuration);

builder.Services.AddScoped<ILogger>((provider) => {
	using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
	ILogger logger = factory.CreateLogger("Program");
    return logger;
});

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(policy =>
	{
		policy.WithOrigins("https://localhost:49964")
			.AllowAnyHeader()
			.AllowAnyMethod();
	});
});

builder.Services.AddControllers();

if (builder.Environment.IsDevelopment()) // by default added only for dev.
{
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();
}

var app = builder.Build();
app.MapControllers();
app.UseCors();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
	{
		c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
	});
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

await Task.Run(async () => {
	using (var scope = app.Services.CreateScope())
	{
		var userService = scope.ServiceProvider.GetService<IRandomUserService>();
		var storageService = app.Services.GetService<IUserStorageService>();

		for (var i = 0; i < 10; i++)
		{
			storageService.AllUsers.AddRange((await userService.GetAllUsersAsync()).Users);
		}
	}
});

app.Run();
