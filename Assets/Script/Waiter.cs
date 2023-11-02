using System.Collections;
using UnityEngine;

public class Waiter : MonoBehaviour
{
    public float timeWaiting;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Waiting());
    }
    IEnumerator Waiting()
    {
        print(Time.time);
        yield return new WaitForSeconds(timeWaiting);
        print(Time.time);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
