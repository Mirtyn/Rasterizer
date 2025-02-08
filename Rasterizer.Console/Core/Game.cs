using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Rasterizer.Core
{
    public abstract class Game
    {
        protected string WindowName { get; set; }
        protected int InitialWindowHeight { get; set; }
        protected int InitialWindowWidth { get; set; }
        private GameWindowSettings gameWindowSettings = GameWindowSettings.Default;
        private NativeWindowSettings nativeWindowSettings = NativeWindowSettings.Default;

        protected GameWindow Window;

        public Game(string windowName, int initialWindowHeight, int initialWindowWidth)
        {
            WindowName = windowName;
            InitialWindowHeight = initialWindowHeight;
            InitialWindowWidth = initialWindowWidth;
        }

        public void Run()
        {
            Initialize();
            Window = new GameWindow(gameWindowSettings, nativeWindowSettings);
            GameTime gameTime = new GameTime();
            Window.Load += LoadContent;
            Window.UpdateFrame += (FrameEventArgs frameEventArgs) =>
            {
                var time = frameEventArgs.Time;
                gameTime.TotalGameTime += TimeSpan.FromMilliseconds(time);
                gameTime.ElapsedGameTime = TimeSpan.FromMilliseconds(time);
                Update(gameTime);
            };

            Window.RenderFrame += (FrameEventArgs frameEventArgs) =>
            {
                Render(gameTime);
                Window.SwapBuffers();
            };
            Window.Run();
        }

        protected abstract void Initialize();
        protected abstract void LoadContent();
        protected abstract void Update(GameTime gameTime);
        protected abstract void Render(GameTime gameTime);
    }
}
