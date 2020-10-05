using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> goombas;
    public Text uiText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (goombas.Count <= 0)
        {
            uiText.color = new Color(0, 1, 1);
            uiText.text = "Victory!";
        }
    }
}
