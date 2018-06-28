echo on
Set SolutionDir=%~1

rem ---------------------------------------------------------------------------------------------------------------------

echo COPYING: DynaShape.dll 

echo      TO: Dynamo Core
Copy "%SolutionDir%\bin\DynaShape.dll" "%AppData%\Dynamo\Dynamo Core\1.3\packages\_DynaShape\bin"
Copy "%SolutionDir%\bin\DynaShape.xml" "%AppData%\Dynamo\Dynamo Core\1.3\packages\_DynaShape\bin"
Copy "%SolutionDir%\bin\DynaShape.dll" "%AppData%\Dynamo\Dynamo Core\2.0\packages\_DynaShape\bin"
Copy "%SolutionDir%\bin\DynaShape.xml" "%AppData%\Dynamo\Dynamo Core\2.0\packages\_DynaShape\bin"

echo      TO: Dynamo Revit
Copy "%SolutionDir%\bin\DynaShape.dll" "%AppData%\Dynamo\Dynamo Revit\1.3\packages\_DynaShape\bin"
Copy "%SolutionDir%\bin\DynaShape.xml" "%AppData%\Dynamo\Dynamo Revit\1.3\packages\_DynaShape\bin"
Copy "%SolutionDir%\bin\DynaShape.dll" "%AppData%\Dynamo\Dynamo Revit\2.0\packages\_DynaShape\bin"
Copy "%SolutionDir%\bin\DynaShape.xml" "%AppData%\Dynamo\Dynamo Revit\2.0\packages\_DynaShape\bin"

echo      TO: Dynashape Installer
Copy "%SolutionDir%\bin\DynaShape.dll" "%SolutionDir%\..\DynaShapeInstaller_VS\DynaShapeSetup\Resources"
Copy "%SolutionDir%\bin\DynaShape.xml" "%SolutionDir%\..\DynaShapeInstaller_VS\DynaShapeSetup\Resources"

echo COPYING: DynaShapeUI.dll

echo      TO: Dynamo Core
Copy "%SolutionDir%\bin\DynaShapeUI.dll" "%AppData%\Dynamo\Dynamo Core\1.3\packages\_DynaShape\bin"
Copy "%SolutionDir%\bin\DynaShapeUI.xml" "%AppData%\Dynamo\Dynamo Core\1.3\packages\_DynaShape\bin"

rem ---------------------------------------------------------------------------------------------------------------------

echo COPYING: DynaShapeZeroTouch.dll

echo      TO: Dynamo Core
Copy "%SolutionDir%\bin)DynaShapeZeroTouch.dll" "%AppData%\Dynamo\Dynamo Core\1.3\packages\_DynaShape\bin"
Copy "%SolutionDir%\binDynaShapeZeroTouch.xml" "%AppData%\Dynamo\Dynamo Core\1.3\packages\_DynaShape\bin"

rem ---------------------------------------------------------------------------------------------------------------------

echo COPYING: Manifest Files

echo      TO: Dynamo Core
Copy "%SolutionDir%\ManifestFiles\pkg.json" "%SolutionDir%\..\DynaShapeInstaller_VS\DynaShapeSetup\Resources"
Copy "%SolutionDir%\ManifestFiles\DynaShapeUI_DynamoCustomization.xml" "%AppData%\Dynamo\Dynamo Core\1.3\packages\_DynaShape\bin"
Copy "%SolutionDir%\ManifestFiles\DynaShapeZeroTouch_DynamoCustomization.xml" "%AppData%\Dynamo\Dynamo Core\1.3\packages\_DynaShape\bin"

