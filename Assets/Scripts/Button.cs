using UnityEngine;

public class Button : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject parent;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Press(){
        spriteRenderer.color = Color.red;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        parent.transform.GetChild(0).gameObject.SetActive(true);
    }
}
