using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

public class DialogTextManager : MonoBehaviour
{
    //1/16 追加:登録関数の窓口作成（ボタンのOnClickと同じ仕組み）
    [SerializeField] private UnityEvent onCompletedEvents = new UnityEngine.Events.UnityEvent();
    //1/16 追加:テキスト送り終了後から関数を実行するまでの時間
    [SerializeField] float eventDelayTime;
    //1/16 終了したかどうかのフラグ(これがないと終了後繰り返し関数を実行してしまう)
    bool isEnd;

    public UnityAction onClickText;
    public string[] scenarios;
    [SerializeField] Text uiText;
    [SerializeField]
    [Range(0.001f, 0.3f)]
    float intervalForCharacterDisplay = 0.05f;

    private string currentText = string.Empty;
    private float timeUntilDisplay = 0;
    private float timeElapsed = 1;
    private int currentLine = 0;
    private int lastUpdateCharacter = -1;

    public static DialogTextManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // 文字の表示が完了しているかどうか
    public bool IsCompleteDisplayText
    {
        get { return Time.time > timeElapsed + timeUntilDisplay; }
    }

    void Update()
    {
        // 文字の表示が完了してるならクリック時に次の行を表示する
        if (IsCompleteDisplayText)
        {
            if (currentLine < scenarios.Length && Input.GetMouseButtonDown(0))
            {
                SetNextLine();
            }
        }
        else
        {
            // 完了してないなら文字をすべて表示する
            if (Input.GetMouseButtonDown(0))
            {
                timeUntilDisplay = 0;
            }
        }

        int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUntilDisplay) * currentText.Length);
        if (displayCharacterCount != lastUpdateCharacter)
        {
            uiText.text = currentText.Substring(0, displayCharacterCount);
            lastUpdateCharacter = displayCharacterCount;
        }
        CheckCompletedText(); // 1/16 追加:
    }

    // 1/16 追加:終了したか調べて終了していれば登録関数を実装する
    void CheckCompletedText()
    {
        if (isEnd == false && IsCompleteDisplayText && scenarios.Length == currentLine)
        {
            isEnd = true;
            // 登録関数をeventDelayTime秒後に実行
            Invoke("EventFunction", eventDelayTime);
        }
    }
    // 1/16 追加:登録関数の実行
    void EventFunction()
    {
        onCompletedEvents.Invoke();
    }


    public void SetNextLine()
    {
        isEnd = false;
        if (scenarios.Length - 1 < currentLine)
        {
            return;
        }
        currentText = scenarios[currentLine];
        timeUntilDisplay = currentText.Length * intervalForCharacterDisplay;
        timeElapsed = Time.time;
        currentLine++;
        lastUpdateCharacter = -1;
    }
    // 基本的に使うのはこれだけ
    public void SetScenarios(string[] sc)
    {
        scenarios = sc;
        currentLine = 0;
        SetNextLine();
    }
}