using UnityEngine;

public class FrameRate : MonoBehaviour
{
    public int frameRate;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Fps: " + Application.targetFrameRate);
        if (Application.targetFrameRate != frameRate)
        {
            Application.targetFrameRate = frameRate;
        }
    }
}
