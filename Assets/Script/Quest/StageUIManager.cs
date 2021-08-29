using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// StageUI(ステージ数のUI/進行ボタン/街に戻るボタン)の管理
public class StageUIManager : MonoBehaviour
{
    //文字を変更させるためにtextとして読み込み
    public Text stegeText;
    //表示させるかさせないかは、オブジェクトとして表示、非表示を
    //おこなうので gameObjectとして登録
    public GameObject stageClearText;
    public GameObject nextButton;   // ボタンを取得 
    public GameObject toTownButton; // ボタンを取得

    private void Start() {
        stageClearText.SetActive(false);
    }

    public void UpdateUI(int currentStage)
    {
        stegeText.text = string.Format("ステージ：{0}", currentStage+1);
    }
        public void HideButtons()
    {
        nextButton.SetActive(false);
        toTownButton.SetActive(false);
    }
    public void ShowButtons()
    {
        nextButton.SetActive(true);
        toTownButton.SetActive(true);
    }
    public void ShowClearText()
    {
        stageClearText.SetActive(true);
        nextButton.SetActive(false);
        toTownButton.SetActive(true);
    }
}