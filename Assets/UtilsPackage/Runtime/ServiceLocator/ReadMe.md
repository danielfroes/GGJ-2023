# Service Locator 

- The service locator is a dependency system. With it, you can easily access services throughout the project, with zero performance cost.

## How to use

### Register
- You can register a service by calling the method Register and passing the instance you want to keep track of. 
```
ServiceLocator.Register(new MyService())
```
- !! Be careful to not register two services with the same type, because if will you do, the first one will be overwritten and you will only have access to the last one.

### Get Service
- To access the service, you only need to call the method Get, passing the Type of the service. 
```
ServiceLocator.Get<MyService>()
```

### Unregister
- To remove the service from the service locator use the method  Unregister, passing the Type you want to remove. 
```
ServiceLocator.Unregister<MyService>()
```
 
