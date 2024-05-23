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
    public Checkpoint RespawnPoint = null;
    public int MaxLives = 3;
    [HideInInspector]
    public int Lives = 0;

    private Rigidbody rb = null;
    private bool onGround = false;

    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void FixedUpdate()
    {
        if (transform.position.y < -20.0f)
            if (RespawnPoint != null && Lives > 0)
            {
                transform.SetPositionAndRotation(
                    RespawnPoint.transform.position
                    + new Vector3(0.0f, (RespawnPoint.transform.localScale.y + transform.localScale.y) * 0.5f, 0.0f),
                    Quaternion.identity
                );
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                Lives -= 1;
            }
            else
                SceneManager.LoadScene(0);

        if (onGround && Input.GetKey(KeyCode.Space))
        {
            onGround = false;
            rb.AddForce(cam.transform.up * JumpForce, ForceMode.VelocityChange);
        }

        float forward = Input.GetKey(KeyCode.W) ? 1.0f : 0.0f;
        float backward = Input.GetKey(KeyCode.S) ? -1.0f : 0.0f;
        float left = Input.GetKey(KeyCode.A) ? -1.0f : 0.0f;
        float right = Input.GetKey(KeyCode.D) ? 1.0f : 0.0f;
        float a = Input.GetKey(KeyCode.Q) ? -1.0f : 0.0f;
        float b = Input.GetKey(KeyCode.E) ? 1.0f : 0.0f;

        Vector3 moveDirection =
            (forward + backward) * cam.transform.right +
            (left + right) * -cam.transform.forward +
            (a + b) * cam.transform.up;

        rb.AddTorque(moveDirection.normalized * MoveForce, ForceMode.Force);
    }

    public void OnCollisionStay()
    {
        onGround = true;
    }

    public void OnCollisionExit()
    {
        onGround = false;
    }
}
