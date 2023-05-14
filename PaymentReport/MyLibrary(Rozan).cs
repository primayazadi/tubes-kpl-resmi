using System;

namespace ValidationLibrary
{
    public class InputValidator
    {
        public static bool IsValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;
            return true;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;
            return email.Contains("@");
        }
    }
}
