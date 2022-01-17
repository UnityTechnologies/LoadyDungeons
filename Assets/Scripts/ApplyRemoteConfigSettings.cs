using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.RemoteConfig;
using Unity.Services.Core;
using Unity.Services.Authentication;

using System.Threading.Tasks;

using UnityEngine.UI;

// This script handles the set-up and fetching of the Remote Configuration settings
public class ApplyRemoteConfigSettings : MonoBehaviour
{
    public static ApplyRemoteConfigSettings Instance {get; private set;}
  
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
    
    async Task InitializeRemoteConfigAsync()
    {
        // initialize handlers for unity game services
        await UnityServices.InitializeAsync();

        // remote config requires authentication for managing environment information
        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
    }
    
    void Awake()
    {
        if (Instance == null) 
        {
            Instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    async void Start()
    {
        await InitializeRemoteConfigAsync();

        // Fetch the Dashboard Remote Config from RemoteConfigManager    
        //RemoteConfigManagerScript.FetchConfigs();
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(){}, new appAttributes(){});

        // Optional Settings
        // Set the user’s unique ID:
        // ConfigManager.SetCustomUserID("some-user-id");

        // Set the environment ID: 
        // Defaults to Production, unless Development Build is Checked
        ConfigManager.SetEnvironmentID("951304dd-2b96-421c-ace2-a944d56b2948");

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
                if(StartButtonText != null)
                {
                    SetLocalization(language);
                }

                activeHat = ConfigManager.appConfig.GetInt("ActiveHat");

                Debug.Log("RC Size " + (ConfigManager.appConfig.GetFloat("CharacterSize")));

                characterSize = ConfigManager.appConfig.GetFloat("CharacterSize");
                
                Debug.Log("RC Speed " + (ConfigManager.appConfig.GetFloat("CharacterSpeed")));

                characterSpeed = ConfigManager.appConfig.GetFloat("CharacterSpeed");

                Debug.Log("RC Active Hat " + (ConfigManager.appConfig.GetInt("ActiveHat")));
                break;
        }
    }

    // Public function for access outside of the class
    public void FetchConfigs()
    {
        ConfigManager.FetchConfigs<userAttributes, appAttributes>(new userAttributes(){}, new appAttributes(){});

        ConfigManager.FetchCompleted += RemoteConfigLoaded;

        //activeHat = ConfigManager.appConfig.GetInt("ActiveHat");

        Debug.Log("RC Size " + (ConfigManager.appConfig.GetFloat("CharacterSize")));

        //characterSize = ConfigManager.appConfig.GetFloat("CharacterSize");

        Debug.Log("RC Speed " + (ConfigManager.appConfig.GetFloat("CharacterSpeed")));

        //characterSpeed = ConfigManager.appConfig.GetFloat("CharacterSpeed");

        Debug.Log("RC Active Hat " + (ConfigManager.appConfig.GetInt("ActiveHat")));
        Debug.Log("Local Active Hat " + activeHat);
    }

    // Can also use a Switch / Case check, as well as a Scriptable Object to hold the variable for the new language for more areas of the game to 
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

        else if (str == "French")
        {
            StartButtonText.GetComponent<Text>().text = "Bienvennue";
            StoreButtonText.GetComponent<Text>().text = "Depanneur";
            Debug.Log("French Localization Set!");
        }

        else if (str == "German")
        {
            StartButtonText.GetComponent<Text>().text = "Abspielen";
            StoreButtonText.GetComponent<Text>().text = "Einkaufen";
            Debug.Log("German Localization Set!");
        }
    }
}

