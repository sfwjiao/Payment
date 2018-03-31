using System.Net;

namespace Payment.Http
{
    internal interface ICertModel
	{
		void SetCert(HttpWebRequest request);
	}
}
