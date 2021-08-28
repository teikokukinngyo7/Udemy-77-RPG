using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUIManeger : MonoBehaviour
{
    // Start is called before the first frame update
    public Text hpText;
    public Text nameText;
    
    public void SetupUI(EnemyManager enemy)
    {
            hpText.text = string.Format("HP : {0}", enemy.hp);
            nameText.text = string.Format("{0}", enemy.name);

    }

    public void UpdateUI(EnemyManager enemy)
    {
    hpText.text = string.Format("HP : {0}", enemy.hp);

    }
}
