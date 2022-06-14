![LD](https://user-images.githubusercontent.com/263776/110165036-dde21300-7db7-11eb-8f49-e7745ed44b35.png)

# Loady Dungeons
Loady Dungeons is a **demo game** intended to onboard users into using the [Addressable Assets](https://docs.unity3d.com/Packages/com.unity.addressables@0.3/manual/index.html) package and the Unity [Cloud Content Delivery](https://unity.com/products/cloud-content-delivery) service. Although there is a lot of room for code and asset optimizations, the demo is designed to demonstrate the uses of the Addressables and CCD tools. 

In addition, there is also a Remote Config integration for users to understand how to implement Remote Config and how to integrate it with an existing CCD and Addressables project.

:computer: If you are following the video tutorial, you can download the starting project [here](https://github.com/UnityTechnologies/LoadyDungeons/releases/tag/ws0.4.0).

### Gameplay
The gameplay is simple: you control _Dino_ on her quest to discover all the dungeons in the world. Touch anywhere on the floor of the map, and she will move to that spot. Find the chest, get the key and open the door to go to the next level.

### Prerequisites
* Unity Version: 2021.3.2f1 (LTS) 
* Authentication: 2.0.0
* Addressables Package: 1.19.19
* Cloud Content Delivery Management: 2.0.4
* Remote Config Version: 3.0.0-pre.29

# Services Overview
**Authentication** :
>Authentication allows the user to log-in securely as a single sign-on across platforms. This allows developers to allocate and associate data with that account which is important for Cloud Content Delivery and Remote Config services to function correctly.

**Cloud Content Delivery** :
>Loady Dungeons utilizes the benefits of Cloud Content Delivery to manage and offload data to the Cloud and dynamically retrieve it when the player needs it. This ensures that developers can continue to build, update, edit and deploy game content updates with minimal hassle and supported by a world-class Content Delivery Network

**Remote Config** :
>By integrating Remote Config, developers are able to deploy a change to their game immediately without the need for patching or downloading. In Loady Dungeons, the Remote Config dashboard and relevant scripts allows you to change which hats are available, if any seasonal levels should be displayed, and even if the localization language should be different! 

:construction: We are still working on the project, if you have any suggestions or would like to contribute please let us know.

![AllLevels](https://user-images.githubusercontent.com/263776/110165940-42ea3880-7db9-11eb-871c-13e4933e2540.png)

### Asset Bundle Architecture
The project uses a simple approach for managing the bundles with the assets. Each **gameplay scene** is bundled in a separate group (Level_00, Level_01, Level_02 and Level_03). Level_01 is bundled with the game, so it uses the LocalBuildPath and LocalLoadPath. The other levels and the Hats group(containing prefabs as Addressable assets) are bundled separate (and downloaded from the cloud), they use the RemoteBuilPath and RemoteLoadPath.

![Asset Architecture](https://user-images.githubusercontent.com/263776/110168293-9611ba80-7dbc-11eb-9945-417a16c3386d.jpg)

### Additional Resources
* If you’d like to learn more about this demo, and how to use Cloud Content Delivery, [click here](https://www.youtube.com/watch?v=J9XbISBpfp0). 
* If you’d like to watch the full Technical Workshop for Cloud Content Delivery, [click here](https://www.youtube.com/watch?v=5IvPPI7YnwU). 
* To learn more about the Remote Config branch, [click here](https://www.youtube.com/watch?v=RL3-VY8runI). 
* If you want to learn more about how to optimize the usage of Addressables, read [this post](https://blog.unity.com/technology/tales-from-the-optimization-trenches-saving-memory-with-addressables) by Patrick DeVarney. 
