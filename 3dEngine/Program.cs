namespace _3dEngine;

class Program
{
    static void Main()
    {
        Console.SetWindowSize(120, 30);
        Frame frame = new Frame();
        frame.MainLoop();
    }
}