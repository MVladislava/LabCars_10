using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabAvto_10
{
    public class Menu
    {
        public void MenuChoise()
        {
            Console.WriteLine($@" Меню:
1.Создание и вывод масива объектов
2.Самый дорогой внедорожник (is)
3.Средняя скорость легковых автомобилей (as)
4.Суммарная стоимость всех автомобилей (typeof)
5.Создание и вывод и подсчёт объектов с помощью IInit
6.Сортировка по бренду с помощью интерфейса IComparable + BinarySearch
7.Сортировка по цвету с помощью интерфейса IComparer + BinarySearch
8.Клонирование и поверхностное копирование");
        }
    }
}
