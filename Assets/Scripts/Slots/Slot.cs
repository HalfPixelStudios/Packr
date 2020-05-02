﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    public bool hideWhenHeld = false;
    public GameObject item;
    public Vector2 holdOffset;

    protected void Start() {

    }


    public void SetItem(GameObject item) {

        item.SetActive(!hideWhenHeld);

        this.item = item;
        item.transform.position = transform.position;
        item.transform.parent = transform;
        item.transform.localPosition = new Vector3(holdOffset.x, holdOffset.y, 0);

    }

    public GameObject RemoveItem() {
        GameObject removed = this.item;
        this.item = null;
        return removed;
    }

    public void DestroyItem() {
        GameObject destroy = RemoveItem();
        Destroy(destroy);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
