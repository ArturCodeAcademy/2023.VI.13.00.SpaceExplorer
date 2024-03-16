using TMPro;
using UnityEngine;

public class FuelPointer : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private TMP_Text _distanceText;

    private static RocketController _rocketController;

    private void Awake()
    {
		_rocketController ??= FindObjectOfType<RocketController>();
	}

    private void Update()
    {
		transform.position = _rocketController.transform.position;
        transform.up = _parent.position - transform.position;

        float distance = Vector3.Distance(_parent.position, transform.position);
        _distanceText.text = $"{distance:F0} km"; 
	}
}
