using System;
using System.Collections.Generic;
using System.Linq;

namespace battle_ship
{
    class Program
    {
        public static Dictionary<int, string> shipsPlayer;
        public static Dictionary<int, string> shipsComputer;
        public static Dictionary<int, string> shipsComputerForPlayer;
        static void Main(string[] args)
        {
            shipsPlayer = MakeNewDictWithSpace();
            shipsComputer = MakeNewDictWithSpace();
            shipsComputerForPlayer = MakeNewDictWithSpace();

            PutNewShip(shipsComputer);
            Console.WriteLine(MakeMap(shipsPlayer, shipsComputer));

            int type;
            while (!IsExistAllShips(shipsPlayer, 10))
            {
                type = ChooseTypeShipMenu();
                if (IsIxistShip(shipsPlayer, type))
                {
                    Console.WriteLine("Корабль такого типа вы уже разместили. Выберите пожалуйста другой тип корабля");
                    continue;
                }
                MakeSectionOfShip(shipsPlayer, type);
                Console.WriteLine(MakeMap(shipsPlayer, shipsComputer));
            }
            Console.WriteLine("Игра началась!");
            while (true)
            {
                Console.WriteLine("Введите координаты для выстрела:");
                MakeShot(shipsComputer,shipsComputerForPlayer);
                GetShot(shipsPlayer);
                Console.WriteLine(MakeMap(shipsPlayer, shipsComputerForPlayer));
                if (shipsComputer.FirstOrDefault(e => int.TryParse(e.Value, out _)).Value == null)
                {
                    Console.WriteLine("Вы выиграли");
                    break;
                }
                else if (shipsPlayer.FirstOrDefault(e => int.TryParse(e.Value, out _)).Value == null)
                {
                    Console.WriteLine("Вы проиграли");
                    break;
                }
            }
            


            // Console.Write("Введите координату x: ");
            // int x = Console.Read();            
            // Console.Write("Введите координату y: ");
            // int y = Console.Read();
            // MakeSectionOfShip(shipsPlayer, type, x, y);
            // while (true)
            // {
            //   
            // }

            // ships[55] = "o";
            // ships = MakeSectionOfShip(ships, "4", 5, 6);
            // ships = MakeShot(ships, 7, 6);


        }



        public static int ChooseTypeShipMenu()
        {
            int type;
            try
            {
                Console.Write("Please choose the type of ship to be placed on the map:\n" +
                             "1. Single-deck ship\n" +
                             "2. Double-deck ship\n" +
                             "3. Triple-deck ship\n" +
                             "4. Four-deck ship\n" +
                             "Please enter (1,2,3 or 4): ");
                type = int.Parse(Console.ReadLine());
                if (type > 0 && type <= 4)                   
                    return type;
                else
                    throw new Exception("Ошибка! Вы можете ввести только 1,2,3 или 4");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка! Вы ввели не число");
                return ChooseTypeShipMenu();
            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1.Message);
                return ChooseTypeShipMenu();
            }
        }

        public static int EnterCoordShipMenu(string axis)
        {
            int coord;
            try
            {
                Console.Write($"Пожалуйста введите координаты по оси {axis}\n"+
                             "Please enter (from 1 till 9): ");
                coord = int.Parse(Console.ReadLine());
                2if (coord > 0 && coord <= 9)
                    return coord;
                else
                    throw new Exception("Ошибка! Вы можете ввести только от 1 до 9");
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка! Вы ввели не число");
                return EnterCoordShipMenu(axis);
            }
            catch (Exception ex1)
            {
                Console.WriteLine(ex1.Message);
                return EnterCoordShipMenu(axis);
            }
        }

