using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCounter : MonoBehaviour
{
     [Range(1f,2f)]
    public int player=1;
    
     private void OnCollisionEnter2D(Collision2D other) {
         Debug.Log(player);
        GameManager.Instance.ChangePoints(player);
    }
}
