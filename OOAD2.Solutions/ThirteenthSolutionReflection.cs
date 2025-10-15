using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD2.Solutions
{
    public class ThirteenthSolutionReflection
    {
        // В моём решении на C# все четыре варианта формально реализуемы, в отличие от Java, где нельзя 
        // уменьшить область видимости метода в наследнике. В C# это достигается за счёт различия между
        // override и new shadowing: первый вариант и четвёртый выглядят аналогично Java через 
        // virtual/override, третий тоже допустим, так как приватные методы не наследуются и в потомке
        // создаётся новый метод. А вот второй вариант отличается — в C# его можно показать с помощью
        // private new, тогда как в Java это невозможно, а в Python всё решается только договорённостями,
        // так как строгих модификаторов доступа там нет.
    }
}
