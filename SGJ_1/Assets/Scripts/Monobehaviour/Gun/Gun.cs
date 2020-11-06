using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Gun : MonoBehaviour
{
    [Header("Точка вылета снаряда")]
    [SerializeField] private Transform firePoint;

    [Header("Длина рейкаста")]
    [SerializeField] private float raycastDistance;

    private void Awake()
    {
        PlayerShoot.Shot += Shoot;
    }

    private void OnDisable()
    {
        PlayerShoot.Shot -= Shoot;
    }

    private void Shoot(float damage, float effectTime, bool isStun)
    {
        if (damage == 0) LightShoot(isStun, effectTime);
        else ElectricShoot(damage);
    }

    private void ElectricShoot(float damage)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            IAttackable attackInterface = hit.collider.GetComponent<IAttackable>();
            if (attackInterface != null) attackInterface.GetDamage(damage);
        }
    }

    private void LightShoot(bool isStun, float effectTime)
    {

    }
}
