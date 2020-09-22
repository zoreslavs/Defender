using UnityEngine;

public class MineBehaviour : MonoBehaviour
{
    public float damage;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            collider.gameObject.GetComponent<EnemyBehaviour>().HandleHit(transform.position, damage);
            Destroy(gameObject);
        }
    }
}