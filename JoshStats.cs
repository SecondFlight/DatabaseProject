using DatabaseProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DatabaseProjectTest
{
    class JoshStats
    {
        public static void GetMajorCounts()
        {
            using (var db = new DatabaseContext())
            {
                Console.WriteLine("User counts by major:");
                var counts = new List<int>();
                var majorsAsList = db.Majors.ToList();
                for (int i = 0; i < majorsAsList.Count; i++)
                {
                    var major = majorsAsList[i];
                    counts.Add(db.UserMajors.Where(x => x.major == major.major).Count());
                }
                int topCount = 20;
                Console.WriteLine("Top " + topCount.ToString() + ":");
                for (int i = 0; i < topCount; i++)
                {
                    var maxIndex = counts.IndexOf(counts.Max());
                    Console.WriteLine((i + 1).ToString() + ": " + majorsAsList[maxIndex].major + " (" + counts.Max().ToString() + ")");
                    counts.RemoveAt(maxIndex);
                    majorsAsList.RemoveAt(maxIndex);
                }
                /*
                int bottomCount = 5;
                Console.WriteLine();
                Console.WriteLine("Bottom " + bottomCount.ToString() + ":");
                var majorsToReverseIterate = new List<string>();
                var countsToReverseIterate = new List<int>();
                int ind = 0;
                while (true)
                {
                    if (ind >= bottomCount)
                        break;
                    var minIndex = counts.IndexOf(counts.Min());
                    var thing = majorsAsList[minIndex].major;
                    if (thing != "Life Safety & Fire Systems Specialist" && 
                        thing != "Guest Lodging Coordinator PT" &&
                        thing != "Graduate Enrollment Counselor" &&
                        thing != "Personal Selling" &&
                        thing != "Quick Print Assistant" &&
                        thing != "Assistant Department Manager" &&
                        thing != "Instructor" &&
                        thing != "English-Graduate" &&
                        thing != "Student Production Manager Pt" &&
                        thing != "Director of Purchasing Services")
                    {
                        majorsToReverseIterate.Add(thing);
                        countsToReverseIterate.Add(counts.Min());
                        ind++;
                    }
                    counts.RemoveAt(minIndex);
                    majorsAsList.RemoveAt(minIndex);
                }
                for (int i = majorsToReverseIterate.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine((i + 1).ToString() + ": " + majorsToReverseIterate[i] + " (" + countsToReverseIterate[i].ToString() + ")");
                }*/
            }
        }

        public static void GetRelationshipStats()
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
                Console.WriteLine(singleCount + " (" + Math.Round(((double)100 * singleCount) / totalCountWhoPutRelStatus).ToString() + "%) put their status as \"Single\".");
                Console.WriteLine(inARelationshipCount + " (" + Math.Round(((double)100 * inARelationshipCount) / totalCountWhoPutRelStatus).ToString() + "%) put their status as \"In a relationship\".");
                Console.WriteLine(engagedCount + " (" + Math.Round(((double)100 * engagedCount) / totalCountWhoPutRelStatus).ToString() + "%) put their status as \"Engaged\".");
                Console.WriteLine(marriedCount + " (" + Math.Round(((double)100 * marriedCount) / totalCountWhoPutRelStatus).ToString() + "%) put their status as \"Married\".");

                Console.WriteLine();

                int singleWithBioCount = db.RelationshipStatuses.Where(x => x.status == "Single").Where(x => db.Bios.Where(y => y.userName == x.userName).FirstOrDefault() != null).Count();
                int inARelationshipWithBioCount = db.RelationshipStatuses.Where(x => x.status == "In a relationship").Where(x => db.Bios.Where(y => y.userName == x.userName).FirstOrDefault() != null).Count();
                int engagedWithBioCount = db.RelationshipStatuses.Where(x => x.status == "Engaged").Where(x => db.Bios.Where(y => y.userName == x.userName).FirstOrDefault() != null).Count();
                int marriedWithBioCount = db.RelationshipStatuses.Where(x => x.status == "Married").Where(x => db.Bios.Where(y => y.userName == x.userName).FirstOrDefault() != null).Count();
                Console.WriteLine(singleWithBioCount + " (" + Math.Round(((double)100 * singleWithBioCount)/singleCount) + "%) of people who put their status as \"Single\" also put a bio.");
                Console.WriteLine(inARelationshipWithBioCount + " (" + Math.Round(((double)100 * inARelationshipWithBioCount) / inARelationshipCount) + "%) of people who put their status as \"In a relationship\" also put a bio.");
                Console.WriteLine(engagedWithBioCount + " (" + Math.Round(((double)100 * engagedWithBioCount) / engagedCount) + "%) of people who put their status as \"Engaged\" also put a bio.");
                Console.WriteLine(marriedWithBioCount + " (" + Math.Round(((double)100 * marriedWithBioCount) / marriedCount) + "%) of people who put their status as \"Married\" also put a bio.");

                Console.WriteLine();

                Console.WriteLine("Class standing of people who put \"Engaged\":");
                foreach (var user in db.RelationshipStatuses.Where(x => x.status == "Engaged"))
                {
                    Console.WriteLine(db.Users.Where(x => x.userName == user.userName).FirstOrDefault().standing);
                }

                Console.WriteLine();

                int singleFR = db.Users.Where(x => x.standing == "FR").Where(x => db.RelationshipStatuses.Where(y => y.userName == x.userName).Where(y => y.status == "Single").FirstOrDefault() != null).Count();
                int singleSO = db.Users.Where(x => x.standing == "SO").Where(x => db.RelationshipStatuses.Where(y => y.userName == x.userName).Where(y => y.status == "Single").FirstOrDefault() != null).Count();
                int singleJR = db.Users.Where(x => x.standing == "JR").Where(x => db.RelationshipStatuses.Where(y => y.userName == x.userName).Where(y => y.status == "Single").FirstOrDefault() != null).Count();
                int singleSR = db.Users.Where(x => x.standing == "SR").Where(x => db.RelationshipStatuses.Where(y => y.userName == x.userName).Where(y => y.status == "Single").FirstOrDefault() != null).Count();

                int relFR = db.Users.Where(x => x.standing == "FR").Where(x => db.RelationshipStatuses.Where(y => y.userName == x.userName).Where(y => y.status == "In a relationship").FirstOrDefault() != null).Count();
                int relSO = db.Users.Where(x => x.standing == "SO").Where(x => db.RelationshipStatuses.Where(y => y.userName == x.userName).Where(y => y.status == "In a relationship").FirstOrDefault() != null).Count();
                int relJR = db.Users.Where(x => x.standing == "JR").Where(x => db.RelationshipStatuses.Where(y => y.userName == x.userName).Where(y => y.status == "In a relationship").FirstOrDefault() != null).Count();
                int relSR = db.Users.Where(x => x.standing == "SR").Where(x => db.RelationshipStatuses.Where(y => y.userName == x.userName).Where(y => y.status == "In a relationship").FirstOrDefault() != null).Count();

                Console.WriteLine(singleFR + " (" + Math.Round(((double)100 * singleFR) / (singleFR + relFR)) + "%) of freshmen who put a relationship status set it to \"Single\".");
                //Console.WriteLine(relFR + " (" + Math.Round(((double)100 * relFR) / (singleFR + relFR)) + "%) of freshmen who put a relationship status set it to \"In a relationship\".");
                //Console.WriteLine();
                Console.WriteLine(singleSO + " (" + Math.Round(((double)100 * singleSO) / (singleSO + relSO)) + "%) of sophomores who put a relationship status set it to \"Single\".");
                //Console.WriteLine(relSO + " (" + Math.Round(((double)100 * relSO) / (singleSO + relSO)) + "%) of sophomores who put a relationship status set it to \"In a relationship\".");
                //Console.WriteLine();
                Console.WriteLine(singleJR + " (" + Math.Round(((double)100 * singleJR) / (singleJR + relJR)) + "%) of juniors who put a relationship status set it to \"Single\".");
                //Console.WriteLine(relJR + " (" + Math.Round(((double)100 * relJR) / (singleJR + relJR)) + "%) of juniors who put a relationship status set it to \"In a relationship\".");
                //Console.WriteLine();
                Console.WriteLine(singleSR + " (" + Math.Round(((double)100 * singleSR) / (singleSR + relSR)) + "%) of seniors who put a relationship status set it to \"Single\".");
                //Console.WriteLine(relSR + " (" + Math.Round(((double)100 * relSR) / (singleSR + relSR)) + "%) of seniors who put a relationship status set it to \"In a relationship\".");
                //Console.WriteLine();

                /*
                var majorSingles = new Dictionary<string, int>();
                var majorRels = new Dictionary<string, int>();

                foreach (var major in db.Majors)
                {
                    majorSingles[major.major] = 0;
                    majorRels[major.major] = 0;
                    // existential crisis moment
                    // there is absoltely no way this is even remotely efficient
                    // I'm pretty sure I'm actively killing puppies with how bad this is
                    foreach (var user in db.RelationshipStatuses.Where(x => db.UserMajors.Where(y => y.major == major.major).Where(y => y.userName == x.userName).FirstOrDefault() != null))
                    {
                        if (user.status == "Single")
                        {
                            majorSingles[major.major]++;
                        }
                        else if (user.status == "In a relationship")
                        {
                            majorRels[major.major]++;
                        }
                    }
                }

                var majorSinglesAsList = from entry in majorSingles orderby entry.Value descending select entry;
                var majorRelsAsList = from entry in majorRels orderby entry.Value descending select entry;

                foreach (var item in majorSinglesAsList)
                {
                    Console.WriteLine(item.Key + ": " + item.Value + " single people.");
                }
                */
            }
        }

        public static void BioInfo()
        {
            using (var db = new DatabaseContext())
            {
                var bios = db.Bios.ToList();
                string longestBio = bios[0].bio;
                string shortestBio = bios[0].bio;
                foreach (var bio in bios)
                {
                    if (bio.bio.Length > longestBio.Length)
                        longestBio = bio.bio;
                    if (bio.bio.Length < shortestBio.Length)
                        shortestBio = bio.bio;
                }

                Console.WriteLine("Longest bio:");
                Console.WriteLine(longestBio);
                Console.WriteLine();
                Console.WriteLine("Shortest bio:");
                Console.WriteLine(shortestBio);


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

        public static void GetSameBirthday()
        {
            Console.Clear();
            Console.Write("Month: ");
            int month = Int32.Parse(Console.ReadLine());
            Console.Write("Day: ");
            int day = Int32.Parse(Console.ReadLine());
            using (var db = new DatabaseContext())
            {
                foreach (var user in db.Users.Where(x => x.birthdayDay == day).Where(x => x.birthdayMonth == month))
                {
                    Console.Write(user.firstName);
                    Console.Write(" ");
                    Console.WriteLine(user.lastName);
                }
            }
        }
    }
}
