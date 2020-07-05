using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

        }
    }

    public void RestartGame()
    {
        LoadGamePlay();
    }
    void LoadGamePlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
