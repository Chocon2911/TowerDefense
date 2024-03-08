using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuyMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponent();
    }

    protected virtual void Reset()
    {
        this.ResetValue();
        this.LoadComponent();
    }

    protected virtual void LoadComponent()
    {
        // For Override
    }

    protected virtual void ResetValue()
    {
        // For Override
    }

    protected virtual void OnEnable()
    {
        // For Override
    }

    protected virtual void Start()
    {
        // For Override
    }

    protected virtual void Update()
    {
        // For Override
    }
    protected virtual void FixedUpdate()
    {
        // For Override
    }
}
