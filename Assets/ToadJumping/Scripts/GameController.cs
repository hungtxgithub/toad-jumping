using Assets.ToadJumping.Scripts;
using Assets.ToadJumping.ViewModel;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public GameObject BG;


    public GameObject batEnemy;
    public GameObject beeEnemy;
    public GameObject ghostEnemy;
    public GameObject skullEnemy;
    public GameObject warning;
    public GameObject mainCharacter;
    public GameObject maskCharacter;
    public GameObject virtualCharacter;
    public GameObject pinkCharacter;
    public AudioSource deathSound;

    public GameObject platformContainer;
    public GameObject mainPlatform1;
    public GameObject mainPlatform2;
    public GameObject mainPlatform3;
    public GameObject mainPlatform4;

    public GameObject gameoverDialog;
    public GameObject GamePause;
    public GameObject top;
    public GameObject ranking;
    public GameObject shopping;
    public GameObject ItemPlay;

    public GameObject healthBar;

    public float lastXPosition;
    public PlatformObjectVM[] listLastPlatform { get; set; } = new PlatformObjectVM[3];

    public int score;
    public int bestScore;

    public float speedGameCurrent = 1;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        gameIsActive = false;
        HideHealthBar();
        //bestScore = SaveFile.Instance.getBestScore();

    }

    void HideHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.transform.localScale = new Vector3(0, 0);
        }
    }

    public List<PlatformObjectVM> GetListPlatform()
    {
        return new List<PlatformObjectVM>(){
            new PlatformObjectVM(){GameObject = mainPlatform1, IsNormal = true},
            new PlatformObjectVM(){GameObject = mainPlatform2, IsNormal = false},
            new PlatformObjectVM(){GameObject = mainPlatform3, IsNormal = false},
            new PlatformObjectVM(){GameObject = mainPlatform4, IsNormal = false}
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
        string currentSkin = ShopController.Instance.getCurrentPlayer();
        string itemCard = SaveFile.Instance.getItem().Count > 0 ? SaveFile.Instance.getItem()[0] : "";
        Debug.Log("currentSkin: " + currentSkin);
        switch (currentSkin)
        {
            case "NinjaFrog":
                Common.Instance.SpawnObject(mainCharacter, new Vector2(0, 0));
                break;
            case "MaskDude":
                Common.Instance.SpawnObject(maskCharacter, new Vector2(0, 0));
                break;
            case "PinkMan":
                Common.Instance.SpawnObject(pinkCharacter, new Vector2(0, 0));
                break;
            case "VirtualGuy":
                Common.Instance.SpawnObject(virtualCharacter, new Vector2(0, 0));
                break;
        }

        if(itemCard != "")
        {
            Common.Instance.SpawnObject(ItemPlay, new Vector2(0, 2f));
        } 

        PlatformScript.Instance.RandomStartPlatform(GetListPlatform());

        Time.timeScale = 1;
    }

    public void GameOverUI()
    {
        if (!GameObject.FindWithTag("PauseGame"))
        {
            ranking.SetActive(true);
            RankController.Instance.getTotalScore(score);
            GameObject.FindWithTag("BtnPlayTag").GetComponentInChildren<Text>().text = "Replay";
            GameObject.FindWithTag("BtnPlayTag").GetComponent<Button>().onClick.RemoveListener(GoBtnClick);
            GameObject.FindWithTag("BtnPlayTag").GetComponent<Button>().onClick.AddListener(() => ReplayBtn());
            Time.timeScale = 0;
        }
    }

    public void GoBtnUI()
    {
        menu.SetActive(false);
        BG.SetActive(true);
        ranking.SetActive(false);
        Common.Instance.SpawnObject(top, new Vector2(0f, 0f));
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        speedGameCurrent = 1;
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


        if (GameObject.FindWithTag("PauseGame"))
        {
            Common.Instance.DestroyWithTag("PauseGame");
        }
        speedGameCurrent = 1;
        Time.timeScale = 1;
    }

    public void DisPlayRank()
    {
        ranking.SetActive(!ranking.activeInHierarchy);
        if (gameIsActive && !ranking.activeInHierarchy)
        {
            BackHome();
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

    public void PausGame()
    {
        Common.Instance.SpawnObject(GamePause, new Vector2(0, 0.5f));
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Common.Instance.DestroyWithTag("PauseGame");
        Time.timeScale = 1;
    }

    public void BackHome()
    {
        Common.Instance.DestroyWithTag("MainCharacter");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ActiveItemPlay()
    {
        Common.Instance.DestroyWithTag("ArmorClick");
        SaveFile.Instance.setItem(new List<string>());
        CharacterController.Instance.ApplyArmorItemEffect();
    }
}
