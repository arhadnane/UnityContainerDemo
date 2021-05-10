using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;

namespace UnityContainerDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            IUnityContainer container = new UnityContainer();
            //or
            //var container = new UnityContainer();

            container.RegisterType<ICar, BMW>();
            Driver drv = container.Resolve<Driver>();
            drv.RunCar();

            container.RegisterType<ICar, Audi>("LuxuryCar");

            container.RegisterType<ICar, BMW>();
            ICar ford = new Ford();
            container.RegisterInstance<ICar>(ford);
            Driver driver0 = container.Resolve<Driver>();

            driver0.RunCar();
            driver0.RunCar();
            driver0.RunCar();
            driver0.RunCar();
            driver0.RunCar();


            // Registers Driver type            
            container.RegisterType<Driver>("LuxuryCarDriver",
                            new InjectionConstructor(container.Resolve<ICar>("LuxuryCar")));

            Driver driver1 = container.Resolve<Driver>();// injects BMW
            driver1.RunCar();

            Driver driver2 = container.Resolve<Driver>("LuxuryCarDriver");// injects Audi
            driver2.RunCar();

            Driver driver3 = container.Resolve<Driver>();

            driver3.RunCar();

            /*
            Driver driver = new Driver(new BMW());
            driver.RunCar();
            */
            Console.ReadLine();
        }
    }
}
