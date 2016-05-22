using UnityEngine;
using System.Collections;

public class JumpMesh : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController playerScript = other.GetComponent<CharacterController>();
            playerScript.isGrounded = true;
            playerScript.moveEffects = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController playerScript = other.GetComponent<CharacterController>();
            playerScript.isGrounded = false;
        }
    }
}
