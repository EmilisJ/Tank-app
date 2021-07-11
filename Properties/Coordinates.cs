using System;

namespace lecture05_tankas
{
    public class Coordinates
    {
        private int _x, _y;
        private bool _hasMoved = false;

        public Coordinates(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            string raport = "Tanko pozicija: (";
            if (_x == 0 && _y == 0)
            {
                if (_hasMoved == false)
                {
                    raport = "Tankas nepajudėjo iš vietos.";
                    return raport;
                } else
                {
                    raport = $"Tankas buvo pajudėjęs, bet galiausiai grįžo į pradinę poziciją";
                    return raport;
                }
            }
            else if (_x == 0 && _y > 0)
            {
                raport += $"Šiaurė: {_y}).";
                return raport;
            }
            else if (_x == 0 && _y < 0)
            {
                raport += $"Pietūs: {Math.Abs(_y)}).";
                return raport;
            }
            else if (_x > 0 && _y == 0)
            {
                raport += $"Rytai: {_x}).";
                return raport;
            }
            else if (_x < 0 && _y == 0)
            {
                raport += $"Vakarai: {Math.Abs(_x)}).";
                return raport;
            }
            else if (_x > 0 && _y > 0)
            {
                raport += $"Šiaurė: {_y}, Rytai: {_x}).";
                return raport;
            }
            else if (_x > 0 && _y < 0)
            {
                raport += $"Pietūs: {Math.Abs(_y)}, Rytai: {_x}).";
                return raport;
            }
            else if (_x < 0 && _y > 0)
            {
                raport += $"Šiaurė: {_y}, Vakarai: { Math.Abs(_x)}).";
                return raport;
            }
            else if (_x < 0 && _y < 0)
            {
                raport += $"Pietūs: {Math.Abs(_y)}, Vakarai: { Math.Abs(_x)}).";
                return raport;
            }
            else
            {
                return null;
            }       
        }

        public int GetX()
        {
            return _x;
        }
        public void SetX(int x)
        {
            _x = x;
        }

        public int GetY()
        {
            return _y;
        }
        public void SetY(int y)
        {
            _y = y;
        }

        public bool GetHasMoved()
        {
            return _hasMoved;
        }
        public void SetHasMoved(bool hasMoved)
        {
            _hasMoved = hasMoved;
        }

    }

}
