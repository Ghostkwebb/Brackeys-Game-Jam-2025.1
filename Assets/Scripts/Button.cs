using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
}
