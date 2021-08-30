using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayreManager : MonoBehaviour
{
    public int hp;
    public int at;

    //　エネミーに攻撃する。
    public int Attack(EnemyManager enemy)
    {
        int damage = enemy.Damage(at);
        return damage;
    }

    //　プレイヤーがダメージを受ける。
    public int Damage(int damage)
    {

        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }
        return damage;
    }

}
