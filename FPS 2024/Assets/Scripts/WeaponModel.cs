using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "weapon asset" )] 
public class WeaponModel : ScriptableObject 
{
    [SerializeField] float damage;
    [SerializeField] float range;
    [SerializeField] float fireRate;
    [SerializeField] float spread;
    [SerializeField] float reloadTime;
    [SerializeField] float timeBetweenShoots;
    [SerializeField] int magazineCap;
    [SerializeField] int bulletsForShoot;
    [SerializeField] bool automatic;
    [SerializeField] bool scope;
    [SerializeField] Mesh model;
    [SerializeField] Material material;
    [SerializeField] Vector3 weaponPosition;

    public float Damage { get => damage;}
    public float Range { get => range;}
    public float FireRate { get => fireRate;}
    public float Spread { get => spread;}
    public float ReloadTime { get => reloadTime;}
    public float TimeBetweenShoots { get => timeBetweenShoots;}
    public int MagazineCap { get => magazineCap;}
    public int BulletsForShoot { get => bulletsForShoot;}
    public bool Automatic { get => automatic;}
    public bool Scope { get => scope;}
    public Mesh Model { get => model;}
    public Material Material { get => material;}
    public Vector3 WeaponPosition { get => weaponPosition;}

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
