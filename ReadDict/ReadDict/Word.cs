using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace ReadDict
{
    class Word
    {
        public int index;
        public string content;
        public string normalized_content;
        public string t9crypt;

        public Word(int _index, string _content)
        {
            index = _index;
            content = _content;
            normalized_content = RemoveDiacritics(content);
            t9crypt = encodeToT9(normalized_content);
        }

        public string encodeToT9(string _content)
        {
            string t9code = "";
            Dictionary<Char, int> t9Table = new Dictionary<char, int>();

            #region t9 table itens
            int key_abc = 2;
            int key_def = 3;
            int key_ghi = 4;
            int key_jkl = 5;
            int key_mno = 6;
            int key_pqrs = 7;
            int key_tuv = 8;
            int key_wxyz = 9;
            int key_space = 0;
            int key_signs = 1;

            t9Table.Add('a', key_abc);
            t9Table.Add('b', key_abc);
            t9Table.Add('c', key_abc);
            t9Table.Add('d', key_def);
            t9Table.Add('e', key_def);
            t9Table.Add('f', key_def);
            t9Table.Add('g', key_ghi);
            t9Table.Add('h', key_ghi);
            t9Table.Add('i', key_ghi);
            t9Table.Add('j', key_jkl);
            t9Table.Add('k', key_jkl);
            t9Table.Add('l', key_jkl);
            t9Table.Add('m', key_mno);
            t9Table.Add('n', key_mno);
            t9Table.Add('o', key_mno);
            t9Table.Add('p', key_pqrs);
            t9Table.Add('q', key_pqrs);
            t9Table.Add('r', key_pqrs);
            t9Table.Add('s', key_pqrs);
            t9Table.Add('t', key_tuv);
            t9Table.Add('u', key_tuv);
            t9Table.Add('v', key_tuv);
            t9Table.Add('w', key_wxyz);
            t9Table.Add('x', key_wxyz);
            t9Table.Add('y', key_wxyz);
            t9Table.Add('z', key_wxyz);
            t9Table.Add(' ', key_space);
            t9Table.Add('.', key_signs);
            t9Table.Add(',', key_signs);
            t9Table.Add('!', key_signs);
            t9Table.Add('?', key_signs);
            t9Table.Add('-', key_signs);
            t9Table.Add('_', key_signs);
            #endregion

            foreach (char c in _content)
            {
                t9code += t9Table[c];
            }

            return t9code;
        }

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
