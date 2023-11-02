using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    private int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite FullHeart;
    public Sprite EmptyHeart;

    public GameObject player;

    void Update()
    {
        health = player.GetComponent<PlayerController>().health;
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = FullHeart;
            }
            else hearts[i].sprite = EmptyHeart;
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else hearts[i].enabled = false;
        }
    }
}
