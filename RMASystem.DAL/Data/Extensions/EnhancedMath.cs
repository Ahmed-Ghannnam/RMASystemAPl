using System;
using RMASystem.DAL;

namespace RMASystem.DAL

{
    public static class EnhancedMath
    {
        private delegate double RoundingFunction(double value);

        private enum RoundingDirection { Up, Down }

        public static double RoundUp(double value, int precision)
        {
            return Round(value, precision, RoundingDirection.Up);
        }

        public static double RoundDown(double value, int precision)
        {
            return Round(value, precision, RoundingDirection.Down);
        }

        public static float RoundUp(float value, int precision)
        {
            return Round(value, precision, RoundingDirection.Up);
        }

        public static float RoundDown(float value, int precision)
        {
            return Round(value, precision, RoundingDirection.Down);
        }

        public static decimal RoundUp(decimal number, int places)
        {
            decimal factor = RoundFactor(places);
            number *= factor;
            number = Math.Ceiling(number);
            number /= factor;
            return number;
        }

        public static decimal RoundDown(decimal number, int places)
        {
            decimal factor = RoundFactor(places);
            number *= factor;
            number = Math.Floor(number);
            number /= factor;
            return number;
        }

        internal static decimal RoundFactor(int places)
        {
            decimal factor = 1m;

            if (places < 0)
            {
                places = -places;
                for (int i = 0; i < places; i++)
                    factor /= 10m;
            }

            else
            {
                for (int i = 0; i < places; i++)
                    factor *= 10m;
            }

            return factor;
        }

        private static double Round(double value, int precision, RoundingDirection roundingDirection)
        {
            RoundingFunction roundingFunction;
            if (roundingDirection == RoundingDirection.Up)
                roundingFunction = Math.Ceiling;
            else
                roundingFunction = Math.Floor;
            value *= Math.Pow(10, precision);
            value = roundingFunction(value);
            return value * Math.Pow(10, -1 * precision);
        }


        private static float Round(float value, int precision, RoundingDirection roundingDirection)
        {
            double dblValue = value;
            RoundingFunction roundingFunction;
            if (roundingDirection == RoundingDirection.Up)
                roundingFunction = Math.Ceiling;
            else
                roundingFunction = Math.Floor;
            dblValue *= Math.Pow(10, precision);
            dblValue = roundingFunction(dblValue);
            dblValue = dblValue * Math.Pow(10, -1 * precision);
            return (float)dblValue;
        }

        public static decimal RoundWithTruncate(this decimal value, int precision)
        {
            decimal factor = Math.Pow(10, precision).To<decimal>();
            return Math.Truncate(value * factor) / factor;
        }
    }
}
