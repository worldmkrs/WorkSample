
using System;
using System.Collections.Generic;
using System.Linq;


namespace InMemoryDictionary
{
    class Program
    {
        static void Main()
        {
            while (true)
            { 
                var command = Console.ReadLine();
                var commands = command.Split(' ');
                switch (commands[0])
                {
                    case "ADD":
                        if (commands.Length == 3)
                        {
                            MyStore.Add(commands[1], commands[2]);
                        }
                        break;
                    case "REMOVE":
                        if (commands.Length == 3)
                        {
                            MyStore.Remove(commands[1], commands[2]);
                        }
                        break;
                    case "REMOVEALL":
                        if (commands.Length == 2)
                        {
                            MyStore.RemoveAll(commands[1]);
                        }
                        break;
                    case "CLEAR":
                        MyStore.Clear();
                        break;
                    case "KEYS":
                        MyStore.Keys();
                        break;
                    case "KEYEXISTS":
                        if (commands.Length == 2)
                        {
                            MyStore.KeyExist(commands[1]);
                        }
                        break;
                    case "ALLMEMBERS":
                        MyStore.AllMembers();
                        break;
                    case "ITEMS":
                        MyStore.Items();
                        break;

                }
            }
        }
    }

    public class MyStore
    {
        public static List<KeyStore> data = new List<KeyStore>();
        public static void Add(string key, string value)
        {
            data.Add(new KeyStore(key, value));
            Print("Added");
        }

        public static void Remove(string key, string value)
        {
            if (data.Any(x => x.Key == key && x.Value == value))
            {
                data.RemoveAll(x => x.Key == key && x.Value == value);
                Print("Removed");
            }
            else
            {
                Print("ERROR, member does not exist");
            }
        }

        public static void Clear()
        {
            data.Clear();
            Print("Removed");
        }

        public static void KeyExist(string key)
        {
            Print(data.Any(x => x.Key == key).ToString());
        }

        public static void RemoveAll(string member)
        {
            if (data.Any(x => x.Key == member))
            {
                data.RemoveAll(x => x.Key == member);
                Print("Removed");
            }
            else
            {
                Print("ERROR, key does not exist");
            }
        }

        public static void Keys()
        {
            var keys = data.Select(x => x.Key).ToList();
            var index = 1;
            if (keys.Any())
            {
                keys.ForEach(x =>
                {
                    Print($"{index}) {x}");
                    index++;
                });
            }
            else
            {
                Print("(empty set)");
            }
        }

        public static void Items()
        {
            var items = data.Select(x => $"{ x.Key}: { x.Value}").ToList();
            var index = 1;
            if (items.Any())
            {
                items.ForEach(x =>
                {
                    Print($"{index}) {x}");
                    index++;
                });
            }
            else
            {
                Print("(empty set)");
            }
        }

        public static void AllMembers()
        {
            var members = data.Select(x => x.Value).ToList();
            var index = 1;
            if (members.Any())
            {
                members.ForEach(x =>
                {
                    Print($"{index}) {x}");
                    index++;
                });
            }
            else
            {
                Print("(empty set)");
            }
        }

        static void Print(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class KeyStore
    {
        public KeyStore(string key, string value)
        {
            Key = key;
            Value = value;
        }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
