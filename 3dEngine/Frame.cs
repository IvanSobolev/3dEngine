using _3dEngine.AbstractClass;
using _3dEngine.Interfaces;
using _3dEngine.StaticClass;

namespace _3dEngine;
public class Frame(Scene activeScene, IScreen screen)
{
    private readonly IScreen _screen = screen;
    private readonly Scene _activeScene = activeScene;

    public void MainLoop()
    {
        _activeScene.Start();
        
        for (int t = 0; true; t++)
        {
            GameTime.StartFrame();
            _activeScene.Update();
            for (int j = 0; j < _screen.GetHeight(); j++)
            {
                for (int i = 0; i < _screen.GetWidth(); i++)
                {
                    _screen.SetPixelPos(i, j);
                    _screen.Paint(_activeScene.GetPixelBrightness(_screen.GetUv()));
                }
            }
            _screen.Paint( "Fps: " + Double.Round(GameTime.GetFps(), 1)  + "       ", Vector2Int.Zero);
            
            GameTime.EndFrame();
        }
    }
}