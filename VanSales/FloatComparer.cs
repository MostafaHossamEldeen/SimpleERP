using System;
using System.Diagnostics.CodeAnalysis;

namespace VanSales
{
    /// <summary>
    /// Compares the first 7 digits of two float values.
    /// </summary>
    public static class FloatComparer
    {
        #region Constants

        private const float FloatZero = 0.0f;

        /// <summary>
        /// Defines the Epsilon for comparing a value with zero.
        /// </summary>
        internal const float ZeroCompareEpsilon = 0.0000001f;

        /// <summary>
        /// The number of digits to compare two float values.
        /// </summary>
        private const int CompareDigitsCount = 7;

        private const int DecimalSystemBase = 10;

        /// <summary>
        /// The equality multiplier.
        /// </summary>
        internal static readonly float EqualityMultiplier = (float)Math.Pow(DecimalSystemBase, -CompareDigitsCount);

        #endregion

        #region Methods

        /// <summary>
        /// Compares the specified float values.
        /// </summary>
        /// <param name="x">The first float value.</param>
        /// <param name="y">The second float value.</param>
        /// <param name="digits">The digits.</param>
        /// <returns>
        /// 0 if the values are equal for the given number of digits, -1 if x is smaller than y, +1 if x is larger than y.
        /// </returns>
        public static int Compare(this float x, float y, int? digits)
        {
            if (digits.HasValue)
            {
                return Compare(
                    x,
                    y,
                    (float)Math.Pow(DecimalSystemBase, -digits.Value));
            }
            else
            {
                return Compare(x, y);
            }
        }

        /// <summary>
        /// Compares two float values with
        /// an dynamic epsilon
        /// If one of the float values is 0.0 it compares directly against Epsilon.
        /// </summary>
        /// <param name="x">The first float value.</param>
        /// <param name="y">The second float values.</param>
        /// <returns>
        /// Returns 0 if the first 14 digits are equal, -1 if x is smaller than y, +1 if x is larger than y.
        /// </returns>
        [SuppressMessage("ReSharper", "CompareOfFloatsByEqualityOperator", Justification = "It is correct here.GüHa")]
        [SuppressMessage("Reliability", "S1244:Floating point numbers should not be tested for equality", Justification = "Special case here.GüHa")]
        [SuppressMessage("Maintainability", "S1541:Methods should not be too complex", Justification = "Better readability.GüHa")]
        public static int Compare(this float x, float y, float? equalityMultiplier = null)
        {
            if (float.IsPositiveInfinity(x))
            {
                return float.IsPositiveInfinity(y) ? 0 : 1;
            }

            if (float.IsNegativeInfinity(x))
            {
                return float.IsNegativeInfinity(y) ? 0 : -1;
            }

            if (x == 0.0 && Math.Abs(y) < ZeroCompareEpsilon)
            {
                return 0;
            }

            if (y == 0.0 && Math.Abs(x) < ZeroCompareEpsilon)
            {
                return 0;
            }

            if (Math.Abs(x - y) <= Math.Abs(x * (equalityMultiplier ?? EqualityMultiplier)))
            {
                return 0;
            }

            return x < y ? -1 : 1;
        }

        /// <summary>
        /// Compares two float values with a dynamic epsilon and digits for rounding.
        /// </summary>
        /// <param name="x">The first float value.</param>
        /// <param name="y">The second float values.</param>
        /// <param name="digits">The digits.</param>
        /// <returns>
        /// <c>true</c> if the first values are equal with the given precision; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEqual(this float x, float y, int? digits)
        {
            return Compare(x, y, digits) == 0;
        }

        /// <summary>
        /// Determines whether the specified float value is equal to the second value.
        /// </summary>
        /// <param name="x">The first float value.</param>
        /// <param name="y">The second float values.</param>
        /// <returns>
        /// <c>true</c> if the first values are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEqual(this float x, float y)
        {
            return Compare(x, y) == 0;
        }

        /// <summary>
        /// Determines whether the specified float value is equal to the second value.
        /// </summary>
        /// <param name="x">The first float value.</param>
        /// <param name="y">The second float? values.</param>
        /// <returns>
        /// <c>true</c> if the first values are equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEqual(this float x, float? y)
        {
            if (!y.HasValue)
            {
                return false;
            }

            return Compare(x, y.Value) == 0;
        }

        /// <summary>
        /// Determines whether the specified float value is larger than the second.
        /// </summary>
        /// <param name="x">The first float value.</param>
        /// <param name="y">The second float values.</param>
        /// <returns>
        /// <c>true</c> if the first value is larger than the second value; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsLarger(this float x, float y)
        {
            return Compare(x, y) > 0;
        }

