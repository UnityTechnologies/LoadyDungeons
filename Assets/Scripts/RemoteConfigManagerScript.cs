using UnityEngine;
using UnityEngine.Events;
using Unity.RemoteConfig;

public static class RemoteConfigManagerScript
{
    private struct userAttributes
    {
        //Put user attributes here
    }

    //Same goes for app attributes
    private struct appAttributes
    {
        //Put app attributes here
    }

    static private userAttributes userAttributesConfig = new userAttributes(){};
    static private appAttributes appAttributesConfig = new appAttributes(){};
    static public UnityEvent RefreshSettings = new UnityEvent();

    static void RemoteConfigManager()
    {
        ConfigManager.FetchCompleted += ProcessRemoteSettings;
    }

    static void ProcessRemoteSettings(ConfigResponse configResponse)
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
                Debug.Log("New Settings loaded!");
                RefreshSettings.Invoke();
                break;
        }
    }

    public static void FetchConfigs()
    {
        ConfigManager.FetchConfigs(userAttributesConfig, appAttributesConfig);
    }
}
