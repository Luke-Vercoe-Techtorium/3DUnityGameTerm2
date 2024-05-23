using TMPro;
using UnityEngine;

public class Lives : MonoBehaviour
{
    private TextMeshProUGUI text = null;
    [SerializeField]
    private PlayerWalking Player = null;

    public void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        text.text = $"Lives: {Player.Lives}";
    }
}
