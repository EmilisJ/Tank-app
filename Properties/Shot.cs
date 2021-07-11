using System;
namespace lecture05_tankas
{
    public class Shot
    {
        private Coordinates _position;
        private Directions _direction;
        int _number;

        public Shot(Coordinates position, Directions direction, int no)
        {
            _position = new Coordinates(position.GetX(), position.GetY());
            _direction = direction;
            _number = no;
        }

        public override string ToString()
        {
            string raport = $"{_number} Šūvio metu: kryptis = ";

            switch (_direction)
            {
                case Directions.North:
                    raport += "Šiaurė, ";
                    break;
                case Directions.South:
                    raport += "Pietūs, ";
                    break;
                case Directions.East:
                    raport += "Rytai, ";
                    break;
                case Directions.West:
                    raport += "Vakarai, ";
                    break;
            }

            if (_position.GetX() == 0 && _position.GetY() == 0)
            {
                raport += "Tankas buvo pradžios taške.";
                return raport;
            } else
            {
                raport += _position;
                return raport;
            }

        } 
    }

}
