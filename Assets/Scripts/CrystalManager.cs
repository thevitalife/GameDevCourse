using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrystalManager : MonoBehaviour
{
    [SerializeField]
    private float targetCrystalValue;

    [SerializeField]
    private Portal portal;

    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    private Color notEnoughCrystalColor;

    [SerializeField]
    private Color enoughCrystalColor;

    [SerializeField]
    private Color allCrystalsCollectedColor;

    private float maxCrystals;

    private float currentCrystalValue;

    public static CrystalManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateText();
    }

    public void RegisterCrystal(float value)
    {
        maxCrystals += value;
        UpdateText();
    }

    public void AddValue(float value)
    {
        currentCrystalValue += value;
        UpdateText();
        CheckToOpenPortal();
    }

    public void UpdateText()
    {
        text.text = $"<color=#{ColorUtility.ToHtmlStringRGBA(GetCurrentCrystalColor(currentCrystalValue))}>{currentCrystalValue}</color> / {targetCrystalValue}";
    }

    public void CheckToOpenPortal()
    {
        if (currentCrystalValue >= targetCrystalValue)
        {
            portal.Activate();
        }
    }

    public Color GetCurrentCrystalColor(float currentValue)
    {
        if (currentValue < targetCrystalValue)
        {
            return notEnoughCrystalColor;
        }
        else if (currentValue < maxCrystals)
        {
            return enoughCrystalColor;
        }
        else
        {
            return allCrystalsCollectedColor;
        }
    }
}
