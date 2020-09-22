using UnityEngine;

public class MinePlacerBehaviour : MonoBehaviour
{
    public GameObject mine;
    public float timeBtwPlaces;

    private float timeToNextPlace = 0;

    void Start()
    {

    }

    void Update()
    {
        if (timeToNextPlace <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 minePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                minePos.z = 0;
                Instantiate(mine, minePos, Quaternion.identity);

                timeToNextPlace = timeBtwPlaces;
            }
        }
        else
        {
            timeToNextPlace -= Time.deltaTime;
        }
    }
}