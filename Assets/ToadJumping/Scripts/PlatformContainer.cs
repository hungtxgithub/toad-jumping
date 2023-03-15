using Assets.ToadJumping.Scripts;
using Assets.ToadJumping.ViewModel;
using UnityEngine;

public class PlatformContainer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * 1 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
        {
            Destroy(gameObject);
            Debug.Log("Đã xóa PlatformContainer");
            InstancePlatform();
            Debug.Log("Đã Instance Platform");
        }
    }

    private void InstancePlatform()
    {
        var listPlatformInRow = new PlatformObjectVM[3];
        int numberPlatformInRow = Random.Range(1, 4);

        var listLastPlatform = GameController.Instance.listLastPlatform;
        if (listLastPlatform[0] != null && listLastPlatform[0].IsNormal == true)
            listPlatformInRow = Platform.Instance.RandomPlatformPos0(GameController.Instance.GetListPlatform(), numberPlatformInRow);
        else if (listLastPlatform[1] != null && listLastPlatform[1].IsNormal == true)
            listPlatformInRow = Platform.Instance.RandomPlatformPos1(GameController.Instance.GetListPlatform(), numberPlatformInRow);
        else if (listLastPlatform[2] != null && listLastPlatform[2].IsNormal == true)
            listPlatformInRow = Platform.Instance.RandomPlatformPos2(GameController.Instance.GetListPlatform(), numberPlatformInRow);

        GameController.Instance.listLastPlatform = listPlatformInRow;

        var parent = Common.Instance.SpawnObjectHasReturn(GameController.Instance.platformContainer, new Vector2(0, 5.5f));

        float posX = -2;
        for (int j = 0; j < 3; j++)
        {
            if (listPlatformInRow[j] != null)
            {
                var child = Common.Instance.SpawnObjectHasReturn(listPlatformInRow[j].GameObject, new Vector2(posX, 5.5f));
                child.transform.SetParent(parent.transform);
            }
            posX += 2;
        }
    }
}
