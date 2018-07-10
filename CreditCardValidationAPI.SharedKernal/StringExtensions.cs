using System;
using System.Linq;

namespace CreditCardValidationAPI.SharedKernal
{
    public static class StringExtensions
    {
        public static bool IsAllCharactorNumber(this string str)
        {
            Func<char, bool> isNumberCharacter = (char character) => character >= '0' && character <= '9';
            return str.All(isNumberCharacter);
        }
    }
}
