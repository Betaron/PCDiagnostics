using System.Reflection;
using System.Text.Json.Serialization;

namespace PCDiagnostics.Web;

public class Startup
{
	private const string Ver = "v1";
	public IConfiguration Configuration { get; }

	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public void ConfigureServices(IServiceCollection services)
	{
		services.AddControllers().AddJsonOptions(j =>
		{
			j.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
		});
		services.AddSwaggerGen(options =>
		{
			options.SwaggerDoc(Ver, new Microsoft.OpenApi.Models.OpenApiInfo
			{ Title = "PC Diagnostics Server", Version = Ver });
			var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
			options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
		});
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
	{
		if (environment.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint($"/swagger/{Ver}/swagger.json", $"PCDiagnostics.Web {Ver}");
				c.RoutePrefix = string.Empty;
			});
		}

		app.UseHttpsRedirection();
		app.UseRouting();
		app.UseEndpoints(endpoints => endpoints.MapControllers());
	}

}
