using UnityEngine;
using static OptionMenu;

public class Spawning : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float _timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime;
    public bool fly;
    public float timeWaiting;
    private Vector2 _pos;

    private void Start()
    {
        minTime -= (float)SelectedLevel / 5.0f;
        decreaseTime += (float)SelectedLevel / 5.0f;
    }

    private void Update()
    {
        var position = transform.position;
        if (!(Time.time > timeWaiting)) return;
        if (_timeBtwSpawn <= 0)
        {
            var rand = Random.Range(0, obstaclePatterns.Length);
            var flyPos = Random.Range(0, 2);
            if (obstaclePatterns[rand].name == "Flying")
            {
                    
                _pos = flyPos == 1 ? new Vector2(position.x, position.y + 1.32f) : new Vector2(position.x, position.y);
            }
            else _pos = new Vector2(position.x, position.y);

            Instantiate(obstaclePatterns[rand], _pos, Quaternion.identity);
            _timeBtwSpawn = startTimeBtwSpawn;
            if (startTimeBtwSpawn > minTime)
                startTimeBtwSpawn -= decreaseTime;
            else if (startTimeBtwSpawn < minTime)
                startTimeBtwSpawn = minTime;
        }
        else
        {
            _timeBtwSpawn -= Time.deltaTime;
        }

    }
}
