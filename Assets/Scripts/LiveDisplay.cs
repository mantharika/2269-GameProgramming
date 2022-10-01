using TMPro;
using UnityEngine;

public class LiveDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void UpdatePoint(int live)
    {
        scoreText.text = $"Lives: {live}";
    }
}
