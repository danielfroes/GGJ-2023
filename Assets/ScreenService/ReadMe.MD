

## How Create a Screen
 * A screen is defined as a prefab with a component that inherits from `AScreen`. In this script will be responsable to control the behaviour of the screen. We can still follow the MVP architecture, making the AScreen children being the view or the presenter.

 * After creating the prefab, we need to mark it as adressable, put it in the screens group and create a `ScreenData` scriptable object. To create follow the path Inca-3D/Screen Data in the Create Asset Menu.
Fill the adressable asset field with your screen reference and check if the type showed below matches the screen you created.

 * Now, search for the prefab Screen Manager and place the scriptable object you created in the screens list, to register the screen in the system. 

 ## How to use the Screen Manager

 * The Screen Manager currently is a singleton, so to access it you only need to use: `ScreenManager.Instance`

 * To open a screen, use the `Show` method, passing the type of the screen, just as the following: `ScreenManager.Instance.Show<TestScreen>();`