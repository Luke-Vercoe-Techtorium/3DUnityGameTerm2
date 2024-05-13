using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private float LookSpeed = 8.0f;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }

        float lookVertical = Input.GetAxisRaw("Mouse Y");
        cam.transform.rotation = Quaternion.AngleAxis(lookVertical * LookSpeed, -cam.transform.right) * cam.transform.rotation;

        float lookHorizontal = Input.GetAxisRaw("Mouse X");
        transform.SetPositionAndRotation(
            Player.transform.position,
            Quaternion.AngleAxis(lookHorizontal * LookSpeed, transform.up) * transform.rotation
        );

        var distance = 5.0f;
        if (Physics.Raycast(
            cam.transform.position,
            -cam.transform.forward,
            out var hitInfo
        ))
        {
            distance = Mathf.Min(
                hitInfo.distance
                    - Camera.main.nearClipPlane / Vector3.Dot(cam.transform.forward, hitInfo.normal),
                distance
            );
        }
        cam.transform.localScale = new(cam.transform.localScale.x, cam.transform.localScale.y, distance);
    }
}
