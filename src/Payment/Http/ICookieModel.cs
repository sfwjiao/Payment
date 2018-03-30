using System.Net;

namespace Payment.Http
{
    public interface ICookieModel
	{
		void SetCookies(HttpWebRequest request);
		void GetCookies(HttpWebResponse response);
		CookieCollection Cookies { get; }
	}
}
