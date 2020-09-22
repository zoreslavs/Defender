using UnityEngine;

public class FlameBehaviour : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public float damage;
    public LayerMask whatIsSolid;

    private float curDistance = 0;
    private float curFlameTime = 0;
    private Vector3 maxScale;
    private Vector3 minScale;
    private Vector3 scaleDiff;
    private SpriteRenderer sprite;

    void Start()
    {
        maxScale = transform.localScale;
        minScale = maxScale / 5;
        scaleDiff = maxScale - minScale;

        transform.localScale = minScale;

        sprite = transform.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (curFlameTime >= lifetime)
        {
            Destroy(gameObject);
            return;
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyBehaviour>().HandleHit(transform.position, damage);
                curDistance = distance;
            }
        }

        if (curDistance < distance)
        {
            Vector2 velocity = Vector2.up * speed * Time.deltaTime;
            transform.Translate(velocity);

            curDistance += speed * Time.deltaTime;
        }
        else
        {
            curFlameTime += Time.deltaTime;
            float alpha = (lifetime - curFlameTime) / lifetime;
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha);
        }

        if (transform.localScale.x < maxScale.x)
        {
            Vector3 curScale = scaleDiff * (curDistance / distance) + minScale;
            transform.localScale = curScale;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}