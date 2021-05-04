using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBody : MonoBehaviour
{
    [Header("Weapon part")]
    public List<GameObject> w_Barrel = new List<GameObject>();
    public List<GameObject> w_Stock = new List<GameObject>();
    public List<GameObject> w_Magazine = new List<GameObject>();
    public List<GameObject> w_Scope = new List<GameObject>();

    [Header("Part placement")]
    public Transform t_Barrel;
    public Transform t_Stock;
    public Transform t_Magazine;
    public Transform t_Scope;

    [Header("Add Part")]
    public bool add_Barrel;
    public bool add_Stock;
    public bool add_Magazine;
    public bool add_Scope;

    private void Start()
    {
        int barrel_To_Spawn = Random.Range(0, w_Barrel.Count);
        int stock_To_Spawn = Random.Range(0, w_Stock.Count);
        int magazine_To_Spawn = Random.Range(0, w_Magazine.Count);
        int scope_To_Spawn = Random.Range(0, w_Scope.Count);

        if (add_Barrel)
        {
            SpawnBarrel(barrel_To_Spawn);
        }
        if (add_Stock)
        {
            SpawnStock(stock_To_Spawn);
        }
        if (add_Magazine)
        {
            SpawnMagazine(magazine_To_Spawn);
        }
        if (add_Scope)
        {
            SpawnScope(scope_To_Spawn);
        }
    }

    void SpawnBarrel(int SB)
    {
        GameObject B = Instantiate(w_Barrel[SB], t_Barrel.position, t_Barrel.rotation);
        B.transform.parent = t_Barrel.transform;
        print(SB);
    }
    void SpawnStock(int SS)
    {
        GameObject S = Instantiate(w_Stock[SS], t_Stock.position, t_Stock.rotation);
        S.transform.parent = t_Stock.transform;
    }
    void SpawnMagazine(int SM)
    {
        GameObject M = Instantiate(w_Magazine[SM], t_Magazine.position, t_Magazine.rotation);
        M.transform.parent = t_Magazine.transform;

    }
    void SpawnScope(int SS)
    {
        GameObject S = Instantiate(w_Scope[SS], t_Scope.position, t_Scope.rotation);
        S.transform.parent = t_Scope.transform;

    }
}
