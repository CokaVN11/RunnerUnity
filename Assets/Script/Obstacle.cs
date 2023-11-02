using UnityEngine;

namespace Script
{
    public class Obstacle : MonoBehaviour
    {
        public int damage = 1;
        public float speed;

        public int level;
        private static readonly int State = Animator.StringToHash("State");

        // Start is called before the first frame update
        private void Start()
        {
            level = OptionMenu.SelectedLevel;
            speed = speed * level + speed;
        }

        private void FixedUpdate()
        {
            transform.Translate(speed * Time.fixedDeltaTime * Vector2.left);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            other.GetComponent<PlayerController>().health -= damage;
            other.GetComponent<PlayerController>().touching = true;
            other.GetComponent<Animator>().SetInteger(State, 2);
            // Debug.Log(other.GetComponent<PlayerController>().health);
            Destroy(gameObject);
        }
    }
}
