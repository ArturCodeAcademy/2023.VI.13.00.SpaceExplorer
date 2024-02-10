using UnityEngine;

[RequireComponent(typeof(SateliteInfoPanel))]
public class Satelite : MonoBehaviour
{
    [field: SerializeField] public SateliteInfoPanel Panel { get; private set; }

#if UNITY_EDITOR

    [ContextMenu("Set Satelite Info")]
    private void SetSateliteInfo()
    {
		Panel ??= GetComponent<SateliteInfoPanel>();
	}

#endif
}
