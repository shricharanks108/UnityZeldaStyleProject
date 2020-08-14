using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite threeQuarterHeart;
    public Sprite halfHeart;
    public Sprite quarterHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;

    void Start()
    {
        InitHearts();
    }

    public void InitHearts()
    {
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }

    public void UpdateHearts()
    {
        float tempHealth = playerCurrentHealth.RuntimeValue / 4;
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            float currHeart = Mathf.Ceil(tempHealth - 1);

            if (i <= tempHealth - 1)
            {
                //FullHeart
                hearts[i].sprite = fullHeart;
            }
            else if (i >= tempHealth)
            {
                //emptyHeart
                hearts[i].sprite = emptyHeart;
            }
            else if (i == currHeart && (tempHealth % 1) == .50)
            {
                //Half full heart
                hearts[i].sprite = halfHeart;
            }
            else if (i == currHeart && (tempHealth % 1) == .25)
            {
                //1/4 heart
                hearts[i].sprite = quarterHeart;
            }
            else if (i == currHeart && (tempHealth % 1) == .75)
            {
                //3/4 heart
                hearts[i].sprite = threeQuarterHeart;
            }
        }
    }
}