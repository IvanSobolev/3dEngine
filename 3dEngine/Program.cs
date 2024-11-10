using _3dEngine.Implementation;
using _3dEngine.Implementation.Scenes;

namespace _3dEngine;

class Program
{
    static void Main()
    {
        new Frame(new Scene1(new DisplaysManager()), new ConsoleScreen()).MainLoop();
    }
}