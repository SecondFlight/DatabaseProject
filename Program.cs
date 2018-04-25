using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DatabaseProject
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Write("(a)dd data, (r)un queries, e(x)it: ");
                var input = Console.ReadKey();
                if (input.KeyChar == 'a')
                {
                    AddUserData();
                }
                else if (input.KeyChar == 'r')
                {
                    PrintSpacer();
                    Console.WriteLine("What would you like to know? (Keep in mind not everyone input data)");
                    Console.WriteLine("General Data             -     G: ");
                    Console.WriteLine("Stats about Jonathan     -     J: ");
                    Console.WriteLine("Count Majors             -     M: ");
                    Console.WriteLine("Count Names              -     N: ");
                    Console.WriteLine("Favorite Foods           -     F: ");
                    Console.WriteLine("Favorite Movies          -     O: ");
                    Console.WriteLine("Personality Type         -     P: ");
                    Console.WriteLine("Relationship Status      -     R: ");
                    Console.WriteLine("Music                    -     A: ");
                    Console.WriteLine("Shows                    -     S: ");
                    Console.WriteLine("Hobbies                  -     H: ");
                    Console.WriteLine("Career Goals             -     C: ");
                    Console.Write("So what'll it be? ");
                    char c = Char.ToUpper(Console.ReadKey().KeyChar);
                    Console.WriteLine();
                    switch (c)
                    {
                        case 'C':
                            Console.WriteLine();
                            CareerGoals();
                            break;
                        case 'H':
                            Console.WriteLine();
                            Hobbies();
                            break;
                        case 'S':
                            Console.WriteLine();
                            FaveShows();
                            break;
                        case 'A':
                            Console.WriteLine();
                            FaveMusic();
                            break;
                        case 'R':
                            Console.WriteLine();
                            RelationshipStatus();
                            break;
                        case 'P':
                            Console.WriteLine();
                            PersonalityType();
                            break;
                        case 'O':
                            Console.WriteLine();
                            FavoriteMovies();
                            break;
                        case 'F' :
                            Console.WriteLine();
                            FavoriteFoods();
                            break;
                        case 'N' :
                            Console.WriteLine();
                            CountName();
                            break;
                        case 'G':
                            Console.WriteLine();
                            GetUserStats();
                            break;
                        case 'J':
                            Console.WriteLine();
                            Stats();
                            break;
                        case 'M':
                            Console.WriteLine();
                            CountMajors();
                            break;
                    }
                    PrintSpacer();
                }
                else if (input.KeyChar == 'x')
                {
                    break;
                }
            }
        }

        static void GetUserStats()
        {
            using (var db = new DatabaseContext())
            {
                int userCount = db.Users.Count();
                int usersWithDataCount = CountUsersWhoPutData();
                Console.WriteLine("There are " + userCount.ToString() + " users.");
                Console.WriteLine("Info was added by " + usersWithDataCount.ToString() + " users, or only " + Math.Round(((double)usersWithDataCount * 100) / userCount).ToString() + "% of users.");
                int totalCountWhoPutRelStatus = db.RelationshipStatuses.Count();
                Console.WriteLine(totalCountWhoPutRelStatus.ToString() + " users put a relationship status.");
                int singleCount = db.RelationshipStatuses.Where(x => x.status == "Single").Count();
                int inARelationshipCount = db.RelationshipStatuses.Where(x => x.status == "In a relationship").Count();
                int engagedCount = db.RelationshipStatuses.Where(x => x.status == "Engaged").Count();
                int marriedCount = db.RelationshipStatuses.Where(x => x.status == "Married").Count();
                Console.WriteLine(singleCount + " (" + Math.Round(((double)100.0 * singleCount) / totalCountWhoPutRelStatus).ToString() + "%) put their status as \"Single\".");
                Console.WriteLine(inARelationshipCount + " (" + Math.Round(((double)100.0 * inARelationshipCount) / totalCountWhoPutRelStatus).ToString() + "%) put their status as \"In a relationship\".");
                Console.WriteLine(engagedCount + " (" + Math.Round(((double)100.0 * engagedCount) / totalCountWhoPutRelStatus).ToString() + "%) put their status as \"Engaged\".");
                Console.WriteLine(marriedCount + " (" + Math.Round(((double)100.0 * marriedCount) / totalCountWhoPutRelStatus).ToString() + "%) put their status as \"Married\".");
            }
        }

        static void CareerGoals()
        {
            using (var db = new DatabaseContext())
            {
                Console.Write("Name a career and I'll count the people who want to work in that field: ");
                string career = Console.ReadLine().ToUpper();
                int careerCount = db.Careers.Where(x => x.careerGoals.ToUpper().Contains(career)).Count();
                int totalCareers = db.Careers.Count();
                Console.WriteLine();
                Console.WriteLine("There are " + careerCount + " people who like the show " + career);
                Console.WriteLine("Out of " + totalCareers + " people who added data for this category, that is " + (careerCount * 100.0) / totalCareers + "%");
            }
        }

        static void FaveShows()
        {
            using (var db = new DatabaseContext())
            {
                Console.Write("Name a show and I'll count the people who like it: ");
                string show = Console.ReadLine().ToUpper();
                int showCount = db.Shows.Where(x => x.shows.ToUpper().Contains(show)).Count();
                int totalShows = db.Shows.Count();
                Console.WriteLine();
                Console.WriteLine("There are " + showCount + " people who like the show " + show);
                Console.WriteLine("Out of " + totalShows + " people who added data for this category, that is " + (showCount * 100.0) / totalShows + "%");
            }
        }

        static void Hobbies()
        {
            using (var db = new DatabaseContext()) 
            {
                Console.Write("Name a hobby to see how many people enjoy that: ");
                string hobby = Console.ReadLine().ToUpper();
                Console.WriteLine();
                int hobbyCount = db.Hobbies.Where(x => x.hobbies.ToUpper().Contains(hobby)).Count();
                Console.WriteLine("There are " + hobbyCount + " people who enjoy " + hobby);
                int totalHobbies = db.Hobbies.Count();
                Console.WriteLine("Out of " + totalHobbies + " people who added data for this category, that is " + Math.Round((hobbyCount * 100.0) / totalHobbies, 2) + "%");
            }
        }

        static void FaveMusic()
        {
            using (var db = new DatabaseContext())
            {
                Console.Write("Name a song/artist/genre to see how many people like it: ");
                string music = Console.ReadLine().ToUpper();
                Console.WriteLine();
                int musicCount = db.Musics.Where(x => x.music.ToUpper().Contains(music)).Count();
                Console.WriteLine("There are " + musicCount + " people who like " + music);
                int totalMusic = db.Musics.Count();
                Console.WriteLine("Out of " + totalMusic + " people who added data for this category, that is " + Math.Round((musicCount * 100.0) / totalMusic, 2) + "%");
            }
        }

        static void PersonalityType()
        {
            using (var db = new DatabaseContext())
            {
                Console.Write("What Meyers-Briggs Personality Type would you like to check? ");
                string pt = Console.ReadLine().ToUpper();
                Console.WriteLine();
                int ptCount = db.Personality.Where(x => x.personalityType.ToUpper() == pt).Count();
                Console.WriteLine("There are " + ptCount + " people with a personality type of " + pt);
                int totalPt = db.Personality.Count();
                Console.WriteLine("Out of " + totalPt + " people who added data for this category, that is " + Math.Round((ptCount * 100.0) / totalPt,2) + "%");
            }
        }

        static void Stats()
        {
            using (var db = new DatabaseContext())
            {
                int BirthdayCount = db.Users.Where(x => x.birthdayMonth == 6).Count();
                Console.WriteLine("There are " + BirthdayCount + " people born in the month of June");
                int countJonathans = db.Users.Where(x => x.firstName == "Jonathan" || x.firstName == "Johnathan" || x.firstName == "jonathan" || x.firstName == "johnathan").Count();
                Console.WriteLine("There are " + countJonathans + " people named Jonathan or Johnathan");
            }
        }

        static void RelationshipStatus()
        {
            using (var db = new DatabaseContext())
            {
                Console.WriteLine("What relationship status would you like to count?");
                Console.WriteLine("Single - S");
                Console.WriteLine("In A Relationship - R");
                Console.WriteLine("Engaged - E");
                Console.WriteLine("Married - M");
                int totalRel = db.RelationshipStatuses.Count();
                char c = Char.ToUpper(Console.ReadKey().KeyChar);
                switch (c)
                {
                    case 'M':
                        Console.WriteLine();
                        int married = db.RelationshipStatuses.Where(x => x.status == "Married").Count();
                        Console.WriteLine("There are " + married + " people who are married");
                        Console.WriteLine("Out of " + totalRel + " people who added data for this category, that is " + Math.Round((married * 100.0) / totalRel,2) + "%");
                        break;
                    case 'E':
                        Console.WriteLine();
                        int engaged = db.RelationshipStatuses.Where(x => x.status == "Engaged").Count();
                        Console.WriteLine("There are " + engaged + " people who are engaged");
                        Console.WriteLine("Out of " + totalRel + " people who added data for this category, that is " + Math.Round((engaged * 100.0) / totalRel, 2) + "%");
                        break;
                    case 'R':
                        Console.WriteLine();
                        int iar = db.RelationshipStatuses.Where(x => x.status == "In a relationship").Count();
                        Console.WriteLine("There are " + iar + " people who are in a realtionship");
                        Console.WriteLine("Out of " + totalRel + " people who added data for this category, that is " + Math.Round((iar * 100.0) / totalRel,2) + "%");
                        break;
                    case 'S':
                        Console.WriteLine();
                        int single = db.RelationshipStatuses.Where(x => x.status == "Single").Count();
                        Console.WriteLine("There are " + single + " people who are single");
                        Console.WriteLine("Out of " + totalRel + " people who added data for this category, that is " + Math.Round((single * 100.0) / totalRel, 2) + "%");
                        break;
                }
            }
        }

        static void CountMajors()
        {
            using (var db = new DatabaseContext())
            {
                Console.Write("What major would you like to count? ");
                string major = Console.ReadLine().ToUpper();
                int majorCount = db.UserMajors.Where(x => x.major.ToUpper().Contains(major)).Count();
                Console.WriteLine("There are " + majorCount + " people majoring in " + major);
                int totalMajors = db.UserMajors.Count();
                Console.WriteLine("Out of " + totalMajors + " people, that is " + Math.Round((majorCount * 100.0) / totalMajors, 2) + "%");
            }
        }

        static void CountName()
        {
            using (var db = new DatabaseContext())
            {
                Console.Write("Would you like to count first or last names? ");
                string input = Console.ReadLine().ToUpper();
                if(input.Contains("FIRST"))
                {
                    Console.Write("What first name would you like to count? ");
                    string name = Console.ReadLine().ToUpper();
                    Console.WriteLine();
                    int nameCount = db.Users.Where(x => x.firstName.ToUpper() == name).Count();
                    Console.WriteLine("There are " + nameCount + " people with the first name " + name);
                    int totalPeople = db.Users.Count();
                    Console.WriteLine("Out of " + totalPeople + " people, that is " + Math.Round((nameCount * 100.0) / totalPeople, 2) + "%");
                }
                else if (input.Contains("LAST"))
                {
                    Console.Write("What last name would you like to count? ");
                    string name = Console.ReadLine().ToUpper();
                    Console.WriteLine();
                    int nameCount = db.Users.Where(x => x.lastName.ToUpper() == name).Count();
                    Console.WriteLine("There are " + nameCount + " people with the last name " + name);
                    int totalPeople = db.Users.Count();
                    Console.WriteLine("Out of " + totalPeople + " people, that is " + Math.Round((nameCount * 100.0) / totalPeople, 2) + "%");
                }
                else
                {
                    Console.WriteLine("Sorry, that's an invalid request. We really didn't demand much of you...");
                }

            }
        }

        static void FavoriteFoods()
        {
            using (var db = new DatabaseContext())
            {
                Console.Write("Name a food and I'll tell you how many people like it: ");
                string food = Console.ReadLine().ToUpper();
                Console.WriteLine();
                int foodCount = db.Foods.Where(x => x.foods.ToUpper().Contains(food)).Count();
                Console.WriteLine("There are " + foodCount + " people who like " + food);
                int totalPeople = db.Foods.Count();
                Console.WriteLine("Out of " + totalPeople + " people who added data for this category, that is " + Math.Round((foodCount * 100.0) / totalPeople, 2) + "%");
            }
        }

        static void FavoriteMovies()
        {
            using (var db = new DatabaseContext())
            {
                Console.Write("Name a movie and I'll tell you how many people like it: ");
                string movie = Console.ReadLine().ToUpper();
                Console.WriteLine();
                int movieCount = db.Movies.Where(x => x.movies.ToUpper().Contains(movie)).Count();
                Console.WriteLine("There are " + movieCount + " people who like " + movie);
                int totalPeople = db.Movies.Count();
                Console.WriteLine("Out of " + totalPeople + " people who added data for this category, that is " + Math.Round((movieCount * 100.0) / totalPeople, 2) + "%");
            }
        }

        static int CountUsersWhoPutData()
        {
            using (var db = new DatabaseContext())
            {
                int result = 0;
                foreach (var user in db.Users)
                {
                    var username = user.userName;
                    if (db.Bios.Where(x => x.userName == username).FirstOrDefault() != null ||
                        db.Books.Where(x => x.userName == username).FirstOrDefault() != null ||
                        db.Careers.Where(x => x.userName == username).FirstOrDefault() != null ||
                        db.UserClubs.Where(x => x.userName == username).FirstOrDefault() != null ||
                        /*db.ContactInfos.Where(x => x.userName == username).FirstOrDefault() != null ||*/
                        db.Foods.Where(x => x.userName == username).FirstOrDefault() != null ||
                        db.Hobbies.Where(x => x.userName == username).FirstOrDefault() != null ||
                        db.UserInterests.Where(x => x.userName == username).FirstOrDefault() != null ||
                        db.Locations.Where(x => x.userName == username).FirstOrDefault() != null ||
                        db.Movies.Where(x => x.userName == username).FirstOrDefault() != null ||
                        db.Musics.Where(x => x.userName == username).FirstOrDefault() != null ||
                        db.Personality.Where(x => x.userName == username).FirstOrDefault() != null ||
                        db.PetPeeves.Where(x => x.userName == username).FirstOrDefault() != null ||
                        db.RelationshipStatuses.Where(x => x.userName == username).FirstOrDefault() != null ||
                        db.Shows.Where(x => x.userName == username).FirstOrDefault() != null)
                    {
                        result++;
                    }
                }
                return result;
            }
        }

        static void PrintSpacer()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine();
        }

        static void AddUserData()
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

            using (var db = new DatabaseContext())
            {
                /*db.Bios.FromSql("DELETE * FROM dbo.Bios");
                db.RelationshipStatuses.FromSql("DELETE * FROM dbo.RelationshipStatuses");
                db.Books.FromSql("DELETE * FROM dbo.Books");
                db.Careers.FromSql("DELETE * FROM dbo.Careers");
                db.Clubs.FromSql("DELETE * FROM dbo.Clubs");
                db.ContactInfos.FromSql("DELETE * FROM dbo.ContactInfos");
                db.Foods.FromSql("DELETE * FROM dbo.Foods");
                db.Hobbies.FromSql("DELETE * FROM dbo.Hobbies");
                db.Interests.FromSql("DELETE * FROM dbo.Interests");
                db.Locations.FromSql("DELETE * FROM dbo.Locations");
                db.Majors.FromSql("DELETE * FROM dbo.Majors");
                db.Movies.FromSql("DELETE * FROM dbo.Movies");
                db.Musics.FromSql("DELETE * FROM dbo.Musics");
                db.Personality.FromSql("DELETE * FROM dbo.Personality");
                db.PetPeeves.FromSql("DELETE * FROM dbo.PetPeeves");
                db.Shows.FromSql("DELETE * FROM dbo.Shows");
                db.UserClubs.FromSql("DELETE * FROM dbo.UserClubs");
                db.UserInterests.FromSql("DELETE * FROM dbo.UserInterests");
                db.UserMajors.FromSql("DELETE * FROM dbo.UserMajors");
                db.Users.FromSql("DELETE * FROM dbo.Users");
                db.SaveChanges();*/
                int count = 0;
                int total = usernames.Count;
                Console.WriteLine();
                foreach (var username in usernames)
                {
                    Console.Clear();
                    Console.WriteLine(Math.Round(((double)(100 * count)) / total).ToString() + "%");
                    count++;
                    var user = userData[username];
                    var birthdaySplit = user.birthday.Split("/");
                    db.Users.Add(new Users
                    {
                        userName = username,
                        lastName = user.lastName,
                        firstName = user.firstName,
                        standing = user.standing,
                        birthdayMonth = Int32.Parse(birthdaySplit[0]),
                        birthdayDay = Int32.Parse(birthdaySplit[1]),
                        email = user.email,
                        workplace = user.workplace
                    });
                    if (user.bio != "")
                    {
                        db.Bios.Add(new Bio
                        {
                            userName = username,
                            bio = user.bio
                        });
                    }
                    if (user.books != "")
                    {
                        db.Books.Add(new Books
                        {
                            userName = username,
                            books = user.books
                        });
                    }
                    if (user.careerGoals != "")
                    {
                        db.Careers.Add(new Career
                        {
                            userName = username,
                            careerGoals = user.careerGoals
                        });
                    }
                    foreach (var club in user.clubs)
                    {
                        if (db.Clubs.Where(x => x.clubName == club).FirstOrDefault() != null)
                        {
                            db.Clubs.Add(new Club { clubName = club });
                        }
                        db.UserClubs.Add(new UserClub { userName = username, clubName = club });
                    }
                    if (user.twitter != "" ||
                        user.facebook != "" ||
                        user.instagram != "" ||
                        user.linkedin != "" ||
                        user.behance != "" ||
                        user.phone != "" ||
                        user.website != "")
                    {
                        db.ContactInfos.Add(new ContactInfo
                        {
                            userName = username,
                            Twitter = user.twitter,
                            Facebook = user.facebook,
                            Instagram = user.instagram,
                            Linkedin = user.linkedin,
                            Behance = user.behance,
                            phone = user.phone,
                            websiteURL = user.website
                        });
                    }
                    if (user.foods != "")
                    {
                        db.Foods.Add(new Foods
                        {
                            userName = username,
                            foods = user.foods
                        });
                    }
                    if (user.hobbies != "")
                    {
                        db.Hobbies.Add(new Hobbies
                        {
                            userName = username,
                            hobbies = user.hobbies
                        });
                    }
                    foreach (var interest in user.interests)
                    {
                        if (db.Interests.Where(x => x.interestName == interest).FirstOrDefault() == null)
                        {
                            db.Interests.Add(new Interest { interestName = interest });
                        }
                        db.UserInterests.Add(new UserInterest { userName = username, interestName = interest });
                    }
                    int zip;
                    if (!Int32.TryParse(user.zip, out zip))
                        zip = -1;
                    if (user.address != "" || user.city != "" || user.state != "" || zip != -1)
                    {
                        db.Locations.Add(new Location
                        {
                            userName = username,
                            address = user.address,
                            city = user.city,
                            state = user.state,
                            zip = zip
                        });
                    }
                    foreach (var major in user.major.Distinct())
                    {
                        if (db.Majors.Where(x => x.major == major).FirstOrDefault() == null)
                        {
                            db.Majors.Add(new Major { major = major });
                        }
                        var thingToAdd = new UserMajor { userName = username, major = major };
                        //var test2 = db.UserMajors;
                        //var test = db.UserMajors.Where(x => x.userName == username).Where(x => x.major == major);
                        if (db.UserMajors.Where(x => x.userName == username).Where(x => x.major == major).FirstOrDefault() == null)
                            db.UserMajors.Add(thingToAdd);
                    }
                    if (user.movies != "")
                    {
                        db.Movies.Add(new Movies
                        {
                            userName = username,
                            movies = user.movies
                        });
                    }
                    if (user.music != "")
                    {
                        db.Musics.Add(new Music
                        {
                            userName = username,
                            music = user.music
                        });
                    }
                    if (user.personality != "")
                    {
                        db.Personality.Add(new Personality
                        {
                            userName = username,
                            personalityType = user.personality
                        });
                    }
                    if (user.petPeeves != "")
                    {
                        db.PetPeeves.Add(new PetPeeves
                        {
                            userName = username,
                            petPeeves = user.petPeeves
                        });
                    }
                    if (user.relationshipStatus != "")
                    {
                        db.RelationshipStatuses.Add(new RelationshipStatus
                        {
                            userName = username,
                            status = user.relationshipStatus
                        });
                    }
                    if (user.shows != "")
                    {
                        db.Shows.Add(new Shows
                        {
                            userName = username,
                            shows = user.shows
                        });
                    }
                    db.SaveChanges();
                }
            }

            /*int singleWithBio = 0;
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
            */
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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=users.db");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserClub>()
                .HasKey(c => new { c.clubName, c.userName });

            modelBuilder.Entity<UserInterest>()
                .HasKey(c => new { c.interestName, c.userName });

            modelBuilder.Entity<UserMajor>()
                .HasKey(c => new { c.major, c.userName });
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Bio> Bios { get; set; }
        public DbSet<RelationshipStatus> RelationshipStatuses { get; set; }
        public DbSet<Personality> Personality { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<UserMajor> UserMajors { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Shows> Shows { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Music> Musics { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<UserClub> UserClubs { get; set; }
        public DbSet<PetPeeves> PetPeeves { get; set; }
        public DbSet<Hobbies> Hobbies { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<UserInterest> UserInterests { get; set; }
        public DbSet<Foods> Foods { get; set; }
    }

    public class Users
    {
        [Key]
        public string userName { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string standing { get; set; }
        public int birthdayMonth { get; set; }
        public int birthdayDay { get; set; }
        public string email { get; set; }
        public string workplace { get; set; }
    }

    public class Bio
    {
        [Key]
        public string userName { get; set; }
        public string bio { get; set; }
    }

    public class RelationshipStatus
    {
        [Key]
        public string userName { get; set; }
        public string status { get; set; }
    }

    public class Personality 
    {
        [Key]
        public string userName { get; set; }
        public string personalityType { get; set; }
    }

    public class Major
    {
        [Key]
        public string major { get; set; }
    }

    public class UserMajor
    {
        public string userName { get; set; }
        public string major { get; set; }
    }

    public class Books
    {
        [Key]
        public string userName { get; set; }
        public string books { get; set; }
    }

    public class Movies
    {
        [Key]
        public string userName { get; set; }
        public string movies { get; set; }
    }

    public class Shows 
    {
        [Key]
        public string userName { get; set; }
        public string shows { get; set; }
    }

    public class ContactInfo
    {
        [Key]
        public string userName { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Linkedin { get; set; }
        public string Behance { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string websiteURL { get; set; }
    }

    public class Music 
    {
        [Key]
        public string userName { get; set; }
        public string music { get; set; }
    }

    public class Career
    {
        [Key]
        public string userName { get; set; }
        public string careerGoals { get; set; }
    }

    public class Location 
    {
        [Key]
        public string userName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
    }

    public class Club
    {
        [Key]
        public string clubName { get; set; }
    }

    public class UserClub
    {
        public string clubName { get; set; }
        public string userName { get; set; }
    }

    public class PetPeeves
    {
        [Key]
        public string userName { get; set; }
        public string petPeeves { get; set; }
    }

    public class Hobbies
    {
        [Key]
        public string userName { get; set; }
        public string hobbies { get; set; }
    }

    public class Interest
    {
        [Key]
        public string interestName { get; set; }
    }

    public class UserInterest
    {
        public string userName { get; set; }
        public string interestName { get; set; }
    }

    public class Foods
    {
        [Key]
        public string userName { get; set; }
        public string foods { get; set; }
    }
}
