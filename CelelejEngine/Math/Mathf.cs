﻿using System;
using System.ComponentModel;

namespace CelelejEngine
{
    /// <summary>
    ///   A collection of common math functions.
    /// </summary>
    public struct Mathf
    {
        /// <summary>
        ///   The value for which all absolute numbers smaller than are considered equal to zero.
        /// </summary>
        public const float Epsilon = 1e-6f;

        /// <summary>
        ///   A value specifying the approximation of π which is 180 degrees.
        /// </summary>
        public const float Pi = (float)Math.PI;

        /// <summary>
        ///   A value specifying the approximation of 2π which is 360 degrees.
        /// </summary>
        public const float TwoPi = (float)(2 * Math.PI);

        /// <summary>
        ///   A value specifying the approximation of π/2 which is 90 degrees.
        /// </summary>
        public const float PiOverTwo = (float)(Math.PI / 2);

        /// <summary>
        ///   A value specifying the approximation of π/4 which is 45 degrees.
        /// </summary>
        public const float PiOverFour = (float)(Math.PI / 4);

        /// <summary>
        ///   A representation of positive infinity (Read Only).
        /// </summary>
        public const float Infinity = float.PositiveInfinity;

        /// <summary>
        ///   A representation of negative infinity (Read Only).
        /// </summary>
        public const float NegativeInfinity = float.NegativeInfinity;

        /// <summary>
        ///   Degrees-to-radians conversion constant (Read Only).
        /// </summary>
        public const float Deg2Rad = 0.0174532924f;

        /// <summary>
        ///   Radians-to-degrees conversion constant (Read Only).
        /// </summary>
        public const float Rad2Deg = 57.29578f;

        /// <summary>
        ///   Returns the absolute value of f.
        /// </summary>
        /// <param name="f"></param>
        public static float Abs(float f)
        {
            return Math.Abs(f);
        }

        /// <summary>
        ///   Returns the absolute value of value.
        /// </summary>
        /// <param name="value"></param>
        public static int Abs(int value)
        {
            return Math.Abs(value);
        }

        /// <summary>
        ///   Returns the arc-cosine of f - the angle in radians whose cosine is f.
        /// </summary>
        /// <param name="f"></param>
        public static float Acos(float f)
        {
            return (float)Math.Acos(f);
        }

        /// <summary>
        ///   Compares two floating point values if they are similar.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static bool Approximately(float a, float b)
        {
            return Abs(b - a) < Max(1E-06f * Max(Abs(a), Abs(b)), Epsilon * 8f);
        }

        /// <summary>
        ///   Returns the arc-sine of f - the angle in radians whose sine is f.
        /// </summary>
        /// <param name="f"></param>
        public static float Asin(float f)
        {
            return (float)Math.Asin(f);
        }

        /// <summary>
        ///   Returns the arc-tangent of f - the angle in radians whose tangent is f.
        /// </summary>
        /// <param name="f"></param>
        public static float Atan(float f)
        {
            return (float)Math.Atan(f);
        }

        /// <summary>
        ///   Returns the angle in radians whose Tan is y/x.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        public static float Atan2(float y, float x)
        {
            return (float)Math.Atan2(y, x);
        }

        /// <summary>
        ///   Returns the smallest integer greater to or equal to f.
        /// </summary>
        /// <param name="f"></param>
        public static float Ceil(float f)
        {
            return (float)Math.Ceiling(f);
        }

        /// <summary>
        ///   Returns the smallest integer greater to or equal to f.
        /// </summary>
        /// <param name="f"></param>
        public static int CeilToInt(float f)
        {
            return (int)Math.Ceiling(f);
        }

        /// <summary>
        ///   Clamps value between 0 and 1 and returns value.
        /// </summary>
        /// <param name="value"></param>
        public static float Clamp01(float value)
        {
            if (value < 0f)
                return 0f;
            if (value > 1f)
                return 1f;
            return value;
        }

        /// <summary>
        ///   Returns the cosine of angle f in radians.
        /// </summary>
        /// <param name="f"></param>
        public static float Cos(float f)
        {
            return (float)Math.Cos(f);
        }

