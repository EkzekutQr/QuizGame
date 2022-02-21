using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Buttoncs : MonoBehaviour
{
    string buttonSpriteName;
    public void SpriteInstallation(Sprite sprite)
    {
        gameObject.GetComponent<Image>().sprite = sprite;
        SetButtonSpriteName();
    }
    public void AddListenerOnClick(UnityAction action, bool removeAllListeners)
    {
        if (removeAllListeners)
        {
            gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        }
        gameObject.GetComponent<Button>().onClick.AddListener(action);
    }
    public void GetSpriteName()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().GetSpriteNamePressedButton(buttonSpriteName);
    }
    void SetButtonSpriteName()
    {
        buttonSpriteName = gameObject.GetComponent<Image>().sprite.name;
    }
}
