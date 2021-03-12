![LD](https://user-images.githubusercontent.com/263776/110165036-dde21300-7db7-11eb-8f49-e7745ed44b35.png)

Loady Dungeons is a **demo** intended to onboard users into using the [Addressable Assets](https://docs.unity3d.com/Packages/com.unity.addressables@0.3/manual/index.html) package and the Unity [Cloud Content Delivery](https://unity.com/products/cloud-content-delivery) service.

There's a lot of room for code and asset optimizations, however we went with what we thought it was clearer. 

If you want the latest version of the project, you can download it from [here](https://github.com/UnityTechnologies/LoadyDungeons/releases/tag/ws0.4.0).

### Gameplay
The gameplay is pretty simple, you control _Dino_ on her quest to discover all the dungeons in the world. Touch anywhere on the floor and she will move there. Find the chest, get the key and open the door to go to the next level. 

### Prerequisites
* Unity Version: 2020.3 LTS
* Addressables Package: 1.16.16

### More Resources
* If you want to watch the step by step guide, go to our video: [LINK TO VIDEO]()
* For a written guide on how to get started with Cloud Content Delivery, visit the following link [LINK TO GUIDE]()

![AllLevels](https://user-images.githubusercontent.com/263776/110165940-42ea3880-7db9-11eb-871c-13e4933e2540.png)

### Asset Bundle Architecture
The project uses a simple approach for managing the bundles with the assets. Each **gameplay scene** is bundled in a separate group (Level_00, Level_01, Level_02 and Level_03). Level_01 is bundled with the game, so it uses the LocalBuildPath and LocalLoadPath. The other levels and the Hats group(containing prefabs as Addressable assets) are bundled separate (and downloaded from the cloud), they use the RemoteBuilPath and RemoteLoadPath.

![Asset Architecture](https://user-images.githubusercontent.com/263776/110168293-9611ba80-7dbc-11eb-9945-417a16c3386d.jpg)
