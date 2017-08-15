using UnityEngine;
using Vuforia;

public class CameraStabilizationUsingCallback : MonoBehaviour
{
    private Vector3 _lastPosition;
    private Quaternion _lastRotation;

    private void OnEnable()
    {
        _lastPosition = transform.localPosition;
        _lastRotation = transform.localRotation;
        VuforiaARController.Instance.RegisterTrackablesUpdatedCallback(OnTrackablesUpdated);
    }

    private void OnDisable()
    {
        VuforiaARController.Instance.UnregisterTrackablesUpdatedCallback(OnTrackablesUpdated);
    }

    private void OnTrackablesUpdated()
    {
        transform.localPosition = Vector3.Lerp(_lastPosition, transform.localPosition, Time.deltaTime);
        transform.localRotation = Quaternion.Lerp(_lastRotation, transform.localRotation, Time.deltaTime);

        _lastPosition = transform.localPosition;
        _lastRotation = transform.localRotation;
    }
}