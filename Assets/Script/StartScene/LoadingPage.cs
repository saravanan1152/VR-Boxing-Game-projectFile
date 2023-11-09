using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadingPage : MonoBehaviour
{
    public Image image;
    private void Start()
    {
        image.enabled = true;
        StartCoroutine(Fade(false,image,0.2f));
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
    }
}
