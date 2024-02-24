using UnityEngine;
using UnityEngine.Events;

public abstract class BaseMiniGame : MonoBehaviour
{
    public UnityEvent GameFinishedSuccessfully;
    public UnityEvent GameFinishedUnsuccessfully;

    private Rigidbody2D _rocketRb;

	private void Awake()
	{
		GameFinishedSuccessfully ??= new UnityEvent();
		GameFinishedUnsuccessfully ??= new UnityEvent();
	}

	public virtual void StartGame(RocketController controller)
    {
        _rocketRb = controller.GetComponent<Rigidbody2D>();
        _rocketRb.velocity = Vector2.zero;
        _rocketRb.angularVelocity = 0;
        _rocketRb.isKinematic = true;

        controller.transform.parent = transform;
	}

    public void EndGame(bool success)
    {
		_rocketRb.isKinematic = false;
		_rocketRb.transform.parent = null;

		if (success)
			GameFinishedSuccessfully?.Invoke();
		else
			GameFinishedUnsuccessfully?.Invoke();
	}
}
