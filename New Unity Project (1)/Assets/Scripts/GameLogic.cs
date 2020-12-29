using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameLogic : MonoBehaviour
{
 
   

    public bool[,,] Player1Score = new bool[4, 4, 4]; //last parameter defines whether its Score of player one or player two
    public bool[,,] Player2Score = new bool[4, 4, 4];
    public int k = 0;
    bool isWinner = false;

    void Start()
    {
        SetDefaultScore(Player1Score, Player2Score);
    }

    public void SetDefaultScore(bool[,,] Player1Score, bool[,,] Player2Score)
    {
        for (int z = 0; z < 2; z++)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {

                        Player1Score[i, j, k] = false;
                        Player2Score[i, j, k] = false;

                    }
                }
            }
        }
    }
    
    public void UpdateResults(bool[,,] Player1Score, bool[,,] Player2Score,int i, int j, int currPlayer)
    {
        int k = 0;
        
        if (currPlayer == 1){
        
        if (!Player1Score[i, j, k] && !Player2Score[i, j, k])
            {
                Player1Score[i, j, k] = true;
                Debug.Log("i= " + i + " j= " + j + " k= " + k + " " + Player1Score[i, j, k]);

            }
            else if ((Player1Score[i, j, k] || Player2Score[i, j, k]) && !Player1Score[i, j, k + 1] && !Player2Score[i, j, k + 1])
            {
                Player1Score[i, j, k + 1] = true;
                Debug.Log("i= " + i + " j= " + j + " k= " + (k + 1) + " " + Player1Score[i, j, k + 1]);
            }
            else if ((Player2Score[i, j, k] || Player1Score[i, j, k]) && (Player2Score[i, j, k + 1] || Player1Score[i, j, k + 1]) && (!Player1Score[i, j, k + 2] && !Player2Score[i, j, k + 2]))
            {
                Player1Score[i, j, k + 2] = true;
                Debug.Log("i= " + i + " j= " + j + " k= " + (k + 2) + " " + Player1Score[i, j, k + 2]);
            }
            else if ((Player2Score[i, j, k] || Player1Score[i, j, k]) && (Player2Score[i, j, k + 1] || Player1Score[i, j, k + 1]) && (Player2Score[i, j, k + 2] || Player1Score[i, j, k + 2]) && (!Player1Score[i, j, k + 3] && !Player2Score[i, j, k + 3]))
            {

                Player1Score[i, j, k + 3] = true;
                Debug.Log("i= " + i + " j= " + j + " k= " + (k + 3) + " " + Player1Score[i, j, k + 3]);
            }
            }else if (currPlayer == 2)
            {
                if (!Player1Score[i, j, k] && !Player2Score[i, j, k])
                {
                    Player2Score[i, j, k] = true;
                    Debug.Log("i= " + i + " j= " + j + " k= " + k + " " + Player2Score[i, j, k]);

                }
                else if ((Player1Score[i, j, k] || Player2Score[i, j, k]) && !Player1Score[i, j, k + 1] && !Player2Score[i, j, k + 1])
                {
                    Player2Score[i, j, k + 1] = true;
                    Debug.Log("i= " + i + " j= " + j + " k= " + (k + 1) + " " + Player2Score[i, j, k + 1]);
                }
                else if ((Player2Score[i, j, k] || Player1Score[i, j, k]) && (Player2Score[i, j, k + 1] || Player1Score[i, j, k + 1]) && (!Player1Score[i, j, k + 2] && !Player2Score[i, j, k + 2]))
                {
                    Player2Score[i, j, k + 2] = true;
                    Debug.Log("i= " + i + " j= " + j + " k= " + k + 2 + " " + Player2Score[i, j, k + 2]);
                }
                else if ((Player2Score[i, j, k] || Player1Score[i, j, k]) && (Player2Score[i, j, k + 1] || Player1Score[i, j, k + 1]) && (Player2Score[i, j, k + 2] || Player1Score[i, j, k + 2]) && (!Player1Score[i, j, k + 3] && !Player2Score[i, j, k + 3]))
                {

                    Player2Score[i, j, k + 3] = true;
                    Debug.Log("i= " + i + " j= " + j + " k= " + k + 3 + " " + Player2Score[i, j, k + 3]);
                }
        }

    }

    public bool CheckIfWin(bool[,,] playerScore, int z)
    {

        int i, j;
        

        //check horrizontal

        for (k = 0; k < 4; k++)
        {
            //check horizontal diagonalls
            if ((playerScore[0, 0, k]) && (playerScore[1, 1, k]) && (playerScore[2, 2, k]) && (playerScore[3, 3, k]))
            {
                Debug.Log(z);
                Debug.Log("Winner!");
                isWinner = true;
            }
            if ((playerScore[0, 3, k]) && (playerScore[1, 2, k]) && (playerScore[2, 1, k]) && (playerScore[3, 0, k]))
            {
                Debug.Log(z);
                Debug.Log("Winner!");
                isWinner = true;
            }

            //check horrizontal straight lines
            for (j = 0; j < 4; j++)
            {
                if ((playerScore[0, j, k]) && (playerScore[1, j, k]) && (playerScore[2, j, k]) && (playerScore[3, j, k]))
                {
                    Debug.Log(z);
                    Debug.Log("Winner!");
                    isWinner = true;
                }
            }
            for (i = 0; i < 4; i++)
            {

                if (playerScore[i, 0, k] && playerScore[i, 1, k] && playerScore[i, 2, k] && playerScore[i, 3, k])
                {
                    Debug.Log(z);
                    Debug.Log("Winner!");
                    isWinner = true;
                }
            }
        }

        //Check vertical columns
        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                if ((playerScore[i, j, 0]) && (playerScore[i, j, 1]) && (playerScore[i, j, 2]) && (playerScore[i, j, 3]))
                {
                    Debug.Log(z);
                    Debug.Log("Winner!");
                    isWinner = true;
                }
            }
        }

        //Check diagonal between edges
        for (i = 0; i < 4; i++)
        {
            if ((playerScore[0, i, 0]) && (playerScore[1, i, 1]) && (playerScore[2, i, 2]) && (playerScore[3, i, 3])) //from 111 to 444
            {
                Debug.Log(z);
                Debug.Log("Winner!");
                isWinner = true;
            }
            else if ((playerScore[i, 3, 0]) && (playerScore[i, 2, 1]) && (playerScore[i, 1, 2]) && (playerScore[i, 0, 3])) //from 141 to 414
            {
                Debug.Log(z);
                Debug.Log("Winner!");
                isWinner = true;
            }
            else if ((playerScore[3, i, 0]) && (playerScore[2, i, 1]) && (playerScore[1, i, 2]) && (playerScore[0, i, 3])) //from 111 to 444
            {
                Debug.Log(z);
                Debug.Log("Winner!");
                isWinner = true;
            }
            else if ((playerScore[i, 0, 0]) && (playerScore[i, 1, 1]) && (playerScore[i, 2, 2]) && (playerScore[i, 3, 3])) //from 141 to 414
            {
                Debug.Log(z);
                Debug.Log("Winner!");
                isWinner = true;
            }

        }

        //Check diagonal between corners
        if ((playerScore[0, 0, 0]) && (playerScore[1, 1, 1]) && (playerScore[2, 2, 2]) && (playerScore[3, 3, 3])) //from 111 to 444
        {
            Debug.Log(z);
            Debug.Log("Winner!");
            isWinner = true;
        }
        else if ((playerScore[3, 0, 0]) && (playerScore[2, 1, 1]) && (playerScore[1, 2, 2]) && (playerScore[0, 3, 3])) //from 141 to 414
        {
            Debug.Log(z);
            Debug.Log("Winner!");
            isWinner = true;
        }
        else if ((playerScore[3, 3, 0]) && (playerScore[2, 2, 1]) && (playerScore[1, 1, 2]) && (playerScore[0, 0, 3])) //from 441 to 114
        {
            Debug.Log(z);
            Debug.Log("Winner!");
            isWinner = true;
        }
        else if ((playerScore[3, 0, 0]) && (playerScore[2, 1, 1]) && (playerScore[1, 2, 2]) && (playerScore[0, 3, 3])) //from 411 to 144
        {
            Debug.Log(z);
            Debug.Log("Winner!");
            isWinner = true;
        }

        return isWinner;
    }
}

