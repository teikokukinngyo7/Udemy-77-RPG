using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // nameってのはオブジェクトの名前も絡んでくるため、
    //　違うことを示すために、newをつける。
    public new string name;
    public int hp;
    public int at;

    //　プレイヤーに攻撃する。
    public void Attack(PlayreManager player)
    {
        player.Damage(at);
    }

    //　エネミーがダメージを受ける。
    public void Damage(int damage)
    {
        Debug.Log("EnemyのHPは"+hp+"ダメージは"+damage);
        hp -= damage;
        Debug.Log("EnemyのHPは" + hp);
    }

    public void OnTap()
    
    {
    Debug.Log("クリックされた");
    
    }
}
