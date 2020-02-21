using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public int value;
    public int maxValue;
    public bool destroyOnEmpty;
    
    public void Harvest(int _amount) {
        value -= _amount;

        if(destroyOnEmpty && value == 0) {
            Destroy(this.gameObject);
        }
    }
     
}
