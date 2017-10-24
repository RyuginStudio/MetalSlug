using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Gun
{
    private static ShotGun instance;

    private GameObject instateBulletPrefab;

    void Start()
    {

    }

    void Update()
    {
        currentTime = Time.time;

        if (currentTime - coldTimeUpdate > fireColdTime)
        {
            coldTimeUpdate = Time.time;
            admitShoot = true;           
        }
    }

    void Awake()
    {
        instance = this;
    }


    public static ShotGun getInstance()
    {
        return instance;
    }

    public new void bulletTraject()
    {
        var bulletPos = Character.getInstance().upBody.transform.position;
        var characterPos = Character.getInstance().upBody.transform.position;

        //子弹位置、朝向修正
        switch (Character.getInstance().CharacDirection)
        {
            case Character.Direction.lookLeft:
                {
                    bulletPos = new Vector2(characterPos.x - 2.2f, characterPos.y - 0.13f);

                    break;
                }

            case Character.Direction.lookRight:
                {
                    bulletPos = new Vector2(characterPos.x + 2.2f, characterPos.y - 0.13f);

                    break;
                }

            case Character.Direction.lookUp:
                {

                    break;
                }
            case Character.Direction.lookDown:
                {
                    break;
                }

            case Character.Direction.squat:
                {
                    break;
                }

        }

        instateBulletPrefab = GameObject.Instantiate(bulletPrefab, new Vector2(bulletPos.x, bulletPos.y), Quaternion.identity);

        Invoke("bulletDestory", bulletDestoryTime);
    }

    public new void bulletDestory()
    {
        GameObject.Destroy(instateBulletPrefab);
    }
}
