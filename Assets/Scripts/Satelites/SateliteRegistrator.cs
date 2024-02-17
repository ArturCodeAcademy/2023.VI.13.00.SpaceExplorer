using UnityEngine;

public class SateliteRegistrator : MonoBehaviour
{
	[SerializeField] private Satelite _satelite;

	private void Awake()
	{
		_satelite ??= GetComponent<Satelite>();
		SatelitePool.Instance.AddSatelite(_satelite);
	}

	private void OnDestroy()
	{
		SatelitePool.Instance.RemoveSatelite(_satelite);
	}
}
