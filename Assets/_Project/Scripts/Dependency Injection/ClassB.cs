using UnityEngine;

namespace DependencyInjection
{
    public class ClassB : MonoBehaviour
    {
        [Inject]
        ServiceA serviceA;
        
        FactoryA factoryA;
        
        [Inject]
        public void Init(FactoryA factoryA)
        {
            this.factoryA = factoryA;
        }
    }
}