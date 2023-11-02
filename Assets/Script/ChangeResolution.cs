using UnityEngine;

public class ChangeResolution : MonoBehaviour
{
    public int widthRes;
    public int heightRes;
    public void SetMyResolution()
    {
        Screen.SetResolution(widthRes, heightRes, false);
    }
}