        public static string MakeMap(Dictionary<int, string> shipsPlayer, Dictionary<int, string> shipsComputer)
        {
            string v = "   --- --- --- --- --- --- --- --- ---\t\t   --- --- --- --- --- --- --- --- ---\n";
            string map = " --- --- --- Your map --- --- --- ---\t\t--- --- --- Computers's map --- --- ---\n" +
                         "  y\t\t\t\t\t\t  y\n" +
                         $"{v}" +
                         $"9 | {shipsPlayer[19]} | {shipsPlayer[29]} | {shipsPlayer[39]} | {shipsPlayer[49]} | {shipsPlayer[59]} | {shipsPlayer[69]} | {shipsPlayer[79]} | {shipsPlayer[89]} | {shipsPlayer[99]} |\t\t9 | {shipsComputer[19]} | {shipsComputer[29]} | {shipsComputer[39]} | {shipsComputer[49]} | {shipsComputer[59]} | {shipsComputer[69]} | {shipsComputer[79]} | {shipsComputer[89]} | {shipsComputer[99]} |\n" +
                         $"{v}" +
                         $"8 | {shipsPlayer[18]} | {shipsPlayer[28]} | {shipsPlayer[38]} | {shipsPlayer[48]} | {shipsPlayer[58]} | {shipsPlayer[68]} | {shipsPlayer[78]} | {shipsPlayer[88]} | {shipsPlayer[98]} |\t\t8 | {shipsComputer[18]} | {shipsComputer[28]} | {shipsComputer[38]} | {shipsComputer[48]} | {shipsComputer[58]} | {shipsComputer[68]} | {shipsComputer[78]} | {shipsComputer[88]} | {shipsComputer[98]} |\n" +
                         $"{v}" +
                         $"7 | {shipsPlayer[17]} | {shipsPlayer[27]} | {shipsPlayer[37]} | {shipsPlayer[47]} | {shipsPlayer[57]} | {shipsPlayer[67]} | {shipsPlayer[77]} | {shipsPlayer[87]} | {shipsPlayer[97]} |\t\t7 | {shipsComputer[17]} | {shipsComputer[27]} | {shipsComputer[37]} | {shipsComputer[47]} | {shipsComputer[57]} | {shipsComputer[67]} | {shipsComputer[77]} | {shipsComputer[87]} | {shipsComputer[97]} |\n" +
                         $"{v}" +
                         $"6 | {shipsPlayer[16]} | {shipsPlayer[26]} | {shipsPlayer[36]} | {shipsPlayer[46]} | {shipsPlayer[56]} | {shipsPlayer[66]} | {shipsPlayer[76]} | {shipsPlayer[86]} | {shipsPlayer[96]} |\t\t6 | {shipsComputer[16]} | {shipsComputer[26]} | {shipsComputer[36]} | {shipsComputer[46]} | {shipsComputer[56]} | {shipsComputer[66]} | {shipsComputer[76]} | {shipsComputer[86]} | {shipsComputer[96]} |\n" +
                         $"{v}" +
                         $"5 | {shipsPlayer[15]} | {shipsPlayer[25]} | {shipsPlayer[35]} | {shipsPlayer[45]} | {shipsPlayer[55]} | {shipsPlayer[65]} | {shipsPlayer[75]} | {shipsPlayer[85]} | {shipsPlayer[95]} |\t\t5 | {shipsComputer[15]} | {shipsComputer[25]} | {shipsComputer[35]} | {shipsComputer[45]} | {shipsComputer[55]} | {shipsComputer[65]} | {shipsComputer[75]} | {shipsComputer[85]} | {shipsComputer[95]} |\n" +
                         $"{v}" +
                         $"4 | {shipsPlayer[14]} | {shipsPlayer[24]} | {shipsPlayer[34]} | {shipsPlayer[44]} | {shipsPlayer[54]} | {shipsPlayer[64]} | {shipsPlayer[74]} | {shipsPlayer[84]} | {shipsPlayer[94]} |\t\t4 | {shipsComputer[14]} | {shipsComputer[24]} | {shipsComputer[34]} | {shipsComputer[44]} | {shipsComputer[54]} | {shipsComputer[64]} | {shipsComputer[74]} | {shipsComputer[84]} | {shipsComputer[94]} |\n" +
                         $"{v}" +
                         $"3 | {shipsPlayer[13]} | {shipsPlayer[23]} | {shipsPlayer[33]} | {shipsPlayer[43]} | {shipsPlayer[53]} | {shipsPlayer[63]} | {shipsPlayer[73]} | {shipsPlayer[83]} | {shipsPlayer[93]} |\t\t3 | {shipsComputer[13]} | {shipsComputer[23]} | {shipsComputer[33]} | {shipsComputer[43]} | {shipsComputer[53]} | {shipsComputer[63]} | {shipsComputer[73]} | {shipsComputer[83]} | {shipsComputer[93]} |\n" +
                         $"{v}" +
                         $"2 | {shipsPlayer[12]} | {shipsPlayer[22]} | {shipsPlayer[32]} | {shipsPlayer[42]} | {shipsPlayer[52]} | {shipsPlayer[62]} | {shipsPlayer[72]} | {shipsPlayer[82]} | {shipsPlayer[92]} |\t\t2 | {shipsComputer[12]} | {shipsComputer[22]} | {shipsComputer[32]} | {shipsComputer[42]} | {shipsComputer[52]} | {shipsComputer[62]} | {shipsComputer[72]} | {shipsComputer[82]} | {shipsComputer[92]} |\n" +
                         $"{v}" +
                         $"1 | {shipsPlayer[11]} | {shipsPlayer[21]} | {shipsPlayer[31]} | {shipsPlayer[41]} | {shipsPlayer[51]} | {shipsPlayer[61]} | {shipsPlayer[71]} | {shipsPlayer[81]} | {shipsPlayer[91]} |\t\t1 | {shipsComputer[11]} | {shipsComputer[21]} | {shipsComputer[31]} | {shipsComputer[41]} | {shipsComputer[51]} | {shipsComputer[61]} | {shipsComputer[71]} | {shipsComputer[81]} | {shipsComputer[91]} |\n" +
                         "   --- --- --- --- --- --- --- --- --- x\t   --- --- --- --- --- --- --- --- --- x\n" +
                         "    1   2   3   4   5   6   7   8   9\t\t    1   2   3   4   5   6   7   8   9";
            return map;
        }

