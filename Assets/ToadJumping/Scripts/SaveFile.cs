using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Object = UnityEngine.Object;

public class SaveFile : MonoBehaviour
{
    string filePath = Application.dataPath + "/savefile.json";

    private Dictionary<string, List<GameObject>> dicGameObj = new Dictionary<string, List<GameObject>>();
    private Dictionary<string, List<string>> dicStr = new Dictionary<string, List<string>>();

    private void Awake()
    {
        if (!File.Exists(filePath))
        {
            //using (FileStream fs = File.Create(filePath)) { fs.Close(); }
        }
    }

    public String getCurrentPlayer()
    {
        return dicStr["CurrentPlayer"][0];
    }

    public List<String> getPlayer()
    {
        List<String> list = dicStr["Player"];
        return list;
    }
    
    public List<String> getItem()
    {
        List<String> list = dicStr["Item"];
        return list;
    }

    public int getGoldUser()
    {
        return int.Parse(dicStr["Gold"][0]);
    }

    public List<GameObject> getMonster()
    {
        return dicGameObj["Monster"];
    }

    public List<GameObject> getPlatform()
    {
        return dicGameObj["Platform"];
    }

    public void setCurrentPlayer(string currentPlayer)
    {
        List<string> list = new List<string>();
        list.Add(currentPlayer);
        dicStr.Add("CurrentPlayer", list);
    }

    public void setPlayer(List<string> lPlayer)
    {
        dicStr.Add("Player", lPlayer);
    }
    
    public void setItem(List<string> lItem)
    {
        dicStr.Add("Item", lItem);
    }

    public void setGold(int gold)
    {
        List<string> list = new List<string>();
        list.Add(gold.ToString());
        dicStr.Add("Gold", list);
    }

    public void setMonster(List<GameObject> lMonster)
    {
        dicGameObj.Add("Monster", lMonster);
    }

    public void setPlatform(List<GameObject> lPlatform)
    {
        dicGameObj.Add("Platform", lPlatform);
    }
}
