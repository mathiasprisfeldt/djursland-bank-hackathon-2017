using System;
using AcrylecSkeleton.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public Player Player { get; set; }

    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += SceneManagerOnSceneLoaded;
    }

    private void SceneManagerOnSceneLoaded(Scene arg0, LoadSceneMode loadSceneMode)
    {
        Player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
