using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private RocketController _rocket;
    [SerializeField] private Health _health;
    [SerializeField] private FuelTank _fuelTank;

	[SerializeField] private GameObject _gameOverScreen;

	private void Awake()
	{
		_gameOverScreen.SetActive(false);
	}

	private void OnEnable()
	{
		_health.Died += StopGame;
		_fuelTank.FuelValueChanged += OnFuelValueChanged;
	}

	private void OnDisable()
	{
		_health.Died -= StopGame;
		_fuelTank.FuelValueChanged -= OnFuelValueChanged;
	}

	private void OnFuelValueChanged(float current, float _)
	{
		if (current <= 0)
			StopGame();
	}

	private void StopGame()
	{
		_rocket.enabled = false;
		_gameOverScreen.SetActive(true);
		enabled = false;
	}
}
