using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace KeyboardAnalyzer
{
    public class Word
    {
        public int frequency;
        public string content;
        public string normalized_content;
        public string t4crypt;
        public string t9crypt;
        public string t14crypt;

        public Word(string _content)
        {
            content = _content;
            normalized_content = RemoveDiacritics(content);
            t4crypt = encodeToT4(normalized_content);
            t9crypt = encodeToT9(normalized_content);
            t14crypt = encodeToT14(normalized_content);
            frequency = 0;
        }

        public Word(string _content, int _frequency)
        {
            content = _content;
            normalized_content = RemoveDiacritics(content);
            t4crypt = encodeToT4(normalized_content);
            t9crypt = encodeToT9(normalized_content);
            t14crypt = encodeToT14(normalized_content);
            frequency = _frequency;
        }

        public string encodeToT4(string _content)
        {
            string t4code = "";
            Dictionary<Char, int> t4Table = new Dictionary<char, int>();

            #region t4 table itens
            int key_abcdef = 2;
            int key_ghijklm = 3;
            int key_nopqrst = 4;
            int key_uvxwyz = 5;
            int key_signs = 1;

            t4Table.Add('a', key_abcdef);
            t4Table.Add('b', key_abcdef);
            t4Table.Add('c', key_abcdef);
            t4Table.Add('d', key_abcdef);
            t4Table.Add('e', key_abcdef);
            t4Table.Add('f', key_abcdef);
            t4Table.Add('g', key_ghijklm);
            t4Table.Add('h', key_ghijklm);
            t4Table.Add('i', key_ghijklm);
            t4Table.Add('j', key_ghijklm);
            t4Table.Add('k', key_ghijklm);
            t4Table.Add('l', key_ghijklm);
            t4Table.Add('m', key_ghijklm);
            t4Table.Add('n', key_nopqrst);
            t4Table.Add('o', key_nopqrst);
            t4Table.Add('p', key_nopqrst);
            t4Table.Add('q', key_nopqrst);
            t4Table.Add('r', key_nopqrst);
            t4Table.Add('s', key_nopqrst);
            t4Table.Add('t', key_nopqrst);
            t4Table.Add('u', key_uvxwyz);
            t4Table.Add('v', key_uvxwyz);
            t4Table.Add('w', key_uvxwyz);
            t4Table.Add('x', key_uvxwyz);
            t4Table.Add('y', key_uvxwyz);
            t4Table.Add('z', key_uvxwyz);
            t4Table.Add(' ', key_signs);
            t4Table.Add('.', key_signs);
            t4Table.Add(',', key_signs);
            t4Table.Add('!', key_signs);
            t4Table.Add('?', key_signs);
            t4Table.Add('-', key_signs);
            t4Table.Add('_', key_signs);
            #endregion

            foreach (char c in _content)
            {
                t4code += t4Table[c];
            }

            return t4code;
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

        public string encodeToT14(string _content)
        {
            string t14code = "";
            Dictionary<Char, int> t14Table = new Dictionary<char, int>();

            #region t14 table itens
            //int key_backspace = 1;
            int key_ab = 2;
            int key_cd = 3;
            int key_ef = 4;
            int key_gh = 5;
            int key_ij = 6;
            int key_kl = 7;
            int key_mn = 8;
            int key_op = 9;
            int key_qr = 10;
            int key_st = 11;
            int key_uv = 12;
            int key_wx = 13;
            int key_yz = 14;
            int key_signs = 15;

            t14Table.Add('a', key_ab);
            t14Table.Add('b', key_ab);
            t14Table.Add('c', key_cd);
            t14Table.Add('d', key_cd);
            t14Table.Add('e', key_ef);
            t14Table.Add('f', key_ef);
            t14Table.Add('g', key_gh);
            t14Table.Add('h', key_gh);
            t14Table.Add('i', key_ij);
            t14Table.Add('j', key_ij);
            t14Table.Add('k', key_kl);
            t14Table.Add('l', key_kl);
            t14Table.Add('m', key_mn);
            t14Table.Add('n', key_mn);
            t14Table.Add('o', key_op);
            t14Table.Add('p', key_op);
            t14Table.Add('q', key_qr);
            t14Table.Add('r', key_qr);
            t14Table.Add('s', key_st);
            t14Table.Add('t', key_st);
            t14Table.Add('u', key_uv);
            t14Table.Add('v', key_uv);
            t14Table.Add('w', key_wx);
            t14Table.Add('x', key_wx);
            t14Table.Add('y', key_yz);
            t14Table.Add('z', key_yz);
            t14Table.Add(' ', key_signs);
            t14Table.Add('.', key_signs);
            t14Table.Add(',', key_signs);
            t14Table.Add('!', key_signs);
            t14Table.Add('?', key_signs);
            t14Table.Add('-', key_signs);
            t14Table.Add('_', key_signs);
            #endregion

            foreach (char c in _content)
            {
                t14code += t14Table[c];
            }

            return t14code;
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
