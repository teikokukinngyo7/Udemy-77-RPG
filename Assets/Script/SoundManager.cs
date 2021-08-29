using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{   
    //シングルトン
    //ゲーム内に一つしか存在しないもの(音を管理するものとか)
    //　利用場所:シーン感でのデータ共有/オブジェクト共有
    // 書き方

    //instance はなんでもいい
    public static SoundManager instance;

    private void Awake() {
        
    if (instance == null)
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    else
    {
        
        Destroy(this.gameObject);

        }
    }
    //SEのスピーカー
    public AudioSource audioSource;
    //　鳴らす素材
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        PlaySE();
    }
    public void PlaySE()
    {
        audioSource.PlayOneShot(audioClip); // SEを一度だけならす
    }

}
