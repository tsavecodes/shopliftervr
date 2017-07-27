using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState { INTRO, MAIN_MENU, IN_GAME }
public delegate void OnStateChangeHandler();



public class GameManager : MonoBehaviour
{
    protected GameManager() { }
    private static GameManager instance = null;
    public event OnStateChangeHandler OnStateChange;
    public GameState gameState { get; private set; }

    public Color alarmColor;

    public bool isHoldingObjective = false;

    public int level = 1;
    public GameObject[] securityColliders;

    public GameObject playerCollider;


    public static GameManager Instance
    {
        get {
            if (GameManager.instance == null)
            {
                DontDestroyOnLoad(GameManager.instance);
                GameManager.instance = new GameManager();
            }
            return GameManager.instance;
        }
    }

    public void SetGameState(GameState state)
    {
        this.gameState = state;
        OnStateChange();
    }


    public void OnApplicationQuit()
    {
        GameManager.instance = null;
    }


    void Update()
    {
       
    }


    public void SecurityCollisionDetected(Collider collider)
    {

       // GameObject item = GameObject.FindGameObjectWithTag("MainObjective");

        if(isHoldingObjective)
        {
            GameObject alarmLight = GameObject.FindGameObjectWithTag("AlarmLight");
            alarmLight.GetComponent<Light>().color = Color.red;
            Debug.Log("SecurityCollisionDetected");
        } else
        {
            Debug.Log("not breaking the law");
        }
        
    }
}
