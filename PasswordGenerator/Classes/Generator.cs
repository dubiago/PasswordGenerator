using PasswordGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace PasswordGenerator.Classes
{
    public static class Generator
    {        
        public static Password Generate(this Password password)
        {
            string value;
            int size;
            List<int> ascii;
            Random r;
            string[] excluded;

            do
            {
                ascii = new List<int>();

                value = String.Empty;
                if (password.ExcludedCharacters != null)
                {
                    excluded = password.ExcludedCharacters.Split(",");

                    foreach (string item in excluded)
                    {
                        if (item.Length == 1)
                        {
                            password.Excluded.Add((int)item.ToCharArray()[0]);
                        }
                    }
                }

                r = new Random(System.DateTime.Now.Millisecond);

                ascii.AddRange(GetCharacterSet(r, password.Excluded, password.MinUC, 65, 90));
                ascii.AddRange(GetCharacterSet(r, password.Excluded, password.MinLC, 97, 122));
                ascii.AddRange(GetCharacterSet(r, password.Excluded, password.MinSp, 33, 47));
                ascii.AddRange(GetCharacterSet(r, password.Excluded, password.MinNum, 48, 57));

                if (password.MaxChar != null)
                {
                    size = r.Next(password.MinChar, password.MaxChar.GetValueOrDefault());
                }
                else
                {
                    size = password.MinChar;
                }

                ascii.AddRange(GetCharacterSet(r, password.Excluded, size - password.MinUC - password.MinLC - password.MinSp - password.MinNum, 97, 122));

                ascii.Shuffle();
                foreach(int item in ascii)
                {
                    value += (char)item;
                }

            } while ((password.UserName != null && value.Contains(password.UserName)) && value == String.Empty);

            password.Value = value;

            return password;
        }

        public static List<int> GetCharacterSet(Random r, List<int> excluded, int dimension, int minValue, int maxValue)
        {
            List<int> cs = new List<int>();
            int ascii;

            for(int i = 0; i < dimension; i++)
            {
                do
                {
                    ascii = r.Next(minValue, maxValue);
                } while (excluded.Contains(ascii) && excluded.Count > 0);
                cs.Add(ascii);
            }

            return cs;
        }        
    }
}
