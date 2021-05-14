![LD](https://user-images.githubusercontent.com/263776/110165036-dde21300-7db7-11eb-8f49-e7745ed44b35.png)

# Loady Dungeons

Loady Dungeons is a **demo game** intended to onboard users into using the [Addressable Assets](https://docs.unity3d.com/Packages/com.unity.addressables@0.3/manual/index.html) package and the Unity [Cloud Content Delivery](https://unity.com/products/cloud-content-delivery) service. Although there is a lot of room for code and asset optimizations, the demo is designed to demonstrate the uses of the Addressables and CCD tools. 

If you are following the video tutorial, you can download the starting project [here](https://github.com/UnityTechnologies/LoadyDungeons/releases/tag/ws0.4.0).

### Gameplay
The gameplay is simple: you control _Dino_ on her quest to discover all the dungeons in the world. Touch anywhere on the floor of the map, and she will move to that spot. Find the chest, get the key and open the door to go to the next level.

### Prerequisites
* Unity Version: 2020.3 LTS
* Addressables Package: 1.16.16

![AllLevels](https://user-images.githubusercontent.com/263776/110165940-42ea3880-7db9-11eb-871c-13e4933e2540.png)

### Asset Bundle Architecture
The project uses a simple approach for managing the bundles with the assets. Each **gameplay scene** is bundled in a separate group (Level_00, Level_01, Level_02 and Level_03). Level_01 is bundled with the game, so it uses the LocalBuildPath and LocalLoadPath. The other levels and the Hats group(containing prefabs as Addressable assets) are bundled separate (and downloaded from the cloud), they use the RemoteBuilPath and RemoteLoadPath.

![Asset Architecture](https://user-images.githubusercontent.com/263776/110168293-9611ba80-7dbc-11eb-9945-417a16c3386d.jpg)

### More Resources
* If you’d like to learn more about this demo, and how to use Cloud Content Delivery, [click here](https://www.youtube.com/watch?v=zadjp30LTMs). 
* If you’d like to watch the full Technical Workshop for Cloud Content Delivery, [click here](https://create.unity3d.com/CCD-technical-workshop?utm_source=demand-gen&utm_medium=video&utm_campaign=asset-links-operate-gms&utm_content=build-vs-buy-ccd-webinar). 
