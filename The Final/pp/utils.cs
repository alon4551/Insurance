using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pp
{
    public static class utils
    {

        public static int getLestId(string name)
        {
            List<Row> table=Access.getObjects(SQL_Queries.Select(name));
            if (table == null || table.Count == 0)
                return -1;
            int big = int.Parse(table[0].GetColValue(0).ToString());
            foreach (Row row in table)
                if (big < int.Parse(row.GetColValue(0).ToString()))
                    big = int.Parse(row.GetColValue(0).ToString());
            return big;
        }
        public static bool Check(int type,string value)
        {
            if (type == -1) return true;
            switch (type)
            {
                case 0://not zero answer
                    return value != "";
                case 1://id 
                    return Validate_Id(value);
                case 2://mobile phone
                    return Validate_Phone(value,10,'5');
                case 3://local phone
                    return Validate_Phone(value,9,'8');
                case 4://email
                    return Validate_Email(value);
                default:
                    return false;
            }
        }
        public static bool Check(string value, int years)
        {
            return Validate_Date(value, years);
        }
        private static bool Validate_Id(string id)
        {
            
            if (id.Length != 9)
                return false;
            foreach(char i in id)
                if (i < '0' || i > '9') return false;
            int sum=0,digit;
            for (int i = 0; i < 9; i++)
            {
                digit =( id[i] - '0')*((i%2)+1);
                sum += digit>9?digit-9:digit;
            }
            return (sum % 10 == 0);
        }
        private static bool Validate_Phone(string phone, int limit_digit,char typePhone)
        {
            if (phone[0] != '0' && (phone[1] != typePhone))
                return false;
            foreach (char i in phone)
                if ((i < '0' || i > '9')&&i!='-') return false;
            if (phone.Length > (limit_digit+2) || phone.Length < limit_digit)
                return false;
            int digit = 0, spaces = 0;
            foreach (char i in phone)
            {
                if (i == '-') spaces++;
                if (i >= '0' && i <= '9') digit++;
                if ((i < '0' || i > '9') && i != '-') return false;
            }
            if ((spaces   >2) || digit != limit_digit) return false;
            return true;

        }
        private static bool Validate_Email(string email) {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        private static bool Validate_Date(string date,int years) {
            try
            {
                int day, mouth, year;
                day = DateTime.Now.Day - DateTime.Parse(date).Day;
                mouth = DateTime.Now.Month - DateTime.Parse(date).Month;
                year = DateTime.Now.Year - DateTime.Parse(date).Year;
                if (year == years)
                {
                    if (mouth == 0)
                        return day >= 0 ? true : false;
                    else if (mouth > 0)
                        return true;
                    else
                        return false;
                }
                else if (year > years)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public static void Load_List(ListBox box,List<string> names) {
            box.Items.Clear();
            foreach (string name in names)
                box.Items.Add(name);
        }
        public static void Load_List(ComboBox box,List<string> names) {
            box.Items.Clear();
            foreach (string name in names)
                box.Items.Add(name);
        }
        public static List<string> GetNames(List<Question> questions) {
            List<string> names = new List<string>();
            foreach (Question q in questions)
                names.Add(q.Q);
            return names;
        }
        public static List<string> GetNames(List<Insurance> insurances) {
            List<string> names = new List<string>();
            foreach (Insurance i in insurances)
                names.Add(i.Name);
            return names;
        }
        public static List<string> GetNames(List<American_Answer> answers)
        {
            List<string> names = new List<string>();
            foreach (American_Answer i in answers)
                names.Add(i.Answer);
            return names;
        }
        public static List<string> GetNames(List<Condition_Date> answers)
        {
            List<string> names = new List<string>();
            foreach (var i in answers)
                if (i.Range != -1)
                    names.Add(i.Limit + "--" + (i.Limit + i.Range));
                else
                    names.Add(i.Limit + "-- no limit");
            return names;
        }

        internal static List<Question> OrginazeQuestions(List<Question> questions)
        {
            List<Question> orginzed = new List<Question>();
            int i = 0;
            for (; i< questions.Count;)
            {
                foreach (Question q in questions)
                    if (i == q.Order)
                    {
                        orginzed.Add(q);
                        i++;
                        break;
                    }
            }
            return orginzed;
        }
    }
}
