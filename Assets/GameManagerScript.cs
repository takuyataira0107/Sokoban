using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    /* int[] map = { 0, 0, 2, 1, 0, 2, 0, 0, 0 };
     string debugText = ""; */

    public GameObject playerPrefab;
    public GameObject boxPrefab;
    int[,] map;   // レベルデザイン用の配列
    GameObject[,] field;   // ゲーム管理用の配列

    
    Vector2Int GetPlayerIndex()
    {
        for(int y = 0; y < field.GetLength(0); y++)
        {
            for(int x = 0; x < field.GetLength(1); x++)
            {
                if (field[y,x] == null) { continue; }
                if (field[y,x].tag == "Player") 
                {
                    return new Vector2Int(x, y);
                }
            }
        }
        return new Vector2Int(-1, -1);
    }
   
    
    
    bool MoveNumber(Vector2Int moveFrom, Vector2Int moveTo)
    {
        /*
        if(moveTo.y < 0 || moveTo.y >= field.GetLength(0)){ return false; }
        if(moveTo.x < 0 || moveTo.x >= field.GetLength(1)){ return false; }

        
        if (map[moveTo] == 2)
        {
            int velocity = moveTo - moveFrom;

            bool success = MoveNumber(2, moveTo, moveTo + velocity);
            if (!success) {return false;}
        }
        map[moveTo] = number;
        map[moveFrom] = 0;
        */


        if (field[moveTo.y, moveTo.x] != null && field[moveTo.y, moveTo.x].tag == "Box") 
        {
            Vector2Int velocity = moveTo - moveFrom;
            bool success = MoveNumber(moveTo, moveTo + velocity);
            if (!success) {  return false; }
        }

        
        field[moveFrom.y, moveFrom.x].transform.position = 
          new Vector3(moveTo.x, map.GetLength(0) - moveTo.y, 0);
        field[moveTo.y, moveTo.x] = field[moveFrom.y, moveFrom.x];

        field[moveFrom.y, moveFrom.x] = null;
        return true;
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
            {2, 2, 2, 0, 0},
            {0, 2, 1, 0, 0},
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
                if (map[y, x] == 2)
                {
                    //GameObject instance
                    field[y, x] = Instantiate(
                         boxPrefab,
                         new Vector3(x, map.GetLength(0) - y, 0),
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
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector2Int playerIndex = GetPlayerIndex();
            MoveNumber(
                playerIndex, 
                playerIndex + new Vector2Int(1, 0));
            //PrintArray();

        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector2Int playerIndex = GetPlayerIndex();

            MoveNumber(playerIndex, playerIndex - new Vector2Int(1, 0));
            //PrintArray();

        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2Int playerIndex = GetPlayerIndex();

            MoveNumber(playerIndex, playerIndex - new Vector2Int(0, 1));
            //PrintArray();

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector2Int playerIndex = GetPlayerIndex();

            MoveNumber(playerIndex, playerIndex + new Vector2Int(0, 1));
            //PrintArray();

        }

    }
}
