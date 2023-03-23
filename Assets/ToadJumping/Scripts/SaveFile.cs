using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using Newtonsoft.Json;

public class SaveFile : MonoBehaviour
{
    private static SaveFile instance;
    public static SaveFile Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<SaveFile>();
            }
            return instance;
        }
    }

    private Dictionary<string, List<string>> dicStr = new Dictionary<string, List<string>>();


    private void Awake()
    {
        instance = this;
        if (!File.Exists(Application.dataPath + "/savefile.json"))
        {
            using (FileStream fs = File.Create(Application.dataPath + "/savefile.json")) { fs.Close(); }
        }

        LoadGame();
    }

    private void Start()
    {
        
    }

    public int getBestScore()
    {
        return int.Parse(dicStr.ContainsKey("BestScore") ? dicStr["BestScore"][0] : "0");
    }
    
    public int getlastScore()
    {
        return int.Parse(dicStr.ContainsKey("LastScore") ? dicStr["LastScore"][0] : "0");
    }

    public String getCurrentPlayer()
    {
        return dicStr.ContainsKey("CurrentPlayer") ? dicStr["CurrentPlayer"][0] : "NinjaFrog";
    }

    public List<String> getPlayer()
    {
        List<String> list = dicStr.ContainsKey("Player") ? dicStr["Player"] : new List<string>();
        if (list.Count() == 0) list.Add("NinjaFrog"); // list empty default add NinjaForg
        return list;
    }
    
    public List<String> getItem()
    {
        List<String> list = dicStr.ContainsKey("Item") ? dicStr["Item"] : new List<string>();
        return list;
    }

    public int getGoldUser()
    {
        return int.Parse(dicStr.ContainsKey("Gold") ? dicStr["Gold"][0] : "0");
    }

    public void setBestScore(int bestScore)
    {
        List<string> list = new List<string>();
        list.Add(bestScore.ToString());
        if (dicStr.ContainsKey("BestScore"))
        {
            dicStr["BestScore"] = list;
        }
        else
        {
            dicStr.Add("BestScore", list);
        }
        saveFileClick();
    }
    
    public void setLastScore(int lastScore)
    {
        List<string> list = new List<string>();
        list.Add(lastScore.ToString());
        if (dicStr.ContainsKey("LastScore"))
        {
            dicStr["LastScore"] = list;
        }
        else
        {
            dicStr.Add("LastScore", list);
        }
        saveFileClick();
    }

    public void setCurrentPlayer(string currentPlayer)
    {
        List<string> list = new List<string>();
        list.Add(currentPlayer);
        if (dicStr.ContainsKey("CurrentPlayer"))
        {
            dicStr["CurrentPlayer"] = list;
        }
        else
        {
            dicStr.Add("CurrentPlayer", list);
        }
        saveFileClick();
    }

    public void setPlayer(List<string> lPlayer)
    {
        if (dicStr.ContainsKey("Player"))
        {
            dicStr["Player"] = lPlayer;
        }
        else
        {
            dicStr.Add("Player", lPlayer);
        }
        saveFileClick();
    }
    
    public void setItem(List<string> lItem)
    {
        if (dicStr.ContainsKey("Item"))
        {
            dicStr["Item"] = lItem;
        }
        else
        {
            dicStr.Add("Item", lItem);
        }
        saveFileClick();
    }

    public void setGold(int gold)
    {
        List<string> list = new List<string>();
        list.Add(gold.ToString());
        if(dicStr.ContainsKey("Gold"))
        {
            dicStr["Gold"] = list;
        } else
        {
            dicStr.Add("Gold", list);
        }
        saveFileClick();
    }

    public void saveFileClick()
    {
        //string tesstjson = JsonUtility.ToJson(1);
        string json = JsonConvert.SerializeObject(dicStr);
        File.WriteAllText("savefile.json", json);
    }

    public void LoadGame()
    {
        string json = File.ReadAllText("savefile.json");
        dicStr = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(json);
    }
}
