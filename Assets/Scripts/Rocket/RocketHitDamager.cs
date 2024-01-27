using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Health))]
public class RocketHitDamager : MonoBehaviour
{
    [SerializeField, Min(0)] private float _damagePerVelocity = 1f;
	[SerializeField, Min(0)] private float _minVelocityToDamage = 1f;

    private Rigidbody2D _rigidbody;
	private Health _health;

    private void Awake()
    {
		_rigidbody = GetComponent<Rigidbody2D>();
		_health = GetComponent<Health>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.relativeVelocity.magnitude < _minVelocityToDamage)
			return;

		float damage = _damagePerVelocity * collision.relativeVelocity.magnitude;
		_health.TakeDamage(damage);
	}
}
