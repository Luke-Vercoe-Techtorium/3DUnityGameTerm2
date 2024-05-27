using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI text = null;
    private float startTime = 0.0f;

    public void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Start()
    {
        startTime = Time.fixedTime;
    }

    public void Update()
    {
        var time = Time.fixedTime - startTime;
        text.text = time.ToString("0.00");
    }
}
