using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameAero : DefaultAero
{
    override protected void CreateBullet()
    {
        float currentTime = Time.fixedTime;
        if (currentTime - lastShootTime > shootingSpeed)
        {
            AudioManager.PlayShootAudio();
            lastShootTime = currentTime;
            GameObject newBullet1 = Instantiate(bullet, new Vector3(transform.position.x - 0.5f, transform.position.y + 0.65f), Quaternion.identity);
            newBullet1.SetActive(true);
            GameObject newBullet2 = Instantiate(bullet, new Vector3(transform.position.x + 0.5f, transform.position.y + 0.65f), Quaternion.identity);
            newBullet2.SetActive(true);
        }
    }
}
