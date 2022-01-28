using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Memory originalCard;
    [SerializeField] private Sprite[] sprites;
    private Memory firstcard;
    private Memory secondcard;
    private const int numRows = 2;
    private const int numColumnss = 4;
    private const float offsetX = 5;
    private const float offsetY = 7;
    public TextMeshProUGUI scoreText;

    private int score ;
    [SerializeField]private GameObject introImage;
    [SerializeField]private TextMeshProUGUI IntroName;


    private IEnumerator Intro()
    {
        IntroName.text = "By NdunguThe";
        introImage.SetActive(true);
        yield return new WaitForSeconds(3);
        introImage.SetActive(false);
    }
    public bool canReveal()
    {
        return secondcard == null;
    }

    public void cardRevealed(Memory card)
    {
        if(firstcard == null)
        {
            firstcard = card;
        }
        else if(secondcard == null)
        {
            secondcard = card;
            StartCoroutine(CheckScore());
        }
        

    }

    private IEnumerator CheckScore()
    {
        if(firstcard._id == secondcard._id)
        {
            score += 2;
        }
        else
        {
            yield return new WaitForSeconds(3);
            firstcard.Unreveal();
            secondcard.Unreveal();
        }
        firstcard = null;
        secondcard = null;
        
    }

    void Start()
    {
        StartCoroutine(Intro());
        Vector3 startPos = originalCard.transform.position;

        int[] numbers ={0,0,1,1,2,2,3,3};
        numbers = KnuthShuffle(numbers);
        for(int i=0 ; i< numColumnss ;i++)
        {
            Memory card;
            for (int j=0 ;j<numRows ;j++)
            {
                if(i == 0 && j ==0)
                {
                card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as Memory;
                    card.transform.position = new Vector3(startPos.x + offsetX * i,startPos.y - offsetY * j,startPos.z);
                    
                }
                int id;
                int index = j * numColumnss + i;
                id = numbers[index];
                card.SetCard(id,sprites[id]);

            }
    
        }
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;
    }

     private int[] KnuthShuffle(int[] numbers)
    {    
        int[] newArray =  numbers.Clone() as int[];
        for (int i =0; i<newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i,newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;

        }
        return newArray;
    }
   
    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

}
