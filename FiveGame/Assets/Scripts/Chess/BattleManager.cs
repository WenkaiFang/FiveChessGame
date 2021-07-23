using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleEnum
{
    blackTurn,
    whiteTurn,
    check,
    Finish,
    none
}
public class BattleManager : MonoBehaviour
{
    public static BattleManager instance;
    Coroutine game;
    public BattleEnum be;
    public bool isWhiteWin;
    public int lastChessCount;





    // 测试用
    public Text state;
    public Text result;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        be = BattleEnum.none;
    }

    // Update is called once per frame
    void Update()
    {
        if (game==null && Input.GetKeyDown(KeyCode.Alpha1))
        {
            game = StartCoroutine(StartGame());
        }
        state.text = be.ToString();
        if (be == BattleEnum.Finish)
        {
            result.text = isWhiteWin ? "白方胜" : "黑方胜";
        }
    }

    IEnumerator StartGame()
    {

        yield return null;
        be = BattleEnum.blackTurn;
        ChessManager.instance.ResetChesses();
        lastChessCount = 0;
        while (be!= BattleEnum.Finish)
        {
            if (ChessManager.instance.ReturnChessCount() > lastChessCount)
            {
                lastChessCount ++;
                if (ChessManager.instance.ResultCheck())
                {
                    be = BattleEnum.Finish;
                }
                else
                {
                    if (be == BattleEnum.blackTurn)
                    {
                        be = BattleEnum.whiteTurn;
                    }
                    else
                    {
                        be = BattleEnum.blackTurn;
                    }
                }
            }
            yield return new WaitForSeconds(0.2f);
        }
        result.text = "";
        game = null;
    }

}
