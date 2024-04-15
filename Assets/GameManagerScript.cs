using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    int[] map = { 0, 0, 2, 1, 0, 2, 0, 0, 0 };
    string debugText = "";

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

    void Start()
    {

        for(int i = 0; i < map.Length; i++) 
        {
            debugText += map[i].ToString() + ",";
        }

        Debug.Log(debugText);

        PrintArray();

    }

    // Update is called once per frame
    void Update()
    {

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
    }
}
