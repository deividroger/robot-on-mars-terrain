namespace Robot.Models
{
    public class MarsPlateauGrid
    {

        public MarsPlateauGrid(int pointsX, int pointsY)
        {
            PointsX = pointsX;
            PointsY = pointsY;
        }

        public int PointsX { get; private set; }
        public int PointsY { get; private set; }

    }
}