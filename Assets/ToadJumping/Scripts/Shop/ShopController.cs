using Assets.ToadJumping.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Path;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    private static ShopController instance;

    [SerializeField]
    public List<GameObject> items;
    [SerializeField]
    public List<GameObject> players;

    public GameObject btnMain;

    // true: items, false: players
    private bool optionActive;
    //xác ??nh mode hi?n t?i hi?n th? gì
    private bool currentActive;

    private List<GameObject> selectedItems;

    private GameObject selectedGameObject;

    private int index;

    //danh sách l?y t? file khi ng??i dùng mua
    private List<String> cardPlayer = new List<string>();
    private List<String> cardItem = new List<string>();
    //vàng ??c t? file ra
    private int totalGold { get; set; }
    private string playerNameActive = "MaskDude";

    public static ShopController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<ShopController>();
            }
            return instance;
        }
    }

    public string getCurrentPlayer()
    {
        return playerNameActive;
    }

    private void Awake()
    {
        instance = this;
        optionActive = false;
        currentActive = optionActive;
        selectedItems = players;
        index = 0;

        //data test
        cardPlayer.Add("MaskDude");
        cardPlayer.Add("NinjaFrog");
        //cardItem.Add("Armor");
        totalGold = 2000;

    }

    private void Start()
    {

    }

    public void openShop()
    {
        selectedGameObject = selectedItems[index];
        ShopController.Instance.SpawnObject(selectedGameObject, new Vector2(0, 0f));
        setTextUserGold();
        checkDisplayBtn();
    }

    public void closeShop()
    {
        Destroy(GameObject.Find(selectedGameObject.name + "(Clone)"));
    }

    public void setUpShopDisPlay()
    {
        if (currentActive != optionActive)
        {
            Destroy(GameObject.Find(selectedGameObject.name + "(Clone)"));
            index = 0;
            selectedGameObject = selectedItems[index];
            ShopController.Instance.SpawnObject(selectedGameObject, new Vector2(0, 0f));
            currentActive = optionActive;
        }
    }

    public void displayItem()
    {
        optionActive = true;
        selectedItems = items;
        setUpShopDisPlay();
        checkDisplayBtn();
    }

    public void displayPlayer()
    {
        optionActive = false;
        selectedItems = players;
        setUpShopDisPlay();
        checkDisplayBtn();
    }

    public void nextOption()
    {
        Destroy(GameObject.Find(selectedGameObject.name + "(Clone)"));
        selectedGameObject = null;
        index = (index + 1) == selectedItems.Count ? 0 : index + 1;
        selectedGameObject = selectedItems[index];
        ShopController.Instance.SpawnObject(selectedGameObject, new Vector2(0, 0f));
        checkDisplayBtn();
    }

    public void PrevousOption()
    {
        Destroy(GameObject.Find(selectedGameObject.name + "(Clone)"));
        selectedGameObject = null;
        index = index == 0 ? selectedItems.Count - 1 : index - 1;
        selectedGameObject = selectedItems[index];
        ShopController.Instance.SpawnObject(selectedGameObject, new Vector2(0, 0f));
        checkDisplayBtn();
    }

    public void checkDisplayBtn()
    {
        var currentObjCost = selectedGameObject.GetComponents<ShopObj>();
        //set display text and name obj
        GameObject.Find("TextNameObj").GetComponent<Text>().text = selectedGameObject.tag;
        GameObject.Find("TextCost").GetComponent<Text>().text = currentObjCost.Length > 0 ? currentObjCost[0].Cost.ToString() : "";

        if (!optionActive)
        {
            if (!btnMain.activeInHierarchy) btnMain.SetActive(true);

            if (selectedGameObject.tag != playerNameActive)
            {
                btnMain.GetComponentInChildren<Text>().text = cardPlayer.Contains(selectedGameObject.tag) ? "USE" : "BUY";
                if (currentObjCost.Length == 0 || (currentObjCost[0].Cost <= totalGold || cardPlayer.Contains(selectedGameObject.tag)))
                {
                    btnMain.GetComponent<Button>().interactable = true;
                }
                else
                {
                    btnMain.GetComponent<Button>().interactable = false;
                }
            }
            else
            {
                btnMain.GetComponentInChildren<Text>().text = "USED";
                btnMain.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            btnMain.GetComponentInChildren<Text>().text = "BUY";
            btnMain.GetComponent<Button>().interactable = true;
            btnMain.SetActive(!cardItem.Contains(selectedGameObject.name));
        }
    }
    /**
     * posion: Z: -17550 
     * Scale: 817.4957, 978.4969, 195
     * -329
     */

    /// <summary>
    /// Spawn object with Position x, y
    /// </summary>
    /// <param name="posX"></param>
    /// <param name="posY"></param>
    public void SpawnObject(GameObject obj, Vector2 vector2)
    {
        Instantiate(obj, vector2, Quaternion.identity);
    }

    public void setTextUserGold()
    {
        GameObject.Find("TextUserGold").GetComponent<Text>().text = totalGold.ToString();
    }

    public void updateUserGold(int num, bool typeCheck)
    {
        // true +, false -
        if (num != 0)
        {
            if (typeCheck)
            {
                totalGold += num;
            }
            else
            {
                totalGold -= num;
            }
        }
    }

    public void clickMainBtn()
    {
        var TextBtn = btnMain.GetComponentInChildren<Text>().text;
        var currentObjCost = selectedGameObject.GetComponents<ShopObj>();
        int currentCost = currentObjCost.Length > 0 ? currentObjCost[0].Cost : 0;
        switch (TextBtn)
        {
            case "BUY":
                updateUserGold(currentCost, false);
                cardPlayer.Add(selectedGameObject.tag);
                setTextUserGold();
                checkDisplayBtn();
                break;

            case "USE":
                playerNameActive = selectedGameObject.tag;
                checkDisplayBtn();
                break;

            default:
                break;
        }
    }
}