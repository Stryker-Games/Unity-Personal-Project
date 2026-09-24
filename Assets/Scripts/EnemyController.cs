using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody enemyRb;
    GameObject player;
    [SerializeField] float enemySpeed;
    bool onGround;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAtPlayer = (player.transform.position - transform.position).normalized;
        
        if (onGround)
        {
            enemyRb.AddForce(lookAtPlayer * enemySpeed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}
