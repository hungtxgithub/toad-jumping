using Assets.ToadJumping.Scripts;
using Assets.ToadJumping.ViewModel;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    
    private bool gameIsActive;

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

    //public GameObject title;
    //public GameObject character;
    //public GameObject goBtnWrap;
    //public GameObject platform;
    public GameObject menu;


    public GameObject batEnemy;
    public GameObject beeEnemy;
    public GameObject ghostEnemy;
    public GameObject skullEnemy;
    public GameObject warning;
    public GameObject mainCharacter;

    public GameObject platformContainer;
    public GameObject mainPlatform1;
    public GameObject mainPlatform2;
    public GameObject mainPlatform3;

    public GameObject gameoverDialog;
    public GameObject top;
    public GameObject ranking;
    public GameObject shopping;

    public GameObject healthBar;

public float lastXPosition;
    public PlatformObjectVM[] listLastPlatform { get; set; } = new PlatformObjectVM[3];

    public int score;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
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
        gameIsActive = true;
        GoBtnUI();
        //Random enemy function
        EnemyScript.Instance.RandomEnemy();
        Common.Instance.SpawnObject(mainCharacter, new Vector2(0, 0.5f));
        PlatformScript.Instance.RandomStartPlatform(GetListPlatform());
    }

    public void GameOverUI()
    {
        //Common.Instance.SpawnObject(gameoverDialog, new Vector2(0f, 0f));
        ranking.SetActive(true);
        GameObject.FindWithTag("BtnPlayTag").GetComponentInChildren<Text>().text = "Replay";
        GameObject.FindWithTag("BtnPlayTag").GetComponent<Button>().onClick.RemoveListener(GoBtnClick);
        GameObject.FindWithTag("BtnPlayTag").GetComponent<Button>().onClick.AddListener(() => ReplayBtn());
        Time.timeScale = 0;
    }

    public void GoBtnUI()
    {
        //title.SetActive(false);
        //character.SetActive(false);
        //platform.SetActive(false);
        //goBtnWrap.SetActive(false);
        menu.SetActive(false);
        ranking.SetActive(false);
        Common.Instance.SpawnObject(top, new Vector2(0f, 0f));
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ReplayBtn()
    {
        Instance.score = 0;

        //Common.Instance.DestroyWithTag("GameoverDialog");
        ranking.SetActive(false);
        Common.Instance.DestroyWithTag("Top");
        Common.Instance.DestroyWithTag("PlatformContainer");
        Common.Instance.DestroyWithTag("Enemy");
        Common.Instance.DestroyWithTag("Warning");
        Common.Instance.DestroyWithTag("MainCharacter");
        EnemyScript.Instance.RandomEnemy();
        Common.Instance.SpawnObject(mainCharacter, new Vector2(0, 0.5f));
        PlatformScript.Instance.RandomStartPlatform(GetListPlatform());
        Common.Instance.SpawnObject(top, new Vector2(0f, 0f));

        Time.timeScale = 1;
    }

    public void DisPlayRank()
    {
        ranking.SetActive(!ranking.activeInHierarchy);
        if (gameIsActive && !ranking.activeInHierarchy)
        {
            menu.SetActive(true);
        }
    }

    public void DisPlayShop()
    {
        shopping.SetActive(!shopping.activeInHierarchy);
        if (shopping.activeInHierarchy)
        {
            ShopController.Instance.openShop();
        }
        else
        {
            ShopController.Instance.closeShop();
        }
    }
}
