using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private GameObject PauseMenu;
    [SerializeField]
    private GameObject cam;
    [SerializeField]
    private float LookSpeed = 8.0f;

    public void OnEnable()
    {
        UnPause();
    }

    public void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Pause()
    {
        PauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0.0f;
    }

    private void UnPause()
    {
        PauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1.0f;
    }

    public void Update()
    {
        if (PauseMenu.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                UnPause();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Pause();

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
}
