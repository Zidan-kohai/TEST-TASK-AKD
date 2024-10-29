using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ServiseInstaller", menuName = "Installers/ServiseInstaller")]
public class ServiseInstaller : ScriptableObjectInstaller<ServiseInstaller>
{
    public override void InstallBindings()
    {
    }
}