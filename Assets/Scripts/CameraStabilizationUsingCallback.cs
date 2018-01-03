using HoloToolkit.Unity.InputModule;
using UnityEngine;
using Vuforia;

public class CameraStabilizationUsingCallback : MonoBehaviour, IStabilizer
{
    private readonly BaseRayStabilizer _rayStabilizer = new VuforiaStabilizer();
    public bool IsStabilizing { get; set; }

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
        if (IsStabilizing)
        {
            transform.localPosition = _rayStabilizer.StablePosition;
            transform.localRotation = _rayStabilizer.StableRotation;
        }
    }

}