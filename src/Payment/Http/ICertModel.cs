using System.Net;

namespace Payment.Http
{
    public interface ICertModel
	{
		void SetCert(HttpWebRequest request);
	}
}
