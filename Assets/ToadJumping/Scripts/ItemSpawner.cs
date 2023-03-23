using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject heartPrefab;
	[SerializeField] GameObject armorPrefab;
    [SerializeField] bool hasItem;
    const float HeartRate = 0.02f;
    const float ArmorRate = 0.04f;
    const float CoinRate = 0.4f;
	// Start is called before the first frame update
	void Start()
    {
		SpawnHeart();
		SpawnArmor();
		SpawnCoin();
		HasNoItem();
	}

    void SpawnHeart()
    {
		if (hasItem) return;
        float rate = Random.Range(0, 1f);
        if(rate < HeartRate)
        {
            Destroy(coinPrefab);
            Destroy(armorPrefab);
			hasItem = true;
        }
		
	}

    void SpawnCoin()
    {
		if(hasItem) return;
		float rate = Random.Range(0, 1f);
		if (rate < CoinRate)
		{
			Destroy(heartPrefab);
			Destroy(armorPrefab);
			hasItem = true;
		}
	}

	void SpawnArmor()
	{
		if (hasItem) return;
		float rate = Random.Range(0, 1f);
		if (rate < ArmorRate)
		{
			Destroy(heartPrefab);
			Destroy(coinPrefab);
			hasItem = true;
		}
	}

	void HasNoItem()
	{
		if(!hasItem)
		{
			Destroy(heartPrefab);
			Destroy(armorPrefab); 
			Destroy(coinPrefab);
		}
	}
}
