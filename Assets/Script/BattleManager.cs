using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Player と対戦の管理
public class BattleManager : MonoBehaviour
{   
    public PlayreUIManager playerUI;
    public EnemyUIManeger enemyUI;
    // Unity 上で指定されたオブジェクトを
    // playerとenemyの名前で登録する。
    public PlayreManager player;
    EnemyManager enemy;

    //初期設定
    public void Setup(EnemyManager enemyManager)
    {
        enemy = enemyManager;
        Debug.Log(enemy);
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

    }

    void EnemyAttack()
    {
        enemy.Attack(player);
        playerUI.UpdateUI(player);
    }

}
