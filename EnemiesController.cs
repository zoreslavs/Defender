using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public float enemyAppearTime;
    public int enemiesMaxCount;

    private float minEnemyPosX;
    private float maxEnemyPosX;
    private float enemyStartPosY;

    private float curTime = 0;
    private int enemiesCurCount = 0;

    private List<GameObject> enPrefabs = new List<GameObject>();
    private List<GameObject> enObjectsList = new List<GameObject>();
    private List<int> enRemovedIndexes = new List<int>();
    private List<float>enPositionsX = new List<float>();

    void Start()
    {
        foreach (Transform enemy in transform)
        {
            enemy.gameObject.SetActive(false);
            enPrefabs.Add(enemy.gameObject);
        }

        curTime = enemyAppearTime;
        enemyStartPosY = enPrefabs[0].transform.position.y;

        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        float enemyWidth = enPrefabs[0].transform.GetComponent<SpriteRenderer>().bounds.size.x * 1.2f;

        minEnemyPosX = screenBounds.x * -1 + enemyWidth;
        maxEnemyPosX = screenBounds.x - enemyWidth * 0.5f;

        float posX = minEnemyPosX;
        while (posX < maxEnemyPosX)
        {
            enPositionsX.Add(posX);
            posX += enemyWidth;
        }
    }

    void Update()
    {
        if (curTime >= enemyAppearTime)
        {
            UpdateEnemiesList();

            if (enemiesCurCount < enemiesMaxCount)
            {
                CreateNewEnemy();
            }
        }

        curTime += Time.deltaTime;
    }

    private void UpdateEnemiesList()
    {
        enRemovedIndexes.Clear();
        for (int i = 0; i < enObjectsList.Count; i++)
        {
            GameObject enemy = enObjectsList[i];
            if (enemy == null)
            {
                enRemovedIndexes.Add(i);
            }
        }
        foreach (int index in enRemovedIndexes)
        {
            if (index < enObjectsList.Count)
            {
                enObjectsList.RemoveAt(index);
                enemiesCurCount--;
            }
        }
    }

    private void CreateNewEnemy()
    {
        curTime = 0;
        enemiesCurCount++;

        int randIndex = (int)(Random.value * enPositionsX.Count);
        if (randIndex >= enPositionsX.Count)
            randIndex = enPositionsX.Count - 1;

        Vector3 position = new Vector3(GetRandomPosX(), enemyStartPosY, transform.position.z);
        GameObject newEnemy = Instantiate(GetRandomEnemyPrefab(), position, Quaternion.identity);
        newEnemy.SetActive(true);

        enObjectsList.Add(newEnemy);
    }

    private float GetRandomPosX()
    {
        float posX;
        int randIndex = (int)(Random.value * enPositionsX.Count);
        if (randIndex >= enPositionsX.Count)
            randIndex = enPositionsX.Count - 1;

        posX = enPositionsX[randIndex]; //Random.Range(minEnemyPosX, maxEnemyPosX)
        foreach (GameObject enemy in enObjectsList)
        {
            if (enemy != null && enemy.transform.position.x == posX)
            {
                posX = GetRandomPosX();
                break;
            }
        }
        return posX;
    }

    private GameObject GetRandomEnemyPrefab()
    {
        int randIndex = (int)(Random.value * enPrefabs.Count);
        if (randIndex >= enPrefabs.Count)
            randIndex = enPrefabs.Count - 1;

        return enPrefabs[randIndex];
    }
}