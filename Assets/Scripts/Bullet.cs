using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float DecayTime = 5.0f;
    private float timer = 0.0f;

    public void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= DecayTime)
            Destroy(gameObject);
    }
}
