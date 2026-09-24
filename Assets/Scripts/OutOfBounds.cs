using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -26 || transform.position.x > 26)
        {
            Destroy(gameObject);
        }

        if (transform.position.z < -26 || transform.position.z > 26)
        {
            Destroy(gameObject);
        }

        if (transform.position.y < -26 || transform.position.y > 26)
        {
            Destroy(gameObject);
        }

        if (player.transform.position.y < -26 || player.transform.position.y > 26)
        {
            player.transform.position = new Vector3 (0, 0.5f, 0);
        }
    }
}