        /// <summary>
        /// Determines whether the specified float value is larger than the second.
        /// </summary>
        /// <param name="x">The first float value.</param>
        /// <param name="y">The second float? values.</param>
        /// <returns>
        /// <c>true</c> if the first value is larger than the second value; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsLarger(this float x, float? y)
        {
            if (!y.HasValue)
            {
                return false;
            }

            return Compare(x, y.Value) > 0;
        }

        /// <summary>
        /// Determines whether the first float value is larger than the second.
        /// </summary>
        /// <param name="x">The first float value.</param>
        /// <param name="y">The second float values.</param>
        /// <returns>
        /// <c>true</c> if the first value is larger than or equal to the second value; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsLargerOrEqual(this float x, float y)
        {
            return Compare(x, y) >= 0;
        }

        /// <summary>
        /// Determines whether the first float value is larger than the second.
        /// </summary>
        /// <param name="x">The first float value.</param>
        /// <param name="y">The second float? values.</param>
        /// <returns>
        /// <c>true</c> if the first value is larger than or equal to the second value; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsLargerOrEqual(this float x, float? y)
        {
            if (!y.HasValue)
            {
                return false;
            }

            return Compare(x, y.Value) >= 0;
        }

        /// <summary>
        /// Determines whether the specified float value is smaller than the second value.
        /// </summary>
        /// <param name="x">The first float value.</param>
        /// <param name="y">The second float values.</param>
        /// <returns>
        /// <c>true</c> if the first value is smaller than the second value; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSmaller(this float x, float y)
        {
            return Compare(x, y) < 0;
        }

        /// <summary>
        /// Determines whether the specified float value is smaller than the second value.
        /// </summary>
        /// <param name="x">The first float value.</param>
        /// <param name="y">The second float? values.</param>
        /// <returns>
        /// <c>true</c> if the first value is smaller than the second value; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSmaller(this float x, float? y)
        {
            if (!y.HasValue)
            {
                return false;
            }

            return Compare(x, y.Value) < 0;
        }

        /// <summary>
        /// Determines whether the first float value is smaller than the second value.
        /// </summary>
        /// <param name="x">The first float value.</param>
        /// <param name="y">The second float values.</param>
        /// <returns>
        /// <c>true</c> if the first value is smaller than or equal to the second value; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSmallerOrEqual(this float x, float y)
        {
            return Compare(x, y) <= 0;
        }

        /// <summary>
        /// Determines whether the first float value is smaller than the second value.
        /// </summary>
        /// <param name="x">The first float value.</param>
        /// <param name="y">The second float? values.</param>
        /// <returns>
        /// <c>true</c> if the first value is smaller than or equal to the second value; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsSmallerOrEqual(this float x, float? y)
        {
            if (!y.HasValue)
            {
                return false;
            }

            return Compare(x, y.Value) <= 0;
        }

        /// <summary>
        /// Determines whether the specified float value is positive.
        /// </summary>
        /// <param name="x">The float value.</param>
        /// <returns>
        ///   <c>true</c> if the specified x is positive; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPositive(this float x)
        {
            return Compare(x, FloatZero) > 0;
        }

        /// <summary>
        /// Determines whether the given value is negative.
        /// </summary>
        /// <param name="x">The float value.</param>
        /// <returns>
        /// <c>true</c> if the given value is negative.
        /// </returns>
        public static bool IsNegative(this float x)
        {
            return Compare(x, FloatZero) < 0;
        }

        /// <summary>
        /// Determines whether the given value is negative or zero.
        /// </summary>
        /// <param name="x">The float value.</param>
        /// <returns>
        /// <c>true</c> if the given value is negative or zero.
        /// </returns>
        public static bool IsNegativeOrZero(this float x)
        {
            return Compare(x, FloatZero) <= 0;
        }

        /// <summary>
        /// Determines whether the specified float value is zero.
        /// </summary>
        /// <param name="x">The float value.</param>
        /// <returns>
        /// <c>true</c> if the specified x is zero; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsZero(this float x)
        {
            return IsEqual(x, FloatZero);
        }

        /// <summary>
        /// Determines whether the specified x is nan.
        /// </summary>
        /// <param name="x">The float value.</param>
        /// <returns>
        ///   <c>true</c> if the specified x is nan; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNan(this float x)
        {
            return float.IsNaN(x);
        }

        /// <summary>
        /// Determines whether the specified x is infinity.
        /// </summary>
        /// <param name="x">The float value.</param>
        /// <returns>
        ///   <c>true</c> if the specified x is infinity; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsInfinity(this float x)
        {
            return float.IsInfinity(x);
        }

        #endregion
    }
}
