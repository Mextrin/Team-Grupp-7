using UnityEngine;
using System.Collections;

public class AIControls : MonoBehaviour
{
    public bool left, right, jump;
    Transform character;

    // Use this for initialization
    void Start()
    {
        character = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
