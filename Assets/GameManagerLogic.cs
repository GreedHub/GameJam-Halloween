using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableVariables;
using UnityEngine.SceneManagement;
public class GameManagerLogic : MonoBehaviour
{
    [SerializeField] IntReference spiritPressure;
    // Start is called before the first frame update
    void Start()
    {
        spiritPressure.Value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(spiritPressure.Value >= 100) GameOver();
    }

    void GameOver(){
        //Play death sound
        //Show death screen
        RestartGame();
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
