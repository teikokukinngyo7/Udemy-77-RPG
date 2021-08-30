using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
//using UnityEngine.UI;


// クエスト全体を管理
public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefab; // 生成するプレファブ(Unityエディタから設定する)
    public BattleManager battleManager;
    public GameObject questBG;

    //もしげんざいのエンカウントテーブルが-1なら敵と遭遇
    int[] encountTable = { -1, -1, 0, -1, -1, 0,};

    public int currentStage = 0; // 現在のステージ進行度
    //ゲーム開始時から現在のステージを反映させる。
    private void Start()
    {
        stageUI.UpdateUI(currentStage);
        DialogTextManager.instance.SetScenarios(new string[]{"森についた \n"});

    }

    IEnumerator seaching()
    {
            // 背景を大きく 1びょうかけてふわっとさせ、
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 1f)
        //　1びょうかけてもとに戻す。
            .OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));
        // フェードアウトさせるために、カラーの薄さを変更させる。
        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 1f)
            .OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));

        yield return new WaitForSeconds(2f);

        currentStage++;
        
        // 進行度をUIに反映
        stageUI.UpdateUI(currentStage);


        if (encountTable.Length <= currentStage)
        {
            Debug.Log("クエストクリア");
            // クリア処理
            QuestClear();
        }

        else if (encountTable[currentStage] == 0) // 0なら遭遇
        {
            Debug.Log("敵に遭遇");
            EncountEnemy();
        }    
        else
        {
            stageUI.ShowButtons();
        }
    }
    // Nextボタンが押されたら
    public void OnNextButton()
    {
        stageUI.HideButtons();
        StartCoroutine(seaching());
    }

    
    void EncountEnemy()
    {   
        Debug.Log("HideBattle");
        stageUI.HideButtons(); // 敵にあったら非表示
        //enemyPrefabをゲームオブジェクトとして作成
        GameObject enemyObj = Instantiate(enemyPrefab);
        //バトルマネージャにエネミーの値を渡すために、enemy変数に
        //EnemyManager のコンポーネント(enemyprefabに割当
        //られているEnemyManager.cs)をうけわたす。
        EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
        //講義92バトルマネージャが管理しているエネミーにprefabから
        //作成したエネミーを受け渡してやる。
        battleManager.Setup(enemy);
    }

    public void EndBattle()
    {
        Debug.Log("EndBattle");
        stageUI.ShowButtons();
    }

    void QuestClear()
    {
        //クエストクリアと表示、
        stageUI.ShowClearText();
        //街に戻るボタンのみを表示。
        
        
        //ScenceTransisionManager.LoadTo("Town");

    }
}