using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        StartBlinking();
        Destroy(gameObject, 7);
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Blink()
    {
        while (true)
        {
            text.text = "Press Up Arrow to jump over the obstacles and earn points";
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
            yield return new WaitForSeconds(0.75f);
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            yield return new WaitForSeconds(0.75f);
            text.text = "Press Down Arrow to evade the bird and earn points";
            text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
            yield return new WaitForSeconds(0.75f);
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
            yield return new WaitForSeconds(0.75f);
        }
    }
    private void StartBlinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");

    }
    private void StopBlinking()
    {
        StopCoroutine("Blink");
    }
}
