using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//Player と対戦の管理
public class BattleManager : MonoBehaviour
{   
    public Transform playerDamagePanel;
    public QuestManager questManager;
    public PlayreUIManager playerUI;
    public EnemyUIManeger enemyUI;
    // Unity 上で指定されたオブジェクトを
    // playerとenemyの名前で登録する。
    public PlayreManager player;
    EnemyManager enemy;

    private void Start() 
    {
        enemyUI.gameObject.SetActive(false);
        //StartCoroutine(SampleCol());
    }
    //2秒待つための関数。
    /*IEnumerator SampleCol()
    {
        Debug.Log("コルーチン開始");
        yield return new WaitForSeconds(2f);
        Debug.Log("２秒経過");
    }*/

    //初期設定
    public void Setup(EnemyManager enemyManager)
    {
        enemyUI.gameObject.SetActive(true);
        Debug.Log("battlemanagerSETUP");
        enemy = enemyManager;
        enemyUI.SetupUI(enemy);
        playerUI.SetupUI(player);

        //prefabに設定されているEnemyManagerから、
        //AddEventLintenerOnTap 関数に引数としてPlayerAttack関数を
        //渡すことによって、prefab上で、PlayerAttackが実行可能。
        enemy.AddEventLintenerOnTap(PlayerAttack);
        //Dotweenの実行　enemyをすこし動かす
        // enemy.transform.DOMove(new Vector3(0,10,0), 5f);
    }
    void PlayerAttack()
    {
        //コルーチンの連打対策
        StopAllCoroutines();
        DialogTextManager.instance.SetScenarios(new string[] { "Playerの攻撃" });

        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);
                if (enemy.hp <= 0)
        {   
;
            StartCoroutine(EndBattle());
        }
        else
        {
            StartCoroutine(EnemyTurn());
        }

    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);
        playerDamagePanel.DOShakePosition(0.3f, 0.5f, 20, 0, false, true);

        int damage = enemy.Attack(player);
        playerUI.UpdateUI(player);

        DialogTextManager.instance.SetScenarios(new string[] {
        "モンスターの攻撃\nプレイヤーは"+damage+"ダメージを受けた。"
        });
        
    }

    IEnumerator EndBattle()
    {
        yield return new WaitForSeconds(1f);

        enemyUI.gameObject.SetActive(false);// ここ
        //敵オブジェクトの削除
        Destroy(enemy.gameObject);
        Debug.Log("EndBattle");
        questManager.EndBattle();

    }
}
