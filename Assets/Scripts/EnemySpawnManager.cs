using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2.0f, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector3 enemyPosition = new Vector3 (RandomPositionX(), 1f, RandomPositionZ());
        Instantiate(enemiesObject[RandomEnemy()], enemyPosition, transform.rotation);
    }

    int RandomEnemy()
    {
        return Random.Range(0, enemiesObject.Length);
    }

    float RandomPositionX()
    {
        return Random.Range(-20, 20);
    }

    float RandomPositionZ()
    {
        return Random.Range(-20, 20);
    }
}
