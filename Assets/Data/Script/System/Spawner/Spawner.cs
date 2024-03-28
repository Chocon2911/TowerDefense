using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : PrefabHolder
{
    //==========================================Spawn=================================================
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
    //========================================Other Func==============================================
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
