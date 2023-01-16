using System.IO;
using System.Net;
using System.Text.Json;

namespace PCDiagnostics.Client;

internal enum HttpMethods
{
	Get,
	Post,
	Put,
	Delete
}

internal class Requests
{
	public static TResponse? ServerRequest<TResponse>(string url, object? body = null, string method = "POST")
	{
		HttpWebRequest webRequest = WebRequest.CreateHttp(url);
		webRequest.Method = method;
		webRequest.ContentType = "application/json";
		if (body != null)
			using (StreamWriter writer = new StreamWriter(webRequest.GetRequestStream()))
			{
				writer.Write(JsonSerializer.Serialize(body));
			}
		HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
		using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
		{
			if (!reader.EndOfStream)
				return JsonSerializer.Deserialize<TResponse>(reader.ReadToEnd(),
					options: new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
			else
				return default;
		}
	}
}
