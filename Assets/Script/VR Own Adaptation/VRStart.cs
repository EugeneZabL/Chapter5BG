using Google.XR.Cardboard;
using UnityEngine;


public class VRStart : MonoBehaviour
{
    public void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.brightness = 1.0f;
    }

    public void Update()
    {
        if (Api.IsGearButtonPressed)
        {
            Api.ScanDeviceParams();
        }

        if (Api.IsCloseButtonPressed)
        {
            Application.Quit();
        }

        if (Api.IsTriggerHeldPressed)
        {
            Api.Recenter();
        }

#if !UNITY_EDITOR
Api.UpdateScreenParams();
#endif

    }
}
