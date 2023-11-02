using System;
using UnityEngine;
using Zenject;
using Lesson4.HW1;

public class GlobalInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindInputHandler();
    }  
    
    public void BindInputHandler()
        => Container.BindInterfacesAndSelfTo<InputHandler>().AsSingle().NonLazy();
}
