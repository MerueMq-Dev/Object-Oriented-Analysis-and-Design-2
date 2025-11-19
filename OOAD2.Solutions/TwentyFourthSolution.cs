using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOAD2.Solutions
{
    public class TwentyFourthSolution
    {
        //  Абстрагирование
        //  Изначально существовал класс EmailNotification для отправки уведомлений по почте.Когда потребовалось добавить SMS и push-уведомления,
        //  выяснилось, что отправка писем — частный случай более общего процесса.Поэтому ввели базовый класс Notification с общими операциями типа
        //  send() и validate(), а EmailNotification превратился в один из его наследников наряду с SmsNotification и PushNotification.
        
        //  Факторизация
        //  В системе библиотеки работали независимые классы Book, Magazine и DVD. При развитии проекта обнаружилось, что все они поддерживают похожие
        //  действия: выдачу читателям, возврат, бронирование.Тогда для них создали общий родительский класс LibraryItem с этими операциями, а книги,
        //  журналы и диски остались его специализациями со своими уникальными свойствами.
    }
}
