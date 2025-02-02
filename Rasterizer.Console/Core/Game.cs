using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Rasterizer.Core
{
    public abstract class Game
    {
        protected string WindowName { get; set; }
        protected int InitialWindowHeight { get; set; }
        protected int InitialWindowWidth { get; set; }
        private GameWindowSettings gameWindowSettings = new GameWindowSettings();
        private NativeWindowSettings nativeWindowSettings = new NativeWindowSettings();

        public Game(string windowName, int initialWindowHeight, int initialWindowWidth)
        {
            WindowName = windowName;
            InitialWindowHeight = initialWindowHeight;
            InitialWindowWidth = initialWindowWidth;
        }

        public void Run()
        {
            Initialize();
            using GameWindow gameWindow = new GameWindow(gameWindowSettings, nativeWindowSettings);
            GameTime gameTime = new GameTime();
            gameWindow.Load += LoadContent;
            gameWindow.UpdateFrame += (FrameEventArgs frameEventArgs) =>
            {
                var time = frameEventArgs.Time;
                gameTime.TotalGameTime += TimeSpan.FromMilliseconds(time);
                gameTime.ElapsedGameTime = TimeSpan.FromMilliseconds(time);
                Update(gameTime);
            };

            gameWindow.RenderFrame += (FrameEventArgs frameEventArgs) =>
            {
                Render(gameTime);
                gameWindow.SwapBuffers();
            };
            gameWindow.Run();
        }

        protected abstract void Initialize();
        protected abstract void LoadContent();
        protected abstract void Update(GameTime gameTime);
        protected abstract void Render(GameTime gameTime);
    }
}
