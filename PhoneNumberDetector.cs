using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App.BusinessLogicModel
{
    public class PhoneNumberDetector
    {
        public Dictionary<string, string> DetectPhoneNumbers(string inputText)
        {
            // Regular expressions to match different phone number formats
            var phoneNumberPatterns = new Dictionary<string, string>
    {
        { @"\b\d{3}[-\s]?\d{3}[-\s]?\d{4}\b", "XXX XXX XXXX" },        // 123 456 7890, 123-456-7890
        { @"\b\d{2}[-\s]?\d{3}[-\s]?\d{3}[-\s]?\d{4}\b", "XX XXX XXX XXXX" }, // 91-123-456-7890, 91 123 456 7890
        { @"\(\d{2,3}\)\d{7,8}", "(XX)XXXXXXXXXX" },                     // (91)1234567890
        { @"\b\d{10}\b", "XXXXXXXXXX" },                             // 01234567890
        { @"\b\d{4}[-]?\d{6}\b", "XXXX-XXXXXXX" },                     // 0123-4567890
        { @"\bONE\sTWO\sTHREE\sFOUR\sFIVE\sSIX\sSEVEN\sEIGHT\sNINE\sZERO\b", "Textual English" }, // English numbers
        { @"\bएक\sदो\sतीन\sचार\sपांच\sछह\sसात\sआठ\sनौ\sशू\b", "Textual Hindi" }, // Hindi numbers
        { @"\bONE\sदो\sतीन\sFOUR\sFIVE\sछह\sSEVEN\sEIGHT\sNINE\sशू\b", "Textual English & Hindi" } // Combination of English & Hindi
    };

            var phoneNumbersWithFormats = new Dictionary<string, string>();

            // Iterate over patterns and find matches in the text
            foreach (var pattern in phoneNumberPatterns)
            {
                var matches = Regex.Matches(inputText, pattern.Key);
                foreach (Match match in matches)
                {
                    if (!phoneNumbersWithFormats.ContainsKey(match.Value))
                    {
                        phoneNumbersWithFormats.Add(match.Value, pattern.Value);
                    }
                    else
                    {
                        // Append format information to existing value
                        phoneNumbersWithFormats[match.Value] += ", " + pattern.Value;
                    }
                }
            }

            return phoneNumbersWithFormats;
        }
    }
}
