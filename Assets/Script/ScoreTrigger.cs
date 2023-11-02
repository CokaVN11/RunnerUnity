using UnityEngine;
using UnityEngine.UI;

public class ScoreTrigger : MonoBehaviour
{
    public int score;
    public Text scoreDisplay;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = score.ToString();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Obstacles"))
        {
            if (player.GetComponent<PlayerController>().health >= 1)
                score++;
            Destroy(other.gameObject);
        }
    }
}
