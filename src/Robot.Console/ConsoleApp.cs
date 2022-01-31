using Robot.Interfaces;
using Robot.Models;
using System.Linq;

namespace Robot.Console
{
    public static class ConsoleApp
    {
        public static void Run(IRobotService robotService)
        {
            try
            {
                System.Console.WriteLine("Please, inform the value of the boundaries XxY format");
                System.Console.WriteLine("example: 2x2 or 4X4 so on");

                var borders = System.Console.ReadLine().Trim().Split('x').Select(int.Parse).ToList();

                System.Console.WriteLine("Please, inform the moviments (F: Move forward | R: Turn the robot right | L: Turn the robot left)");
                System.Console.WriteLine("example: FRLF");


                robotService.SetStartingPoint(1, 1, Compass.North, new MarsPlateauGrid(borders[0], borders[1]));

                var commands = System.Console.ReadLine().ToUpper();

                robotService.Move(commands);

                System.Console.WriteLine("Your final position is:");

                System.Console.WriteLine(robotService.GetCurrentPosition());

                System.Console.ReadKey();


            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);

            }
        }
    }
}
