using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateCubeClick : MonoBehaviour
{

    public GameManager gameManager;
    public Ray ray;
    public RaycastHit hit;
    public GameObject GreenCube;
    public GameObject RedCube;
    public Camera fpsCam;
    public GameLogic GameLogic;
    public Text PlayerText;
    
    int i, j;
    int k = 0;

    public bool IsSpaceOnStack => !GameLogic.Player1Score[i, j, k + 3] && !GameLogic.Player2Score[i, j, k + 3];

    public bool isWinner = false;
    public int currentPlayer = 1;
    public bool didWin = false;


    public void Update()
    {
        if (gameManager.GameHasEnded && Input.GetButtonDown("Fire1")) SceneManager.LoadScene("Menu");


        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))

        {
            string _tag = hit.collider.tag;

            if (Input.GetButtonDown("Fire1") && !(_tag =="Obstacle") )
            {
                float X = (float)(Mathf.Round(hit.transform.position.x - 0.1f)+0.5);
                float Z = hit.transform.position.z;
                float Y = hit.transform.position.y;

                DetermineCoordinates(X,Z);

                if (currentPlayer == 1 && IsSpaceOnStack)
                {
                    
                   GameObject obj = Instantiate(GreenCube, new Vector3(hit.transform.position.x, hit.transform.position.y + 4, hit.transform.position.z),
                               Quaternion.identity) as GameObject;
                    GameLogic.UpdateResults(GameLogic.Player1Score, GameLogic.Player2Score, i, j,currentPlayer);
                    didWin = GameLogic.CheckIfWin(GameLogic.Player1Score, currentPlayer);
                    if (didWin){
                        FindObjectOfType<GameManager>().EndGame();
                        }
                    currentPlayer = 2;
                    PlayerText.text = "Player " +currentPlayer.ToString();
                }
                else if (currentPlayer == 2 && IsSpaceOnStack)
                {
                     GameObject obj = Instantiate(RedCube, new Vector3(hit.transform.position.x, hit.transform.position.y + 4, hit.transform.position.z),
                                Quaternion.identity) as GameObject;
                    GameLogic.UpdateResults(GameLogic.Player1Score, GameLogic.Player2Score, i, j,currentPlayer);
                    didWin = GameLogic.CheckIfWin(GameLogic.Player2Score, currentPlayer);
                     if (didWin){
                        FindObjectOfType<GameManager>().EndGame();
                        }
                    currentPlayer = 1;
                    PlayerText.text = "Player " +currentPlayer.ToString();
                }
            }


        }
    }

        public void DetermineCoordinates(float X,float Z)
    {

        if (X == -2.5f) j = 0;
        else if (X == -1.5f) j = 1;
        else if (X == -0.5f) j = 2;
        else if (X == 0.5f) j = 3;

        if (Z == 10.5) i = 0;
        else if (Z == 9.5) i = 1;
        else if (Z == 8.5f) i = 2;
        else if (Z > 7.1f && Z < 7.9f) i = 3;

    }
}