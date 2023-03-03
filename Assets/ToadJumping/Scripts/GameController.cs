using Assets.ToadJumping.Scripts;
using Assets.ToadJumping.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject title;
    public GameObject character;
    public GameObject platform;
    public GameObject goBtnWrap;

    public GameObject batEnemy;
    public GameObject beeEnemy;
    public GameObject ghostEnemy;
    public GameObject skullEnemy;
    public GameObject warning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Handle click button
    /// </summary>
    public void GoBtnClick()
    {
        title.SetActive(false);
        character.SetActive(false);
        platform.SetActive(false);
        goBtnWrap.SetActive(false);

        //Random enemy function
        gameObject.AddComponent<EnemyScript>().RandomEnemy();
    }


}
