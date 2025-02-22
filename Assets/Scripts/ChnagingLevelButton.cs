using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChnagingLevelButton : MonoBehaviour
{
    public Sprite pressedSprite; 
    public Sprite unpressedSprite;
    public SpriteRenderer spriteRenderer;

    public void NextLevelButton(){
        StartCoroutine(LoadNextLevel());
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

    void OnTriggerEnter2D(Collider2D collision)
    {   
        if(collision.gameObject.tag == "Player"){
            spriteRenderer.sprite = pressedSprite;
            NextLevelButton();
        }
    }
}
