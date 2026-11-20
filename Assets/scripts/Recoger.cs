using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Recoger : MonoBehaviour
{

    private List<Item> Inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Inventory = new List<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToInventory(Item item)
    {
        Inventory.Add(item);
    }
}
