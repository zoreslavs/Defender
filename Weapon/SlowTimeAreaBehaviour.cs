using UnityEngine;

public class SlowTimeAreaBehaviour : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("OnTriggerStay2D: " + gameObject.tag + " : " + collider.tag);
        if (collider.gameObject.CompareTag("Enemy"))
        {
            collider.gameObject.GetComponent<EnemyBehaviour>().SlowTime(true);
        }
    }
}
