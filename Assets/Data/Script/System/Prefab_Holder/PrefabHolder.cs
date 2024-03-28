using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabHolder : HuyMonoBehaviour
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected Transform prefab;
    [SerializeField] protected List<Transform> holders;
    [SerializeField] protected List<Transform> prefabs;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadHolder();
        this.LoadPrefab();
        this.LoadHolders();
        this.LoadPrefabs();
    }

    //======================================Load Component============================================
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
        foreach (Transform obj in holderTrans) this.holders.Add(obj);
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
        foreach (Transform obj in prefabTrans) this.prefabs.Add(obj);
        Debug.Log(transform.name + ": LoadPrefabList", transform.gameObject);
        this.HidePrefab();
    }

    //==========================================Other=================================================
    protected virtual void HidePrefab()
    {
        foreach (Transform obj in this.prefabs)
        {
            obj.gameObject.SetActive(false);
        }
        Debug.Log(transform.name + ": HidePrefab", transform.gameObject);
    }
}
