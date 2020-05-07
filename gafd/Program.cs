using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameLife
{
    class Program
    {
        //public static Music paranoid; 
        public static RenderWindow Window { get; private set; }
        public static Game game { get; private set; }

        public static bool IsPressed = false;
        public static bool IsPressedRight = false;

        static void Main()
        {
            Window = new RenderWindow(new VideoMode(LiveCell.Size * Universe.universeWight, LiveCell.Size * Universe.universeHeight), "Conway's Game of life", Styles.Close);
            Window.SetVerticalSyncEnabled(true);

            Window.Closed += Win_Closed;
            Window.MouseMoved += Win_MouseEntered;
            Window.MouseButtonPressed += Win_MouseButtonPressed;
            Window.MouseButtonReleased += Win_MouseButtonReleased;
            Window.KeyPressed += Win_LiveOnOff;
          
            try
            {
                //paranoid = new Music("Music//" + "Black Sabbath - Paranoid.ogg");
                //paranoid.Play();
                //paranoid.Loop = true;
            }
            catch{ }
            game = new Game();

            // Логика и прорисовка
            while (Window.IsOpen)
            {
                Window.DispatchEvents();
                game.Update();
                Window.Clear(Color.Black);
                game.Draw();
                Window.Display();
            }
            
        }

        // по нажатии пробела определяет, будут ли клетки менять состояния
        private static void Win_LiveOnOff(object sender, KeyEventArgs e)
        {
            if(e.Code == Keyboard.Key.Space)
            {
                LiveCell.IsOn = !LiveCell.IsOn;
            }
        }

        // Активипуется при отпускаании кнопок мыши
        private static void Win_MouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.Button == Mouse.Button.Left)
                    IsPressed = false;
                else
                    IsPressedRight = false;
            }
            catch { }
        }

        // Активипуется при нажатии кнопок мыши(Левая - рисует, Правая - стирает)
        private static void Win_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.Button == Mouse.Button.Right)
                {
                    game.universe.liveCells[(e.X - e.X % LiveCell.Size) / LiveCell.Size, (e.Y - e.Y % LiveCell.Size) / LiveCell.Size].state = false;
                    IsPressedRight = true;
                }
                else if (e.Button == Mouse.Button.Left)
                {
                    IsPressed = true;
                    game.universe.liveCells[(e.X - e.X % LiveCell.Size) / LiveCell.Size, (e.Y - e.Y % LiveCell.Size) / LiveCell.Size].state = true;
                }
            }
            catch { }
        }

        // Считывает положение мыши
        private static void Win_MouseEntered(object sender, MouseMoveEventArgs e)
        {
            try
            {
                if (IsPressed)
                    game.universe.liveCells[(e.X - e.X % LiveCell.Size) / LiveCell.Size, (e.Y - e.Y % LiveCell.Size) / LiveCell.Size].state = true;
                if (IsPressedRight)
                    game.universe.liveCells[(e.X - e.X % LiveCell.Size) / LiveCell.Size, (e.Y - e.Y % LiveCell.Size) / LiveCell.Size].state = false;
            }
            catch {}
        }

        // Закрытие окна
        private static void Win_Closed(object sender, EventArgs e)
        {
            Window.Close();
        }
    }
}