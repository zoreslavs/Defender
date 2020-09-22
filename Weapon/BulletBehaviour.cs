using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public float damage;
    public LayerMask whatIsSolid;
    
    void Start()
    {
        
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyBehaviour>().HandleHit(transform.position, damage);
            }
            Destroy(gameObject);
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
