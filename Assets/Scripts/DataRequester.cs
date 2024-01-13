using Newtonsoft.Json;
using System.Collections;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class DataRequester : MonoBehaviour
{
    public bool IsDataReady { get; private set; } = false;
    public RequestResponeObject Data { get; private set; }

    private string _apiKey;

    private const string URL = "https://api.n2yo.com/rest/v1/satellite/above/{0}/{1}/{2}/{3}/{4}/&apiKey={5}";

	private void Start()
	{
		_apiKey = Resources.Load<TextAsset>("api-key").text;
        StartCoroutine(RequestData());
	}

	private IEnumerator RequestData()
    {
		string url = string.Format( URL,
									54.6872,
									25.2797,
                                    0,
                                    60,
                                    0,
                                    _apiKey);

		HttpClient client = new();
        Task<string> response = client.GetStringAsync(url);
        yield return new WaitUntil(() => response.IsCompleted);

        string json = response.Result;
        Data = JsonConvert.DeserializeObject<RequestResponeObject>(json);
        IsDataReady = true;
	}
}
