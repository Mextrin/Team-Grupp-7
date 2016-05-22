using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonPressUI : MonoBehaviour
{
    public void OnButtonPress(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
