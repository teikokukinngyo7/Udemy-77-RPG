using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayreUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text hpText;
    public Text atText;
    
    public void UpdateUI()
    {
    hpText.text = string.Format("HP : {0}",80);

    }

    
}