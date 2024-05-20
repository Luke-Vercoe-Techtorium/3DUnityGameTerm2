using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab = null;
    [SerializeField]
    private float ShootDelay = 1.0f;
    [SerializeField]
    private float ShootStrength = 1.0f;
    private float timer = 0.0f;

    public void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        while (timer >= ShootDelay)
        {
            GameObject bullet = Instantiate(
                BulletPrefab,
                transform.position
                    + (transform.localScale.y + 0.5f * BulletPrefab.transform.localScale.y) * transform.up,
                transform.rotation
            );
            bullet.GetComponent<Rigidbody>().AddForce(transform.up * ShootStrength, ForceMode.VelocityChange);
            timer -= ShootDelay;
        }
    }
}