        /// <summary>
        ///   Calculates the shortest difference between two given angles given in degrees.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        public static float DeltaAngle(float current, float target)
        {
            float single = Repeat(target - current, 360f);
            if (single > 180f)
                single = single - 360f;
            return single;
        }

        /// <summary>
        ///   Returns e raised to the specified power.
        /// </summary>
        /// <param name="power"></param>
        public static float Exp(float power)
        {
            return (float)Math.Exp(power);
        }

        /// <summary>
        ///   Returns the largest integer smaller to or equal to f.
        /// </summary>
        /// <param name="f"></param>
        public static float Floor(float f)
        {
            return (float)Math.Floor(f);
        }

        /// <summary>
        ///   Returns the largest integer smaller to or equal to f.
        /// </summary>
        /// <param name="f"></param>
        public static int FloorToInt(float f)
        {
            return (int)Math.Floor(f);
        }

        public static float Gamma(float value, float absmax, float gamma)
        {
            bool flag = value < 0f;
            float single = Abs(value);
            if (single > absmax)
                return !flag ? single : -single;
            float single1 = Pow(single / absmax, gamma) * absmax;
            return !flag ? single1 : -single1;
        }
        
        /// <summary>
        ///   Calculates the linear parameter t that produces the interpolant value within the range [a, b].
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="value"></param>
        public static float InverseLerp(float a, float b, float value)
        {
            if (a == b)
                return 0f;
            return Clamp01((value - a) / (b - a));
        }
        
        /// <summary>
        ///   Same as Lerp but makes sure the values interpolate correctly when they wrap around 360 degrees.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        public static float LerpAngle(float a, float b, float t)
        {
            float single = Repeat(b - a, 360f);
            if (single > 180f)
                single = single - 360f;
            return a + single * Clamp01(t);
        }

        /// <summary>
        ///   Linearly interpolates between a and b by t.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="t"></param>
        public static float LerpUnclamped(float a, float b, float t)
        {
            return a + (b - a) * t;
        }
        
        internal static bool LineIntersection(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, ref Vector2 result)
        {
            float single = p2.X - p1.X;
            float single1 = p2.Y - p1.Y;
            float single2 = p4.X - p3.X;
            float single3 = p4.Y - p3.Y;
            float single4 = single * single3 - single1 * single2;
            if (single4 == 0f)
                return false;
            float single5 = p3.X - p1.X;
            float single6 = p3.Y - p1.Y;
            float single7 = (single5 * single3 - single6 * single2) / single4;
            result = new Vector2(p1.X + single7 * single, p1.Y + single7 * single1);
            return true;
        }

        internal static bool LineSegmentIntersection(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, ref Vector2 result)
        {
            float single = p2.X - p1.X;
            float single1 = p2.Y - p1.Y;
            float single2 = p4.X - p3.X;
            float single3 = p4.Y - p3.Y;
            float single4 = single * single3 - single1 * single2;
            if (single4 == 0f)
                return false;
            float single5 = p3.X - p1.X;
            float single6 = p3.Y - p1.Y;
            float single7 = (single5 * single3 - single6 * single2) / single4;
            if ((single7 < 0f) || (single7 > 1f))
                return false;
            float single8 = (single5 * single1 - single6 * single) / single4;
            if ((single8 < 0f) || (single8 > 1f))
                return false;
            result = new Vector2(p1.X + single7 * single, p1.Y + single7 * single1);
            return true;
        }

        /// <summary>
        ///   Returns the logarithm of a specified number in a specified base.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="p"></param>
        public static float Log(float f, float p)
        {
            return (float)Math.Log(f, p);
        }

        /// <summary>
        ///   Returns the natural (base e) logarithm of a specified number.
        /// </summary>
        /// <param name="f"></param>
        public static float Log(float f)
        {
            return (float)Math.Log(f);
        }

