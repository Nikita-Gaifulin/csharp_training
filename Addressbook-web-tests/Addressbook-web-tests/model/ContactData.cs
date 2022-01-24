using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace addressbookWebTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string[] myDetails = new string[19];

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

        public string[] Details
        {
           get
           {
                myDetails[0] = (FirstName + " " + Middlename + " " + Lastname).Trim();
                myDetails[0] = Regex.Replace(myDetails[0], @"\s+", " ");
                myDetails[1] = Nickname;
                myDetails[2] = Title;
                myDetails[3] = Company;
                myDetails[4] = Address;
                if (Home != "" && Home != null)
                {
                    myDetails[5] = "H: " + Home;
                }
                if (Mobile != "" && Mobile != null)
                {
                    myDetails[6] = "M: " + Mobile;
                }
                if (Work != "" && Work != null)
                {
                    myDetails[7] = "W: " + Work;
                }
                if (Fax != "" && Fax != null)
                {
                    myDetails[8] = "F: " + Fax;
                }
                myDetails[9] = Email;
                myDetails[10] = Email2;
                myDetails[11] = Email3;

                if (Homepage != "" && Homepage != null)
                {
                    myDetails[12] = "Homepage:";
                    myDetails[13] = Homepage;
                }


                if (Byear != "" && Byear != null)
                {
                    if (Int32.Parse(Byear) > DateTime.Now.Year)
                    {
                        Byear = Byear + " " + "(" + (DateTime.Now.Year - Int32.Parse(Byear)).ToString() + ")";
                    }
                }

                if (Bday == "0")
                {
                    Bday = "";
                }

                if (Bday != "" && Bday != null)
                {
                    Bday = Bday + ". ";
                }

                if (Bmonth != "" && Bmonth != null)
                {
                    Bmonth = Bmonth + " ";
                }

                if ((Bday != "" && Bday != null) || (Bmonth != "" && Bmonth != null) || (Byear != "" && Byear != null))
                {
                    myDetails[14] = ("Birthday " + Bday + Bmonth + Byear).Trim();
                }

                if (Ayear != "" && Ayear != null)
                {
                    if (Int32.Parse(Ayear) > DateTime.Now.Year)
                    {
                        Ayear = Ayear + " "+ "(" + (DateTime.Now.Year - Int32.Parse(Ayear)).ToString() + ")";
                    }
                }

                if (Aday == "0")
                {
                    Aday = "";
                }

                if (Aday != "" && Aday != null)
                {
                    Aday = Aday + ". ";
                }

                if (Amonth != "" && Amonth != null)
                {
                    Amonth = Amonth + " ";
                }

                if ((Aday != "" && Aday != null) || (Amonth != "" && Amonth != null) || (Ayear != "" && Ayear != null))
                {
                    myDetails[15] = ("Anniversary " + Aday + Amonth + Ayear).Trim();
                }
                myDetails[16] = Address2;
                if (Phone2 != "" && Phone2 != null)
                {
                    myDetails[17] = "P: " + Phone2;
                }
                myDetails[18] = Notes;
                myDetails = myDetails.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                return myDetails;
           }
           set 
           {
                myDetails = value;
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