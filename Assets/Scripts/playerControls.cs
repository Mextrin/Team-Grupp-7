using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
    public bool right, left, up;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            left = true;
        else if (Input.GetKeyUp(KeyCode.A))
            left = false;

        if (Input.GetKeyDown(KeyCode.D))
            right = true;
        else if (Input.GetKeyUp(KeyCode.D))
            right = false;

        if (Input.GetKeyDown(KeyCode.W))
            up = true;
        else if (Input.GetKeyUp(KeyCode.W))
            up = false;
    }
}
