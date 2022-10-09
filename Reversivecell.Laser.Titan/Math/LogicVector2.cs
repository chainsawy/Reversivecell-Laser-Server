namespace Reversivecell.Laser.Titan.Math
{
    using Reversivecell.Laser.Titan.DataStream;

    public class LogicVector2
    {
        private int _x;
        private int _y;

        public LogicVector2()
        {
        }

        public LogicVector2(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        public void Destruct()
        {
            this._x = 0;
            this._y = 0;
        }
        
        public void Add(LogicVector2 vector2)
        {
            this._x += vector2._x;
            this._y += vector2._y;
        }

        public LogicVector2 Clone()
        {
            return new LogicVector2(this._x, this._y);
        }

        public int Dot(LogicVector2 vector2)
        {
            return this._x * vector2._x + this._y * vector2._y;
        }

        public int GetAngle()
        {
            return LogicMath.GetAngle(this._x, this._y);
        }

        public int GetAngleBetween(int x, int y)
        {
            return LogicMath.GetAngleBetween(LogicMath.GetAngle(this._x, this._y), LogicMath.GetAngle(x, y));
        }

        public int GetDistance(LogicVector2 vector2)
        {
            int x = this._x - vector2._x;
            int distance = 0x7FFFFFFF;

            if ((uint) (x + 46340) <= 92680)
            {
                int y = this._y - vector2._y;

                if ((uint) (y + 46340) <= 92680)
                {
                    int distanceX = x * x;
                    int distanceY = y * y;

                    if ((uint) distanceY < (distanceX ^ 0x7FFFFFFFu))
                    {
                        distance = distanceX + distanceY;
                    }
                }
            }

            return LogicMath.Sqrt(distance);
        }

        public int GetDistanceSquared(LogicVector2 vector2)
        {
            int x = this._x - vector2._x;
            int distance = 0x7FFFFFFF;

            if ((uint) (x + 46340) <= 92680)
            {
                int y = this._y - vector2._y;

                if ((uint) (y + 46340) <= 92680)
                {
                    int distanceX = x * x;
                    int distanceY = y * y;

                    if ((uint) distanceY < (distanceX ^ 0x7FFFFFFFu))
                    {
                        distance = distanceX + distanceY;
                    }
                }
            }

            return distance;
        }

        public int GetDistanceSquaredTo(int x, int y)
        {
            int distance = 0x7FFFFFFF;

            x -= this._x;

            if ((uint) (x + 46340) <= 92680)
            {
                y -= this._y;

                if ((uint) (y + 46340) <= 92680)
                {
                    int distanceX = x * x;
                    int distanceY = y * y;

                    if ((uint) distanceY < (distanceX ^ 0x7FFFFFFFu))
                    {
                        distance = distanceX + distanceY;
                    }
                }
            }

            return distance;
        }

        public int GetLength()
        {
            int length = 0x7FFFFFFF;

            if ((uint) (46340 - this._x) <= 92680)
            {
                if ((uint) (46340 - this._y) <= 92680)
                {
                    int lengthX = this._x * this._x;
                    int lengthY = this._y * this._y;

                    if ((uint) lengthY < (lengthX ^ 0x7FFFFFFFu))
                    {
                        length = lengthX + lengthY;
                    }
                }
            }

            return LogicMath.Sqrt(length);
        }

        public int GetLengthSquared()
        {
            int length = 0x7FFFFFFF;

            if ((uint) (46340 - this._x) <= 92680)
            {
                if ((uint) (46340 - this._y) <= 92680)
                {
                    int lengthX = this._x * this._x;
                    int lengthY = this._y * this._y;

                    if ((uint) lengthY < (lengthX ^ 0x7FFFFFFFu))
                    {
                        length = lengthX + lengthY;
                    }
                }
            }

            return length;
        }

        public bool IsEqual(LogicVector2 vector2)
        {
            return this._x == vector2._x && this._y == vector2._y;
        }

        public bool IsInArea(int minX, int minY, int maxX, int maxY)
        {
            if (this._x >= minX && this._y >= minY)
                return this._x < minX + maxX && this._y < maxY + minY;
            return false;
        }

        public void Multiply(LogicVector2 vector2)
        {
            this._x *= vector2._x;
            this._y *= vector2._y;
        }

        public int Normalize(int value)
        {
            int length = this.GetLength();

            if (length != 0)
            {
                this._x = this._x * value / length;
                this._y = this._y * value / length;
            }

            return length;
        }

        public void Rotate(int degrees)
        {
            int newX = LogicMath.GetRotatedX(this._x, this._y, degrees);
            int newY = LogicMath.GetRotatedY(this._x, this._y, degrees);

            this._x = newX;
            this._y = newY;
        }

        public int GetX()
        {
            return _x;
        }

        public int GetY()
        {
            return _y;
        }

        public void Set(int x, int y)
        {
            this._x = x;
            this._y = y;
        }

        public void Substract(LogicVector2 vector2)
        {
            this._x -= vector2._x;
            this._y -= vector2._y;
        }

        public void Decode(ByteStream stream)
        {
            this._x = stream.ReadInt();
            this._y = stream.ReadInt();
        }

        public void Encode(ChecksumEncoder stream)
        {
            stream.WriteInt(this._x);
            stream.WriteInt(this._y);
        }

        public override string ToString()
        {
            return "LogicVector2(" + this._x + "," + this._y + ")";
        }
    }
}