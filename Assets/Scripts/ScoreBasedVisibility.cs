using UnityEngine;

public class ScoreBasedVisibility : MonoBehaviour
{
    public GameObject objectGroup;
    public int newRequiredScore;

    void Start()
    {
        GlobalScore.RequiredScore = 0;
    }

    void Update()
    {
        GlobalScore.RequiredScore = newRequiredScore;
        objectGroup.SetActive(GlobalScore.Score >= GlobalScore.RequiredScore);
    }
}
