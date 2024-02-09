namespace HW_Middleware
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _environment;

        public MyMiddleware(RequestDelegate next, IWebHostEnvironment environment)
        {
            _next = next;
            _environment = environment;
        }

        public async Task Invoke(HttpContext context)
        {
            string filePath = @"D:\VS Projects\HW_Middleware\HW_Middleware\logs.txt";

            context.Response.OnStarting(() =>
            {
                using (StreamWriter writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine("Request from: " + _environment.ApplicationName + " Request to: " + context.Request.Path);
                }
                return Task.CompletedTask;
            });

            await _next(context);
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMy(this IApplicationBuilder app)
        {
            return app.UseMiddleware<MyMiddleware>();

        }
    }
}
