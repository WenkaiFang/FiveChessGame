using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessManager : MonoBehaviour
{
    public static ChessManager instance;
    public List<Position> chesses;
    public Transform chessesTransform;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        CreateChesses();
    }

    public void CreateChesses()
    {
        while (chesses.Count < 225)
        {
            Position temp = Instantiate(chesses[0], chessesTransform);
            temp.positon = new Vector2((int)chesses.Count % 15, (int)chesses.Count / 15);
            chesses.Add(temp);

        }

    }


    public int ReturnChessCount()
    {
        int result = 0;
        foreach (Position item in chesses)
        {
            if (item.cpe != ChessPositionEnum.none)
            {
                result++;
            }
        }
        return result;
    }

    public void ResetChesses()
    {
        foreach (Position item in chesses)
        {
            item.cpe = ChessPositionEnum.none;
        }
    }

    public bool ResultCheck()
    {
        bool flag = false;
        //判断是否是黑子赢
        if (BattleManager.instance.be == BattleEnum.blackTurn)
            foreach (Position item in chesses)
            {
                if (item.cpe == ChessPositionEnum.black)
                {
                    int x = (int)item.positon.x;
                    int y = (int)item.positon.y;
                    int countLeft = 0, countUp = 0, countLeftCorner = 0, countRightCorner = 0;
                    // 横向判断
                    if (x + 1 < 15)
                    {
                        if (chesses[x + 1 + y * 15].cpe == ChessPositionEnum.black)
                        {
                            countLeft++;
                            if (x + 2 < 15)
                            {
                                if (chesses[x + 2 + y * 15].cpe == ChessPositionEnum.black)
                                {
                                    countLeft++;
                                    if (x + 3 < 15)
                                    {
                                        if (chesses[x + 3 + y * 15].cpe == ChessPositionEnum.black)
                                        {
                                            countLeft++;
                                            if (x + 4 < 15)
                                            {
                                                if (chesses[x + 4 + y * 15].cpe == ChessPositionEnum.black)
                                                {
                                                    countLeft++;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }

                    if (x - 1 > 0)
                    {
                        if (chesses[x - 1 + y * 15].cpe == ChessPositionEnum.black)
                        {
                            countLeft++;
                            if (x - 2 > 0)
                            {
                                if (chesses[x - 2 + y * 15].cpe == ChessPositionEnum.black)
                                {
                                    countLeft++;
                                    if (x - 3 > 0)
                                    {
                                        if (chesses[x - 3 + y * 15].cpe == ChessPositionEnum.black)
                                        {
                                            countLeft++;
                                            if (x - 4 > 0)
                                            {
                                                if (chesses[x - 4 + y * 15].cpe == ChessPositionEnum.black)
                                                {
                                                    countLeft++;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }

                    if (countLeft + 1 >= 5)
                    {
                        BattleManager.instance.isWhiteWin = false;
                        return true;
                    }
                    // 纵向
                    if (y + 1 < 15)
                    {
                        if (chesses[x + (1 + y) * 15].cpe == ChessPositionEnum.black)
                        {
                            countUp++; if (y + 2 < 15)
                            {
                                if (chesses[x + (2 + y) * 15].cpe == ChessPositionEnum.black)
                                {
                                    countUp++;
                                    if (y + 3 < 15)
                                    {
                                        if (chesses[x + (3 + y) * 15].cpe == ChessPositionEnum.black)
                                        {
                                            countUp++;
                                            if (y + 4 < 15)
                                            {
                                                if (chesses[x + (4 + y) * 15].cpe == ChessPositionEnum.black)
                                                {
                                                    countUp++;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }



                    if (y - 1 > 0)
                    {
                        if (chesses[x + (-1 + y) * 15].cpe == ChessPositionEnum.black)
                        {
                            countUp++;
                            if (y - 2 > 0)
                            {
                                if (chesses[x + (-2 + y) * 15].cpe == ChessPositionEnum.black)
                                {
                                    countUp++;
                                    if (y - 3 > 0)
                                    {
                                        if (chesses[x + (-3 + y) * 15].cpe == ChessPositionEnum.black)
                                        {
                                            countUp++;
                                            if (y - 4 > 0)
                                            {
                                                if (chesses[x + (-4 + y) * 15].cpe == ChessPositionEnum.black)
                                                {
                                                    countUp++;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }

                    if (countUp + 1 >= 5)
                    {
                        BattleManager.instance.isWhiteWin = false;
                        return true;
                    }

                    // 右斜线
                    if (x + 1 < 15 && y + 1 < 15)
                    {
                        if (chesses[x + 1 + (y + 1) * 15].cpe == ChessPositionEnum.black)
                        {
                            countRightCorner++;
                            if (x + 2 < 15 && y + 2 < 15)
                            {
                                if (chesses[x + 2 + (y + 2) * 15].cpe == ChessPositionEnum.black)
                                {
                                    countRightCorner++;
                                    if (x + 3 < 15 && y + 3 < 15)
                                    {
                                        if (chesses[x + 3 + (y + 3) * 15].cpe == ChessPositionEnum.black)
                                        {
                                            countRightCorner++;
                                            if (x + 4 < 15 && y + 4 < 15)
                                            {
                                                if (chesses[x + 4 + (y + 4) * 15].cpe == ChessPositionEnum.black)
                                                {
                                                    countRightCorner++;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }



                    if (x - 1 > 0 && y - 1 > 0)
                    {
                        if (chesses[x - 1 + (y - 1) * 15].cpe == ChessPositionEnum.black)
                        {
                            countRightCorner++;
                            if (x - 2 > 0 && y - 2 > 0)
                            {
                                if (chesses[x - 2 + (y - 2) * 15].cpe == ChessPositionEnum.black)
                                {
                                    countRightCorner++;
                                    if (x - 3 > 0 && y - 3 > 0)
                                    {
                                        if (chesses[x - 3 + (y - 3) * 15].cpe == ChessPositionEnum.black)
                                        {
                                            countRightCorner++;
                                            if (x - 4 > 0 && y - 4 < 0)
                                            {
                                                if (chesses[x - 4 + (y - 4) * 15].cpe == ChessPositionEnum.black)
                                                {
                                                    countRightCorner++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (countRightCorner + 1 >= 5)
                    {
                        BattleManager.instance.isWhiteWin = false;
                        return true;
                    }

                    // 左斜线
                    if (x - 1 < 15 && y + 1 < 15)
                    {
                        if (chesses[x - 1 + (y + 1) * 15].cpe == ChessPositionEnum.black)
                        {
                            countLeftCorner++;
                            if (x - 2 < 15 && y + 2 < 15)
                            {
                                if (chesses[x - 2 + (y + 2) * 15].cpe == ChessPositionEnum.black)
                                {
                                    countLeftCorner++;
                                    if (x - 3 < 15 && y + 3 < 15)
                                    {
                                        if (chesses[x - 3 + (y + 3) * 15].cpe == ChessPositionEnum.black)
                                        {
                                            countLeftCorner++;
                                            if (x - 4 < 15 && y + 4 < 15)
                                            {
                                                if (chesses[x - 4 + (y + 4) * 15].cpe == ChessPositionEnum.black)
                                                {
                                                    countLeftCorner++;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }

                    if (x + 1 > 0 && y - 1 > 0)
                    {
                        if (chesses[x + 1 + (y - 1) * 15].cpe == ChessPositionEnum.black)
                        {
                            countLeftCorner++;
                            if (x + 2 > 0 && y - 2 > 0)
                            {
                                if (chesses[x + 2 + (y - 2) * 15].cpe == ChessPositionEnum.black)
                                {
                                    countLeftCorner++;
                                    if (x + 3 > 0 && y - 3 > 0)
                                    {
                                        if (chesses[x + 3 + (y - 3) * 15].cpe == ChessPositionEnum.black)
                                        {
                                            countLeftCorner++;
                                            if (x + 4 > 0 && y - 4 < 0)
                                            {
                                                if (chesses[x + 4 + (y - 4) * 15].cpe == ChessPositionEnum.black)
                                                {
                                                    countLeftCorner++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (countLeftCorner + 1 >= 5)
                    {
                        BattleManager.instance.isWhiteWin = false;
                        return true;
                    }
                }

            }
        else
        {
            foreach (Position item in chesses)
            {
                if (item.cpe == ChessPositionEnum.white)
                {
                    int x = (int)item.positon.x;
                    int y = (int)item.positon.y;
                    int countLeft = 0, countUp = 0, countLeftCorner = 0, countRightCorner = 0;
                    // 横向判断
                    if (x + 1 < 15)
                    {
                        if (chesses[x + 1 + y * 15].cpe == ChessPositionEnum.white)
                        {
                            countLeft++;
                            if (x + 2 < 15)
                            {
                                if (chesses[x + 2 + y * 15].cpe == ChessPositionEnum.white)
                                {
                                    countLeft++;
                                    if (x + 3 < 15)
                                    {
                                        if (chesses[x + 3 + y * 15].cpe == ChessPositionEnum.white)
                                        {
                                            countLeft++;
                                            if (x + 4 < 15)
                                            {
                                                if (chesses[x + 4 + y * 15].cpe == ChessPositionEnum.white)
                                                {
                                                    countLeft++;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }

                    if (x - 1 > 0)
                    {
                        if (chesses[x - 1 + y * 15].cpe == ChessPositionEnum.white)
                        {
                            countLeft++;
                            if (x - 2 > 0)
                            {
                                if (chesses[x - 2 + y * 15].cpe == ChessPositionEnum.white)
                                {
                                    countLeft++;
                                    if (x - 3 > 0)
                                    {
                                        if (chesses[x - 3 + y * 15].cpe == ChessPositionEnum.white)
                                        {
                                            countLeft++;
                                            if (x - 4 > 0)
                                            {
                                                if (chesses[x - 4 + y * 15].cpe == ChessPositionEnum.white)
                                                {
                                                    countLeft++;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }

                    if (countLeft + 1 >= 5)
                    {
                        BattleManager.instance.isWhiteWin = true;
                        return true;
                    }
                    // 纵向
                    if (y + 1 < 15)
                    {
                        if (chesses[x + (1 + y) * 15].cpe == ChessPositionEnum.white)
                        {
                            countUp++; if (y + 2 < 15)
                            {
                                if (chesses[x + (2 + y) * 15].cpe == ChessPositionEnum.white)
                                {
                                    countUp++;
                                    if (y + 3 < 15)
                                    {
                                        if (chesses[x + (3 + y) * 15].cpe == ChessPositionEnum.white)
                                        {
                                            countUp++;
                                            if (y + 4 < 15)
                                            {
                                                if (chesses[x + (4 + y) * 15].cpe == ChessPositionEnum.white)
                                                {
                                                    countUp++;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }



                    if (y - 1 > 0)
                    {
                        if (chesses[x + (-1 + y) * 15].cpe == ChessPositionEnum.white)
                        {
                            countUp++;
                            if (y - 2 > 0)
                            {
                                if (chesses[x + (-2 + y) * 15].cpe == ChessPositionEnum.white)
                                {
                                    countUp++;
                                    if (y - 3 > 0)
                                    {
                                        if (chesses[x + (-3 + y) * 15].cpe == ChessPositionEnum.white)
                                        {
                                            countUp++;
                                            if (y - 4 > 0)
                                            {
                                                if (chesses[x + (-4 + y) * 15].cpe == ChessPositionEnum.white)
                                                {
                                                    countUp++;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }

                    if (countUp + 1 >= 5)
                    {
                        BattleManager.instance.isWhiteWin = true;
                        return true;
                    }

                    // 右斜线
                    if (x + 1 < 15 && y + 1 < 15)
                    {
                        if (chesses[x + 1 + (y + 1) * 15].cpe == ChessPositionEnum.white)
                        {
                            countRightCorner++;
                            if (x + 2 < 15 && y + 2 < 15)
                            {
                                if (chesses[x + 2 + (y + 2) * 15].cpe == ChessPositionEnum.white)
                                {
                                    countRightCorner++;
                                    if (x + 3 < 15 && y + 3 < 15)
                                    {
                                        if (chesses[x + 3 + (y + 3) * 15].cpe == ChessPositionEnum.white)
                                        {
                                            countRightCorner++;
                                            if (x + 4 < 15 && y + 4 < 15)
                                            {
                                                if (chesses[x + 4 + (y + 4) * 15].cpe == ChessPositionEnum.white)
                                                {
                                                    countRightCorner++;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }



                    if (x - 1 > 0 && y - 1 > 0)
                    {
                        if (chesses[x - 1 + (y - 1) * 15].cpe == ChessPositionEnum.white)
                        {
                            countRightCorner++;
                            if (x - 2 > 0 && y - 2 > 0)
                            {
                                if (chesses[x - 2 + (y - 2) * 15].cpe == ChessPositionEnum.white)
                                {
                                    countRightCorner++;
                                    if (x - 3 > 0 && y - 3 > 0)
                                    {
                                        if (chesses[x - 3 + (y - 3) * 15].cpe == ChessPositionEnum.white)
                                        {
                                            countRightCorner++;
                                            if (x - 4 > 0 && y - 4 < 0)
                                            {
                                                if (chesses[x - 4 + (y - 4) * 15].cpe == ChessPositionEnum.white)
                                                {
                                                    countRightCorner++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (countRightCorner + 1 >= 5)
                    {
                        BattleManager.instance.isWhiteWin = true;
                        return true;
                    }

                    // 左斜线
                    if (x - 1 < 15 && y + 1 < 15)
                    {
                        if (chesses[x - 1 + (y + 1) * 15].cpe == ChessPositionEnum.white)
                        {
                            countLeftCorner++;
                            if (x - 2 < 15 && y + 2 < 15)
                            {
                                if (chesses[x - 2 + (y + 2) * 15].cpe == ChessPositionEnum.white)
                                {
                                    countLeftCorner++;
                                    if (x - 3 < 15 && y + 3 < 15)
                                    {
                                        if (chesses[x - 3 + (y + 3) * 15].cpe == ChessPositionEnum.white)
                                        {
                                            countLeftCorner++;
                                            if (x - 4 < 15 && y + 4 < 15)
                                            {
                                                if (chesses[x - 4 + (y + 4) * 15].cpe == ChessPositionEnum.white)
                                                {
                                                    countLeftCorner++;
                                                }
                                            }
                                        }

                                    }
                                }
                            }
                        }
                    }

                    if (x + 1 > 0 && y - 1 > 0)
                    {
                        if (chesses[x + 1 + (y - 1) * 15].cpe == ChessPositionEnum.white)
                        {
                            countLeftCorner++;
                            if (x + 2 > 0 && y - 2 > 0)
                            {
                                if (chesses[x + 2 + (y - 2) * 15].cpe == ChessPositionEnum.white)
                                {
                                    countLeftCorner++;
                                    if (x + 3 > 0 && y - 3 > 0)
                                    {
                                        if (chesses[x + 3 + (y - 3) * 15].cpe == ChessPositionEnum.white)
                                        {
                                            countLeftCorner++;
                                            if (x + 4 > 0 && y - 4 < 0)
                                            {
                                                if (chesses[x + 4 + (y - 4) * 15].cpe == ChessPositionEnum.white)
                                                {
                                                    countLeftCorner++;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (countLeftCorner + 1 >= 5)
                    {
                        BattleManager.instance.isWhiteWin = true;
                        return true;
                    }
                }

            }
        }

        return flag;
    }
}
