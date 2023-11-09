using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
   [SerializeField] public int numberofDeathEnemes;
    [SerializeField] private TextMeshProUGUI textNumperOfDeath;
    [SerializeField] GameObject WinningImage;
    [SerializeField] ParticleSystem WinningParticle;
    public bool winBool;
    // Start is called before the first frame update
    void Start()
    {
        WinningImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        textNumperOfDeath.text=numberofDeathEnemes.ToString();

        win();
    }

    void win()
    {
        if (numberofDeathEnemes == 5)
        {
            winBool = true;
            WinningImage.SetActive(true);
            WinningParticle.Play();
        }
    }
}
