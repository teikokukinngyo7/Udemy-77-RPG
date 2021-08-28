using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIManeger : MonoBehaviour
{
    // Start is called before the first frame update
    public Text hpText;
    public Text nameText;
    
    public void UpdateUI()
    {
    hpText.text = string.Format("HP : {0}",80);

    }
}
