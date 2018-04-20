using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace DatabaseProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var removedUsersFile = "removedUsers.json";
            var userDataFile = "userdata.json";
            var usernamesFile = "usernames.json";
            var removedUsers = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(removedUsersFile));
            var usernames = JsonConvert.DeserializeObject<List<Username>>(File.ReadAllText(usernamesFile)).Select(x => x.username).ToList();
            usernames.RemoveAll(
                new Predicate<string>((string val) =>
                {
                    return removedUsers.Contains(val);
                }
            ));
            Dictionary<string, User> userData = JsonConvert.DeserializeObject<Dictionary<string, User>>(File.ReadAllText(userDataFile));
            int singleWithBio = 0;
            int single = 0;
            int relationshipWithBio = 0;
            int relationship = 0;
            int marriedWithBio = 0;
            int married = 0;
            int bios = 0;
            foreach (var username in usernames)
            {
                User data = userData[username];
                if (data.bio != "")
                    bios++;
                if (data.relationshipStatus == "Single")
                {
                    single++;
                    if (data.bio != "")
                        singleWithBio++;
                }
                else if (data.relationshipStatus == "Married")
                {
                    married++;
                    if (data.bio != "")
                        marriedWithBio++;
                }
                else if (data.relationshipStatus == "In a relationship")
                {
                    relationship++;
                    if (data.bio != "")
                        relationshipWithBio++;
                }
            }
            Console.WriteLine(Math.Round((double)100 * singleWithBio / single).ToString() + "% of " + single.ToString() + " single people filled out a bio.");
            Console.WriteLine(Math.Round((double)100 * relationshipWithBio / relationship).ToString() + "% of " + relationship.ToString() + " people in a relationship filled out a bio.");
            Console.WriteLine(Math.Round((double)100 * marriedWithBio / married).ToString() + "% of " + married.ToString() + " married people filled out a bio.");
            Console.WriteLine((100 - Math.Round((double)100 * (singleWithBio + relationshipWithBio + marriedWithBio) / bios)).ToString() + "% of people filled out a bio without providing a relationship status.");
            Console.ReadKey();
        }
    }

    class User
    {
        public string email;
        public string phone;
        public string website;
        public string birthday;
        public string relationshipStatus;
        public string personality;
        public string workplace;
        public string address;
        public string city;
        public string state;
        public string zip;
        public string twitter;
        public string facebook;
        public string instagram;
        public string linkedin;
        public string behance;
        public string books;
        public string movies;
        public string shows;
        public string music;
        public string foods;
        public string careerGoals;
        public string petPeeves;
        public string hobbies;
        public List<string> interests;
        public List<string> clubs;
        public string bio;
        public string firstName;
        public string lastName;
        public string standing;
        public List<string> major;
        public List<string> booksAsList;
        public List<string> showsAsList;
        public List<string> musicAsList;
        public List<string> foodsAsList;
        public List<string> hobbiesAsList;
        public string photoPath;
    }

    class Username
    {
        public string username;
        public string photoPath;
    }
}
