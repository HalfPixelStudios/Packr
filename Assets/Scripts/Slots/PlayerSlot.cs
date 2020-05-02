﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlot : Slot {

    public float pickup_radius;

    List<Slot> inRange = new List<Slot>();



    private void Start() {
        //override superclass
        CircleCollider2D col = gameObject.AddComponent<CircleCollider2D>();
        col.isTrigger = true;
        col.radius = pickup_radius;

    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.E)) {
            Slot closest = null;
            float closestDist = float.PositiveInfinity;
            foreach (var slot in inRange) {

                var dist = Vector3.Distance(slot.transform.position, transform.position);
                if (dist < closestDist) {
                    closestDist = dist;
                    closest = slot;
                }

            }

            if (closest) {
                if (this.item == null && closest.item != null) { //take item from slot

                    GameObject newItem = closest.RemoveItem();
                    SetItem(newItem);


                } else if (this.item != null) { //otherwise put item into slot

                    
                    if (closest.item == null) {
                        GameObject newItem = RemoveItem();
                        closest.SetItem(newItem);

                    } else { //attempt to craft item PROB MOVE THIS CODE TO TABLE SCRIPT OR SM

                        ItemInfo item1 = closest.item.GetComponent<Item>().info;
                        ItemInfo item2 = this.item.GetComponent<Item>().info;
                        ItemInfo crafted = CraftingRecipes.Craft(item1,item2);

                        if (crafted) { //create new item and place in slot
                            DestroyItem();
                            closest.DestroyItem();
                            
                            GameObject newItem = Item.CreateItem(crafted);
                            closest.SetItem(newItem);
                        }

                    }

                }
            }

        }
        inRange.Clear();

    }


    private void OnTriggerStay2D(Collider2D other) {

        Slot slot = other.GetComponent<Slot>();
        if (slot != null) { //if the other thing actually has the slot compenet
            inRange.Add(slot);
        }
    }
}
