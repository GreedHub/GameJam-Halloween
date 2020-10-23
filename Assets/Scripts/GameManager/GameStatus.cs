using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
[CreateAssetMenu(fileName = "New GameStatus", menuName="Utils/GameStatus")]
public class GameStatus: ScriptableObject{    
    public GameStates state;
    public bool hasWon;
    public bool isExitDoorLocked;
    public bool isFlashlightEnabled;
}

public enum GameStates{
    START,
    PLAYING,
    END
}