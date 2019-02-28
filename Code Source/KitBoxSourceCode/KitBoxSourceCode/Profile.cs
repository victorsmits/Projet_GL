﻿using System;
namespace KitBoxSourceCode
{
    public class Profile
    {
        private string FirstName;
        private string LastName;
        private string Email;

        public Profile(string LN, string FN, string mail = null)
        {
            FirstName = FN;
            LastName = LN;
            Email = mail;
        }

        public string GetEmail => Email;

        public string GetLastName => LastName;

        public string GetFirstName => FirstName;
    }
}
