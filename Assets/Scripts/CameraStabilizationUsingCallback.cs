using HoloToolkit.Unity.InputModule;
using UnityEngine;
using Vuforia;

public class CameraStabilizationUsingCallback : MonoBehaviour
{
    private readonly BaseRayStabilizer _rayStabilizer = new VuforiaStabilizer();

    private void OnEnable()
    {
        _rayStabilizer.Reset();
        VuforiaARController.Instance.RegisterTrackablesUpdatedCallback(OnTrackablesUpdated);
    }

    private void OnDisable()
    {
        VuforiaARController.Instance.UnregisterTrackablesUpdatedCallback(OnTrackablesUpdated);
    }

    private void OnTrackablesUpdated()
    {
        _rayStabilizer.UpdateStability(transform.localPosition, transform.localRotation);

        transform.localPosition = _rayStabilizer.StablePosition;
        transform.localRotation = _rayStabilizer.StableRotation;
    }
}