using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour   
{
    [SerializeField]
    private TMP_Text text;
    private float value;
    public static Wallet Instance { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        value = PlayerPrefs.GetFloat("Wallet", 0);
        text.text = value.ToString();
    }

    public void AddValue(float newValue)
    {
        value += newValue;
        Debug.Log(value);
        text.text = value.ToString();
        PlayerPrefs.SetFloat("Wallet", value);
    }

}
