using Assets.ToadJumping.Scripts;
using Assets.ToadJumping.ViewModel;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;

    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<GameController>();
            }
            return instance;
        }
    }

    public GameObject title;
    public GameObject character;
    public GameObject goBtnWrap;
    public GameObject platform;

    public GameObject batEnemy;
    public GameObject beeEnemy;
    public GameObject ghostEnemy;
    public GameObject skullEnemy;
    public GameObject warning;
    public GameObject mainCharacter;

    public GameObject mainPlatform1;
    public GameObject mainPlatform2;
    public GameObject mainPlatform3;

    public GameObject gameoverDialog;
    public GameObject top;


    public float lastXPosition { get; set; }


    private void Awake()
    {
        instance = this;
    }


    public List<PlatformObjectVM> GetListPlatform()
    {
        return new List<PlatformObjectVM>(){
            new PlatformObjectVM(){GameObject = mainPlatform1, IsNormal = true},
            new PlatformObjectVM(){GameObject = mainPlatform2, IsNormal = false},
            new PlatformObjectVM(){GameObject = mainPlatform3, IsNormal = false}
        };
    }

    /// <summary>
    /// Handle click button
    /// </summary>
    public void GoBtnClick()
    {
        GoBtnUI();
        //Random enemy function
        EnemyScript.Instance.RandomEnemy();
        Common.Instance.SpawnObject(mainCharacter, new Vector2(0, 0.5f));
        Platform.Instance.RandomStartPlatform(GetListPlatform());
    }

    public void GameOverUI()
    {
        Common.Instance.SpawnObject(gameoverDialog, new Vector2(0f, 0f));
        Time.timeScale = 0;

    }

    public void GoBtnUI()
    {
        title.SetActive(false);
        character.SetActive(false);
        platform.SetActive(false);
        goBtnWrap.SetActive(false);
        Common.Instance.SpawnObject(top, new Vector2(0f, 0f));
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ReplayBtn()
    {
        Common.Instance.DestroyWithTag("GameoverDialog");
        Common.Instance.DestroyWithTag("Top");
        Common.Instance.DestroyWithTag("Platform");
        Common.Instance.DestroyWithTag("Enemy");
        Common.Instance.DestroyWithTag("Warning");
        EnemyScript.Instance.RandomEnemy();
        Common.Instance.SpawnObject(mainCharacter, new Vector2(0, 0.5f));
        Platform.Instance.RandomStartPlatform(GetListPlatform());
        Common.Instance.SpawnObject(top, new Vector2(0f, 0f));

        Time.timeScale = 1;
    }
}
