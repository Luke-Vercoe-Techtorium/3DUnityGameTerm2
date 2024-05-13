using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerWalking>(out var player))
            player.RespawnPoint = this;
    }
}
