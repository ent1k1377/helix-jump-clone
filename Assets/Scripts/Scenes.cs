using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using IJunior.TypedScenes;
using TMPro;
using UnityEngine.UI;

public class Scenes : MonoBehaviour
{
    [SerializeField] private Slider numberLevels;
    [SerializeField] private TextMeshProUGUI numberLevelsText;

    private void Start()
    {
        ChangeValue();
    }
    public void OnPlayButtonClick()
    {
        Main_GamePlay.Load((int)numberLevels.value);
    }
    public void ChangeValue()
    {
        numberLevelsText.text = numberLevels.value.ToString();
    }
    public void Quit()
    {
        Application.Quit();
    }
    
}
