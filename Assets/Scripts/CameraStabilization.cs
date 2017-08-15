using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class CameraStabilization : MonoBehaviour
{
    private BaseRayStabilizer _rayStabilizer;

    private void Awake()
    {
        _rayStabilizer = new VuforiaStabilizer();
    }

    private void OnEnable()
    {
        _rayStabilizer.Reset();
        _rayStabilizer.UpdateStability(transform.localPosition, transform.localRotation);
    }

    private void LateUpdate()
    {
        _rayStabilizer.UpdateStability(transform.localPosition, transform.localRotation);

        transform.localPosition = _rayStabilizer.StablePosition;
        transform.localRotation = _rayStabilizer.StableRotation;
    }
}
