namespace API.Extensions
{
	public static class MiddlewareExtensions
	{
		public static void UseCustomMiddlewares(this IApplicationBuilder app)
		{
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints => endpoints.MapControllers());
		}
	}
}
