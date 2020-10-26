using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using ScriptableVariables;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] GameStatus gameStatus;
    [SerializeField] GameObject wonScreen;
    [SerializeField] GameObject defeatScreen; 
    [SerializeField] GameObject startScreen; 
    [SerializeField] GameObject playScreen;
    [SerializeField] IntReference spiritPressure;

    // Start is called before the first frame update
    void Start()
    {
        startScreen.SetActive(true);
        wonScreen.SetActive(false);
        defeatScreen.SetActive(false);
        spiritPressure.Value = 0;
        gameStatus.state = GameStates.START; 
        gameStatus.isExitDoorLocked = true;
        gameStatus.hasWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(spiritPressure.Value >= 100) GameOver(false);

        if(gameStatus.state == GameStates.END){
            if(gameStatus.hasWon){
                Won();
            }else{
                Defeat();
            }
        }
    }

    void GameOver(bool hasWon){

        gameStatus.hasWon = hasWon;
        gameStatus.state = GameStates.END;
        
    }

    public void StartGame(){
        startScreen.SetActive(false);
        playScreen.SetActive(true);
        gameStatus.state = GameStates.PLAYING;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Defeat(){
        playScreen.SetActive(false);
        defeatScreen.SetActive(true);
        gameStatus.state = GameStates.END;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Won(){
        playScreen.SetActive(false);
        wonScreen.SetActive(true);
        gameStatus.hasWon = true;
        gameStatus.state = GameStates.END;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
