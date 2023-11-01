using System;
using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInputHandler();
    }  
    
    public void BindInputHandler()
        => Container.BindInterfacesAndSelfTo<InputHandler>().AsSingle().NonLazy();
}
