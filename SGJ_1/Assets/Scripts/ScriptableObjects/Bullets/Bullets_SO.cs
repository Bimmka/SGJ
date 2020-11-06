using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Bullet", menuName = "Bullet/Create Bullet", order = 51)]
public class Bullets_SO : ScriptableObject
{
    [Header("Префаб снаряда")]
    [SerializeField] private GameObject bulletPrefab;

    [Header("Время охлаждения")]
    [SerializeField] private float coolingTime;

    [Header("Станящее оружие?")]
    [SerializeField] private bool isStunGun = false;


    #region Load Time

    [Header("Максимальное время зарядки")]
    [SerializeField] private float maxLoadTime;

    [Header("Время зарядки для второй ступени")]
    [SerializeField] private float secondStageLoadTime;

    [Header("Время заряда для третей ступени")]
    [SerializeField] private float thirdStageLoadTime;

    [Header("Время заряда для четвертой ступени")]
    [SerializeField] private float fourthStageLoadTime;

    public float LoadTime => maxLoadTime;
    public float SecondStageLoadTime => secondStageLoadTime;
    public float ThirdStageLoadTime => thirdStageLoadTime;
    public float FourthStageLoadTime => fourthStageLoadTime;
    #endregion


    #region Damage
    [Header("Урон на первой ступени")]
    [SerializeField] private float firstStageDamage;

    [Header("Урон на второй ступени")]
    [SerializeField] private float secondStageDamage;

    [Header("Урон на третьей ступени")]
    [SerializeField] private float thirdStageDamage;

    public float FirstStageDamage => firstStageDamage;
    public float SecondStageDamage => secondStageDamage;
    public float ThirdStageDamage => thirdStageDamage;
    #endregion

    #region Support

    [Header("Первое Замедление")]
    [SerializeField] private float firstStageSlow;

    [Header("Второе Замедление")]
    [SerializeField] private float secondStageSlow;

    [Header("Время стана")]
    [SerializeField] private float thirdStageStunTime;

    public float FirstSlowPrecent => firstStageSlow;
    public float SecondSlowPrecent => secondStageSlow;
    public float FirstStunTime => thirdStageStunTime;
    #endregion


    public GameObject Prefab => bulletPrefab;
    public float CollingTime => coolingTime;
    public bool IsStunGun => isStunGun;

    public float GetDamageByStage(float time)
    {
        if (time > thirdStageLoadTime && time < fourthStageLoadTime)
        {
            Debug.Log(thirdStageDamage);
            return thirdStageDamage;
        }
        if (time > secondStageLoadTime && time < thirdStageLoadTime)
        {
            Debug.Log(secondStageDamage);
            return secondStageDamage;
        }
        Debug.Log(firstStageDamage);
        return firstStageDamage;
    }

    public bool IsStun(float time)
    {
        return time > thirdStageStunTime;
    }

    public float GetEffeectTimeByStage(float time)
    {
        if (time > thirdStageLoadTime && time < fourthStageLoadTime)
        {
            Debug.Log(thirdStageStunTime);
            return thirdStageStunTime;
        }
        if (time > secondStageLoadTime && time < thirdStageLoadTime)
        {
            Debug.Log(secondStageSlow);
            return secondStageSlow;
        }
        Debug.Log(firstStageSlow);
        return firstStageSlow;
    }

}
