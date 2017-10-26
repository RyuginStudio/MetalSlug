using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Gun
{
    private static ShotGun instance;

    private GameObject instateBulletPrefab;

    //预制件朝向
    private Quaternion prefabDirect;

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
                    prefabDirect = Quaternion.Euler(0, 180, 0);
                    break;
                }

            case Character.Direction.lookRight:
                {
                    bulletPos = new Vector2(characterPos.x + 2.2f, characterPos.y - 0.13f);
                    prefabDirect = Quaternion.Euler(0, 0, 0);
                    break;
                }

            case Character.Direction.lookUp:
                {
                    if(Character.getInstance().downBody.transform.rotation.y != 0) //0：左；非0：右
                    {
                        bulletPos = new Vector2(Character.getInstance().downBody.transform.position.x + 0.2f, Character.getInstance().downBody.transform.position.y + 3.7f);
                        prefabDirect = Quaternion.Euler(0, 0, 90);
                    }
                    else
                    {
                        bulletPos = new Vector2(Character.getInstance().downBody.transform.position.x - 0.2f, Character.getInstance().downBody.transform.position.y + 3.7f);
                        prefabDirect = Quaternion.Euler(0, 180, 90);
                    }
                    break;
                }
            case Character.Direction.lookDown:
                {
                    break;
                }

            case Character.Direction.squat:
                {
                    if (Character.getInstance().downBody.transform.rotation.y != 0) //0：左；非0：右
                    {
                        bulletPos = new Vector2(characterPos.x + 2.2f, characterPos.y - 0.13f);
                        prefabDirect = new Quaternion(0, 0, 0, 0);

                    }
                    else
                    {
                        bulletPos = new Vector2(characterPos.x - 2.2f, characterPos.y - 0.13f);
                        prefabDirect = new Quaternion(0, 180, 0, 0);
                    }
                    break;
                }

        }      

        instateBulletPrefab = GameObject.Instantiate(bulletPrefab, new Vector2(bulletPos.x, bulletPos.y), prefabDirect);
        
        Invoke("bulletDestory", bulletDestoryTime);
    }

    public new void bulletDestory()
    {
        GameObject.Destroy(instateBulletPrefab);
    }

}
