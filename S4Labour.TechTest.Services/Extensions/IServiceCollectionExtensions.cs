using F3R4L.DevPack.Api.Factories;
using F3R4L.DevPack.Api.Services;
using F3R4L.DevPack.Api.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Options;
using S4Labour.TechTest.Services;
using S4Labour.TechTest.Services.Endpoints.Options;

namespace S4Labour.TechTest.Services.Extensions
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<RemoteUrlOptions>(configuration.GetSection(RemoteUrlOptions.ConfigurationSection));

			return services;
		}

		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<IRandomUserService, RandomUserService>();
			services.AddSingleton<IUserStorageService, UserStorageService>();

			services.AddHttpClient();

			services.AddSingleton(typeof(IHttpContextAccessor), typeof(HttpContextAccessor));
			services.AddSingleton(typeof(IHttpClientGenerationFactory), typeof(HttpClientGenerationFactory));
			services.AddSingleton(typeof(IOptionsMonitor<HttpClientFactoryOptions>), typeof(OptionsMonitor<HttpClientFactoryOptions>));
			services.AddScoped(typeof(IApiService), typeof(ApiService));
			services.AddScoped(typeof(IJsonSerialisationWrapper), typeof(JsonSerialisationWrapper));

			return services;
		}
	}
}
