using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject focalPoint;
    [SerializeField] GameObject projectilePrefab;
    float normalSpeed = 10;
    float boostedSpeed = 20;
    float jumpforce = 15f;
    float playerSpeed;
    InputSystem_Actions controls;

    Vector2 moveInput;
    Rigidbody playerRb;
    bool onGround;

    void Awake()
    {
        controls = new InputSystem_Actions();
        focalPoint = GameObject.Find("Focal Point");
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controls.Player.Sprint.IsPressed())
        {
            playerSpeed = boostedSpeed;
        }
        else
        {
            playerSpeed = normalSpeed;
        }
        
        if (onGround)
        {
            moveInput = controls.Player.Move.ReadValue<Vector2>();
            playerRb.AddForce(focalPoint.transform.forward * moveInput.y * playerSpeed * Time.deltaTime, ForceMode.Impulse);
            playerRb.AddForce(focalPoint.transform.right * moveInput.x * playerSpeed * Time.deltaTime, ForceMode.Impulse);
            
            if (controls.Player.Jump.IsPressed())
            {
                playerRb.AddForce(Vector3.up * jumpforce);
            }
        }

        if (controls.Player.Attack.IsPressed())
        {
            ShootProjectile();
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

    void ShootProjectile()
    {
        Vector3 projectilePosition = focalPoint.transform.position + new Vector3(0, 0, 1);
        Instantiate(projectilePrefab, projectilePosition, focalPoint.transform.rotation);
    }
}