        public static Dictionary<int, string> MakeNewDictWithSpace()
        {
            Dictionary<int, string> dictWithSpace = new Dictionary<int, string>();
            for (int i = 11; i < 100; i++)
            {
                if (i % 10 == 0)
                    continue;
                dictWithSpace.Add(i, " ");
            }
            return dictWithSpace;
        }

        public static void MakeSectionOfShip(Dictionary<int, string> dict, int type)
        {
            int x = EnterCoordShipMenu("x");
            int y = EnterCoordShipMenu("y");
            int key = int.Parse($"{x}{y}");
            if (IsExistSpace(dict, key))
                dict[key] = type.ToString();
            else
            {
                Console.WriteLine("В этих координатах уже размещён корабль. Повторите ввод");
                MakeSectionOfShip(dict, type);
            }                
        }

        public static void GetShot(Dictionary<int, string> shipsPlayer)
        {
            Random random = new Random();
            int x = random.Next(1,10);
            int y = random.Next(1,10);
            int key = int.Parse($"{x}{y}");
            if (int.TryParse(shipsPlayer[key], out _))
                shipsPlayer[key] = "x";
            else
                shipsPlayer[key] = "o";
        }

        public static void MakeShot(Dictionary<int, string> shipsComputer,
            Dictionary<int, string> shipsComputerForPlayer)
        {
            int x = EnterCoordShipMenu("x");
            int y = EnterCoordShipMenu("y");
            int key = int.Parse($"{x}{y}");
            shipsComputerForPlayer[key] = int.TryParse(shipsComputer[key], out _) ? "x" : "o";
        }

        public static bool IsExistAllShips(Dictionary<int, string> dict, int count)
        {
            int i = 0; 
            foreach (var item in dict)
            {
                if (int.TryParse(item.Value, out _))
                    i++;
                if (i == count)
                    return true;
            }
            return false;
        }
        public static bool IsIxistShip(Dictionary<int, string> dict, int type)
        {
            int i = 0;
            foreach (var item in dict)
            {
                if (item.Value == $"{type}")
                    i++;
                if (i == type)
                    return true;
            }
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
            string[] values;
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
            for (int i = 1; i <= 4 ; i++)
            {
                values = dict.Where(e => e.Value == i.ToString()).Select(v => v.Value).ToArray();
                if (values.Length > i)
                {
                    dict = MakeNewDictWithSpace();
                    PutNewShip(dict);
                }                  
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
            value = string.Empty;
        }
    }
}
