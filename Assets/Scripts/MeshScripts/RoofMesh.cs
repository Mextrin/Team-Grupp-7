using UnityEngine;
using System.Collections;

public class RoofMesh : MonoBehaviour
{
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController playerScript = other.GetComponent<CharacterController>();
            playerScript.direction.y = 0;
            playerScript.moveEffects = true;
        }
    }
}
