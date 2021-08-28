using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// StageUI(ステージ数のUI/進行ボタン/街に戻るボタン)の管理
public class StageUIManager : MonoBehaviour
{
    public Text stegeText;
    public GameObject nextButton;   // ボタンを取得 
    public GameObject toTownButton; // ボタンを取得

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
}