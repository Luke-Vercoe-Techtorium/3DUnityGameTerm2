using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerWalking>(out var player))
            if (player.RespawnPoint != this)
            {
                player.RespawnPoint = this;
                player.Lives = player.MaxLives;
            }
    }
}
