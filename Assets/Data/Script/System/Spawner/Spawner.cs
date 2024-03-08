using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : HuyMonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected Transform prefab;
    [SerializeField] protected List<Transform> holders;
    [SerializeField] protected List<Transform> prefabs;
    public Transform Holder => holder;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHolder();
        this.LoadPrefab();
        this.LoadHolders();
        this.LoadPrefabs();
    }

    //======================================Load Component=========================================
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder", transform.gameObject);
    }

    protected virtual void LoadHolders()
    {
        if (this.holders.Count > 0) return;
        Transform holderTrans = transform.Find("Holder");
        foreach(Transform obj in holderTrans) this.holders.Add(obj);
        Debug.Log(transform.name + ": LoadHolderList", transform.gameObject);
    }

    protected virtual void LoadPrefab()
    {
        if (this.prefab != null) return;
        this.prefab = transform.Find("Prefab").GetComponent<Transform>();
        Debug.Log(transform.name + ": LoadPrefab", transform.gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (this.prefabs.Count > 0) return;
        Transform prefabTrans = transform.Find("Prefab");
        foreach(Transform obj in prefabTrans) this.prefabs.Add(obj);
        Debug.Log(transform.name + ": LoadPrefabList", transform.gameObject);
    }

    //==========================================Spawn==============================================
    public virtual Transform Spawn(string name, Vector2 pos, Quaternion rot)
    {
        Transform prefab = this.GetPrefabByName(name);
        Transform newPrefab = this.GetObjFromPool(prefab);
        newPrefab.SetPositionAndRotation(pos, rot);
        newPrefab.parent = this.holder;
        return newPrefab;
    }

    public virtual void DespawnObj(Transform prefab)
    {
        if (prefab.parent != this.holder) Debug.LogError(transform.name + ": Wrong holder", transform.gameObject);
        this.holders.Add(prefab);
        prefab.gameObject.SetActive(false);
    }
    //========================================Other Func===========================================
    protected virtual Transform GetPrefabByName(string name)
    {
        foreach(Transform obj in this.prefabs)
        {
            if (obj.name == name) return obj;
        }
        return null;
    }

    protected virtual Transform GetObjFromPool(Transform prefab)
    {
        if (prefab == null) return null;
        if (this.holders.Count > 0) return this.holders[0];
        return Instantiate(prefab);
    }
}
