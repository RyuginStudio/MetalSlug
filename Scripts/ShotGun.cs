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
        //Debug.Log("init()");
        holdGun = gunKind.shotGun;
        bombCapacity = 1;
        fireCodeTime = 1;
        damageValue = 100;

        bulletPrefab = GameData.getInstance().Prefab_bulletPrefab;
    }

    public override void bulletTraject()
    {
        int prefabDirect;
        var characterPos = Character.getInstance().upBody.transform.position;

        //子弹位置修正
        var bulletPos = Character.getInstance().CharacDirection == Character.Direction.lookLeft
        ? new Vector2(characterPos.x - 2.2f, characterPos.y - 0.13f)
        : new Vector2(characterPos.x + 2.2f, characterPos.y - 0.13f);

        prefabDirect = Character.getInstance().CharacDirection == Character.Direction.lookLeft
        ? 1
        : 0;

        var a = GameObject.Instantiate(bulletPrefab, new Vector2(bulletPos.x, bulletPos.y), new Quaternion(0, prefabDirect, 0, 0));  

    }

    public override void bulletRemove()
    {
        throw new System.NotImplementedException();
    }
}
