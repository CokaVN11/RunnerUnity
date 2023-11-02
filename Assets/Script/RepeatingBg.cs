using UnityEngine;

public class RepeatingBg : MonoBehaviour
{
    public float speed;
    private float _endX, _startX;
    public int level;

    public Transform root;

    private BoxCollider2D _collider;
    // Start is called before the first frame update
    private void Start()
    {
        level = OptionMenu.SelectedLevel;
        _collider = gameObject.GetComponent<BoxCollider2D>();
        speed = speed * level + speed;
        var position = root.position;
        var size = _collider.size;
        _endX = position.x - size.x;
        _startX = position.x + size.x - 0.2f;
    }

    private void FixedUpdate()
    {
        transform.Translate(speed * Time.fixedDeltaTime * Vector2.left);

        if (!(transform.position.x <= _endX)) return;
        Vector2 pos = new(_startX, transform.position.y);
        transform.position = pos;
        Debug.Log("FPS: " + 1/Time.deltaTime);
    }
}
