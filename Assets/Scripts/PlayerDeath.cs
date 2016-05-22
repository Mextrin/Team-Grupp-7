using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Assertions;
using System.Collections.Generic;

public class PlayerDeath : MonoBehaviour
{
    public Gradient fading;

    public GameObject player;
    public GameObject deathCanvas, whilePlayingCanvas;

    public List<GameObject> deathUIElements = new List<GameObject>();
    public List<GameObject> playerUIElements = new List<GameObject>();

    public float fadeIn, fadeOut;
    public bool simultaneousFade;

    float playerDeathTime;
    bool playerDeathRegistered;

    // Use this for initialization
    void Start()
    {
        deathCanvas = GameObject.Find("DeathUI");
        whilePlayingCanvas = GameObject.Find("PlayerUI");

        foreach (Transform child in deathCanvas.transform)
        {
            deathUIElements.Add(child.gameObject);
            child.gameObject.SetActive(false);
        }

        foreach (Transform child in whilePlayingCanvas.transform)
        {
            playerUIElements.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");

        if (player == null)
        {
            if (!playerDeathRegistered)
            {
                playerDeathRegistered = !playerDeathRegistered;
                playerDeathTime = Time.time;
            }

            for (int i = 0; i < playerUIElements.Count; i++)
            {
                playerUIElements[i].GetComponent<Image>().color = fading.Evaluate(Mathf.Clamp(fadeOut - (Time.time - playerDeathTime), 0, fadeOut) / fadeOut);
            }
            
            for (int i = 0; i < deathUIElements.Count; i++)
            {
                deathUIElements[i].SetActive(true);
                deathUIElements[i].GetComponent<Image>().color = fading.Evaluate(Mathf.Clamp(Time.time - playerDeathTime, 0, fadeIn) / fadeIn);
            }
        }
    }
}
