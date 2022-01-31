using Robot.Interfaces;
using System;
using Robot.Models;

namespace Robot.Services
{
    public class RobotService : IRobotService
    {
        private int _positionX;
        private int _positionY;
        private Compass _direction;
        private MarsPlateauGrid _grid;

        public void SetStartingPoint(int x, int y, Compass direction, MarsPlateauGrid grid)
        {
            if (x < 1 || y < 1) throw new Exception("There is no 0,0 position");

            _positionX = x;
            _positionY = y;
            _direction = direction;
            _grid = grid;
        }

        public void Move(string commmands)
        {
            if (_grid == null) throw new Exception("Grid not initialized");


            foreach (var command in commmands.ToUpper())
            {
                switch (command)
                {
                    case 'F':
                        MoveFoward();
                        break;
                    case 'L':
                        RotateLeft();
                        break;
                    case 'R':
                        this.RotateRight();
                        break;
                    default:
                        throw new Exception($"Invalid command {command}");
                }

                if (MovimentOutOfBoundaries())
                    throw new Exception($"You cannot make a move outside the borders 1X1 AND {_grid.PointsX}X{_grid.PointsY}");

            }
        }

        public string GetCurrentPosition()
            => $"{_positionX},{_positionY},{_direction}";

        private void MoveFoward()
        {
            switch (_direction)
            {
                case Compass.North:
                    _positionY += 1;
                    break;
                case Compass.South:
                    _positionY -= 1;
                    break;
                case Compass.East:
                    _positionX += 1;
                    break;
                case Compass.West:
                    _positionX -= 1;
                    break;

            }
        }

        private void RotateLeft()
        {
            switch (_direction)
            {
                case Compass.North:
                    _direction = Compass.West;
                    break;
                case Compass.South:
                    _direction = Compass.East;
                    break;
                case Compass.East:
                    _direction = Compass.North;
                    break;
                case Compass.West:
                    _direction = Compass.South;
                    break;
            }
        }

        private void RotateRight()
        {
            switch (_direction)
            {
                case Compass.North:
                    _direction = Compass.East;
                    break;
                case Compass.South:
                    _direction = Compass.West;
                    break;
                case Compass.East:
                    _direction = Compass.South;
                    break;
                case Compass.West:
                    _direction = Compass.North;
                    break;
            }
        }

        private bool MovimentOutOfBoundaries()
            => _positionX < 1 || _positionX > _grid.PointsX || _positionY < 1 || _positionY > _grid.PointsY;


    }
}
