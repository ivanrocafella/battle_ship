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
            => dict.ContainsKey(key) && !int.TryParse(dict[key], out _);

        public static Dictionary<int, string> PutNewShip(Dictionary<int, string> dict)
        {
            List<int> keys = dict.Select(k => k.Key).ToList();
            Random random = new Random();
            int indexKey;
            int key;
            int keyOfLastValue;
            string keyStr = string.Empty;
            string lastValue = string.Empty;
            string value = string.Empty;
            int x;
            int y;
            int direction;// 0 - right, 1 - left, 2 - up, 3 - down          
            int elemFordelKey;
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    value = i.ToString();
                    direction = random.Next(4);
                    if (lastValue == value && int.TryParse(lastValue, out _))
                   {
                        keyOfLastValue = dict.FirstOrDefault(v => v.Value == lastValue).Key;
                        int[] xy = keyOfLastValue.ToString().Select(e => int.Parse(e.ToString())).ToArray();
                        switch (direction)
                        {
                            case 0:                                
                                x = xy[0] + 1;
                                keyStr = int.Parse($"{x}{xy[1]}").ToString();
                                break;
                            case 1:
                                x = xy[0] - 1;
                                keyStr = int.Parse($"{x}{xy[1]}").ToString();
                                break;
                            case 2:
                                y = xy[1] + 1;
                                keyStr = int.Parse($"{xy[0]}{y}").ToString();
                                break;
                            case 3:
                                y = xy[1] - 1;
                                keyStr = int.Parse($"{xy[0]}{y}").ToString();
                                break;
                        }
                        key = int.Parse(keyStr);
                        if (IsExistSpace(dict, key))
                        {
                            MakeSectionOfShip(ref dict, ref value, ref lastValue, ref key, i, ref keys);
                        }
                        else
                        {
                            do
                            {
                                elemFordelKey = dict.FirstOrDefault(e => e.Value == lastValue).Key;
                                dict[elemFordelKey] = " ";
                            } 
                            while (elemFordelKey != 0);
                            --i;
                            lastValue = i.ToString();
                        }
                    }
                   else
                   {                    
                     indexKey = random.Next(keys.Count);
                     key = keys[indexKey];
                     if (IsExistSpace(dict, key))
                     {
                       MakeSectionOfShip(ref dict, ref value, ref lastValue, ref key, i, ref keys);
                     }
                    }  
                };
            }
            return dict;
        }

        public static void MakeSectionOfShip(ref Dictionary<int, string> dict, ref string value,
            ref string lastValue, ref int key, int type, ref List<int> keys)
        {
            value = $"{type}";
            dict[key] = value;
            lastValue = value;
            keys.Remove(key);
        }
    }
}
