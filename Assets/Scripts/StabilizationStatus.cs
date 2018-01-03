using UnityEngine;

public class StabilizationStatus : MonoBehaviour
{
    [SerializeField]
    private GameObject _stabilizerHolder;
    [SerializeField]
    private GameObject _onText;
    [SerializeField]
    private GameObject _offText;

    private IStabilizer _stabilizer;


    private void Awake()
    {
        _stabilizer = _stabilizerHolder.GetComponent<IStabilizer>();
    }

    private void Update()
    {
        if (_stabilizer == null) { return; }

        _onText.SetActive(_stabilizer.IsStabilizing);
        _offText.SetActive(!_stabilizer.IsStabilizing);
    }

    public void ToggleStabilization()
    {
        if (_stabilizer == null) { return; }
        _stabilizer.IsStabilizing = !_stabilizer.IsStabilizing;
    }
}
