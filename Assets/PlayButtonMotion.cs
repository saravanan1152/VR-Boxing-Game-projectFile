using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class PlayButtonMotion : MonoBehaviour
{
    public Image image;
    private AudioSource audioSource;
   
    // Start is called before the first frame update
    void Start()
    {
       audioSource = GetComponent<AudioSource>();
        image=GameObject.FindGameObjectWithTag("FadeIn").GetComponent<Image>();

        audioSource.PlayOneShot(audioSource.clip);
        StartCoroutine(Timeing());

    
    }

     
 
    public IEnumerator Timeing()
    {
      
        yield return new WaitForSeconds(0.02f);

        StartCoroutine(Fade(true,image,0.2f));

    }
     IEnumerator Fade(bool fadeIn, Image image, float speed)
    {
        Color temp;
        if (fadeIn)
        {
            temp = image.color;
            temp.a = 0;
            image.color = temp;
            while (image.color.a != 1f)
            {
                temp = image.color;
                temp.a += Time.deltaTime * speed;
                temp.a = Mathf.Clamp(temp.a, 0f, 1f);
                image.color = temp;
                yield return null;
            }
        }
        else
        {
            temp = image.color;
            temp.a = 1;
            image.color = temp;
            while (image.color.a != 0f)
            {
                temp = image.color;
                temp.a -= Time.deltaTime * speed;
                temp.a = Mathf.Clamp(temp.a, 0f, 1f);
                image.color = temp;
                yield return null;
            }
        }
        SceneManager.LoadScene("Game");


    }

    IEnumerator load()
    {
        yield return new WaitForSeconds(0.5f);
        
    }

}
