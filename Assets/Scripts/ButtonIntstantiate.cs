using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class ButtonIntstantiate : MonoBehaviour
{
    string number;
    int num;
    int currentCount = 0;

    GameObject pref;
    GameObject buttongo;

    public void InstallationOnSpot(int count)
    {
        pref = Resources.Load<GameObject>("Prefabs/Button");
        number = Regex.Replace(gameObject.name, "[^0-9]", "");//Получение номера спота для кнопки
        int.TryParse(number, out num);

        if (num <= count)
        {
            if (currentCount < num)
            {
                SetImageActive();
                buttongo = Instantiate(pref, transform.position, Quaternion.identity, gameObject.transform) as GameObject;
            }
        }
        currentCount = count; //Проверка, есть ли уже кнопка на споте
        SetRndColorOnImage();
    }
    void SetImageActive()
    {
        gameObject.GetComponent<Image>().enabled = true;
    }
    void SetRndColorOnImage()
    {
        if (gameObject.GetComponent<Image>().enabled)
        {
            Color imageColor;
            imageColor = Random.ColorHSV(0.6f, 1, 0.5f, 0.7f, 1, 1, 0.45f, 0.5f);
            gameObject.GetComponent<Image>().color = imageColor;
        }
    }
}
