using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject parent;
    public GameObject Canvas;
    public CanvasGroup canvasGroup;

    public float fadeDuration = 1.0f;
    bool couroutineCompleted = false;


    void Start()
    {
        canvasGroup.alpha = 0;
    }

    void Update()
    {
        
    }

    public void Press(){
        spriteRenderer.color = Color.red;
        StartCoroutine(LoadNextLevel());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(FadeInCanvas());
        couroutineCompleted = true;
    }

    private IEnumerator FadeInCanvas()
    {
        if(couroutineCompleted){
            yield break;
        }
        float elapsedTime = 0.0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            yield return null;
        }
    }

    private IEnumerator LoadNextLevel(){
        yield return new WaitForSecondsRealtime(2);
        int currentSeceneIndex =  SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSeceneIndex + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings){
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
