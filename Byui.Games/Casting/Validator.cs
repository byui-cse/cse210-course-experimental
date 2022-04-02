using System;
using System.Collections;


namespace Byui.Games.Casting
{
    /// <summary>
    /// A validator for string and numeric types.
    /// </summary>
    /// <remarks>
    /// The responsibility of Validator is to check the correctness of a value.
    /// </remarks>
    public class Validator
    {

        public static void CheckGreaterThan(int value, int min) 
        {
            if (value <= min) 
            {
                throw new ArgumentOutOfRangeException(
                    $"Value of {value} must be greather than {min}.");
            }
        }

        public static void CheckGreaterThan(float value, float min) 
        {
            if (value <= min)  
            {
                throw new ArgumentOutOfRangeException(
                    $"Value of {value} must be greather than {min}.");
            }
        }

        public static void CheckGreaterThan(double value, double min) 
        {
            if (value <= min) 
            {
                throw new ArgumentOutOfRangeException(
                    $"Value of {value} must be greather than {min}.");
            }
        }

        public static void CheckInRange(int value, int min, int max) 
        {
            if (value < min || value > max) 
            {
                throw new ArgumentOutOfRangeException(
                    $"Value of {value} must be between {min} and {max}.");
            }
        }

        public static void CheckInRange(float value, float min, float max, string paramName) 
        {
            if (value < min || value > max) 
            {
                throw new ArgumentOutOfRangeException(
                    $"{paramName} of {value} must be between {min} and {max}.");
            }
        }

        public static void CheckInRange(double value, double min, double max) 
        {
            if (value < min || value > max) 
            {
                throw new ArgumentOutOfRangeException(
                    $"Value of {value} must be between {min} and {max}.");
            }
        }

        public static void CheckLessThan(int value, int max) 
        {
            if (value >= max) 
            {
                throw new ArgumentOutOfRangeException(
                    $"Value of {value} must be less than {max}.");
            }
        }

        public static void CheckLessThan(float value, float max) 
        {
            if (value >= max) 
            {
                throw new ArgumentOutOfRangeException(
                    $"Value of {value} must be less than {max}.");
            }
        }

        public static void CheckLessThan(double value, double max) 
        {
            if (value >= max) 
            {
                throw new ArgumentOutOfRangeException(
                    $"Value of {value} must be less than {max}.");
            }
        }

        public static void CheckNotBlank(string value) 
        {
            if (value == null || value == string.Empty || value.Replace(" ", "")  == string.Empty)
            {
                throw new ArgumentException("Value can't be blank.");
            }
        }

        public static void CheckNotEmpty(Array array) 
        {
            if (array.Length == 0) 
            {
                throw new ArgumentException("Value can't be empty.");
            }
        }

        public static void CheckNotEmpty(ArrayList arrayList) 
        {
            if (arrayList.Count == 0) 
            {
                throw new ArgumentException("Value can't be empty.");
            }
        }

        public static void CheckNotEmpty(ArrayList collection, string paramName) 
        {
            if (collection.Count == 0) 
            {
                throw new ArgumentException("Value can't be empty");
            }
        }

        public static void CheckNotNull(object reference) 
        {
            if (reference == null) 
            {
                throw new ArgumentNullException("Value can't be null.");
            }
        }

        private Validator() { }
    }
}