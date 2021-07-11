using System;
using System.Collections.Generic;

namespace lecture05_tankas
{
    public class Tank
    {
        private string _name;
        private Coordinates _position = new Coordinates(0, 0);
        private Directions _direction = Directions.North;
        private int _ammo = 10;
        private int _fuel = 100;
        private int _totalShots, _shotsNorth, _shotsSouth, _shotsWest, _shotsEast;
        private List<Shot> _allShots = new List<Shot>();

        public Tank(string name)
        {
            _name = name;
        }

        public void FireShot() {
            if (_ammo > 0)
            {
                UseAmmo();
                _totalShots++;
                switch (_direction)
                {
                    case Directions.North:
                        _shotsNorth++;
                        break;
                    case Directions.South:
                        _shotsSouth++;
                        break;
                    case Directions.East:
                        _shotsEast++;
                        break;
                    case Directions.West:
                        _shotsWest++;
                        break;
                }

                _allShots.Add(new Shot(_position, _direction, _totalShots));

            } else
            {
                Console.WriteLine("Baigėsi šoviniai!");
            }
        }

        public string ShotsToVariousDirections()
        {
            if (_totalShots > 0) {
                string shotInfo = "Tanko šauti kartai:";
                if(_shotsNorth > 0)
                {
                    shotInfo += System.Environment.NewLine + $"\t į Šiaurę: {_shotsNorth}";
                }
                if (_shotsSouth > 0)
                {
                    shotInfo += System.Environment.NewLine + $"\t į Pietus: {_shotsSouth}";
                }
                if (_shotsEast > 0)
                {
                    shotInfo += System.Environment.NewLine + $"\t į Rytus: {_shotsEast}";
                }
                if (_shotsWest > 0)
                {
                    shotInfo += System.Environment.NewLine + $"\t į Vakarus: {_shotsWest}";
                }
                return shotInfo;
            } else
            {
                return "Nebuvo iššautas nei vienas šūvis.";
            }
        }

        public string AllShotsInfo()
        {
            string raport = null;
            if (_totalShots > 0)
            {
                for (int i = 0; i < _totalShots; i++)
                {
                    raport += _allShots[i].ToString() + System.Environment.NewLine;
                }
            }
            return raport;
        }

        public string TranslateDirections() {
            string raport = "Tanko kryptis: ";
            switch (_direction)
            {
                case Directions.North:
                    raport += "Šiaurė.";
                    break;
                case Directions.South:
                    raport += "Pietūs.";
                    break;
                case Directions.East:
                    raport += "Rytai.";
                    break;
                case Directions.West:
                    raport += "Vakarai.";
                    break;
            }


            return raport;
        }

        public void TurnRight()
        {
            switch (_direction)
            {
                case Directions.North:
                    _direction = Directions.East;
                    break;
                case Directions.South:
                    _direction = Directions.West;
                    break;
                case Directions.East:
                    _direction = Directions.South;
                    break;
                case Directions.West:
                    _direction = Directions.North;
                    break;
            }
            Console.WriteLine("Posūkis dešinėn.");
        }

        public void TurnLeft()
        {
            switch (_direction)
            {
                case Directions.North:
                    _direction = Directions.West;
                    break;
                case Directions.South:
                    _direction = Directions.East;
                    break;
                case Directions.East:
                    _direction = Directions.North;
                    break;
                case Directions.West:
                    _direction = Directions.South;
                    break;
            }
            Console.WriteLine("Posūkis kairėn.");
        }

        public void MoveForth()
        {
            if (_fuel > 0)
            {
                string raport = "Pirmyn, " + BurnFuel();

                if (!_position.GetHasMoved())
                {
                    _position.SetHasMoved(true);
                }

                switch (_direction)
                {
                    case Directions.North:
                        _position.SetY(_position.GetY() + 1);
                        break;
                    case Directions.South:
                        _position.SetY(_position.GetY() - 1);
                        break;
                    case Directions.East:
                        _position.SetX(_position.GetX() + 1);
                        break;
                    case Directions.West:
                        _position.SetX(_position.GetX() - 1);
                        break;
                }
                Console.WriteLine(raport);
            } else {
                Console.WriteLine("Baigėsi kuras!");
            }
        }

        public void MoveBackwards()
        {
            if (_fuel > 0)
            {
                string raport = "Atgal, " + BurnFuel();

                if (!_position.GetHasMoved())
                {
                    _position.SetHasMoved(true);
                }

                switch (_direction)
                {
                    case Directions.North:
                        _position.SetY(_position.GetY() - 1);
                        break;
                    case Directions.South:
                        _position.SetY(_position.GetY() + 1);
                        break;
                    case Directions.East:
                        _position.SetX(_position.GetX() - 1);
                        break;
                    case Directions.West:
                        _position.SetX(_position.GetX() + 1);
                        break;
                }
                Console.WriteLine(raport);
            }
            else
            {
                Console.WriteLine("Baigėsi kuras!");
            }
        }

        public void UseAmmo()
        {
            if (_ammo > 0)
            {
                _ammo--;
            }
            Console.WriteLine($"Būūūūm! Liko šovinių: {_ammo}");
        }

        private string BurnFuel() {
            if (_fuel > 0)
            {
                _fuel--;
            }
            return $"Kuro likutis: {_fuel}";
        }

        public void Info() {
            Console.WriteLine();
            Console.WriteLine($"****** Informacija apie: {_name} ******");
            Console.WriteLine(_position);
            Console.WriteLine(TranslateDirections());
            if (_totalShots > 1) {
                Console.WriteLine($"Tanko iššauti šoviniai:{_totalShots}");
            }
            Console.WriteLine(ShotsToVariousDirections());         
            Console.WriteLine(AllShotsInfo());
        }


        public Coordinates GetPosition()
        {
            return _position;
        }
        public void SetPosition(Coordinates position)
        {
            _position = position;
        }

        public Directions GetDirection()
        {
            return _direction;
        }
        public void SetDirection(Directions direction)
        {
            _direction = direction;
        }

        public int GetAmmo()
        {
            return _ammo;
        }
        public void SetAmmo(int ammo)
        {
            _ammo = ammo;
        }

        public int GetFuel()
        {
            return _fuel;
        }
        public void SetFuel(int fuel)
        {
            _fuel = fuel;
        }
    }
}
