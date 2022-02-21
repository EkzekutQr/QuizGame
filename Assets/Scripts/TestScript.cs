using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class TestScript : MonoBehaviour
{[SerializeField]
    GameObject obj;
    string str = "fsaf123";
    string numOnly;

    [SerializeField] int count;
    [SerializeField] int num;

    ButtonIntstantiate cellIntstantiate;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i <= 9; i++)
        {
            obj = GameObject.Find($"CellSpot ({i})");
            cellIntstantiate = (ButtonIntstantiate)obj.GetComponent(typeof(ButtonIntstantiate));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("test" + Count);
    }
    public int Count
    {
        get
        {
            return count;
        }
        private set
        {
            if (value >= 3)
                count = value;
        }
    }
}
