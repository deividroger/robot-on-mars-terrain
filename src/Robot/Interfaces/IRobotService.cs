using Robot.Models;
namespace Robot.Interfaces
{
    public interface IRobotService
    {
        void SetStartingPoint(int x, int y, Compass direction, MarsPlateauGrid grid);

        void Move(string commmands);

        string GetCurrentPosition();
       
    }
}