        /// <summary>
        ///   Returns the base 10 logarithm of a specified number.
        /// </summary>
        /// <param name="f"></param>
        public static float Log10(float f)
        {
            return (float)Math.Log10(f);
        }

        /// <summary>
        ///   Returns largest of two or more values.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static float Max(float a, float b)
        {
            return a <= b ? b : a;
        }

        /// <summary>
        ///   Returns largest of two or more values.
        /// </summary>
        /// <param name="values"></param>
        public static float Max(params float[] values)
        {
            int length = values.Length;
            if (length == 0)
                return 0f;

            float single = values[0];
            for (var i = 1; i < length; i++)
                if (values[i] > single)
                    single = values[i];

            return single;
        }

        /// <summary>
        ///   Returns the largest of two or more values.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static int Max(int a, int b)
        {
            return a <= b ? b : a;
        }

        /// <summary>
        ///   Returns the largest of two or more values.
        /// </summary>
        /// <param name="values"></param>
        public static int Max(params int[] values)
        {
            int length = values.Length;
            if (length == 0)
                return 0;

            int num = values[0];
            for (var i = 1; i < length; i++)
                if (values[i] > num)
                    num = values[i];

            return num;
        }

        /// <summary>
        ///   Returns the smallest of two or more values.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static float Min(float a, float b)
        {
            return a >= b ? b : a;
        }

        /// <summary>
        ///   Returns the smallest of two or more values.
        /// </summary>
        /// <param name="values"></param>
        public static float Min(params float[] values)
        {
            int length = values.Length;
            if (length == 0)
                return 0f;

            float single = values[0];
            for (var i = 1; i < length; i++)
                if (values[i] < single)
                    single = values[i];

            return single;
        }

        /// <summary>
        ///   Returns the smallest of two or more values.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public static int Min(int a, int b)
        {
            return a >= b ? b : a;
        }

        /// <summary>
        ///   Returns the smallest of two or more values.
        /// </summary>
        /// <param name="values"></param>
        public static int Min(params int[] values)
        {
            int length = values.Length;
            if (length == 0)
                return 0;

            int num = values[0];
            for (var i = 1; i < length; i++)
                if (values[i] < num)
                    num = values[i];

            return num;
        }

        /// <summary>
        ///   Moves a value current towards target.
        /// </summary>
        /// <param name="current">The current value.</param>
        /// <param name="target">The value to move towards.</param>
        /// <param name="maxDelta">The maximum change that should be applied to the value.</param>
        public static float MoveTowards(float current, float target, float maxDelta)
        {
            if (Abs(target - current) <= maxDelta)
                return target;
            return current + Sign(target - current) * maxDelta;
        }

        /// <summary>
        ///   Same as MoveTowards but makes sure the values interpolate correctly when they wrap around 360 degrees.
        /// </summary>
        /// <param name="current"></param>
        /// <param name="target"></param>
        /// <param name="maxDelta"></param>
        public static float MoveTowardsAngle(float current, float target, float maxDelta)
        {
            float single = DeltaAngle(current, target);
            if ((-maxDelta < single) && (single < maxDelta))
                return target;
            target = current + single;
            return MoveTowards(current, target, maxDelta);
        }
        
        /// <summary>
        ///   PingPongs the value t, so that it is never larger than length and never smaller than 0.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="length"></param>
        public static float PingPong(float t, float length)
        {
            t = Repeat(t, length * 2f);
            return length - Abs(t - length);
        }

        /// <summary>
        ///   Returns f raised to power p.
        /// </summary>
        /// <param name="f"></param>
        /// <param name="p"></param>
        public static float Pow(float f, float p)
        {
            return (float)Math.Pow(f, p);
        }

        internal static long RandomToLong(System.Random r)
        {
            var numArray = new byte[8];
            r.NextBytes(numArray);
            return (long)(BitConverter.ToUInt64(numArray, 0) & 9223372036854775807L);
        }

        /// <summary>
        ///   Loops the value t, so that it is never larger than length and never smaller than 0.
        /// </summary>
        /// <param name="t"></param>
        /// <param name="length"></param>
        public static float Repeat(float t, float length)
        {
            return t - Floor(t / length) * length;
        }

