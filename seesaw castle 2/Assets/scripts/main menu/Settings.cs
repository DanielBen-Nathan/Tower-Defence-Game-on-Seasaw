using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public bool settingsOn = true;


    public InputField left;
    public InputField right;
    public Slider volumeSlider;
    public Dropdown qualityDropDown;
    public Dropdown resolutionDropDown;
    public Toggle screenToggle;

    // public string path = "Assets/Resources/settings.txt";
    public string path;

    public AudioMixer audioMixer;
    private float volume;
    private Resolution[] resolutions;
    private int currentRes;
    private int quality;
    private bool fullscreen;
    private int res;



    // Use this for initialization
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            resolutionDropDown.gameObject.SetActive(false);
            screenToggle.gameObject.SetActive(false);
            Debug.Log("debug android plat");

        }

        path = Application.persistentDataPath + "/settings.txt";
        Debug.Log("debug path");
        if (!File.Exists(path))
        {
            UpdateFile();
            Debug.Log("debug path not exist");
        }
       
        volumeSlider.value = ReadFileVol();
        //Debug.Log("debug read vol " + ReadFileVol());

        
        int qual = ReadFileQual();
        QualitySettings.SetQualityLevel(qual);
        qualityDropDown.value = qual;
        if (Application.platform != RuntimePlatform.Android)
        {

            screenToggle.isOn = Screen.fullScreen;
            fullscreen = Screen.fullScreen;


            resolutions = Screen.resolutions;
            resolutionDropDown.ClearOptions();
            List<string> options = new List<string>();
            //ReadFileRes();
            currentRes = 0;
            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + "x" + resolutions[i].height;

                options.Add(option);
                if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
                {
                    //  Debug.Log(Screen.currentResolution);
                    currentRes = i;
                    res = i;
                }
                if (resolutions[i].width == resolutions[res].width && resolutions[i].height == resolutions[res].height)
                {

                }
            }
            resolutionDropDown.AddOptions(options);
            resolutionDropDown.value = currentRes;
            resolutionDropDown.RefreshShownValue();
        }
        Apply();

    }


    // Update is called once per frame
    void Update()
    {
        //if (settingsOn) {




        // }

    }
    public void SetVolume(float v)
    {
        // Debug.Log(v);
        volume = v;
        //audioMixer.SetFloat("volume", v);
        //UpdateFile();


    }
    public void SetQuality(int qualIndex)
    {

        quality = qualIndex;

        //QualitySettings.SetQualityLevel(qualIndex);
        //Debug.Log("set qiality to "+qualIndex);
        //quality = qualIndex;
        //UpdateFile();

    }
    public void SetFullScreen(bool isFullScreen)
    {
        fullscreen = isFullScreen;
        //Screen.fullScreen = isFullScreen;
        //UpdateFile();
    }


    public void SetRes(int resIndex)
    {
        res = resIndex;
        //Resolution res = resolutions[resIndex];
        //Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        //UpdateFile();

    }

    public void UpdateFile()
    {
        //Debug.Log("write"+quality);
        // SettingsFile settingsFile = GameObject.Find("levelDataObj").GetComponent<SettingsFile>();
        // settingsFile.WriteSettings();
        Debug.Log("debug write file");
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            //float value;
            //bool result = audioMixer.GetFloat("volume", out value);
            //if (result)
            //{
            //volumeSlider.value = value;
            // }


            writer.WriteLine(volume.ToString());

            writer.WriteLine(QualitySettings.GetQualityLevel());


            if (Application.platform != RuntimePlatform.Android)
            {
                writer.WriteLine(currentRes.ToString());
                writer.WriteLine(Screen.fullScreen.ToString());
                writer.Close();
            }

        }



        //Debug.Log("updated settings file"+quality);




    }
    public float ReadFileVol()
    {
        Debug.Log("debug reading vol");
        StreamReader reader = new StreamReader(path);
        float volumeRead = float.Parse(reader.ReadLine());
        //volume = volumeRead;
        reader.Close();
        volume = volumeRead;

        return volumeRead;


    }

    public int ReadFileQual()
    {
        StreamReader reader = new StreamReader(path);
        reader.ReadLine();
        int qualRead = int.Parse(reader.ReadLine());
        //Debug.Log(qualRead);
        reader.Close();
        //QualitySettings.SetQualityLevel(qualRead);
        quality = qualRead;
        return qualRead;


    }


    public int ReadFileRes()
    {
        StreamReader reader = new StreamReader(path);
        reader.ReadLine();
        reader.ReadLine();
        int resRead = int.Parse(reader.ReadLine());
        //Debug.Log(resRead);
        reader.Close();

        res = resRead;
        return resRead;


    }


    public bool ReadFileScreen()
    {
        StreamReader reader = new StreamReader(path);
        reader.ReadLine();
        reader.ReadLine();
        reader.ReadLine();
        fullscreen = bool.Parse(reader.ReadLine());

        reader.Close();


        return fullscreen;


    }
    public void Apply()
    {
        Debug.Log("debug apply");

        audioMixer.SetFloat("volume", volume);
        QualitySettings.SetQualityLevel(quality);

        if (Application.platform != RuntimePlatform.Android)
        {
            resolutions = Screen.resolutions;
            Resolution res2 = resolutions[res];

            //Screen.fullScreen = fullscreen;


            Screen.SetResolution(res2.width, res2.height, fullscreen);

        }
        UpdateFile();


    }
    public void Back()
    {
        Start();


    }




}
