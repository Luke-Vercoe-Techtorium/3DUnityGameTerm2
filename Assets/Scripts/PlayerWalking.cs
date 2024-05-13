using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWalking : MonoBehaviour
{
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private float MoveForce = 1.0f;
    [SerializeField]
    private float JumpForce = 10.0f;
    [SerializeField]
    public Checkpoint RespawnPoint = null;

    private Rigidbody rb = null;
    private bool onGround = false;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if (onGround && Input.GetKeyDown(KeyCode.Space))
        {
            onGround = false;
            rb.AddForce(cam.transform.up * JumpForce, ForceMode.VelocityChange);
        }
    }

    public void FixedUpdate()
    {
        if (transform.position.y < -20.0f)
            if (RespawnPoint != null)
                transform.position =
                    RespawnPoint.transform.position +
                    new Vector3(0.0f, (RespawnPoint.transform.localScale.y + transform.localScale.y) * 0.5f, 0.0f);
            else
                SceneManager.LoadScene(0);

        float forward = Input.GetKey(KeyCode.W) ? 1.0f : 0.0f;
        float backward = Input.GetKey(KeyCode.S) ? -1.0f : 0.0f;
        float left = Input.GetKey(KeyCode.A) ? -1.0f : 0.0f;
        float right = Input.GetKey(KeyCode.D) ? 1.0f : 0.0f;

        Vector3 moveDirection =
            (forward + backward) * cam.transform.right +
            (left + right) * -cam.transform.forward;

        rb.AddTorque(moveDirection.normalized * MoveForce, ForceMode.Force);
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
