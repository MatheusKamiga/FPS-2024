using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] WeaponModel weapon;
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletImpact;
    [SerializeField] int magazine;
    [SerializeField] MeshFilter ModeloAtual;
    [SerializeField] MeshRenderer materialAtual;
    [SerializeField] float firerate;
    [SerializeField] int bulletsForShoot;
    [SerializeField] float timeBetweenShoots;
    [SerializeField] float spread;
    [SerializeField] float range;
    [SerializeField] float reloadTime;
    [SerializeField] int monetion;

    float timeToShoot;
    float timeToReload;
    
    void Start()
    {
        ModeloAtual = GetComponentInChildren<MeshFilter>(); 
        materialAtual = GetComponentInChildren<MeshRenderer>();

        magazine = weapon.MagazineCap;

        ModeloAtual.mesh = weapon.Model;
        materialAtual.material = weapon.Material;

        firerate = weapon.FireRate;
        bulletsForShoot = weapon.BulletsForShoot;
        timeBetweenShoots = weapon.TimeBetweenShoots;
        spread = weapon.Spread;
        range = weapon.Range;
        reloadTime = weapon.ReloadTime;


    }

    private void Update()
    {
        fire();
    }

    private void fire ()
    {
        StartCoroutine(FireCoroutine());
    }

   private IEnumerator FireCoroutine()
    {
        if (magazine > 0) 
        {
            

            if (Time.time > timeToShoot)
            {
                magazine--;
                timeToShoot = Time.time + 1 / firerate;

                Shoot(true);
                yield return new WaitForSeconds(timeBetweenShoots);
                
            }

        }
    }

    private void Shoot(bool crouching)
    {
        RaycastHit hit;

        float newSpread = crouching ? spread / 2 : spread;

        Vector3 direction = new Vector3(Random.Range(-newSpread, newSpread),
            Random.Range(-newSpread, newSpread), 0) + transform.forward;

        if (Physics.Raycast(firePoint.position, direction, out hit, range))
        {
            Collider obj = hit.transform.GetComponent<Collider>();
            if (obj != null)
            {
                Debug.Log(obj.gameObject.name);
                Instantiate(bulletImpact, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }

        Debug.DrawLine(firePoint.position, firePoint.position + direction * range);
    }

    private void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    private IEnumerator ReloadCoroutine()
    {
        int monicaofaltante;
        if (magazine == 0)
        {
            if (monetion > 0)
            {
                

                if (Time.time > timeToReload)
                {
                    monicaofaltante = weapon.MagazineCap - magazine;
                    magazine = magazine + monicaofaltante;

                    monetion = monetion - monicaofaltante;
                   yield return new WaitForSeconds(reloadTime);
                }
              
            }
        }
           
    }

    void UpdateWeapon(WeaponModel novoWeapon)
    {
        weapon = novoWeapon;
    }

    private void OnDrawGizmos()
    {
        
        // Você pode adicionar gizmos para visualizar coisas como o alcance do disparo
    }


}





