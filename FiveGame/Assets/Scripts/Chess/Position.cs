using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ChessPositionEnum{
    none = 0,
    white = 1,
    black = 2
}

public class Position : MonoBehaviour
{
    public ChessPositionEnum cpe;
    public Image image;
    public Vector2 positon;
    void Start()
    {
        cpe = ChessPositionEnum.none;
    }

    void Update()
    {
        SetImage();
    }

    void SetImage()
    {
        switch (cpe)
        {
            case ChessPositionEnum.none:
                image.color = new Color(0, 0, 0, 0);
                break;
            case ChessPositionEnum.white:
                image.color = new Color(1, 1, 1, 1);
                break;
            case ChessPositionEnum.black:
                image.color = new Color(0, 0, 0 ,1);
                break;
            default:
                break;
        }
    }

    public void CheckValue()
    {
        if (cpe == ChessPositionEnum.none)
        {
            if (BattleManager.instance.be == BattleEnum.blackTurn)
            {
                cpe = ChessPositionEnum.black;
            }
            if (BattleManager.instance.be == BattleEnum.whiteTurn)
            {
                cpe = ChessPositionEnum.white;
            }
        }

    }
}
