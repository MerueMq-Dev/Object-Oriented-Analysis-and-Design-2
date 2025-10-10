using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD2.Solutions
{

    //1. метод публичен в родительском классе FirstBaseClass и публичен в его потомке FirstChildClass.
    public class FirstBaseClass
    {
        public virtual void Show()
        {
            Console.WriteLine("First base class example call");
        }
    }

    public class FirstChildClass : FirstBaseClass
    {
        public override void Show()
        {
            Console.WriteLine("First child class example call");
        }
    }

    // 2. метод публичен в родительском классе SecondBaseClass и скрыт в его потомке SecondChildClass.

    public class SecondBaseClass
    {
        public void Show()
        {
            Console.WriteLine("Second base class example call");
        }
    }

    public class SecondChildClass : SecondBaseClass
    {
        private new void Show()
        {
            Console.WriteLine("Second child class example call");
        }
    }



    //3. метод скрыт в родительском классе ThirdBaseClass и публичен в его потомке ThirdChildClass.

    public class ThirdBaseClass
    {
        private void Show()
        {
            Console.WriteLine("Third base class example call");
        }
    }

    public class ThirdChildClass : ThirdBaseClass
    {
        protected new void Show()
        {
            Console.WriteLine("Third child class example call");
        }
    }



    //4. метод скрыт в родительском классе FourthBaseClass и скрыт в его потомке FourthChildClass.

    public class FourthBaseClass
    {
        protected virtual void Show() {
            Console.WriteLine("Fourth base class example call");
        }
    }


    public class FourthChildClass : FourthBaseClass
    {
        protected override void Show()
        {
            Console.WriteLine("Fourth child class example call");
        }
    }
}
