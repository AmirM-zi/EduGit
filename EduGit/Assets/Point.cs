using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Point : MonoBehaviour
{
    private void Start()
    {
        Vector3 pos = transform.position;
        transform.DOMove(new Vector3(pos.x, pos.y + 3, pos.z), 0.5f).SetLoops(-1, LoopType.Yoyo);
    }

    public void PointCatch()
    {
        Destroy(this.gameObject);
    }
}
