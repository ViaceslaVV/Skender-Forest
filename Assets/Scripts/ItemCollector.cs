using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public TextMeshProUGUI countText;
    private int count = 0;
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Item"))
        {
            countText.text = $"Bottles collected: {++count}";
            Destroy(other.gameObject);
        }
    }
}
