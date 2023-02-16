using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    [SerializeField] private float delaySeconds = 1.0f;
    [SerializeField] private GameObject blackScreenPanel;

    private void Start()
    {
        blackScreenPanel.SetActive(true);
    }
    public void LoadLevel(string sceneName)
    {
        // fade out animation is playing
        blackScreenPanel.GetComponent<Animator>().SetBool("Fade_Out", true);
        // new scene loaded after a delay
        StartCoroutine(DelayedLoadLevel(sceneName));
    }

    private IEnumerator DelayedLoadLevel(string sceneName)
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene(sceneName);
    }
}
