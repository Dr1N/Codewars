using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PhoneDirectory
{
    public static class PhoneDir
    {
        public static string Phone(string book, string num)
        {
            var phoneRegex = new Regex(@"\+\d{1,2}\-\d{3}-\d{3}-\d{4}");
            var nameRegex = new Regex("<.+>");
            var spaceRegex = new Regex(@"\s{2,}");
            
            const string resultPattern = "Phone => {0}, Name => {1}, Address => {2}";
            const string availableChars = ".-";
            
            string result;
            
            var phoneList = book.Split("\n");
    
            
            if (!phoneList.Any(e => e.Contains($"+{num}")))
            {
                return $"Error => Not found: {num}";
            }
            if (phoneList.Count(e => e.Contains($"+{num}")) > 1)
            {
                return $"Error => Too many people: {num}";
            }

            var addressLine = phoneList.First(e => e.Contains($"+{num}"));
            var phone = phoneRegex.Match(addressLine).Value;
            var name = nameRegex.Match(addressLine).Value;
            var addressLineWithoutPnoneAndName = addressLine
                .Replace(phone, string.Empty)
                .Replace(name, string.Empty);
            var addressBuilder = new StringBuilder();
            foreach (var c in addressLineWithoutPnoneAndName)
            {
                if (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || availableChars.Contains(c))
                {
                    addressBuilder.Append(c);
                }
                else
                {
                    addressBuilder.Append(' ');
                }
            }
    
            var address = spaceRegex.Replace(addressBuilder.ToString(), " ");
            result = string.Format(resultPattern, phone.TrimStart('+'), name.Trim('<', '>'), address.Trim());

            return result;
        }
    }
}