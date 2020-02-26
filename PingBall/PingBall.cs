using System;
using System.Drawing;

namespace PingBallWorkspace
{
    public class PingBall
    {
        int _directionX;
        int _directionY;

        int _thresholdX;
        int _thresholdY;

        int _deltaX;
        int _deltaY;

        Counter _x;
        Counter _y;

        public PingBall(int thresholdX = 500, int thresholdY = 500, int directionX = 1, int directionY= 1, 
                            int startingPositionX = 0, int startingPositionY = 0, int deltaX = 3, int deltaY = 4)
        {
            _directionX = directionX;
            _directionY = directionY;

            _thresholdX = thresholdX;
            _thresholdY = thresholdY;

            _deltaX = deltaX;
            _deltaY = deltaY;

            _x = new Counter(_thresholdX, startingPositionX, _directionX, _deltaX);
            _y = new Counter(_thresholdY, startingPositionY, _directionY, _deltaY);
        }

        public Point GetNewPosition()
        {
            Point position = new Point();

            _x.Add("X");
            _y.Add("Y");

            position.X = _x.ShoWPosition();
            position.Y = _y.ShoWPosition();

            return position;
        }
    }

    class Counter
    {
        private int _threshold;
        private int _position;
        public int _direction;
        public int _delta;

        public Counter(int threshold, int startPosition, int direction, int delta)
        {
            _threshold = threshold;
            _position = startPosition;
            _direction = direction;
            _delta = delta;
        }

        public void Add(string axis)
        {
            _position += _delta * _direction;

            if (_position >= _threshold || _position <= 0)
            {
                _direction = _direction * (-1);
            }

            Console.WriteLine("Axis: " + axis + " new position: ", _position + " new direction: " + _direction + " new delta: " + _delta);
        }

        public int ShoWPosition()
        {
            return _position;
        }
    }
}
