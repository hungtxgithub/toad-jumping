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

    [SerializeField]
    public Animator nextAnimation;
    public Animator previousAnimation;

    // true: items, false: players
    private bool optionActive;

    private List<GameObject> selectedItems;

    private GameObject selectedGameObject;
    private int index;
    private List<String> stringCard = new List<string>();

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

    private void Awake()
    {
        instance = this;
        optionActive = true;
        selectedItems = players;
        index = 0;
        stringCard.Add("MaskDude(Clone)");
        stringCard.Add("PinkMan(Clone)");

    }

    private void Start()
    {
        //setUpShopDisPlay();
        //GameObject shop = GameObject.Find("Shopping");
        //if(shop.activeInHierarchy)
        //{
        //    selectedGameObject = selectedItems[0];
        //    ShopController.Instance.SpawnObject(selectedGameObject, new Vector2(0, 0.5f));
        //}
        //selectedGameObject.GetComponent<Animator>().runtimeAnimatorController = nextAnimation.GetComponent<Animator>().runtimeAnimatorController;
        //selectedGameObject.GetComponent<Animator>().SetBool("NextAnimation", false);
    }

    public void openShop()
    {
        selectedGameObject = selectedItems[0];
        ShopController.Instance.SpawnObject(selectedGameObject, new Vector2(0, 0.5f));
    }

    public void closeShop()
    {
        Destroy(GameObject.Find(selectedGameObject.name + "(Clone)"));
    }

    public void setUpShopDisPlay()
    {
        optionActive = !optionActive;
        Destroy(GameObject.Find(selectedGameObject.name + "(Clone)"));
        selectedItems = optionActive ? players : items;
        index = 0;
        selectedGameObject = selectedItems[index];
        ShopController.Instance.SpawnObject(selectedGameObject, new Vector2(0, 0.5f));
    }

    public void nextOption()
    {
        //selectedGameObject.GetComponent<Animator>().enabled = true;
        //selectedGameObject.GetComponent<Animator>().SetBool("NextAnimation", true);

        //selectedGameObject.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Assets/ToadJumping/Art/Animations/GUI/Shop/NextAnimator.controller") as RuntimeAnimatorController;
        //selectedGameObject.GetComponent<Animator>().runtimeAnimatorController = Resources.Load("Assets/ToadJumping/Art/Animations/GUI/Shop/NextAnimator.controller") as RuntimeAnimatorController;
        //selectedGameObject.GetComponent<Animator>().runtimeAnimatorController = nextAnimation.GetComponent<Animator>().runtimeAnimatorController;
        //Destroy(selectedGameObject, 2f);
        Destroy(GameObject.Find(selectedGameObject.name+ "(Clone)"));
        selectedGameObject = null;
        index = (index + 1) == selectedItems.Count ? 0 : index + 1;
        selectedGameObject = selectedItems[index];
        ShopController.Instance.SpawnObject(selectedGameObject, new Vector2(0, 0.5f));
        GameObject.Find("BtnActive").GetComponentInChildren<Text>().text = stringCard.Contains(selectedGameObject.name + "(Clone)") ? "USE" : "BUY";
    }

    public void PrevousOption()
    {
        Destroy(GameObject.Find(selectedGameObject.name + "(Clone)"));
        selectedGameObject = null;
        index = index == 0 ? selectedItems.Count - 1 : index - 1;
        selectedGameObject = selectedItems[index];
        ShopController.Instance.SpawnObject(selectedGameObject, new Vector2(0, 0.5f));
        GameObject.Find("BtnActive").GetComponentInChildren<Text>().text = stringCard.Contains(selectedGameObject.name + "(Clone)") ? "use" : "buy";
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
}
