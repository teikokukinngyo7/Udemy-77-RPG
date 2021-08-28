using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// クエスト全体を管理
public class QuestManager : MonoBehaviour
{
    //public StageUIManager stageUI;
    public int currentStage = 1; // 現在のステージ進行度

    public StageUIManager stageUI;

    //ゲーム開始時から現在のステージを反映させる。
    private void Start()
    {
        stageUI.UpdateUI(currentStage);
    }

    // Nextボタンが押されたら
    public void OnNextButton()
    {
        currentStage++;
        
        // 進行度をUIに反映
        stageUI.UpdateUI(currentStage);
    }
}