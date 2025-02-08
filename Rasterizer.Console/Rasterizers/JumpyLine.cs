using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using Rasterizer.Library.Mathmatics;
using Vector2 = Rasterizer.Library.Mathmatics.Vector2;

namespace Rasterizer.Console.Rasterizers
{
    internal class JumpyLine : AbstractRasterizer
    {
        Random rnd = new Random();
        private Color4 color = Color4.Black;

        private float timer = 0f;
        private float maxTimer = 0.25f;

        private float splitChance = 0.05f;

        private List<Vector2> startPosses;
        private List<Vector2> endPosses;

        private int endPointIndex = 1;

        private List<Vector2> startPositions = new List<Vector2>();
        private List<Vector2> endPositions = new List<Vector2>();
        private List<Color4> colors = new List<Color4>();
        private int index = 0;

        public override void Load()
        {
            startPosses = new List<Vector2>() { new Vector2(Width / 2, Height / 2) };
            endPosses = new List<Vector2>() { new Vector2(Width / 2, Height / 2) };
        }

        public override void Update()
        {
            System.Console.WriteLine("GameTime: " + TotalGameTime);
            System.Console.WriteLine("ElapsedTIme: " + ElapsedTime);

            System.Console.WriteLine("Number Branches: " + startPosses.Count);

            color.R += (float)rnd.NextDouble() * ElapsedTime;
            color.G += (float)rnd.NextDouble() * ElapsedTime;
            color.B += (float)rnd.NextDouble() * ElapsedTime;

            if (color.R > 1f)
            {
                color.R = 0f;
            }
            if (color.G > 1f)
            {
                color.G = 0f;
            }
            if (color.B > 1f)
            {
                color.B = 0f;
            }
        }

        public override void Render()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.ClearColor(color);

            Color4 lineColor = InvertColor(color);

            if (timer < 0f)
            {
                timer += maxTimer;
            }
            else
            {
                timer -= ElapsedTime;

                for (int i = 0; i < index; i++)
                {
                    var color = colors[i];
                    DrawLine(startPositions[i], endPositions[i], color.R, color.G, color.B);
                }

                return;
            }

            for (int i = 0; i < endPointIndex; i++)
            {
                startPosses[i] = endPosses[i];

                var startPos = startPosses[i];

                endPosses[i] = new Vector2(startPos.X + rnd.NextInt64(-50, 50), startPos.Y + rnd.NextInt64(-50, 50));

                var endPos = endPosses[i];

                if (endPos.X < 0)
                {
                    endPos.X += rnd.NextInt64(50, 200);
                }
                else if (endPos.X > Width)
                {
                    endPos.X -= rnd.NextInt64(50, 200);
                }
                if (endPos.Y < 0)
                {
                    endPos.Y += rnd.NextInt64(50, 200);
                }
                else if (endPos.Y > Height)
                {
                    endPos.Y -= rnd.NextInt64(50, 200);
                }

                colors.Add(lineColor);

                startPositions.Add(startPos);
                endPositions.Add(endPos);

                if (rnd.NextSingle() < splitChance)
                {
                    startPosses.Add(startPos);

                    var branchEndPos = new Vector2(startPos.X + rnd.NextInt64(-50, 50), startPos.Y + rnd.NextInt64(-50, 50));

                    if (branchEndPos.X < 0)
                    {
                        branchEndPos.X += rnd.NextInt64(50, 200);
                    }
                    else if (branchEndPos.X > Width)
                    {
                        branchEndPos.X -= rnd.NextInt64(50, 200);
                    }
                    if (branchEndPos.Y < 0)
                    {
                        branchEndPos.Y += rnd.NextInt64(50, 200);
                    }
                    else if (branchEndPos.Y > Height)
                    {
                        branchEndPos.Y -= rnd.NextInt64(50, 200);
                    }

                    endPosses.Add(branchEndPos);
                }

                index++;
            }

            endPointIndex = startPosses.Count;

            for (int i = 0; i < index; i++)
            {
                var color = colors[i];
                DrawLine(startPositions[i], endPositions[i], color.R, color.G, color.B);
            }
        }

        private Color4 InvertColor(Color4 color)
        {
            color.R--;
            color.G--;
            color.B--;

            color.R = MathF.Abs(color.R);
            color.G = MathF.Abs(color.G);
            color.B = MathF.Abs(color.B);

            return color;
        }
    }
}
