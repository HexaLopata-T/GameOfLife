using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameLife
{
    class LiveCell : Transformable, Drawable
    {
        // Будет ли изменяться состояния клеток
        public static bool IsOn = false;

        // Размер клетки
        public const int Size = 8;

        // Ресуемая часть
        RectangleShape shape;

        // Соседи
        LiveCell up;
        LiveCell down;
        LiveCell left;
        LiveCell right;
        LiveCell upleft;
        LiveCell downright;
        LiveCell downleft;
        LiveCell upright;

        // Счетчик соседей
        int counter;

        // Живая/Мертвая
        public bool state = false;

        // Подготовка к прорисовке и инициализации
        public LiveCell(int x, int y)
        {
            shape = new RectangleShape(new Vector2f(Size, Size));
            shape.FillColor = Color.White;
            Position = new Vector2f(x * Size, y * Size);
        }

        // Инициализация соседей
        public void GetComponent(LiveCell up, LiveCell down, LiveCell left, LiveCell right, LiveCell upleft, LiveCell downright, LiveCell downleft, LiveCell upright)
        {
            this.up = up;
            this.down = down;
            this.left = left;
            this.right = right;
            this.upleft = upleft;
            this.downright = downright;
            this.downleft = downleft;
            this.upright = upright;
        }

        // Считывание соседей
        public void updatestate()
        {
            if (state == true)
            {
                shape.FillColor = Color.Blue;
            }
            else
            {
                shape.FillColor = Color.Black;
            }
            if (up != null)
            {
                if (up.state == true)
                {
                    counter += 1;
                }
            }
            if (down != null)
            {
                if (down.state == true)
                {
                    counter += 1;
                }
            }
            if (left != null)
            {
                if (left.state == true)
                {
                    counter += 1;
                }
            }
            if (right != null)
            {
                if (right.state == true)
                {
                    counter += 1;
                }
            }
            if (upleft != null)
            {
                if (upleft.state == true)
                {
                    counter += 1;
                }
            }
            if (downright != null)
            {
                if (downright.state == true)
                {
                    counter += 1;
                }
            }
            if (downleft != null)
            {
                if (downleft.state == true)
                {
                    counter += 1;
                }
            }
            if (upright != null)
            {
                if (upright.state == true)
                {
                    counter += 1;
                }
            }
        }

        // Изменение состояний в зависимости от соседей
        public void setstates()
        {
            if (IsOn)
            {
                if (state == false)
                {
                    if (counter == 3)
                    {
                        state = true;
                    }
                    else
                    {
                        state = false;
                    }
                }
                else if(counter == 3 || counter == 2)
                {
                    state = true;
                }
                else
                {
                    state = false;
                }
            }
            counter = 0;
        }

        // Прорисовка клетки
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            target.Draw(shape, states);
        }
    }
}