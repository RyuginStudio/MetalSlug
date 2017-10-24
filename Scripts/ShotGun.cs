using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Gun
{
    private static ShotGun instance;

    public static ShotGun getInstance()
    {
        if (instance == null)
        {
            instance = new ShotGun();
            instance.init();
        }

        return instance;
    }

    public override void init()
    {
        holdGun = gunKind.shotGun;
        bombCapacity = 1;
        fireCodeTime = 1;
        damageValue = 100;

        bulletPrefab = GameData.getInstance().Prefab_bulletPrefab;
    }

    public override void bulletTraject()
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

        //GameObject.Instantiate(bulletPrefab, new Vector2(bulletPos.x, bulletPos.y),Quaternion.identity); 

    }

    public override void bulletRemove()
    {
        throw new System.NotImplementedException();
    }
}
