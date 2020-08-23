using System;

namespace SafariPark
{
    public class Vehicle
    {
        private int _capacity;
        private int _speed = 10;
        private int _numPassengers;
        public int Position
        { get; private set; }
        public int NumPassengers
        {
            get { return _numPassengers; }
            set
            {
                if (value >= 0 && value <= _capacity)
                {
                    _numPassengers = value;
                }
                else if (value > _capacity)
                {
                    _numPassengers = _capacity;
                }
            }
        }


        public Vehicle() {}

       
        public Vehicle(int capacity, int speed = 10)
        {
            _capacity = capacity;
            _speed = speed;
        }

        public  string Move(int times)
        {
            Position += _speed * times;
            return $"Moving along {times} times";
        }
        public  string Move()
        {
            Position += _speed;
            return "Moving along";
        }
    }
}