using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ResItem
{
    public int width, height;
}
[System.Serializable]
public class LevelItem
{
    public string item;
}

public class OptionMenu : MonoBehaviour
{
    public Toggle fullScreenTog, vsyncTog;
    public List<ResItem> resolutions = new List<ResItem>();
    public List<LevelItem> levels = new List<LevelItem>();
    public TMP_Text textRes;
    public TMP_Text textLevel;

    private int _selectedRes = 0;
    public static int SelectedLevel = 0;
    // Start is called before the first frame update
    private void Start()
    {
        fullScreenTog.isOn = Screen.fullScreen;
        if (Application.platform == RuntimePlatform.WebGLPlayer)
        {
            vsyncTog.isOn = false;
            Application.targetFrameRate = -1;
        }else vsyncTog.isOn = QualitySettings.vSyncCount != 0;

        var foundRes = false;
        for (int i = 0; i < resolutions.Count; ++i)
        {
            if (Screen.width != resolutions[_selectedRes].width ||
                Screen.height != resolutions[_selectedRes].height) continue;
            foundRes = true;
            _selectedRes = i;
            UpdateResText();
        }

        if (foundRes) return;
        ResItem newRes = new()
        {
            width = Screen.width,
            height = Screen.height
        };

        resolutions.Add(newRes);
        _selectedRes = resolutions.Count - 1;

        UpdateResText();
    }
    public void ResLeft()
    {
        _selectedRes--;
        if (_selectedRes < 0)
        {
            _selectedRes = resolutions.Count - 1;
        }
        UpdateResText();
    }
    public void ResRight()
    {
        _selectedRes++;
        if (_selectedRes >= resolutions.Count)
        {
            _selectedRes = 0;
        }
        UpdateResText();
    }

    public void UpdateResText()
    {
        textRes.text = resolutions[_selectedRes].width + " x " + resolutions[_selectedRes].height;
    }
    public void LevelLeft()
    {
        SelectedLevel--;
        if (SelectedLevel < 0)
        {
            SelectedLevel = levels.Count - 1;
        }
        UpdateLevelText();
    }
    public void LevelRight()
    {
        SelectedLevel++;
        if (SelectedLevel >= levels.Count)
        {
            SelectedLevel = 0;
        }
        UpdateLevelText();
    }

    public void UpdateLevelText()
    {
        textLevel.text = levels[SelectedLevel].item;
    }
    public void ApplyGraphics()
    {
        // Screen.fullScreen = fullScreenTog.isOn;

        QualitySettings.vSyncCount = vsyncTog.isOn ? 1 : 0;

        Screen.SetResolution(resolutions[_selectedRes].width, resolutions[_selectedRes].height, fullScreenTog.isOn);
    }

}
