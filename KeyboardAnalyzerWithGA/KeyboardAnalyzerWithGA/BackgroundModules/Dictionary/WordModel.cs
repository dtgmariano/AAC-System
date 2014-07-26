using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace KeyboardAnalyzerWithGA
{
    public class WordModel
    {
        public string content;
        public string input;
        public int frequency;
        public Options.WordCategories category;

        /* Constructor
         */
        public WordModel(string _content, int _frequency)
        {
            this.content = _content;
            this.input = null;
            this.frequency = _frequency;
            this.category = Options.WordCategories.Unknown;
        }

        public WordModel(string _content, string _input, int _frequency)
        {
            this.content = _content;
            this.input = _input;
            this.frequency = _frequency;
            this.category = Options.WordCategories.Unknown;
        }

        public WordModel(string _content, int _frequency, string _input, Options.WordCategories _category)
        {
            this.content = _content;
            this.input = _input;
            this.frequency = _frequency;
            this.category = _category;
        }

        /* Function Name: RemoveDiacritics
         * Description: Function to remove different characters such as: ç, ü, á , and others..
         * Input Parameters: string clearText
         * Output Parameters: string normalizedText
         */
        public string RemoveDiacritics(string clearText)
        {
            string normalizedText = clearText.Normalize(NormalizationForm.FormD);

            StringBuilder sb = new StringBuilder();
            foreach (char ch in normalizedText)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
