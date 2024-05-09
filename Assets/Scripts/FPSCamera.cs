using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private float MoveSpeed = 4.0f;
    [SerializeField]
    private float LookSpeed = 100.0f;
    [SerializeField]
    private float JumpForce = 10.0f;

    private Rigidbody rb = null;
    private bool onGround = false;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Update()
    {
        float lookVertical = Input.GetAxisRaw("Mouse Y");
        cam.transform.rotation = Quaternion.AngleAxis(lookVertical * LookSpeed, -cam.transform.right) * cam.transform.rotation;

        float lookHorizontal = Input.GetAxisRaw("Mouse X");
        rb.MoveRotation(Quaternion.AngleAxis(lookHorizontal * LookSpeed, transform.up) * transform.rotation);

        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            onGround = false;
            rb.AddForce(transform.up * JumpForce, ForceMode.VelocityChange);
        }
    }

    public void FixedUpdate()
    {
        float forward = Input.GetKey(KeyCode.W) ? 1.0f : 0.0f;
        float backward = Input.GetKey(KeyCode.S) ? -1.0f : 0.0f;
        float left = Input.GetKey(KeyCode.A) ? -1.0f : 0.0f;
        float right = Input.GetKey(KeyCode.D) ? 1.0f : 0.0f;
        Vector3 moveDirection =
            (forward + backward) * transform.forward +
            (left + right) * transform.right;
        moveDirection = moveDirection.normalized * MoveSpeed;

        rb.MovePosition(transform.position + moveDirection * Time.fixedDeltaTime);
    }

    public void OnTriggerStay()
    {
        onGround = true;
    }

    public void OnTriggerExit()
    {
        onGround = false;
    }
}
