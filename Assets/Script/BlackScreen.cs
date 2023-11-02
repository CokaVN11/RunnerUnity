using UnityEngine;

public class BlackScreen : MonoBehaviour
{
    private RectTransform rect;
    // Use this for initialization
    void Start()
    {
        rect = GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {

    }
}