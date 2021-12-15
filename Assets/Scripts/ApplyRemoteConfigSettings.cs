using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.RemoteConfig;
using UnityEngine.UI;

public class ApplyRemoteConfigSettings : MonoBehaviour
{
    public string language = "English";
    public float characterSize = 1.0f;
    public float characterSpeed = 1.0f;
    public int activeHat = 0;

    public GameObject StartButtonText;
    public GameObject StoreButtonText; 

    public struct userAttributes
    {
        // Optionally declare variables for any custom user attributes:
    }

    public struct appAttributes
    {
        // // Optionally declare variables for any custom app attributes:
        // public int level;
        // public string appVersion;
    }
    
    void Start()
    {
        // Fetch the Dashboard Remote Config from RemoteConfigManager    
        //RemoteConfigManagerScript.FetchConfigs();
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(){}, new appAttributes(){});

        // Optional Settings
        // Set the user’s unique ID:
        // ConfigManager.SetCustomUserID("some-user-id");

        // Set the environment ID: 
        // Defaults to Production, unless Development Build is Checked
        //ConfigManager.SetEnvironmentID("951304dd-2b96-421c-ace2-a944d56b2948");

        ConfigManager.FetchCompleted += RemoteConfigLoaded;
    }

    // Subscribed event function that provides information on what the ConfigResponse was
    private void RemoteConfigLoaded(ConfigResponse configResponse)
    {
        switch (configResponse.requestOrigin)
        {
            case ConfigOrigin.Default:
                Debug.Log("No settings loaded this session; using default values.");
                break;
            case ConfigOrigin.Cached:
                Debug.Log("No settings loaded this session; using cached values from a previous session.");
                break;
            case ConfigOrigin.Remote:
                Debug.Log("New settings loaded this session; update values accordingly.");

                // Fetch and set Remote Config value for Language
                language = ConfigManager.appConfig.GetString("Language");

                // Call the SetLocalization Function passing in the language string as a parameter
                SetLocalization(language);

                Debug.Log("Size " + (ConfigManager.appConfig.GetFloat("CharacterSize")));
                Debug.Log("Speed " + (ConfigManager.appConfig.GetFloat("CharacterSpeed")));
                break;
        }
    }

    // Can also use a Switch / Case check
    public void SetLocalization(string str)
    {
        if (str == "English")
        {
            StartButtonText.GetComponent<Text>().text = "Start";
            StoreButtonText.GetComponent<Text>().text = "Store";
            Debug.Log("English Localization Set!");
        }

        else if (str == "Spanish")
        {
            StartButtonText.GetComponent<Text>().text = "Comienzo";
            StoreButtonText.GetComponent<Text>().text = "Tienda";
            Debug.Log("Spanish Localization Set!");
        }
    }


}

