using UnityEngine;

public class StabilizationStatus : MonoBehaviour
{
    [SerializeField]
    private MonoBehaviour _stabilizationBehaviour;
    [SerializeField]
    private GameObject _onText;
    [SerializeField]
    private GameObject _offText;


    private void Update()
    {
        if (_stabilizationBehaviour == null) { return; }

        _onText.SetActive(_stabilizationBehaviour.enabled);
        _offText.SetActive(!_stabilizationBehaviour.enabled);
    }
}
