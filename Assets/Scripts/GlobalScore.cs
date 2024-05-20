using UnityEngine;
using UnityEngine.UI;

public class GlobalScore : MonoBehaviour
{
    private static int score = 0;
    public Text scoreText;

    public static int Score
    {
        get { return score; }
    }

    public static void IncrementScore()
    {
        score++;
    }

    public static void ResetScore()
    {
        score = 0;
    }

    void Update()
    {
        scoreText.text = Score.ToString();
    }
}
