using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
// to run the program just run *sh run.sh* in the git bash
namespace GeekTrust
{
    class User{
        private int totalPrice;
        public Music music;
        public Video video;
        public Podcast podcast;


    }
    class Music
    {
        private string category;
        private DateTime renewalDate;
        Dictionary<string, int> Price = new Dictionary<string, int>
        {
            ["FREE"] = 0,
            ["PERSONAL"] = 100,
            ["PREMIUM"] = 250
        };
        public Music(string category, DateTime date)
        {
            this.category = category;
            this.renewalDate = date;
        }
        public int getPrice()
        {
            if (Price.ContainsKey(this.category))
            {
                return Price[this.category];
            }
            else
            {
                return 0;
            }
        }
    }
    class Video
    {
        private string category;
        private DateTime renewalDate;
        Dictionary<string, int> Price = new Dictionary<string, int>
        {
            ["FREE"] = 0,
            ["PERSONAL"] = 200,
            ["PREMIUM"] = 500
        };
        public Video(string category, DateTime date)
        {
            this.category = category;
            this.renewalDate = date;
        }
        public int getPrice()
        {
            if (Price.ContainsKey(this.category))
            {
                return Price[this.category];
            }
            else
            {
                return 0;
            }
        }
    }
    class Podcast
    {
        private string category;
        private DateTime renewalDate;
        public Podcast(string category, DateTime date)
        {
            this.category = category;
            this.renewalDate = date;
        }
        Dictionary<string, int> Price = new Dictionary<string, int>
        {
            ["FREE"] = 0,
            ["PERSONAL"] = 100,
            ["PREMIUM"] = 300
        };
        public int getPrice()
        {
            if (Price.ContainsKey(this.category))
            {
                return Price[this.category];
            }
            else
            {
                return 0;
            }
        }
    }
    class Program
    {
        static int totalSum = 0;
        static DateTime date;
        static void printAnswer(string[] str)
        {
            if (str[0] == "START_SUBSCRIPTION")
            {
                date = DateTime.ParseExact(str[1], "dd-MM-yyyy", new CultureInfo("en-US"));
            }
            if (str[0] == "ADD_SUBSCRIPTION")
            {   
                if (str[1] == "MUSIC")
                {
                    Music music = new Music(str[2], date);
                    totalSum += music.getPrice();
                }
                if (str[1] == "VIDEO")
                {
                    Video video = new Video(str[2], date);
                    totalSum += video.getPrice();
                }
                if (str[1] == "PODCAST")
                {
                    Podcast podcast = new Podcast(str[2], date);
                    totalSum += podcast.getPrice();
                }
            }
        }
        static void Main(string[] args)
        {
            string filePath = args[0];
            string[] lines = File.ReadAllLines(filePath);
            
            foreach(string line in lines){
                printAnswer(line.Split(' '));
            }
            Console.WriteLine("Printing totalsum {0}",totalSum);
        }
    }
}
