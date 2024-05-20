using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthShowManager : MonoBehaviour
{
    public DeathMenuManager deathMenuManager;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        if(deathMenuManager.health > numOfHearts)
        {
            deathMenuManager.health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < deathMenuManager.health)
            {
                hearts[i].sprite = fullHeart;
            } else
            {
                hearts[i].sprite = emptyHeart;
            }

            if(i<numOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }
        }
        
    }
}
