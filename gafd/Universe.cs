using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameLife
{
    class Universe
    {
        private bool Spawned = false; // Подготовлены ли все клетки

        public const int universeWight = 112, universeHeight = 112; // Количество клеток в ширину и высоту

        public LiveCell[,] liveCells = new LiveCell[universeWight, universeHeight];

        // Инициализация всех клеток
        public Universe()
        {
            for (int x = 0; x < universeWight; x++)
                for (int y = 0; y < universeHeight; y++)
                {
                    liveCells[x, y] = new LiveCell(x, y);
                }

            for (int x = 0; x < universeWight; x++)
                for (int y = 0; y < universeHeight; y++)
                {
                    if (y == 0 & x > 0 & x + 1 < universeWight)
                    {
                        liveCells[x, y].GetComponent(liveCells[x, universeHeight - 1], liveCells[x, y + 1], liveCells[x - 1, y], liveCells[x + 1, y], liveCells[x - 1, universeHeight - 1], liveCells[x + 1, y + 1], liveCells[x - 1, y + 1], liveCells[x + 1, universeHeight - 1]);
                    }
                    else if (x == 0 & y > 0 & y + 1 < universeHeight)
                    {
                        liveCells[x, y].GetComponent(liveCells[x, y - 1], liveCells[x, y + 1], liveCells[universeWight - 1, y], liveCells[x + 1, y], liveCells[universeWight - 1, y - 1], liveCells[x + 1, y + 1], liveCells[universeWight - 1, y + 1], liveCells[x + 1, y - 1]);
                    }
                    else if (x == 0 & y == 0)
                    {
                        liveCells[x, y].GetComponent(liveCells[x, universeHeight - 1], liveCells[x, y + 1], liveCells[universeWight - 1, y], liveCells[x + 1, y], liveCells[universeWight - 1, universeHeight - 1], liveCells[x + 1, y + 1], liveCells[universeWight - 1, y + 1], liveCells[x + 1, universeHeight - 1]);
                    }
                    else if(x + 1 == universeWight & y + 1 < universeHeight & y > 0)
                    {
                        liveCells[x, y].GetComponent(liveCells[x, y - 1], liveCells[x, y + 1], liveCells[x - 1, y], liveCells[0, y], liveCells[x - 1, y - 1], liveCells[0, y + 1], liveCells[x - 1, y + 1], liveCells[0, y - 1]);
                    }
                    else if(y + 1 == universeHeight & x + 1 < universeWight & x > 0)
                    {
                        liveCells[x, y].GetComponent(liveCells[x, y - 1], liveCells[x, 0], liveCells[x - 1, y], liveCells[x + 1, y], liveCells[x - 1, y - 1], liveCells[x + 1, 0], liveCells[x - 1, 0], liveCells[x + 1, y - 1]);
                    }
                    else if(x == 0 & y == universeHeight - 1)
                    {
                        liveCells[x, y].GetComponent(liveCells[x, y - 1], liveCells[x, 0], liveCells[universeWight - 1, y], liveCells[x + 1, y], liveCells[universeWight - 1, y - 1], liveCells[x + 1, 0], liveCells[universeWight - 1, 0], liveCells[x + 1, y - 1]);
                    }
                    else if(x == universeWight - 1 & y == 0)
                    {
                        liveCells[x, y].GetComponent(liveCells[x, universeHeight - 1], liveCells[x, y + 1], liveCells[x - 1, y], liveCells[0, y], liveCells[x - 1, universeHeight - 1], liveCells[0, y + 1], liveCells[x - 1, y + 1], liveCells[0, universeHeight - 1]);
                    }
                    else if(x == universeWight - 1 & y == universeHeight - 1)
                    {
                        liveCells[x, y].GetComponent(liveCells[x, y - 1], liveCells[x, 0], liveCells[x - 1, y], liveCells[0, y], liveCells[x - 1, y - 1], liveCells[0, 0], liveCells[x - 1, 0], liveCells[0, y - 1]);
                    }
                    else if (x > 0 & y > 0 & x + 1 < universeWight & y + 1 < universeHeight)
                    {
                        liveCells[x, y].GetComponent(liveCells[x, y - 1], liveCells[x, y + 1], liveCells[x - 1, y], liveCells[x + 1, y], liveCells[x - 1, y - 1], liveCells[x + 1, y + 1], liveCells[x - 1, y + 1], liveCells[x + 1, y - 1]);
                    }
                }
        }

        // Обновляет состояния всех клеткок
        public void UpdateUniverse()
        {
            if (LiveCell.IsOn || !Spawned)
            {
                for (int x = 0; x < universeWight; x++)
                    for (int y = 0; y < universeHeight; y++)
                    {
                        liveCells[x, y].updatestate();
                    }
                for (int x = 0; x < universeWight; x++)
                    for (int y = 0; y < universeHeight; y++)
                    {
                        liveCells[x, y].setstates();
                    }
            }
            else
            {
                Spawned = true;
            }
        }

        // Прорисовывает все клеткм
        public void DrawUniverse()
        {
            if (LiveCell.IsOn)
            {
                Thread.Sleep(50); // Знаю, что плохо, но пока лень
            }
            for (int x = 0; x < universeWight; x++)
                for (int y = 0; y < universeHeight; y++)
                {
                    Program.Window.Draw(liveCells[x, y]);
                }
        }
    }
}