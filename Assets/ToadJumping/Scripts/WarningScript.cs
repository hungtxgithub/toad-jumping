using Assets.ToadJumping.Scripts;
using System.Collections;
using UnityEngine;

public class WarningScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyObjectAfterSeconds(gameObject, 4));
    }

    private void Update()
    {
    }

    /// <summary>
    /// Destroy object After n Seconds
    /// </summary>
    /// <param name="seconds"></param>
    /// <returns></returns>
    private IEnumerator DestroyObjectAfterSeconds(GameObject obj, float seconds)
    {
        int count = 0;
        while (count==0)
        {
            var a = new WaitForSeconds(seconds);
            yield return new WaitForSeconds(seconds);
            Destroy(obj);
            count++;
        }
    }


}
