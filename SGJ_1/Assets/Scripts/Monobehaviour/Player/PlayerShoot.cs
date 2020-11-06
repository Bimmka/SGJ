using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [Header("Точка спавна снарядов")]
    [SerializeField] private Transform firePointTransform;

    [Header("Простой снаряд")]
    [SerializeField] private Bullets_SO electroBullet;

    [Header("Сложный снаряд")]
    [SerializeField] private Bullets_SO lightBullet;

    private bool isShoot;

    public static Action<float,float,bool> Shot;
    private void Awake()
    {

    }

    private void Update()
    {
        
        if (!isShoot) TryShoot();
    }

    private void TryShoot()
    {
        if (Input.GetMouseButtonDown(0)) PrepareBulletShoot();
        else if (Input.GetMouseButtonDown(1)) PrepareLightShoot();
    }

    private void PrepareBulletShoot()
    {
        isShoot = true;
        StartCoroutine(CountdownWeaponLoad(electroBullet.LoadTime, electroBullet.LoadTime, electroBullet.IsStunGun, 0, electroBullet));
    }

    private void PrepareLightShoot()
    {
        isShoot = true;
        StartCoroutine(CountdownWeaponLoad(lightBullet.LoadTime,lightBullet.LoadTime,  lightBullet.IsStunGun, 1, lightBullet));
    }
    private IEnumerator CountdownWeaponLoad (float clickedTime, float maxLoadTime,  bool isStun, int mouseButton, Bullets_SO bullet)
    {
        while (Input.GetMouseButtonUp(mouseButton) == false)
        {
            yield return null;
            clickedTime -= Time.deltaTime;
            if (clickedTime < 0) break;
        }
        if (clickedTime < 0) clickedTime = 0;
        float dif = maxLoadTime - clickedTime;
        
        if (dif != maxLoadTime)
        {
            if (isStun)
            {
                if (lightBullet.IsStun(dif)) Shot(0, lightBullet.FirstStunTime, true);
                else Shot(0, lightBullet.GetEffeectTimeByStage(dif), false);
            }
            else Shot(electroBullet.GetDamageByStage(dif), 0, false);
            isShoot = false;
        }

        StartCoroutine(CoolGun(bullet.CollingTime));
        
    }

    private IEnumerator CoolGun(float coolTime)
    {
        Debug.Log("Cool");
        yield return new WaitForSeconds(coolTime);
        isShoot = false;
    }

}
