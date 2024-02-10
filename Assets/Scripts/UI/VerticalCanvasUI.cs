using UnityEngine;

public class VerticalCanvasUI : MonoBehaviour
{
	private void LateUpdate()
	{
		transform.rotation = Quaternion.Euler(0, 0, 0);
	}
}
