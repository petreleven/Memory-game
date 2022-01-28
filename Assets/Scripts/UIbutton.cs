using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbutton : MonoBehaviour
{
    private SpriteRenderer startButton;
    [SerializeField]private string message;
    [SerializeField]private GameObject targetObject;
    void OnMouseEnter()
    {
        startButton = GetComponent<SpriteRenderer>();
        startButton.color = Color.cyan;
    }
    void OnMouseDown()
    {
        transform.localScale = new Vector3(2.4f,2.4f,24f);
    }
    
    void OnMouseUp()
    {
        transform.localScale = new Vector3(2,2,2);
        targetObject.SendMessage(message);
    }

    void OnMouseExit()
    {
        startButton = GetComponent<SpriteRenderer>();
        startButton.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
