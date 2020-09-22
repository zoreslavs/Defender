using UnityEngine;

public class TimeSlowerBehaviour : MonoBehaviour
{
    public GameObject affectAreaPrefab;
    public float timeBtwPlaces;

    private GameObject affectArea;
    private float timeToNextPlace = 0;
    private bool isPlaced = false;

    void Start()
    {
        affectArea = Instantiate(affectAreaPrefab, Input.mousePosition, Quaternion.identity);
    }

    void Update()
    {
        if (isPlaced)
        {
            Destroy(affectArea.GetComponent<CircleCollider2D>(), 0.1f);

            if (!affectArea.GetComponent<CircleCollider2D>())
            {
                isPlaced = false;
                affectArea.SetActive(false);
            }
        }
        else if (affectArea.activeInHierarchy)
        {
            Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            affectArea.GetComponent<Transform>().position = position;
        }

        if (timeToNextPlace <= 0)
        {
            if (!affectArea.activeInHierarchy)
                affectArea.SetActive(true);

            if (Input.GetMouseButton(0))
            {
                isPlaced = true;
                timeToNextPlace = timeBtwPlaces;

                CircleCollider2D collider = affectArea.AddComponent<CircleCollider2D>();
                collider.isTrigger = true;
            }
        }
        else
        {
            timeToNextPlace -= Time.deltaTime;
        }
    }
}