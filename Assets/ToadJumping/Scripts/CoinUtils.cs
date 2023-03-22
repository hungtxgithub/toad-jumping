using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinUtils : MonoBehaviour
{
    [SerializeField] Item coinItem;
    // Start is called before the first frame update
    void Start()
    {
        print("=> " + coinItem.quantity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
