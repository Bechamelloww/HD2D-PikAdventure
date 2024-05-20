using UnityEngine;

public class ScoreBasedVisibility : MonoBehaviour
{
    public GameObject objectGroup;
    public int requiredScore;

    void Update()
    {
        objectGroup.SetActive(GlobalScore.Score >= requiredScore);
    }
}
