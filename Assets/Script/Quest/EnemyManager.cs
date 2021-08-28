using System;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //関数登録
    //クリックしたいときに実行したい関数(ただし、外部から設定したい。)
    Action tapAction; 
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
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }
    }

    // tapActionに関数を登録する関数を作る。
    public void AddEventLintenerOnTap(Action action)
    {
        //tapActionに登録したい関数を渡す。
        //引数としては関数を渡す。
        tapAction += action;
    }

    public void OnTap()
    
    {
        Debug.Log("クリックされた");
        //Ontapが実行された際に、バトルマネージャのプレイヤー
        //アタックを呼び出す。
        tapAction();

    }
}
