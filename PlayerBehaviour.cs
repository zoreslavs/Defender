using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public float offset;

    private Vector2 screenBounds;
    private float playerWidth;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        playerWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 direction = Vector2.zero;
        if (mousePos.x < playerPos.x - offset)
            direction = Vector2.left;
        else if (mousePos.x > playerPos.x + offset)
            direction = Vector2.right;

        if (direction == Vector2.zero)
            return;

        Vector2 step = direction * speed * Time.deltaTime;
        transform.Translate(step);
    }

    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + playerWidth * 2, screenBounds.x - playerWidth);
        transform.position = viewPos;
    }
}