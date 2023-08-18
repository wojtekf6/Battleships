using System;

namespace Battleships.Utils
{
    public static class InputUtils
    {
        public static string GetInputPattern(int size) => $@"^[A-{(size-1).GetColumnChar()}]\d+$";

        public static bool ValidateMaxSize(string input, int size)
        {
            try
            {
                var num = int.Parse(input.Remove(0, 1));
                return num > 0 && num <= size;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}