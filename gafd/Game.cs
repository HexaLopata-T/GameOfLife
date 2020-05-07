using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Graphics;
using SFML.Audio;
using SFML.Window;
using System.Threading;

namespace GameLife
{
    class Game
    {
        public Universe universe; // По сути все клетки

        public Game()
        {
            universe = new Universe(); // Подготовка всех клеток
        }

        // Обновляет всю логику
        public void Update()
        {
            universe.UpdateUniverse();
        }

        // Прорисовка всех объектов
        public void Draw()
        {
            universe.DrawUniverse();
        }     
    }
}