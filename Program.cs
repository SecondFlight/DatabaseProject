using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace DatabaseProject
{
    class Program
    {
        static void Main()
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

    public class DatabaseContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<personality> Personality { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Shows> Shows { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<PetPeeves> PetPeeves { get; set; }
        public DbSet<Hobbies> Hobbies { get; set; }
        public DbSet<Interests> Interests { get; set; }
        public DbSet<Foods> Foods { get; set; }
    }

    public class Users
    {
        public string userName { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string Bio { get; set; }
        public string standing { get; set; }
        public List<birthday> birthdays { get; set; }
        public string relationshipStatus { get; set; }
    }

    public class birthday
    {
        public int month { get; set; }
        public int day { get; set; }
        public int year { get; set; }
    }
    public class personality 
    {
        public string userName { get; set; }
        public string personalityType { get; set; }
    }

    public class Major
    {
        public string userName { get; set; }
        public string major { get; set; }
    }

    public class Books
    {
        public string userName { get; set; }
        public string books { get; set; }
    }

    public class Movies
    {
        public string userName { get; set; }
        public string movies { get; set; }
    }

    public class Shows 
    {
        public string userName { get; set; }
        public string shows { get; set; }
    }

    public class ContactInfo
    {
        public string userName { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Linkedin { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string websiteURL { get; set; }
    }

    public class Music 
    {
        public string userName { get; set; }
        public string music { get; set; }
    }

    public class Career
    {
        public string userName { get; set; }
        public string careerGoals { get; set; }
    }

    public class Location 
    {
        public string userName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
    }

    public class Club
    {
        public string userName { get; set; }
        public string Clubs { get; set; }
    }

    public class PetPeeves
    {
        public string userName { get; set; }
        public string petPeeves { get; set; }
    }

    public class Hobbies
    {
        public string userName { get; set; }
        public string hobbies { get; set; }
    }

    public class Interests
    {
        public string userName { get; set; }
        public string interests { get; set; }
    }

    public class Foods
    {
        public string userName { get; set; }
        public string foods { get; set; }
    }
}
