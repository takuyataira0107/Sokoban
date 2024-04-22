using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    /* int[] map = { 0, 0, 2, 1, 0, 2, 0, 0, 0 };
     string debugText = ""; */

    public GameObject playerPrefab;
    int[,] map;   // レベルデザイン用の配列
    GameObject[,] field;   // ゲーム管理用の配列

    /*
    void PrintArray()
    {
        string debugText = "";
        for(int i = 0; i < map.Length; i++) 
        {
            debugText += map[i].ToString() + ", ";
        }
        Debug.Log(debugText);
        
    }

    int GetplayerIndex()
    {
        for(int i = 0; i < map.Length; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
        }
        return -1;
    }
    
    bool MoveNumber(int number, int moveFrom, int moveTo)
    {
        if(moveTo < 0 || moveTo >= map.Length){ return false; }

        if (map[moveTo] == 2)
        {
            int velocity = moveTo - moveFrom;

            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            if (!success) {return false;}
        }
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }
    */


    private Vector2Int GetPlayerIndex()
    {
        for(int y = 0;  y < map.GetLength(0); y++)
        {
            for(int x = 0; x < map.GetLength(1); x++)
            {
                if (field[y,x] == null) { continue; }
                if (field[y, x].tag == "Player")
                {
                    return new Vector2Int(x,y);
                }
            }
        }
        return new Vector2Int(-1, -1);
    }


    void Start()
    {

        /*
        for(int i = 0; i < map.Length; i++) 
        {
            debugText += map[i].ToString() + ",";
        }

        Debug.Log(debugText);

        PrintArray();
        */

        // マップの生成
        map = new int[,]
       {
            {0, 0, 0, 0, 0},
            {0, 0, 1, 0, 0},
            {0, 0, 0, 0, 0}
       };

        // string debugText = "";

        field = new GameObject[
            map.GetLength(0),
            map.GetLength(1)
        ];


        // マップに応じて描画
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                /*
                debugText += map[y, x].ToString() + ",";
                */

                if (map[y, x] == 1)
                {
                    //GameObject instance
                    field[y, x] = Instantiate(
                         playerPrefab,
                         new Vector3(x, map.GetLength(0) - y, 0),
                          Quaternion.identity
                     );
                }
                else
                {
                    field[y, x] = Instantiate(
                         playerPrefab,
                         new Vector3(x, map.GetLength(1) - y, 0),
                          Quaternion.identity
                    );
                }
            }
            //debugText += "\n";
        }
       // Debug.Log(debugText);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int playerIndex = GetplayerIndex();

            MoveNumber(1, playerIndex, playerIndex + 1);
            PrintArray();

        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int playerIndex = GetplayerIndex();

            MoveNumber(1, playerIndex, playerIndex - 1);
            PrintArray();

        }
        */
    }
}
