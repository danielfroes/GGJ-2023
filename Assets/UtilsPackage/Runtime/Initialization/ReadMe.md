# Initialization System

- It is the system responsable to setup the systems and initialize the services in the project.

## How to use

- First thing you need to create a class that inherits from IInitializationStep. In the Run method, make the behaviour you want to do in the initialization process.

- Now find the prefab Initialization Manager. In that, find the component InitializationManager and add to the list a new entry and choose the class you created.

- The behaviour will run in order. If your 
step depends in the initialization of another one, just place it after that InitializationStep