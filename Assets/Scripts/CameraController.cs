using UnityEngine;

public class CameraController : MonoBehaviour
{
    InputSystem_Actions controls;
    GameObject player;
    float cameraSensitivity = 100;

    void Awake()
    {
        controls = new InputSystem_Actions();
    }

    void OnEnable()
    {
        controls.Player.Enable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookInput = controls.Player.Look.ReadValue<Vector2>();
        float horizontalInput = lookInput.x;
        transform.Rotate(Vector3.up * horizontalInput * cameraSensitivity * Time.deltaTime);
    }

    void LateUpdate()
    {
        transform.position = player.transform.position;
    }
}
