using System;
using System.Collections.Generic;
using System.Linq;

namespace battle_ship
{
    class Program
    {
        public static Dictionary<int, string> ships;
        static void Main(string[] args)
        {
            ships = MakeNewDictWithSpace();
            // ships[55] = "o";
            // ships = MakeSectionOfShip(ships, "4", 5, 6);
            // ships = MakeShot(ships, 7, 6);
            PutNewShip(ships);
            Console.WriteLine(MakeMap(ships));

        }

        public static string MakeMap(Dictionary<int, string> ships)
        {
            string map = "  y\n" +
                         "   --- --- --- --- --- --- --- --- ---\n" +
                         $"9 | {ships[19]} | {ships[29]} | {ships[39]} | {ships[49]} | {ships[59]} | {ships[69]} | {ships[79]} | {ships[89]} | {ships[99]} |\n" +
                         "   --- --- --- --- --- --- --- --- ---\n" +
                         $"8 | {ships[18]} | {ships[28]} | {ships[38]} | {ships[48]} | {ships[58]} | {ships[68]} | {ships[78]} | {ships[88]} | {ships[98]} |\n" +
                         "   --- --- --- --- --- --- --- --- ---\n" +
                         $"7 | {ships[17]} | {ships[27]} | {ships[37]} | {ships[47]} | {ships[57]} | {ships[67]} | {ships[77]} | {ships[87]} | {ships[97]} |\n" +
                         "   --- --- --- --- --- --- --- --- ---\n" +
                         $"6 | {ships[16]} | {ships[26]} | {ships[36]} | {ships[46]} | {ships[56]} | {ships[66]} | {ships[76]} | {ships[86]} | {ships[96]} |\n" +
                         "   --- --- --- --- --- --- --- --- ---\n" +
                         $"5 | {ships[15]} | {ships[25]} | {ships[35]} | {ships[45]} | {ships[55]} | {ships[65]} | {ships[75]} | {ships[85]} | {ships[95]} |\n" +
                         "   --- --- --- --- --- --- --- --- ---\n" +
                         $"4 | {ships[14]} | {ships[24]} | {ships[34]} | {ships[44]} | {ships[54]} | {ships[64]} | {ships[74]} | {ships[84]} | {ships[94]} |\n" +
                         "   --- --- --- --- --- --- --- --- ---\n" +
                         $"3 | {ships[13]} | {ships[23]} | {ships[33]} | {ships[43]} | {ships[53]} | {ships[63]} | {ships[73]} | {ships[83]} | {ships[93]} |\n" +
                         "   --- --- --- --- --- --- --- --- ---\n" +
                         $"2 | {ships[12]} | {ships[22]} | {ships[32]} | {ships[42]} | {ships[52]} | {ships[62]} | {ships[72]} | {ships[82]} | {ships[92]} |\n" +
                         "   --- --- --- --- --- --- --- --- ---\n" +
                         $"1 | {ships[11]} | {ships[21]} | {ships[31]} | {ships[41]} | {ships[51]} | {ships[61]} | {ships[71]} | {ships[81]} | {ships[91]} |\n" +
                         "   --- --- --- --- --- --- --- --- --- x\n" +
                         "    1   2   3   4   5   6   7   8   9";
            return map;
        }

        public static Dictionary<int, string> MakeNewDictWithSpace()
        {
            Dictionary<int, string> dictWithSpace = new Dictionary<int, string>();
            for (int i = 11; i < 100; i++)
            {
                if (i % 10 == 0)
                    continue;
                dictWithSpace.Add(i," ");
            }
            return dictWithSpace;
        }

        public static Dictionary<int, string> MakeSectionOfShip(Dictionary<int, string> dict, string type, int x, int y)
        {
            int key = int.Parse($"{x}{y}");
            dict[key] = type;
            return dict;
        }

        public static Dictionary<int, string> MakeShot(Dictionary<int, string> dict, int x, int y)
        {
            int key = int.Parse($"{x}{y}");
            if (int.TryParse(dict[key], out _))
                ships[key] = "x";
            else
                ships[key] = "o";
            return dict;
        }

        public static bool IsIxistShip(Dictionary<int, string> dict)
        {
            foreach (var item in dict)
            {
                if (int.TryParse(item.Value, out _))
                    return true;
            };
            return false;
        }

        public static bool IsExistSpace(Dictionary<int, string> dict, int key) 
            => !int.TryParse(dict[key], out _);

        public static Dictionary<int, string> PutNewShip(Dictionary<int, string> dict)
        {
            List<int> keys = dict.Select(k => k.Key).ToList();
            Random random = new Random();
            int indexKey;
            int key;
            int x;
            int y;
            int zeroOrOne;
            for (int i = 1; i <= 7; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                   zeroOrOne = random.Next(1);
                   indexKey = random.Next(keys.Count);
                   key = keys[indexKey];
                   if (IsExistSpace(dict, key))
                   {
                       dict[key] = $"{i}";
                       keys.Remove(key);
                   }      
                };
            }
            return dict;
        }
    }
}
