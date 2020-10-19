using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
   
    [SerializeField]private Slider _progressBar;

    private GameState _gameState;

   

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        DontDestroyOnLoad(this);

       

    }

    public static GameManager Instance()
    {
        return _instance;
    }

    private void Start()
    {
        
        PrepareGame();
        


    }

    private void PrepareGame()
    {
        _gameState = new GameState();
        _gameState.totalCheckPoint = 5;
        ChangeProgressValue();
        
    }

    public void ChangeCheckPoint(int id)
    {
        _gameState.currentCheckPoint = id +1;
        ChangeProgressValue();
    }

    public void ChangeProgressValue()
    {
        float progressValue = (float) _gameState.currentCheckPoint / _gameState.totalCheckPoint;
        _progressBar.value = progressValue;
    }
}
