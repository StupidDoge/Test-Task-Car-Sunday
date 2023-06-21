using UnityEngine;

public class GameInitialization : MonoBehaviour
{
    private void Start()
    {
        SetFrameRate();
    }

    private void SetFrameRate()
    {
        if (Application.isMobilePlatform)
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = 60;
        }
        else
        {
            Application.targetFrameRate = -1;
        }
    }
}
