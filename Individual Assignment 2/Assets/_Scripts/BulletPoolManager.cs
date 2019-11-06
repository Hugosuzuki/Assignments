using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;

    public int maxbullets = 10;
    public int bulletType = 0;

    //TODO: create a structure to contain a collection of bullets
    private List<GameObject> bullets = new List<GameObject>();
    private List<GameObject> activeBullets = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // TODO: add a series of bullets to the Bullet Pool
        for (int i = 0; i < maxbullets; i++)
        {
            if (bulletType == 0)
            {
                bullet.transform.localScale = new Vector3(1f, 1f, 1f);
                bullets.Add(Instantiate(bullet));
                bullets[i].SetActive(false);
            }
            else if (bulletType == 1)
            {
                bullet.transform.localScale = new Vector3(2f, 2f, 2f);
                bullets.Add(Instantiate(bullet));
                bullets[i].SetActive(false);
            }
            else if (bulletType == 2)
            {
                bullet.transform.localScale = new Vector3(3f, 3f, 3f);
                bullets.Add(Instantiate(bullet));
                bullets[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet(Vector3 position)
    {
        //for (int i = 0; i < bullets.Count; i++)
        //{
        //    if (bullets[i].activeSelf == false)
        //    {
        //        bullets[i].SetActive(true);
        //        bullets[i].transform.position = position;
        //        return bullets[i];
        //    }
        //}
        //return null;
        bullets[0].SetActive(true);
        bullets[0].transform.position = position;
        GameObject tempBullet = bullets[0];
        bullets.RemoveAt(0);
        bullets.Add(tempBullet);
        return tempBullet;
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        GameObject temp = bullet;
    }
}
