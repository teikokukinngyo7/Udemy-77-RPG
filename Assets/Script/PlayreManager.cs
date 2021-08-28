using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayreManager : MonoBehaviour
{
    public int hp;
    public int at;

    //　エネミーに攻撃する。
    public void Attack(EnemyManager enemy)
    {
        enemy.Damage(at);
    }

    //　プレイヤーがダメージを受ける。
    public void Damage(int damage)
    {
        Debug.Log("PlayerのHPは"+hp+"ダメージは"+damage);
        hp -= damage;
        Debug.Log("PlayerのHPは"+hp);

    }

}
