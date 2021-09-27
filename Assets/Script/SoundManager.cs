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
    //シングルトン終わり

    public AudioSource audioSourceBGM; // BGMのスピーカー
    public AudioClip[] audioClipsBGM;  // BGMの素材（0:Title, 1:Town, 2:Quest, 3:Battle）


    public AudioSource audioSourceSE; // SEのスピーカー
    public AudioClip[] audioClipsSE; // ならす素材
    public AudioClip[] audioClipsUmedaSE; // ならす素材
　　
public void PlayBGM(string BGMName)
    {
        audioSourceBGM.Stop();
        switch (BGMName)
        {
            default:
            case "OutSider":
                audioSourceBGM.clip = audioClipsBGM[0];
                break;
        }
        audioSourceBGM.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        //PlaySE();
    }

    public void PlaySE(int index)
    {
        audioSourceSE.PlayOneShot(audioClipsSE[index]); // SEを一度だけならす
    }

        public void PlayUmedaSE(int index)
    {
        audioSourceSE.PlayOneShot(audioClipsUmedaSE[index]); // SEを一度だけならす
    }

}
