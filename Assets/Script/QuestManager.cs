using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// クエスト全体を管理
public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefab; // 生成するプレファブ(Unityエディタから設定する)
    public BattleManager battleManager;

    //もしげんざいのエンカウントテーブルが-1なら敵と遭遇
    int[] encountTable = { -1, -1, 0, -1, -0 -1,};

    public int currentStage = 0; // 現在のステージ進行度
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


        if (encountTable.Length <= currentStage)
        {
            Debug.Log("クエストクリア");
            // クリア処理
        }

        else if (encountTable[currentStage] == 0) // 0なら遭遇
        {
            Debug.Log("敵に遭遇");
            EncountEnemy();
        }
    }

    
    void EncountEnemy()
    {
        stageUI.HideButtons(); // 敵にあったら非表示
        GameObject enemyObj = Instantiate(enemyPrefab);
        EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
        battleManager.Setup(enemy);
    }
}