        /// <summary>
        ///   Returns f rounded to the nearest integer.
        /// </summary>
        /// <param name="f"></param>
        public static float Round(float f)
        {
            return (float)Math.Round(f);
        }

        /// <summary>
        ///   Returns f rounded to the nearest integer.
        /// </summary>
        /// <param name="f"></param>
        public static int RoundToInt(float f)
        {
            return (int)Math.Round(f);
        }

        /// <summary>
        ///   Returns the sign of f.
        /// </summary>
        /// <param name="f"></param>
        public static float Sign(float f)
        {
            return f < 0f ? -1f : 1f;
        }

        /// <summary>
        ///   Returns the sine of angle f in radians.
        /// </summary>
        /// <param name="f"></param>
        public static float Sin(float f)
        {
            return (float)Math.Sin(f);
        }

        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed)
        {
            float single = Time.deltaTime;
            return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, single);
        }

        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime)
        {
            float single = Time.deltaTime;
            return SmoothDamp(current, target, ref currentVelocity, smoothTime, float.PositiveInfinity, single);
        }

        public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, [DefaultValue("Mathf.Infinity")] float maxSpeed, [DefaultValue("Time.deltaTime")] float deltaTime)
        {
            smoothTime = Max(0.0001f, smoothTime);
            float single = 2f / smoothTime;
            float single1 = single * deltaTime;
            float single2 = 1f / (1f + single1 + 0.48f * single1 * single1 + 0.235f * single1 * single1 * single1);
            float single3 = current - target;
            float single4 = target;
            float single5 = maxSpeed * smoothTime;
            single3 = Clamp(single3, -single5, single5);
            target = current - single3;
            float single6 = (currentVelocity + single * single3) * deltaTime;
            currentVelocity = (currentVelocity - single * single6) * single2;
            float single7 = target + (single3 + single6) * single2;
            if (single4 - current > 0f == single7 > single4)
            {
                single7 = single4;
                currentVelocity = (single7 - single4) / deltaTime;
            }
            return single7;
        }

        public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed)
        {
            float single = Time.deltaTime;
            return SmoothDampAngle(current, target, ref currentVelocity, smoothTime, maxSpeed, single);
        }

        public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime)
        {
            float single = Time.deltaTime;
            return SmoothDampAngle(current, target, ref currentVelocity, smoothTime, float.PositiveInfinity, single);
        }

        public static float SmoothDampAngle(float current, float target, ref float currentVelocity, float smoothTime, [DefaultValue("Mathf.Infinity")] float maxSpeed, [DefaultValue("Time.deltaTime")] float deltaTime)
        {
            target = current + DeltaAngle(current, target);
            return SmoothDamp(current, target, ref currentVelocity, smoothTime, maxSpeed, deltaTime);
        }

        /// <summary>
        ///   Interpolates between min and max with smoothing at the limits.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="t"></param>
        public static float SmoothStep(float from, float to, float t)
        {
            t = Clamp01(t);
            t = -2f * t * t * t + 3f * t * t;
            return to * t + from * (1f - t);
        }

        /// <summary>
        ///   Returns square root of f.
        /// </summary>
        /// <param name="f"></param>
        public static float Sqrt(float f)
        {
            return (float)Math.Sqrt(f);
        }

        /// <summary>
        ///   Returns the tangent of angle f in radians.
        /// </summary>
        /// <param name="f"></param>
        public static float Tan(float f)
        {
            return (float)Math.Tan(f);
        }

        /// <summary>
        ///   Checks if a and b are almost equals, taking into account the magnitude of floating point numbers (unlike
        ///   <see cref="WithinEpsilon" /> method). See Remarks.
        ///   See remarks.
        /// </summary>
        /// <param name="a">The left value to compare.</param>
        /// <param name="b">The right value to compare.</param>
        /// <returns><c>true</c> if a almost equal to b, <c>false</c> otherwise</returns>
        /// <remarks>
        ///   The code is using the technique described by Bruce Dawson in
        ///   <a href="http://randomascii.wordpress.com/2012/02/25/comparing-floating-point-numbers-2012-edition/">
        ///     Comparing
        ///     Floating point numbers 2012 edition
        ///   </a>
        ///   .
        /// </remarks>
        public static unsafe bool NearEqual(float a, float b)
        {
            // Check if the numbers are really close -- needed
            // when comparing numbers near zero.
            if (IsZero(a - b))
                return true;

            // Original from Bruce Dawson: http://randomascii.wordpress.com/2012/02/25/comparing-floating-point-numbers-2012-edition/
            int aInt = *(int*)&a;
            int bInt = *(int*)&b;

            // Different signs means they do not match.
            if (aInt < 0 != bInt < 0)
                return false;

            // Find the difference in ULPs.
            int ulp = Math.Abs(aInt - bInt);

            // Choose of maxUlp = 4
            // according to http://code.google.com/p/googletest/source/browse/trunk/include/gtest/internal/gtest-internal.h
            const int maxUlp = 4;
            return ulp <= maxUlp;
        }

        /// <summary>
        ///   Determines whether the specified value is close to zero (0.0f).
        /// </summary>
        /// <param name="a">The floating value.</param>
        /// <returns><c>true</c> if the specified value is close to zero (0.0f); otherwise, <c>false</c>.</returns>
        public static bool IsZero(float a)
        {
            return Math.Abs(a) < Epsilon;
        }

        /// <summary>
        ///   Determines whether the specified value is close to one (1.0f).
        /// </summary>
        /// <param name="a">The floating value.</param>
        /// <returns><c>true</c> if the specified value is close to one (1.0f); otherwise, <c>false</c>.</returns>
        public static bool IsOne(float a)
        {
            return IsZero(a - 1.0f);
        }

        /// <summary>
        ///   Checks if a - b are almost equals within a float epsilon.
        /// </summary>
        /// <param name="a">The left value to compare.</param>
        /// <param name="b">The right value to compare.</param>
        /// <param name="epsilon">Epsilon value</param>
        /// <returns><c>true</c> if a almost equal to b within a float epsilon, <c>false</c> otherwise</returns>
        public static bool WithinEpsilon(float a, float b, float epsilon)
        {
            float num = a - b;
            return (-epsilon <= num) && (num <= epsilon);
        }

        /// <summary>
        ///   Converts revolutions to degrees.
        /// </summary>
        /// <param name="revolution">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static float RevolutionsToDegrees(float revolution)
        {
            return revolution * 360.0f;
        }

        /// <summary>
        ///   Converts revolutions to radians.
        /// </summary>
        /// <param name="revolution">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static float RevolutionsToRadians(float revolution)
        {
            return revolution * TwoPi;
        }

        /// <summary>
        ///   Converts revolutions to gradians.
        /// </summary>
        /// <param name="revolution">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static float RevolutionsToGradians(float revolution)
        {
            return revolution * 400.0f;
        }

        /// <summary>
        ///   Converts degrees to revolutions.
        /// </summary>
        /// <param name="degree">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static float DegreesToRevolutions(float degree)
        {
            return degree / 360.0f;
        }

        /// <summary>
        ///   Converts degrees to radians.
        /// </summary>
        /// <param name="degree">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static float DegreesToRadians(float degree)
        {
            return degree * (Pi / 180.0f);
        }

        /// <summary>
        ///   Converts radians to revolutions.
        /// </summary>
        /// <param name="radian">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static float RadiansToRevolutions(float radian)
        {
            return radian / TwoPi;
        }

        /// <summary>
        ///   Converts radians to gradians.
        /// </summary>
        /// <param name="radian">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static float RadiansToGradians(float radian)
        {
            return radian * (200.0f / Pi);
        }

        /// <summary>
        ///   Converts gradians to revolutions.
        /// </summary>
        /// <param name="gradian">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static float GradiansToRevolutions(float gradian)
        {
            return gradian / 400.0f;
        }

        /// <summary>
        ///   Converts gradians to degrees.
        /// </summary>
        /// <param name="gradian">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static float GradiansToDegrees(float gradian)
        {
            return gradian * (9.0f / 10.0f);
        }

        /// <summary>
        ///   Converts gradians to radians.
        /// </summary>
        /// <param name="gradian">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static float GradiansToRadians(float gradian)
        {
            return gradian * (Pi / 200.0f);
        }

        /// <summary>
        ///   Converts radians to degrees.
        /// </summary>
        /// <param name="radian">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static float RadiansToDegrees(float radian)
        {
            return radian * (180.0f / Pi);
        }

        /// <summary>
        ///   Clamps the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <returns>The result of clamping a value between min and max</returns>
        public static float Clamp(float value, float min, float max)
        {
            return value < min ? min : value > max ? max : value;
        }

        /// <summary>
        ///   Clamps the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <returns>The result of clamping a value between min and max</returns>
        public static int Clamp(int value, int min, int max)
        {
            return value < min ? min : value > max ? max : value;
        }

        /// <summary>
        ///   Interpolates between two values using a linear function by a given amount.
        /// </summary>
        /// <remarks>
        ///   See http://www.encyclopediaofmath.org/index.php/Linear_interpolation and
        ///   http://fgiesen.wordpress.com/2012/08/15/linear-interpolation-past-present-and-future/
        /// </remarks>
        /// <param name="from">Value to interpolate from.</param>
        /// <param name="to">Value to interpolate to.</param>
        /// <param name="amount">Interpolation amount.</param>
        /// <returns>The result of linear interpolation of values based on the amount.</returns>
        public static double Lerp(double from, double to, double amount)
        {
            return (1 - amount) * from + amount * to;
        }

        /// <summary>
        ///   Interpolates between two values using a linear function by a given amount.
        /// </summary>
        /// <remarks>
        ///   See http://www.encyclopediaofmath.org/index.php/Linear_interpolation and
        ///   http://fgiesen.wordpress.com/2012/08/15/linear-interpolation-past-present-and-future/
        /// </remarks>
        /// <param name="from">Value to interpolate from.</param>
        /// <param name="to">Value to interpolate to.</param>
        /// <param name="amount">Interpolation amount.</param>
        /// <returns>The result of linear interpolation of values based on the amount.</returns>
        public static float Lerp(float from, float to, float amount)
        {
            return (1 - amount) * from + amount * to;
        }

        /// <summary>
        ///   Interpolates between two values using a linear function by a given amount.
        /// </summary>
        /// <remarks>
        ///   See http://www.encyclopediaofmath.org/index.php/Linear_interpolation and
        ///   http://fgiesen.wordpress.com/2012/08/15/linear-interpolation-past-present-and-future/
        /// </remarks>
        /// <param name="from">Value to interpolate from.</param>
        /// <param name="to">Value to interpolate to.</param>
        /// <param name="amount">Interpolation amount.</param>
        /// <returns>The result of linear interpolation of values based on the amount.</returns>
        public static byte Lerp(byte from, byte to, float amount)
        {
            return (byte)Lerp(from, (float)to, amount);
        }

        /// <summary>
        ///   Performs smooth (cubic Hermite) interpolation between 0 and 1.
        /// </summary>
        /// <remarks>
        ///   See https://en.wikipedia.org/wiki/Smoothstep
        /// </remarks>
        /// <param name="amount">Value between 0 and 1 indicating interpolation amount.</param>
        public static float SmoothStep(float amount)
        {
            return amount <= 0 ? 0
                : amount >= 1 ? 1
                    : amount * amount * (3 - 2 * amount);
        }

        /// <summary>
        ///   Performs a smooth(er) interpolation between 0 and 1 with 1st and 2nd order derivatives of zero at endpoints.
        /// </summary>
        /// <remarks>
        ///   See https://en.wikipedia.org/wiki/Smoothstep
        /// </remarks>
        /// <param name="amount">Value between 0 and 1 indicating interpolation amount.</param>
        public static float SmootherStep(float amount)
        {
            return amount <= 0 ? 0
                : amount >= 1 ? 1
                    : amount * amount * amount * (amount * (amount * 6 - 15) + 10);
        }

        /// <summary>
        ///   Calculates the modulo of the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="modulo">The modulo.</param>
        /// <returns>The result of the modulo applied to value</returns>
        public static float Mod(float value, float modulo)
        {
            if (modulo == 0.0f)
                return value;

            return value % modulo;
        }

        /// <summary>
        ///   Calculates the modulo 2*PI of the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the modulo applied to value</returns>
        public static float Mod2PI(float value)
        {
            return Mod(value, TwoPi);
        }

        /// <summary>
        ///   Wraps the specified value into a range [min, max]
        /// </summary>
        /// <param name="value">The value to wrap.</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <returns>Result of the wrapping.</returns>
        /// <exception cref="ArgumentException">Is thrown when <paramref name="min" /> is greater than <paramref name="max" />.</exception>
        public static int Wrap(int value, int min, int max)
        {
            if (min > max)
                throw new ArgumentException(string.Format("min {0} should be less than or equal to max {1}", min, max), "min");

            // Code from http://stackoverflow.com/a/707426/1356325
            int range_size = max - min + 1;

            if (value < min)
                value += range_size * ((min - value) / range_size + 1);

            return min + (value - min) % range_size;
        }

        /// <summary>
        ///   Wraps the specified value into a range [min, max]
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="min">The min.</param>
        /// <param name="max">The max.</param>
        /// <returns>Result of the wrapping.</returns>
        /// <exception cref="ArgumentException">Is thrown when <paramref name="min" /> is greater than <paramref name="max" />.</exception>
        public static float Wrap(float value, float min, float max)
        {
            if (NearEqual(min, max))
                return min;

            double mind = min;
            double maxd = max;
            double valued = value;

            if (mind > maxd)
                throw new ArgumentException(string.Format("min {0} should be less than or equal to max {1}", min, max), "min");

            double range_size = maxd - mind;
            return (float)(mind + (valued - mind) - range_size * Math.Floor((valued - mind) / range_size));
        }

        /// <summary>
        ///   Gauss function.
        ///   http://en.wikipedia.org/wiki/Gaussian_function#Two-dimensional_Gaussian_function
        /// </summary>
        /// <param name="amplitude">Curve amplitude.</param>
        /// <param name="x">Position X.</param>
        /// <param name="y">Position Y</param>
        /// <param name="centerX">Center X.</param>
        /// <param name="centerY">Center Y.</param>
        /// <param name="sigmaX">Curve sigma X.</param>
        /// <param name="sigmaY">Curve sigma Y.</param>
        /// <returns>The result of Gaussian function.</returns>
        public static float Gauss(float amplitude, float x, float y, float centerX, float centerY, float sigmaX, float sigmaY)
        {
            return (float)Gauss((double)amplitude, x, y, centerX, centerY, sigmaX, sigmaY);
        }

        /// <summary>
        ///   Gauss function.
        ///   http://en.wikipedia.org/wiki/Gaussian_function#Two-dimensional_Gaussian_function
        /// </summary>
        /// <param name="amplitude">Curve amplitude.</param>
        /// <param name="x">Position X.</param>
        /// <param name="y">Position Y</param>
        /// <param name="centerX">Center X.</param>
        /// <param name="centerY">Center Y.</param>
        /// <param name="sigmaX">Curve sigma X.</param>
        /// <param name="sigmaY">Curve sigma Y.</param>
        /// <returns>The result of Gaussian function.</returns>
        public static double Gauss(double amplitude, double x, double y, double centerX, double centerY, double sigmaX, double sigmaY)
        {
            double cx = x - centerX;
            double cy = y - centerY;

            double componentX = cx * cx / (2 * sigmaX * sigmaX);
            double componentY = cy * cy / (2 * sigmaY * sigmaY);

            return amplitude * Math.Exp(-(componentX + componentY));
        }
    }
}