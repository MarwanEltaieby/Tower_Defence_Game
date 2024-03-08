using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] Tower tower;
    public bool IsPlaceable {get {return isPlaceable;}}
    //OR
    // public bool GetIsPlaceable() {return isPlaceable;}
    private void OnMouseDown() {
        if (isPlaceable) {
            bool isPlaced = tower.CreateTower(tower, transform.position);
            //Instantiate(ballista, transform.position, Quaternion.identity);
            isPlaceable = !isPlaced;
        }
    }
}
