using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnimateOnScoreIncrease : MonoBehaviour
{
    private int previousScore;
    public Image m_Image;
    public Sprite[] m_SpriteArray;
    public float m_Speed = .02f;
    private int m_IndexSprite;
    Coroutine m_CorotineAnim;

    void Start()
    {
        previousScore = GlobalScore.Score;
    }

    void Update()
    {
        if (GlobalScore.Score > previousScore)
        {
            Func_PlayUIAnim();
            previousScore = GlobalScore.Score;
        }
    }

    public void Func_PlayUIAnim()
    {
        if (m_CorotineAnim != null)
        {
            StopCoroutine(m_CorotineAnim);
        }
        m_CorotineAnim = StartCoroutine(Func_PlayAnimUI());
    }

    IEnumerator Func_PlayAnimUI()
    {
        m_IndexSprite = 0;
        while (m_IndexSprite < m_SpriteArray.Length)
        {
            m_Image.sprite = m_SpriteArray[m_IndexSprite];
            m_IndexSprite += 1;
            yield return new WaitForSeconds(m_Speed);
        }
    }
}
