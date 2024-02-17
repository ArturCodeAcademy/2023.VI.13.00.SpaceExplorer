using System.Collections;
using System.Linq;
using UnityEngine;

public class SateliteSpawner : MonoBehaviour
{
	[SerializeField, Min(0)] private float _maxHeight;
	[SerializeField, Range(0, 1)] private float _ratio;
    [SerializeField] private Satelite _satelitePrefab;
	[SerializeField] private GameObject[] _sateliteModelPrefabs;

    [SerializeField] private DataRequester _dataRequester;

	private IEnumerator Start()
	{
		yield return new WaitUntil(() => _dataRequester.IsDataReady);

		foreach (var sateliteInfo in _dataRequester.Data.Above)
		{
			if (sateliteInfo.SatAlt > _maxHeight)
				continue;

			var satelite = Instantiate(_satelitePrefab, transform);
			Instantiate(_sateliteModelPrefabs[Random.Range(0, _sateliteModelPrefabs.Length)], satelite.transform);
			satelite.Panel.SetInfo(sateliteInfo);

			var position = Quaternion.Euler(0, 0, sateliteInfo.SatAlt) * Vector3.up * sateliteInfo.SatAlt * _ratio;
			satelite.transform.position = position;
		}
	}
}
