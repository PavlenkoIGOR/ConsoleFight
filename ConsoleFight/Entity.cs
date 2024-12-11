using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Entity
    {
        private int _health;

        public Entity()
        {
            Health = 100;
            Energy = 100;
        }


        public int Health
        {
            get { return _health; }
            set
            {
                // Добавляем проверку, чтобы здоровье не превышало 100
                if (value >= 100)
                {
                    _health = 100;
                }
                else if (value < 0)
                {
                    _health = 0; // Устанавливаем здоровье в 0, если здоровье становится отрицательным
                }
                else
                {
                    _health = value;
                }
            }
        }
        public int Energy { get; set; }
    }
}