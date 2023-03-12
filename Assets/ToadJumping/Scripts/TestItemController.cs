using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


// Generate item for testing purpose
public class TestItemController : MonoBehaviour
{
    [SerializeField] GameObject prefabItem;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefabItem, new Vector2(0, 1.65f), Quaternion.identity);    
    }
}
