using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    GameObject playerGO;
    string sceneName;
    public static int highScore;

    public static GameManager Instance { get; private set; }
    public int Value;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        sceneName = SceneManager.GetActiveScene().name;

        Invoke("CheckGameState", 5f);
    }

    void CheckGameState()
    {
        if (PlayerStates.playerHealth == 0)
        {
            SceneManager.LoadScene(0);
        }
        if (highScore == MonsterSpawnerManager.totalMaxEnemy)
        {
            SceneManager.LoadScene(2);
        }
    }
}
