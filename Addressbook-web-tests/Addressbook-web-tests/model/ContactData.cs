using System;
using System.Text.RegularExpressions;

namespace addressbookWebTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;

        public ContactData(string firstName, string lastname)
        {
            FirstName = firstName;
            Lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (FirstName == other.FirstName) && (Lastname == other.Lastname);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "FirstName =" + FirstName + ", " + "Lastname =" + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            string expectedResult = $"{Lastname} {FirstName}";
            string actualResult = $"{other.Lastname} {other.FirstName}";
            return expectedResult.CompareTo(actualResult);
        }

        public string FirstName { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Home { get; set; }

        public string Mobile { get; set; }

        public string Work { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Bday { get; set; }

        public string Bmonth { get; set; }

        public string Byear { get; set; }

        public string Aday { get; set; }

        public string Amonth { get; set; }

        public string Ayear { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(Home)+ CleanUp(Mobile) + CleanUp(Work) + CleanUp(Phone2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpEmails(Email) + CleanUpEmails(Email2) + CleanUpEmails(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        public string CleanUp(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return Regex.Replace(text, "[ -()]", "") + "\r\n";
        }

        public string CleanUpEmails(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text + "\r\n";
        }
    }

}