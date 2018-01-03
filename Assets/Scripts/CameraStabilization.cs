using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class CameraStabilization : MonoBehaviour, IStabilizer
{
    private readonly BaseRayStabilizer _rayStabilizer = new VuforiaStabilizer();
    public bool IsStabilizing { get; set; }

    private void OnEnable()
    {
        _rayStabilizer.Reset();
    }

    private void LateUpdate()
    {
        _rayStabilizer.UpdateStability(transform.localPosition, transform.localRotation);
        if (IsStabilizing)
        {
            transform.localPosition = _rayStabilizer.StablePosition;
            transform.localRotation = _rayStabilizer.StableRotation;
        }
    }

}
