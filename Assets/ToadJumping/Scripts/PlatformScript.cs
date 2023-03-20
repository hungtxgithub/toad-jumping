using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.ToadJumping.Scripts;
using System.Linq;
using Assets.ToadJumping.ViewModel;

public class PlatformScript : MonoBehaviour
{

    private static PlatformScript instance;
    public static PlatformScript Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject().AddComponent<PlatformScript>();
            }
            return instance;
        }
    }

	private void Awake()
    {
        instance = this;
    }

    public void RandomStartPlatform(List<PlatformObjectVM> listPlatform)
    {
        float posY = -4;


        for (int i = 0; i < Constant.RowOfPlatform; i++)
        {
            var listPlatformInRow = new PlatformObjectVM[3];
            int numberPlatformInRow = Random.Range(1, 4);

            if (i == 0)
            {
                listPlatformInRow[0] = listPlatform.Where(x => x.IsNormal == true).SingleOrDefault();
                for (int k = 1; k < numberPlatformInRow; k++)
                    listPlatformInRow[k] = listPlatform[Random.Range(0, listPlatform.Count)];
            }
            else
            {
                var listLastPlatform = GameController.Instance.listLastPlatform;
                if (listLastPlatform[0] != null && listLastPlatform[0].IsNormal == true)
                    listPlatformInRow = RandomPlatformPos0(listPlatform, numberPlatformInRow);
                else if (listLastPlatform[1] != null && listLastPlatform[1].IsNormal == true)
                    listPlatformInRow = RandomPlatformPos1(listPlatform, numberPlatformInRow);
                else if (listLastPlatform[2] != null && listLastPlatform[2].IsNormal == true)
                    listPlatformInRow = RandomPlatformPos2(listPlatform, numberPlatformInRow);
            }

            GameController.Instance.listLastPlatform = listPlatformInRow;

            var parent = Common.Instance.SpawnObjectHasReturn(GameController.Instance.platformContainer, new Vector2(0, posY));

            float posX = -2;
            for (int j = 0; j < 3; j++)
            {
                if (listPlatformInRow[j] != null)
                {
                    var child = Common.Instance.SpawnObjectHasReturn(listPlatformInRow[j].GameObject, new Vector2(posX, posY));
                    child.transform.SetParent(parent.transform);
                }
                posX += 2;
            }
            posY += 1.5f;

        }
    }

    public PlatformObjectVM[] RandomPlatformPos0(List<PlatformObjectVM> listPlatform, int numberPlatformInRow)
    {
        var listPlatformInRow = new PlatformObjectVM[3];
        int index = Random.Range(0, 2);
        if (index == 1)
        {
            listPlatformInRow = HandleRow0(listPlatform, numberPlatformInRow);
        }
        else
        {
            listPlatformInRow = HandleRow1(listPlatform, numberPlatformInRow);
        }
        return listPlatformInRow;
    }

    public PlatformObjectVM[] RandomPlatformPos1(List<PlatformObjectVM> listPlatform, int numberPlatformInRow)
    {
        var listPlatformInRow = new PlatformObjectVM[3];
        int index = Random.Range(0, 3);
        if (index == 1)
        {
            listPlatformInRow = HandleRow0(listPlatform, numberPlatformInRow);
        }
        else if (index == 2)
        {
            listPlatformInRow = HandleRow1(listPlatform, numberPlatformInRow);
        }
        else
        {
            listPlatformInRow = HandleRow2(listPlatform, numberPlatformInRow);
        }
        return listPlatformInRow;
    }

    public PlatformObjectVM[] RandomPlatformPos2(List<PlatformObjectVM> listPlatform, int numberPlatformInRow)
    {
        var listPlatformInRow = new PlatformObjectVM[3];
        int index = Random.Range(0, 2);
        if (index == 1)
        {
            listPlatformInRow = HandleRow1(listPlatform, numberPlatformInRow);
        }
        else
        {
            listPlatformInRow = HandleRow2(listPlatform, numberPlatformInRow);
        }
        return listPlatformInRow;
    }

    public PlatformObjectVM[] HandleRow0(List<PlatformObjectVM> listPlatform, int numberPlatformInRow)
    {
        var listPlatformInRow = new PlatformObjectVM[3];
        listPlatformInRow[0] = listPlatform.Where(x => x.IsNormal == true).SingleOrDefault();
        for (int k = 1; k < numberPlatformInRow; k++)
            listPlatformInRow[k] = listPlatform[Random.Range(0, listPlatform.Count)];
        return listPlatformInRow;
    }

    public PlatformObjectVM[] HandleRow1(List<PlatformObjectVM> listPlatform, int numberPlatformInRow)
    {
        var listPlatformInRow = new PlatformObjectVM[3];
        listPlatformInRow[1] = listPlatform.Where(x => x.IsNormal == true).SingleOrDefault();
        if (numberPlatformInRow == 2)
            listPlatformInRow[0] = listPlatform[Random.Range(0, listPlatform.Count)];
        else if (numberPlatformInRow == 3)
            listPlatformInRow[2] = listPlatform[Random.Range(0, listPlatform.Count)];
        return listPlatformInRow;
    }

    public PlatformObjectVM[] HandleRow2(List<PlatformObjectVM> listPlatform, int numberPlatformInRow)
    {
        var listPlatformInRow = new PlatformObjectVM[3];
        listPlatformInRow[2] = listPlatform.Where(x => x.IsNormal == true).SingleOrDefault();
        for (int k = numberPlatformInRow - 2; k >= 0; k--)
            listPlatformInRow[k] = listPlatform[Random.Range(0, listPlatform.Count)];
        return listPlatformInRow;
    }

}
