using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseProject
{
    class Program
    {
        static void Main()
        {
            using (var db = new DatabaseContext())
            {
                
            }
        }
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
