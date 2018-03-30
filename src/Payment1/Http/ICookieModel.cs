using System.Net;

namespace Payment.Http
{
    internal interface ICookieModel
	{
		void SetCookies(HttpWebRequest request);
		void GetCookies(HttpWebResponse response);
		CookieCollection Cookies { get; }
	}
}
