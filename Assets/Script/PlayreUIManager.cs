using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayreUIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text hpText;
    public Text atText;

        public void SetupUI(PlayreManager player)
    {
    hpText.text = string.Format("HP : {0}", player.hp);
    atText.text = string.Format("AT : {0}", player.at);
    }

    public void UpdateUI(PlayreManager player)
    {
    hpText.text = string.Format("HP : {0}", player.hp);

    }

    
}