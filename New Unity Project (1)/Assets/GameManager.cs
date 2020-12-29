using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    //public LevelComplete LC;
    //public GameObject LevelCompleteUI;
  
    public Text isWinner;
    public GameObject winMessage;
    public Text PlayerNo;
    public CreateCubeClick createCubeClick;
    public bool GameHasEnded = false;

   

    public void EndGame()
    {
        if (GameHasEnded == false)
        {
            Debug.Log("LOL");
            GameHasEnded = true;

            isWinner.text = createCubeClick.currentPlayer.ToString();
            winMessage.gameObject.SetActive(true);
            PlayerNo.gameObject.SetActive(false);
        }
    }

}