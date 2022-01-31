using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace addressbookWebTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string fullName;
        private string allData;
        private string fullNameNicknameBlock;
        private string titleCompanyAdddrBlock;
        private string phonesBlock;
        private string emailHomePageBlock;
        private string bdayAnniversaryBlock;
        private string secondaryBlock;

        public ContactData()
        {
        }

        public ContactData(string firstName, string lastname)
        {
            Firstname = firstName;
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
            return (Firstname == other.Firstname) && (Lastname == other.Lastname);
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode() + Lastname.GetHashCode();
        }

        public override string ToString()
        {
            return "Firstname =" + Firstname + ", " + "Lastname =" + Lastname;
        }

        public int CompareTo(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return 1;
            }
            string expectedResult = $"{Lastname} {Firstname}";
            string actualResult = $"{other.Lastname} {other.Firstname}";
            return expectedResult.CompareTo(actualResult);
        }

        public string Firstname { get; set; }

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

        public string FullName
        {
            get
            {
                if (fullName != null)
                {
                    return fullName;
                }
                else
                {
                    return Regex.Replace($"{Firstname} {Middlename} {Lastname}", @"\s+", "");
                }
            }

            set
            {
                fullName = value;
            }
        }

        public string GetAge(string day, string month, string year, string fieldName)
        {
            int userMonth;
            int Age;

            switch (month)
            {
                case "January":
                    userMonth = 1;
                    break;

                case "February":
                    userMonth = 2;
                    break;

                case "March":
                    userMonth = 3;
                    break;

                case "April":
                    userMonth = 4;
                    break;

                case "May":
                    userMonth = 5;
                    break;

                case "June":
                    userMonth = 6;
                    break;

                case "July":
                    userMonth = 7;
                    break;

                case "August":
                    userMonth = 8;
                    break;

                case "September":
                    userMonth = 9;
                    break;

                case "October":
                    userMonth = 10;
                    break;

                case "November":
                    userMonth = 11;
                    break;

                case "December":
                    userMonth = 12;
                    break;

                default:
                    userMonth = 0;
                    break;
            }

            if (year != "")
            {
                if ((DateTime.Now.Month >= userMonth) && (DateTime.Now.Day >= Int32.Parse(day)))
                    Age = DateTime.Now.Year - Int32.Parse(year);
                else
                    Age = DateTime.Now.Year - Int32.Parse(year) - 1;
            }
            else Age = 0;
            string FullDate = "";
            if (day != null && day != "-" && day != "0")
            {
                FullDate = day + ".";
            }
            if (month != null && month != "-")
            {
                if (FullDate != "")
                {
                    FullDate += " " + month;
                }
                else
                {
                    FullDate = month;
                }
            }
            if (year != null && year != "")
            {
                if (FullDate != "")
                {
                    FullDate += " " + year;
                }
                else
                {
                    FullDate = year;
                }
            }
            if (FullDate != "")
            {
                if (year != "")
                {
                    return fieldName + FullDate + " (" + Age + ")";
                }
                else
                {
                    return fieldName + FullDate;
                }
            }
            else return "";
        }
        public string GetAnniversary(string day, string month, string year, string fieldName)
        {
            int Anniversary;
            if (year != "")
                Anniversary = DateTime.Now.Year - Int32.Parse(year);
            else
                Anniversary = 0;
            string FullDate = "";
            if (day != null && day != "-" && day != "0")
            {
                FullDate = day + ".";
            }
            if (month != null && month != "-")
            {
                if (FullDate != "")
                {
                    FullDate += " " + month;
                }
                else
                {
                    FullDate = month;
                }
            }
            if (year != null && year != "")
            {
                if (FullDate != "")
                {
                    FullDate += " " + year;
                }
                else
                {
                    FullDate = year;
                }
            }
            if (FullDate != "")
            {
                if (year != null && year != "")
                {
                    return fieldName + FullDate + " (" + Anniversary + ")";
                }
                else
                {
                    return fieldName + FullDate;
                }
            }
            else return "";
        }

        public string AllData
        {
            get
            {
                string fullNameBlock = FullNameNicknameblock;
                string titleBlock = TitleCompAddrBlock;
                string phoneBlock = PhonesBlock;
                string emailBlock = EmailHomepageBlock;
                string dateBlock = BirthAnnivBlock;
                string secondaryBlock = SecondaryBlock;
                string allDetails2 = "";



                if (allData != null)
                {
                    return allData = "";
                }
                else
                {
                    if (fullNameBlock != "")
                    {
                        allDetails2 = fullNameBlock;
                    }
                    if (titleBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNabove(titleBlock);
                        }
                        else
                        {
                            allDetails2 = titleBlock;
                        }
                    }
                    if (phoneBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNRNabove(phoneBlock);
                        }
                        else
                        {
                            allDetails2 = phoneBlock;
                        }
                    }
                    if (emailBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNRNabove(emailBlock);
                        }
                        else
                        {
                            allDetails2 = emailBlock;
                        }
                    }
                    if (dateBlock != null && dateBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNRNabove(dateBlock);
                        }
                        else
                        {
                            allDetails2 = dateBlock;
                        }
                    }
                    else
                        if (secondaryBlock != "" && secondaryBlock != "P:")
                    {
                        allDetails2 += "\r\n";

                    }
                    if (secondaryBlock != "")
                    {
                        if (allDetails2 != "")
                        {
                            allDetails2 += ReturnDetailwithRNRNabove(secondaryBlock);
                        }
                        else
                        {
                            allDetails2 = secondaryBlock;
                        }
                    }
                }
                return allDetails2.Trim();
            }
            set
            {
                allData = value;
            }
        }

        public string FullNameNicknameblock
        {
            get
            {
                if (fullNameNicknameBlock != null)
                {
                    return fullNameNicknameBlock;
                }
                else
                {
                    if (ReturnFullName(Firstname.Trim(), Middlename.Trim(), Lastname.Trim()) != "")
                    {
                        if (Nickname != "")
                        {
                            return (ReturnFullName(Firstname.Trim(), Middlename.Trim(), Lastname.Trim()) + "\r\n" + Nickname.Trim());
                        }
                        else
                        {
                            return ReturnFullName(Firstname.Trim(), Middlename.Trim(), Lastname.Trim());
                        }
                    }
                    else
                        return (ReturnDetailwithoutRN(Nickname));
                }
            }
            set
            {
                fullNameNicknameBlock = value;
            }
        }

        public string TitleCompAddrBlock
        {
            get
            {
                string titleCompAddrBlock = "";
                if (Title != null && Title != "")
                {
                    titleCompAddrBlock = Title.Trim();
                }
                if (Company != null && Company != "")
                {
                    if (titleCompAddrBlock != null && titleCompAddrBlock != "")
                    {
                        titleCompAddrBlock += "\r\n" + Company.Trim();
                    }
                    else
                    {
                        titleCompAddrBlock = Company.Trim();
                    }
                }
                if (Address != null && Address != "")
                {
                    if (titleCompAddrBlock != null && titleCompAddrBlock != "")
                    {
                        titleCompAddrBlock += "\r\n" + Address.Trim();
                    }
                    else
                    {
                        titleCompAddrBlock = Address.Trim();
                    }
                }
                return titleCompAddrBlock;
            }
            set
            {
                titleCompanyAdddrBlock = value;
            }
        }

        public string PhonesBlock
        {
            get
            {
                string phonesBlock = "";

                if (Home != null && Home != "")
                {
                    phonesBlock = ("H: " + Home.Trim()).Trim();
                }
                if (Mobile != null && Mobile != "")
                {
                    if (phonesBlock != null && phonesBlock != "")
                    {
                        phonesBlock += "\r\n" + ("M: " + Mobile.Trim()).Trim();
                    }
                    else
                    {
                        phonesBlock = ("M: " + Mobile.Trim()).Trim();
                    }
                }
                if (Work != null && Work != "")
                {
                    if (phonesBlock != null && phonesBlock != "")
                    {
                        phonesBlock += "\r\n" + ("W: " + Work.Trim()).Trim();
                    }
                    else
                    {
                        phonesBlock = ("W: " + Work.Trim()).Trim();
                    }
                }
                if (Fax != null && Fax != "")
                {
                    if (phonesBlock != null && phonesBlock != "")
                    {
                        phonesBlock += "\r\n" + ("F: " + Fax.Trim()).Trim();
                    }
                    else
                    {
                        phonesBlock = ("F: " + Fax.Trim()).Trim();
                    }
                }
                return phonesBlock;
            }
            set
            {
                phonesBlock = value;
            }
        }

        public string EmailHomepageBlock
        {
            get
            {
                string emailHomepageBlock = "";

                if (Email != null && Email != "")
                {
                    emailHomepageBlock = Email;
                }
                if (Email2 != null && Email2 != "")
                {
                    if (emailHomepageBlock != null && emailHomepageBlock != "")
                    {
                        emailHomepageBlock = emailHomepageBlock.Trim() + "\r\n" + Email2.Trim();
                    }
                    else
                    {
                        emailHomepageBlock = Email2;
                    }
                }
                if (Email3 != null && Email3 != "")
                {
                    if (emailHomepageBlock != null && emailHomepageBlock != "")
                    {
                        emailHomepageBlock = emailHomepageBlock + "\r\n" + Email3.Trim();
                    }
                    else
                    {
                        emailHomepageBlock = Email3;
                    }
                }
                if (Homepage != null && Homepage != "")
                {
                    if (emailHomepageBlock != null && emailHomepageBlock != "")
                    {
                        emailHomepageBlock = emailHomepageBlock + "\r\n" + "Homepage:\r\n" + Homepage.Trim();
                    }
                    else
                    {
                        emailHomepageBlock = "Homepage:\r\n" + Homepage.Trim();
                    }
                }
                return emailHomepageBlock;
            }
            set
            {
                emailHomePageBlock = value;
            }
        }

        public string BirthAnnivBlock
        {
            get
            {
                string bithString = GetAge(Bday, Bmonth, Byear, "Birthday ");
                string annivString = GetAnniversary(Aday, Amonth, Ayear, "Anniversary ");
                string birthAnnivBlock = "";

                if (bithString != null && bithString != "")
                {
                    birthAnnivBlock = bithString.Trim();
                }
                if (annivString != null && annivString != "")
                {
                    if (birthAnnivBlock != null && birthAnnivBlock != "")
                    {
                        birthAnnivBlock += "\r\n" + annivString.Trim();
                    }
                    else
                    {
                        birthAnnivBlock = annivString.Trim();
                    }
                }
                return birthAnnivBlock;
            }
            set
            {
                bdayAnniversaryBlock = value;
            }
        }

        public string SecondaryBlock
        {
            get
            {
                string secondaryBlock = "";
                if (Address2.Trim() != null && Address2.Trim() != "")
                {
                    secondaryBlock = Address2.Trim();
                }
                if (Phone2 != null && Phone2 != "")
                {
                    if (secondaryBlock != null && secondaryBlock != "")
                    {
                        secondaryBlock += "\r\n\r\n" + ("P: " + Phone2.Trim()).Trim();
                    }
                    else
                    {
                        secondaryBlock = "\r\n" + ("P: " + Phone2.Trim()).Trim();
                    }
                }
                if (Notes.Trim() != null && Notes.Trim() != "")
                {
                    if (secondaryBlock != null && secondaryBlock != "")
                    {
                        secondaryBlock += "\r\n\r\n" + Notes.Trim();
                    }
                    else
                    {
                        secondaryBlock = Notes.Trim();
                    }
                }
                return secondaryBlock;
            }
            set
            {
                secondaryBlock = value;
            }

        }

        public string ReturnDetailwithRN(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text + "\r\n";
        }

        public string ReturnDetailwithoutRN(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return text;
        }

        public string ReturnDetailwithRNabove(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return "\r\n" + text;
        }

        public string ReturnDetailwithRNRNabove(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            return "\r\n\r\n" + text;
        }

        public string ReturnFullName(string name, string middlename, string lastname)
        {
            string FullName = "";
            if (name != null && name != "")
            {
                FullName = name;
            }
            if (middlename != null && middlename != "")
            {
                if (FullName != "")
                {
                    FullName += " " + middlename;
                }
                else
                {
                    FullName = middlename;
                }
            }
            if (lastname != null && lastname != "")
            {
                if (FullName != "")
                {
                    FullName += " " + lastname;
                }
                else
                {
                    FullName = lastname;
                }
            }

            return FullName;
        }
    }

}