using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    [SerializeField]List<Buttoncs> buttoncs;
    int rndNum;
    string rndSpiteNameOnButton;
    // Start is called before the first frame update
    public void AddButtongoInList(List<Buttoncs> buttoncs)
    {
        this.buttoncs = buttoncs;
    }
    Buttoncs RandomQuestion()
    {
        {
            rndNum = Random.Range(0, buttoncs.Count);
            return buttoncs[rndNum];
        }
    }
    public void SetQuestion()
    {
        rndSpiteNameOnButton = RandomQuestion().gameObject.GetComponent<Image>().sprite.name;
        gameObject.GetComponent<Text>().text = ("Find " + rndSpiteNameOnButton);
    }
    public string RndSpriteNameOnButton
    {
        get
        {
            return rndSpiteNameOnButton;
        }
    }
}
