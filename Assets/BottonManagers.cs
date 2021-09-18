using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonManagers : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnButtonm(int index)
    {
        SoundManager.instance.PlaySE(index);
    }

}
