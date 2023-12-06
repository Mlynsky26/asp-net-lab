namespace Labolatorium3___App.Models
{
    public class LastVisitCookie
    {
        private readonly RequestDelegate _next;
        public readonly static string CookieName = "VISIT";

        public LastVisitCookie(RequestDelegate @delegate)
        {
            _next = @delegate;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Cookies.ContainsKey(CookieName))
            {
                if (context.Request.Cookies.TryGetValue(CookieName, out string value))
                {
                    var visitDate = DateTime.Parse(value);
                    context.Items.Add(CookieName, visitDate);
                }
                else
                {
                    context.Items.Add(CookieName, "Unknown date of last visit.");
                }
            }
            else
            {
                context.Items.Add(CookieName, "First visit.");
            }

            CookieOptions options = new CookieOptions() { MaxAge = new TimeSpan(400,0,0,0), IsEssential = true};
            context.Response.Cookies.Append(CookieName, DateTime.Now.ToString(), options);
            await _next(context);
        }
    }
}
