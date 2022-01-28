using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour
{
    AudioSource source ;
    [SerializeField]private AudioClip flipSound;
    [SerializeField]private AudioClip menu;
    [SerializeField] private GameObject back;
    [SerializeField] private Sprite image;
   [SerializeField] private Spawner spawner;
    public int _id;

    private void Start()
    {
        source = GetComponent<AudioSource>();
       /* source.clip = menu ;
        source.loop = true;
        source.Play();*/
    }

    public int id()
    {
        return _id;
    }

    public void SetCard(int id,Sprite image)
    {
        GetComponent<SpriteRenderer>().sprite = image;
        _id = id;
    }

    public void OnMouseDown()
    {
        if(back.activeSelf && spawner.canReveal())
        {
            back.SetActive(false);
            spawner.cardRevealed(this);
            source.PlayOneShot(flipSound,1.0f);
        }

    }

    public void Unreveal()
    {
        back.SetActive(true);
    }
}
