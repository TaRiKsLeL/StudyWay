using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] Dropdown characterDropdown;
    [SerializeField] Toggle effectsToggle;
    [SerializeField] Text bokehText;
    [SerializeField] Text bokehValueText;
    [SerializeField] Slider bokehSlider;

    int characterId;
    bool effectsEnabled;
    float bokehValue;

    // Start is called before the first frame update
    void Start()
    {
        SetUpSingleton();
    }

    // Update is called once per frame
    void Update()
    {
        UIByToggle();

        if (bokehValueText)
        {
            bokehValueText.text = bokehSlider.value.ToString();
            characterId = characterDropdown.value;
            bokehValue = bokehSlider.value;
            effectsEnabled = effectsToggle.isOn;
        }

    }

    private void SetUpSingleton()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void UIByToggle()
    {
        if (bokehSlider)
        {
            if (effectsToggle.isOn)
            {
                bokehSlider.interactable = true;
                bokehSlider.enabled = true;
                bokehText.enabled = true;
                bokehValueText.enabled = true;
            }
            else
            {
                bokehSlider.interactable = false;
                bokehSlider.enabled = false;
                bokehText.enabled = false;
                bokehValueText.enabled = false;
            }
        }
    }

    public int GetCharacterId()
    {
        return characterId;
    }

    public float GetBokehValue()
    {
        return bokehValue;
    }

    public bool EffectsEnabled()
    {
        return effectsEnabled;
    }
}
