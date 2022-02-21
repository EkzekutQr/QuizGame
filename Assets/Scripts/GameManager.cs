using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int buttonCount;
    string currentQuestion;
    string pressedButtonSpriteName;

    [SerializeField] List<ButtonIntstantiate> buttonIntstantiate;
    [SerializeField] List<GameObject> buttonSpot;
    [SerializeField] List<GameObject> buttongo;
    [SerializeField] List<Buttoncs> buttoncs;

    SpriteInstantiate spriteinstantiate;
    Question question;

    // Start is called before the first frame update
    void Start()
    {
        spriteinstantiate = gameObject.GetComponent<SpriteInstantiate>();
        question = GameObject.Find("Question").GetComponent<Question>();
        AddButtonSpotList();
        StartGame();
    }
    void AddButtonSpotList()
    {
        buttonSpot.AddRange(GameObject.FindGameObjectsWithTag("ButtonSpot"));
        foreach (GameObject i in buttonSpot)
        {
            buttonIntstantiate.Add(i.GetComponent<ButtonIntstantiate>());
        }
    }
    void StartGame()
    {
        buttonCount = 3;
        InstallationButtonOnSpot();
        AddButtongoInList();
        AddButtonInList();
        GetButtonListToOtherClass();
        AddListenerOnClickButton();
        spriteinstantiate.InstallationSpritesOnButton();
        question.SetQuestion();
        currentQuestion = question.RndSpriteNameOnButton;
    }
    void AnswerCheck()
    {
        if (currentQuestion == pressedButtonSpriteName)
        {
            TrueAnswer();
        }
        else
        {
            WrongAnswer();
        }
    }
    void TrueAnswer()
    {
        if (buttonCount < 9)
        {
            NextRound();
        }
        else
        {
            foreach(GameObject i in buttonSpot)
            {
                i.SetActive(false);
            }
            question.gameObject.SetActive(false);
            GameObject victory;
            GameObject menuButtonPrefab;
            GameObject menuButton;
            victory = Resources.Load<GameObject>("Prefabs/Victory");
            menuButtonPrefab = Resources.Load<GameObject>("Prefabs/MenuButton");
            GameObject canvas;
            canvas = GameObject.Find("Canvas");
            Instantiate<GameObject>(victory, transform.position, Quaternion.identity, canvas.transform);
            menuButton = Instantiate<GameObject>(menuButtonPrefab, transform.position, Quaternion.identity, canvas.transform);
            menuButton.GetComponent<RectTransform>().anchoredPosition = menuButtonPrefab.GetComponent<RectTransform>().anchoredPosition;
            Debug.Log("GameIsEnd");
        }
    }
    void WrongAnswer()
    {
        Debug.Log("WrongAnswer");
    }
    public void NextRound()
    {
        buttonCount = buttonCount + 3;
        InstallationButtonOnSpot();
        AddButtongoInList();
        AddButtonInList();
        GetButtonListToOtherClass();
        AddListenerOnClickButton();
        spriteinstantiate.InstallationSpritesOnButton();
        question.SetQuestion();
        currentQuestion = question.RndSpriteNameOnButton;
    }
    void InstallationButtonOnSpot()
    {
        foreach (ButtonIntstantiate i in buttonIntstantiate)
        {
            i.InstallationOnSpot(buttonCount);
        }
    }
    void AddButtongoInList()
    {
        buttongo.Clear();
        buttongo.AddRange(GameObject.FindGameObjectsWithTag("Button"));
    }
    void AddButtonInList()
    {
        buttoncs.Clear();
        foreach (GameObject i in buttongo)
        {
            buttoncs.Add(i.GetComponent<Buttoncs>());
        }
    }
    void GetButtonListToOtherClass()
    {
        question.AddButtongoInList(buttoncs);
    }
    public void AddListenerOnClickButton()
    {
        foreach (Buttoncs i in buttoncs)
        {
            i.AddListenerOnClick(i.GetSpriteName, true);
            i.AddListenerOnClick(AnswerCheck, false);
        }
    }
    public void GetSpriteNamePressedButton(string spriteName)
    {
        pressedButtonSpriteName = spriteName;
    }
}