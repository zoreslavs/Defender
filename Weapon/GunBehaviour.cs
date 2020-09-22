using UnityEngine;

public class GunBehaviour : MonoBehaviour
{
    public float rotationOffset;
    public float timeBtwShots;
    public GameObject bullet;
    public Transform bulletPoint;

    private float timeToNextShot = 0;

    void Start()
    {
        
    }

    void Update()
    {
        Vector3 gunPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mousePos = Input.mousePosition - gunPos;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + rotationOffset));

        if (timeToNextShot <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, bulletPoint.position, transform.rotation);
                timeToNextShot = timeBtwShots;
            }
        }
        else
        {
            timeToNextShot -= Time.deltaTime;
        }
    }
}
