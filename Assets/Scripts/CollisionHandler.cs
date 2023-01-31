using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Well excuuuuuse me princess!");
                break;
            case "Finish":
                Debug.Log("YOU WON!!!");
                break;
            case "Fuel":
                Debug.Log("You picked up fule!");
                break;
            default:
                Debug.Log("YOU DIED!!!");
                break;
        }
    }
}
