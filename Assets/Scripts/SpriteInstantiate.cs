using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInstantiate : MonoBehaviour
{
    int rndNum;
    [SerializeField] List<Sprite> sprites;
    [SerializeField] List<Buttoncs> button;
    [SerializeField] List<GameObject> buttongo;

    private void Start()
    {

        InstallationSpriteInList();
    }
    public void InstallationSpritesOnButton()
    {
        AddButtonsInList();
        if(sprites.Count >= button.Count)
        {
            foreach (Buttoncs i in button)
            {
                i.SpriteInstallation(RandomSprite());
                sprites.RemoveAt(rndNum);
            }
        }
        else
        {
            Debug.LogError("Not enough elements in the List of sprites. SpriteIntstantiate.cs. InstallationSpritesOnButton()");
        }
    }
    void InstallationSpriteInList()
    {
        sprites.AddRange(Resources.LoadAll<Sprite>("Sprites/Letters"));
    }
    void AddButtonsInList()
    {
        buttongo.Clear();
        button.Clear();
        buttongo.AddRange(GameObject.FindGameObjectsWithTag("Button"));
        foreach (GameObject i in buttongo)
        {
            button.Add(i.GetComponent<Buttoncs>());
        }
    }
    Sprite RandomSprite()
    {
        rndNum = Random.Range(0, sprites.Count);
        return sprites[rndNum];
    }
}
