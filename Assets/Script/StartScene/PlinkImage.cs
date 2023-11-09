using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlinkImage : MonoBehaviour
{
    public Image image;
    public float speed;
    Color temp;
    private void Start()
    {

    }

    private void Update()
    {
        image.enabled = true;
        //  StartCoroutine(FadeTime());

        StartCoroutine(Fade(image, 1f));


    }


    /* IEnumerator FadeTime()
      {
          yield return new WaitForSeconds(2);
          FadeIn();
          yield return new WaitForSeconds(2);
          fadeOut();
      }
      void FadeIn()
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

              }

      }

      public void fadeOut()
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

          }
      }
     */

    IEnumerator Fade( Image image, float speed)
    {
        Color temp;
       
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
}
