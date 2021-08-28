using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player と対戦の管理
public class BattleManager : MonoBehaviour
{   
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
    }
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
    }
    void PlayerAttack()
    {
        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);
                if (enemy.hp <= 0)
        {   
            enemyUI.gameObject.SetActive(false);// ここ
            //敵オブジェクトの削除
            Destroy(enemy.gameObject);
            EndBattle();
        }
        else
        {
            EnemyTurn();
        }

    }

    void EnemyTurn()
    {
        enemy.Attack(player);
        playerUI.UpdateUI(player);
    }

        void EndBattle()
    {
        Debug.Log("EndBattle");
        questManager.EndBattle();

    }
}
