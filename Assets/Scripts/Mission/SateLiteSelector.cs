using System.Collections;
using TMPro;
using UnityEngine;

public class SateLiteSelector : MonoBehaviour
{
    [SerializeField] private DataRequester _dataRequester;
	[SerializeField] private TMP_Text _distanceText;

	private Satelite _target;

	private IEnumerator Start()
	{
		yield return new WaitUntil(() => _dataRequester.IsDataReady);
		yield return new WaitUntil(() => SatelitePool.Instance.SateliteCount > 0);
		
		SelectRandomSatelite();
	}

	private void LateUpdate()
	{
		if (_target is null)
			return;

		Vector3 up = _target.transform.position - transform.position;
		transform.rotation = Quaternion.LookRotation(Vector3.forward, up);
		float distance = Vector3.Distance(transform.position, _target.transform.position);
		_distanceText.text = $"{distance:F0} km";
		_distanceText.transform.rotation = Quaternion.identity;
	}

	private void SelectRandomSatelite()
	{
		if (_target is not null)
		{
			_target.Health.Died -= SelectRandomSatelite;
		}

		_target = SatelitePool.Instance[Random.Range(0, SatelitePool.Instance.SateliteCount)];

		if (_target.gameObject.TryGetComponent(out SateliteRotator rotator))
			Destroy(rotator);

		_target.Health.Died += SelectRandomSatelite;
	}
}
