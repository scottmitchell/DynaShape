<img src="https://forum.dynamobim.com/uploads/dynamobim/original/3X/7/4/74bf86e06c2827782a60f4fa54ce1dbd8136fc2a.png" width = "900">

## How to build, package and install

#### Step 1: Clone source
Clone the source from GitHub and open in Visual Studio.

#### Step 2: Deal with reference files
After open the source in Visual Studio, you may notice that some reference dll files are missing. All of these can be found in the Dynamo Core main folder on your computer (e.g. *C:\Program Files\Dynamo\Dynamo Core\1.x*), except *MeshToolkit.dll*. To get this file you need to first install the MeshToolkit package using the Dynamo Package Manager, you can then find the *MeshToolkit.dll* typically at *%AppData%\Dynamo\Dynamo Core\1.x\packages\MeshToolkit\bin*

#### Step 3: Build
Build the visual studio solution to obtain the DynaShape package, which is located at */bin/DynaShapeLocalPackage/_DynaShape* (inside the Visual Studio solution folder)

***Very Important:*** Notice that there is an underscore character in the *"_DynaShape"* folder's name as shown above. This is to ensure that Dynamo will load the DynaShape package alphabetically AFTER the MeshToolkit package. Otherwise, DynaShape will NOT be loaded correctly.

If the build was done correctly, the content of the package folder should look like this:

<pre>
_DynaShape
├── pkg.json
└── DynaShape_ViewExtensionDefinition.xml
└── bin
    ├── DynaShape.dll
    ├── DynaShape.xml
    ├── DynaShapeUI.dll
    ├── DynaShapeUI.xml
    └── DynaShapeUI_DynamoCustomization.xml
    ├── DynaShapeZeroTouch.dll
    ├── DynaShapeZeroTouch.xml
    └── DynaShapeZeroTouch_DynamoCustomization.xml
</pre>

(Note: You will probably also see some *.pdb* files. These files are only for debugging and are NOT required for DynaShape to function correctly)

#### Step 4: Install the package into Dynamo
Open Dynamo and go to Main-Menu > Settings > Manage Node and Package Paths..., and add a path poiting the local package folder described in step 3.

#### Step 5: Extra one-time setup for mouse manipulation to work
If you use Dynamo 2.0 then this step is not neccesary thanks to the way Dynamo 2.0 handles ViewExtensionDefinition manifest file

For Dynamo 1.x, you will need to manually edit the *AssemblyPath* inside the *DynaShape_ViewExtensionDefinition.xml* file (provided with the Visual Studio solution) so that it points correctly to the *DynaShape.dll* file inside the DynaShape local package folder desribe in Step 3, and then place this xml into *C:\Program Files\Dynamo\Dynamo Core\1.3\viewExtensions*, and restart Dynamo Studio and/or Revit.

Once the package has been installed, you can start playing with these [Dynamo sample scripts](https://drive.google.com/drive/folders/0B8GXDbjowDN_ZHZ0ZWZaSWIwMzA?usp=sharing) to see how DynaShape works.


## Contact Info
* Email: longnguyen.connect@gmail.com
* Twitter: [@LongNguyenP](https://twitter.com/LongNguyenP?lang=en)
* LinkedIn: https://www.linkedin.com/in/longnguyenp/


## Acknowledgement
I would like to acknowledge the following people:
* [Ian Keough](https://twitter.com/ikeough?lang=en) and the [Dynamo](http://dynamobim.org/) development team, for the great visual programming tool.
* The [EPFL Computer Graphics Lab and Geometry Lab](http://lgg.epfl.ch/index.php), for developing the important [theoratical framework](http://lgg.epfl.ch/publications/2012/shapeup/paper.pdf), which DynaShape is based on. 
* [Daniel Piker](https://twitter.com/KangarooPhysics?lang=en), for playing a major role in popularizing physics and constraint-based digital form finding in the design community, mostly via his well-known plugin [KangarooPhysics](http://www.grasshopper3d.com/group/kangaroo.) for Grasshopper. The highly positive response that KangarooPhysics receives from the community has inspired me to start DynaShape in hope to make similar computational design tools available to the Dynamo and BIM community.
* Autodesk (particularly Phil Mueller and Matt Jezyk) for co-organizing and co-sponsoring AEC Hackathon Munich 2017, where DynaShape was born.