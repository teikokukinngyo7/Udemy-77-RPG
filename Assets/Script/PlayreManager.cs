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

        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }

    }

}
