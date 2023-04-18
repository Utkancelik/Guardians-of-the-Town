using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager : MonoBehaviour
{
    public Image Lvl_Rozet;

    public Sprite lvl1, lvl2, lvl3, lvl4, lvl5, lvl6;


    public int experience = 0;

    public Slider experienceSlider;
    private void Start()
    {
        experience = PlayerPrefs.GetInt("Experience", 0);

        experienceSlider.value = experience%10;

        if (experience >= 0 && experience < 10)
        {
            Lvl_Rozet.sprite = lvl1;
        }
        else if (experience >= 10 && experience < 20)
        {
            Lvl_Rozet.sprite = lvl2;
        }
        else if (experience >= 20 && experience < 30)
        {
            Lvl_Rozet.sprite = lvl3;
        }
        else if (experience >= 30 && experience < 40)
        {
            Lvl_Rozet.sprite = lvl4;
        }
        else if (experience >= 40 && experience < 50)
        {
            Lvl_Rozet.sprite = lvl5;
        }
        else if (experience >= 50)
        {
            Lvl_Rozet.sprite = lvl6;
        }
    }
}
