using System;
using Newtonsoft.Json;
namespace chanService
{
	public static class ServiceManager
	{
		const string serviceEndpoint = "https://a.4cdn.org/";
		const string boardCatalogEndpoint = "https://a.4cdn.org/{0}/catalog.json";
		const string threadEndpoint = "https://a.4cdn.org/{0}/{1}.json";

		public static bool checkEndpointStatus()
		{
			try
			{
				JsonConvert.DeserializeObject(serviceEndpoint);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public static Board getBoard(string boardAbbreviation)
		{
			Board result =  JsonConvert.DeserializeObject<Board>(string.Format(boardCatalogEndpoint, boardAbbreviation));
			return result;
		}

		public static Thread getThread(string boardAbbreviation, int postId)
		{
			Thread result = JsonConvert.DeserializeObject<Thread>(string.Format(threadEndpoint, boardAbbreviation, postId));
			return result;
		}
	}
}
