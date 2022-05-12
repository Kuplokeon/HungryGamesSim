using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.CodeDom;
using System.ComponentModel;

namespace HungryGamesSim
{
    class Program
    {
        static void Main(string[] args)
        {
            Setup();
        }

        static void Setup()
        {
            //Console.WriteLine("How many players (2-50)");

            //List<Character> characters = SetUpCharacters();
            //List<Character> characters = AutoLoadCharacters();
            List<Character> characters = AutoLoadCharactersNUMBER(100);
            //List<Character> characters = SetUpCharactersV2();

            Console.Clear();
            Console.WriteLine("Everyone stands on dinner plates and stare at the large Toyota Corolla in the middle of the arena.\nA few seconds pass, and BAM! a pistol fires to initiate the games.");
            DisplayAllCharacterNames(characters, true);

            Console.WriteLine("\n\tPress ENTER to start.");
            Console.ReadLine();

            StartGame(characters);

            //Console.Clear();
            //Console.WriteLine(numPlayers);
            Console.ReadLine();
            //Console.WriteLine("dude hell yea");
        }

        static int GetNumPlayers()
        {
            Console.WriteLine("How many players (2-50)");
            int numPlayers = 0;
            while (!(numPlayers >= 2 && numPlayers <= 50))
            {
                if (!int.TryParse(Console.ReadLine(), out numPlayers))
                {
                    Console.Clear();
                    Console.WriteLine("Please input a valid number between 2 and 50.");
                }
            }
            return numPlayers;
        }

        static List<Character> SetUpCharactersV2()
        {
            bool addingNames = true;

            List<Character> characters = new List<Character>();

            #region
            int counter = 0;
            while (addingNames)
            {
                Console.WriteLine("Please input the name of character #" + (counter + 1) + ". Type \"STOP\" to finalize character list.");
                string inputString = Console.ReadLine();

                string stringToCheck = inputString.Replace(" ", "");
                if (stringToCheck == "STOP" || 
                    stringToCheck == "QUIT" ||
                    stringToCheck == "EXIT" ||
                    stringToCheck == "CANCEL")
                {
                    addingNames = false;
                } else
                {
                    
                    Character newCharacter = new Character();
                    newCharacter.Initialize(inputString);
                    characters.Add(newCharacter);
                }

                Console.Clear();

                counter++;
            }
            #endregion

            #region
            Console.WriteLine("\t\t~ CHARACTER EDITING ~");
            bool editingNames = true;

            while (editingNames)
            {
                Console.Clear();
                DisplayAllCharacterNames(characters, true);
                Console.WriteLine("\nWould you like to edit any character's name? (Y/N)");
                string editNameChoice = Console.ReadLine().ToUpper();
                if (editNameChoice.Contains("Y"))
                {
                    Console.WriteLine("\nWhich name would you like to edit?");

                    Character characterToEdit = null;

                    string playerInput = Console.ReadLine();
                    int characterIndex;

                    if (int.TryParse(playerInput.Replace("#", ""), out characterIndex))
                    {
                        characterToEdit = characters[characterIndex - 1];
                    }
                    else
                    {
                        foreach (Character i in characters)
                        {
                            if (i.name == playerInput)
                            {
                                characterToEdit = i;
                            }
                        }
                    }

                    Console.WriteLine("\nWhat will their new name be?");

                    characterToEdit.name = Console.ReadLine();


                }
                else if (editNameChoice.Contains("N"))
                {
                    editingNames = false;
                }
            }
            #endregion

            return characters;
        }
        
        static List<Character> SetUpCharacters()
        {
            int numPlayers = GetNumPlayers();
            List<Character> characters = new List<Character>(numPlayers);

            Console.Clear();
            Console.WriteLine("CHARACTER NAMING");
            for (int i = 0; i < numPlayers; i++)
            {
                Console.WriteLine("\nPlease input the name of character #" + (i + 1));
                Character newCharacter = new Character();
                newCharacter.Initialize(Console.ReadLine());
                characters.Add(newCharacter);
            }

            Console.WriteLine("\t\t~ CHARACTER EDITING ~");
            bool editingNames = true;

            while (editingNames)
            {
                Console.Clear();
                DisplayAllCharacterNames(characters, true);
                Console.WriteLine("\nWould you like to edit any character's name? (Y/N)");
                string editNameChoice = Console.ReadLine().ToUpper();
                if (editNameChoice.Contains("Y"))
                {
                    Console.WriteLine("\nWhich name would you like to edit?");

                    Character characterToEdit = null;

                    string playerInput = Console.ReadLine();
                    int characterIndex;

                    if (int.TryParse(playerInput.Replace("#", ""), out characterIndex))
                    {
                        characterToEdit = characters[characterIndex - 1];
                    }
                    else
                    {
                        foreach (Character i in characters)
                        {
                            if (i.name == playerInput)
                            {
                                characterToEdit = i;
                            }
                        }
                    }

                    Console.WriteLine("\nWhat will their new name be?");

                    characterToEdit.name = Console.ReadLine();


                }
                else if (editNameChoice.Contains("N"))
                {
                    editingNames = false;
                }
            }

            Console.Clear();

            return characters;
        }

        static List<Character> AutoLoadCharactersNUMBER(int num)
        {
            List<Character> characters = new List<Character>();

            for (int i = 0; i < num; i++)
            {
                Character newGuy = new Character();
                //newGuy.Initialize("Jacob #" + (i + 1));
                newGuy.Initialize("SUPERSPAMTON");
                characters.Add(newGuy);
            }

                return characters;
        }

        static List<Character> AutoLoadCharacters()
        {
            List<Character> characters = new List<Character>();
            List<string> names = new List<string>
            {
                /*"Reece",
                "Rachel",
                "Garrett",
                "Taylor",
                "Kait",
                "Jesus Christ",
                "Satan",
                "Biblically Accurate Angel",
                "Joe Mama",
                "Steve Harvey",
                "Dr. Phil",
                "Cameron Bale",
                "Cheese",
                "Refrigerator",
                "Host",
                "The Grand Master",
                "a corrupted wendigo",
                "Guaard",
                "Lyson",
                "Ixa",
                "Grant",
                "Freddy Fazbore",
                "Peter Griffin",
                "Stuff",
                "Glamrok Febby",
                "Pheb",
                "Larry",
                "Slenderman",
                "Nick D",
                "Jacobathy",
                "Nick C",
                "The Guy",
                "Mario Mario",
                "Luigi Mario",
                "your son",
            //};
            //{
                "Sirius Blak",
                "Britanny",
                "Crab",
                "Goyle",
                "Da Death Deelers",
                "Dobby",
                "Dracula",
                "Albert Dumblydore",
                "Fred",
                "Gorge",
                "Cornelia Fuck",
                "Mystery of Magic Official",
                "Hargrid",
                "Hedwig",
                "Voldemint",
                "Paris Hillton",
                "Loopin",
                //"Luna Lovegood",
                "Draco Malfoy",
                "Lucian Malfoy",
                //"Marlian Munson",
                "Morty McFli",
                "Mc Goggle",
                "Mediocre Dunces",
                "Snope",
                "Magical Magic Creatures",
                "Hair of the Magical Magic Creatures",
                "Filth the cat",
                "Mr. Norris",
                "The Norse",
                "James Potter",
                "Vampire Potter",
                "Preps",
                "Posers",
                "Serious Black",
                //"Tom Rid",
                "Doris Rumbridge",
                //"Cedric",
                "Proffesor Sinister",
                "Professor Slutborn",
                "B'loody Mary",
                "Snaketail",
                "Professor Snape",
                "Volkswagon",
                "Ebony Darkness Dementia Raven Way",
                "Diabolo Weasley",
                "Mr. Weasley",
                "Darkness Weasley",
                "Willow",
                //"Dumbledark",
                //"Dumbledoor",
                //"Dumblydore",
                //"Dumbelldum",
                //"Dumblydumb",
                //"Dumblydunk",
                //"Doomblydoor",
            // };
            // { 
                "Turtle Planter",
                "Buildabear Umbreon",
                "Albino Mincchino",
                "Albino Pachirisu",
                "Refrigerator",
                "Reece",
                "Rachel",
                "Taylor",
                "Garrett",
                "Kait",
                "Hyena Beel",
                "z",
                "Monty",
                "the Montgomery House",
                "Sundrop",
                "Chocolate Soldier",
                "Banana Man",
                "Babybird",
                "Cookie",
                "Neil Ciceriega",
                "Red (Taylor's Version)",
                "your son",
                "Sheldon Cooper",
                "Sorbet Shark Cookie",
                "Fig Cookie",
                "a large box",
                "Luigi",
                "Bowser Build-a-bear",
                "Glamrock Freddy",
                "firstname lastname",
                "YN",
                "MC",
                "Reader-Chan",
                "Truck-kun",
                "Obama",
                "Two Trucks",
                "Moondrop",
                "Ebony Darkness Dementia Ravenway",
                "Dumblydore",
                "Little D #2",
                "Carlos",
                "J u a n",
                "the entire family of Charmin bears",
                "The house of lamintation (building)",
                "Jesus Christ Superstar",
                "Satan",
                "Sha na na",
                "The Beach Boys",
                "a cat from Cats (2019)",
                "Santa Claus",
                "The Ice Cream Bunny",
                "Miss Velma (carnage mode)",
                "Snoopy",
                "Shaggy",
                "Peter Griffin",
                "Stewart Little",
                "Shadowman",
                "NordVPN Man",
                "Mother Man",
                "Raycon Man",
                "Lucifer (Pretty)",
                "Lucifer (Ugly)",
                "Luther Krank",
                "Nora Krank",
                "Vic Frohmeyer",
                "Sneppy",
                "Mr. Anderbro",
                "Anbrose \"Kenny\" Smith",
                "King Gizzard",
                "Lizard Wizard",
                "your \"son\"",
                "Mother Gaddie",
                "Father Gaddie",
                "the fifth roommate",
                "Poisoned Mushroom Cookie",
                "Couch Guy",
                "Pillowman",
                "The Unhinged",
                "The Unhinged and Degloved",
                "Shinx",
                "Stuff",
                "The Pringles guy",
                "Things",
                "The federal agents outside Stuff's house",
                "Ralsei with a gun",
                "a jar of roasted peanuts",
                "Amazon Prime delivery truck",
                "Phone Guy",
                "Ultra-Duster",
            //};
            //{
                "Reece",
                "Jacob",
                "Matt",
                "Dylan",
                "Nick",
                "Cheese",
                "Wind",
                "Abraham Lincoln",
                "John Locke",
                "Sussy Baka",
                "Refrigerator",
                "Minecraft Steve",
                "Sbeve",
                "Bonzi Buddy",
                "Baldi",
                "Frederick Fitzgerald Fazbearington III",
                "Name",
                "Ethan",
            //};
            //{
                "Barte",
                "Bide mc Wide",
                "Buge mc Huge",
                "Don mc Long",
                "Gall mc Tall",
                "Buford",
                "Cheese",
                "Chez",
                "Chief",
                "Fibula",
                "Gary",
                "Gavin",
                "Grand Master",
                "Igrok",
                "Guaard",
                "Host",
                "Larry",
                "Ixa",
                "Grant",
                "Lyson",
                "Innkeeper",
                "Mr. Meaner",
                "Old Man",
                "Pheb",
                "Rena",
                //"Refrigerator",
                "Tibia",
                "Terry",
                "Trevor",
                "your dad",
                "your mom",
                "my son",
                "SUPERSPAMTON",*/
                "Jon Arbuckle",
                "Garfield",
                "Garfeldi",
                "Garfunkle",
            };

            foreach (string i in names)
            {
                Character newCharacter = new Character();
                newCharacter.Initialize(i);
                if (i == "SUPERSPAMTON")
                {
                    newCharacter.health += 25;
                    newCharacter.effects.Add(new Effect ("The Superspampinator"));
                }
                characters.Add(newCharacter);
            }

            return characters;
        }

        static void DisplayAllCharacterNames(List<Character> characters, bool addIndex = false)
        {
            int counter = 0;
            foreach (Character i in characters)
            {
                string stringToWrite = i.name;

                if (addIndex)
                {
                    stringToWrite = "#" + (counter + 1) + " - " + stringToWrite;
                }

                Console.WriteLine(stringToWrite);

                counter++;
            }
        }

        static void StartGame(List<Character> characters)
        {
            while (true)
            {
                List<string> deaths = new List<string>();
                PlayDay(characters, 3, out deaths);

                CannonCeremony(deaths, true, characters);
            }
        }

        static void CannonCeremony(List<string> names, bool displayRemaining = false, List<Character> charactersLeft = null)
        {
            Console.Clear();
            Console.WriteLine("As the sun falls past the horizon, " + names.Count + " cannon shots are heard in the distance...\n");

            foreach (string i in names)
            {
                Console.WriteLine(i);
            }

            if (displayRemaining)
            {
                Console.WriteLine("\n\tRemaining characters:");
                DisplayAllCharacterNames(charactersLeft);
            }

            Console.WriteLine("\n\tPress ENTER to continue");
            Console.ReadLine();
        }

        static void PlayDay(List<Character> characters, int roundsPerDay, out List<string> finalDeaths)
        {
            List<string> deaths = new List<string>();
            for (int i = 0; i < roundsPerDay; i++)
            {
                Console.Clear();

                List<string> deathsFound;
                if (characters.Count == 1)
                {
                    GameOver(characters[0]);
                }
                PlayRound(characters, out deathsFound);
                deaths.AddRange(deathsFound);

                Console.WriteLine("\n\tPress ENTER to continue");
                Console.ReadLine();
            }
            finalDeaths = deaths;
        }

        static void PlayRound(List<Character> characters, out List<string> deaths)
        {
            List<string> deathsFound = new List<string>();

            List<Event> allEvents = new List<Event>()
            {
                #region Team Kills
                new Event (3, "NAME_0 corners NAME_1 and NAME_2. NAME_0 kills them both."){ results = new List<EventResult>{ new EventResult("DEATH\t1"), new EventResult("DEATH\t2") } },
                new Event (3, "NAME_0 corners NAME_1 and NAME_2. NAME_1 and NAME_2 team up to kill NAME_0"){ results = new List<EventResult>{ new EventResult("DEATH\t0") } },
                #endregion

                #region Solo Kills
                new Event (2, "NAME_0 starts to play Wonderwall, and is killed immediately by NAME_1."){ results = new List<EventResult>{ new EventResult("DEATH\t0") } },
                new Event (2, "NAME_0 devours NAME_1."){ results = new List<EventResult>{ new EventResult("DEATH\t1") } },
                new Event (2, "NAME_0 bites the dust."){ results = new List<EventResult>{ new EventResult("DEATH\t0") } },
                new Event (2, "NAME_0 stabs NAME_1."){ results = new List<EventResult>{ new EventResult("DEATH\t1") } },
                new Event (2, "NAME_0's head just *does that*"){ results = new List<EventResult>{ new EventResult("DEATH\t0") } },
                new Event (2, "NAME_0 gets Detroit Smashed by NAME_1!"){ results = new List<EventResult>{ new EventResult("DEATH\t0") } },
                new Event (2, "NAME_0 stabs NAME_1 37 times in the chest."){ results = new List<EventResult>{ new EventResult("DEATH\t1") } },
                //new Event (2, "NAME_0 time travels to the past and kills NAME_1's great-great-grandmother. NAME_1 fades away..."){ results = new List<EventResult>{ new EventResult("DEATH\t1") } },
                //new Event (2, "NAME_0 time travels to the past and kills NAME_1's great-great-grandparents. NAME_1 and NAME_2 fades away..."){ results = new List<EventResult>{ new EventResult("DEATH\t1") } },
                new Event (2, "NAME_0 silently snaps NAME_1's neck."){ results = new List<EventResult>{ new EventResult("DEATH\t1") } },
                new Event (3, "NAME_0 fades away into the mist..."){ results = new List<EventResult>{ new EventResult("DEATH\t0") } },
                new Event (3, "NAME_0 eats a silicon gel packet, and escapes the simulation!"){ results = new List<EventResult>{ new EventResult("DEATH\t0") } },
                //new Event (3, "NAME_0 leaves the arena"){ results = new List<EventResult>{ new EventResult("DEATH\t0") } },
                //new Event (2, "NAME_0 dies of dysentery."){ results = new List<EventResult>{ new EventResult("DEATH\t0") } },
                new Event (2, "NAME_0 and NAME_1 decide to settle things with a coin flip. Heads! NAME_0 slits NAME_1's throat."){ results = new List<EventResult>{ new EventResult("DEATH\t1") } },
                new Event (2, "NAME_0 and NAME_1 decide to settle things with a coin flip. Tails! NAME_1 slits NAME_0's throat."){ results = new List<EventResult>{ new EventResult("DEATH\t0") } },
                new Event (2, "NAME_0 and NAME_1 decide to settle things with a coin flip. It lands on its side!"),
                new Event (2, "NAME_0 triple-dog-dares NAME_1 to eat some suspicious berries. The berries were poisonous."){ results = new List<EventResult>{ new EventResult("DEATH\t1") } },
                #endregion

                #region Empty Events
                new Event (2, "NAME_0 and NAME_1 start a game of chess. NAME_0 wins!"),
                new Event (2, "NAME_0 and NAME_1 start a game of chess. NAME_1 wins!"),
                //new Event (2, "NAME_0 and NAME_1 start a game of chess. It's a draw."),
                new Event (2, "NAME_0 and NAME_1 start a game of chess. NAME_0 gets frustrated and starts eating the pieces."),
                new Event (2, "NAME_0 smells NAME_1. It was not a great idea."),
                new Event (2, "NAME_0 smells NAME_1. It was a great idea."),
                new Event (1, "Today is a great day."),
                new Event (1, "NAME_0 throws their canteen like a frisbee. It flew pretty far."),
                new Event (1, "NAME_0 does a little dance."),
                new Event (1, "NAME_0 puts a little spring in their step."),
                new Event (1, "NAME_0 does a little jig."),
                new Event (1, "NAME_0 started skipping stones."),
                new Event (1, "NAME_0 discovers what the point of the mask is."),
                new Event (1, "NAME_0 learns to ride a bike!"),
                new Event (1, "NAME_0 does a totally sick backflip."),
                new Event (2, "NAME_0 punches NAME_1 in the face."),
                new Event (1, "NAME_0 asks who Joe is..."),
                new Event (1, "NAME_0 goes sicko mode."),
                new Event (1, "NAME_0 enters cilantro mode."),
                new Event (1, "NAME_0 makes room for Jesus in their heart."),
                new Event (1, "NAME_0 watches the clock."),
                new Event (1, "NAME_0 eats a sandwich. It's pretty good."),
                new Event (1, "NAME_0 eats a sandwich. It's not great."),
                new Event (1, "NAME_0 learns the true meaning of Christmas."),
                new Event (1, "NAME_0 eats snake bread."),
                new Event (1, "NAME_0 hunts for food."),
                new Event (1, "NAME_0 wakes up from a deep sleep."),
                new Event (1, "NAME_0 gets a good night's rest."),
                new Event (1, "NAME_0 finally wakes up."),
                new Event (1, "NAME_0 carefully picks berries"),
                new Event (3, "NAME_0, NAME_1, and NAME_2 bring their food together, and have a feast!"),
                new Event (1, "NAME_0 touches some grass."),
                new Event (1, "NAME_0 climbs a tree to get a better view of the arena."),
                new Event (1, "NAME_0 starts a small fire."),
                new Event (1, "NAME_0 purchases [illegal substances]."),
                new Event (1, "NAME_0 screams into the void."),
                new Event (1, "NAME_0 commits mitosis") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 part ii") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (2, "NAME_0 and NAME_1 f u c k e d") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t20") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tNAME_0 and NAME_1's kid") } },
                new Event (1, "NAME_0 screams into the void. The void screams back."),
                new Event (1, "NAME_0 screams into the void. A strange creature walks out of the void...") { conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t15") }, results=new List<EventResult> { new EventResult ("NEW PLAYER\tVoid Creature") } },
                new Event (2, "NAME_0 and NAME_1 scream into the void together."),
                //new Event (1, "NAME_0 loses their credit card. oops."),
                new Event (1, "NAME_0 loses their street cred."),
                new Event (1, "NAME_0 gains 5 million social credit."),
                new Event (2, "NAME_0 insults NAME_1's posture."),
                new Event (1, "NAME_0 sings Daydream Believer, but isn't very good at it."),
                new Event (4, "NAME_0, NAME_1, NAME_2, and NAME_3 start a band! They're not great, but they're in it for the fun."),
                new Event (4, "NAME_0, NAME_1, NAME_2, and NAME_3 start a band! They're an instant hit among the various woodland creatures!"),
                new Event (2, "NAME_0 finds a man-made horror beyond their comprehension. They promptly walk away."),
                new Event (2, "NAME_0 finds a man-made horror beyond their comprehension. The try to run away, but are not fast enough..."){ results = new List<EventResult>{ new EventResult("DEATH\t0") } },
                new Event (1, "NAME_0 gets stuck in the rain."),
                new Event (1, "NAME_0 finds an egg. It it a good egg."),
                new Event (1, "NAME_0 smells something funny."),
                new Event (1, "NAME_0 adds an extra scoop of protein to their protein shake, before topping it off with one more scoop of protein."),
                new Event (3, "NAME_0, NAME_1, and NAME_2 have a heated debate of which KK song is the best."),
                new Event (1, "NAME_0 drinks a tall glass of ice water."),
                new Event (1, "NAME_0 drinks a glass of water. There were bugs in it."),
                new Event (1, "NAME_0 drinks a glass of water. There were bugs in it, but NAME_0 ignores them."),
                new Event (1, "NAME_0 gets a computer virus. Fortunately, they have NordVPN!"),
                new Event (1, "NAME_0 stops to smell the flowers."),
                new Event (2, "NAME_0 steals food from NAME_1."),
                new Event (2, "NAME_0 insults NAME_1's hair style. NAME_1 promptly slashes NAME_0's throat."){ results = new List<EventResult>{ new EventResult("DEATH\t0") } },
                new Event (2, "NAME_0 draws a picture of NAME_1. It's not great, but NAME_1 loves it!"),
                new Event (2, "NAME_0 draws a picture of NAME_1. It's truly a masterpiece!"),
                //new Event (2, "NAME_0 draws a picture of NAME_1. NAME_1 is offended by it, and kills NAME_0."){ results = new List<EventResult>{ new EventResult("DEATH\t0") } },
                new Event (2, "NAME_0 and NAME_1 have a rap battle! Emotionally, no-one survives."),
                new Event (2, "NAME_0 and NAME_1 have a picnic!"),
                new Event (2, "NAME_0 and NAME_1 eat strange berries."),
                new Event (2, "NAME_0 and NAME_1 boogie down."),
                new Event (3, "NAME_0, NAME_1, and NAME_2 meet up to discuss plans. Everyone survives."),
                new Event (6, "NAME_0, NAME_1, NAME_2, NAME_3, NAME_4, and NAME_5 meet up to discuss hexagons."),
                #endregion

                #region Status Effects

                #region Obtaining
                new Event (1, "NAME_0 falls into The Sludge, and contracts Bad Syndrome."){ conditions = new List<EventCondition>{ new EventCondition("DOES NOT HAS EFFECT\t0\tBad Syndrome") }, results = new List<EventResult> { new EventResult ("EFFECT\t0\tBad Syndrome") } },
                new Event (1, "NAME_0 has dysentery!"){ conditions = new List<EventCondition>{ new EventCondition("DOES NOT HAS EFFECT\t0\tDysentery") }, results = new List<EventResult> { new EventResult ("EFFECT\t0\tDysentery") } },
                new Event (1, "NAME_0 is bitten by a vampire!"){ conditions = new List<EventCondition>{ new EventCondition("DOES NOT HAS EFFECT\t0\tVampire") }, results = new List<EventResult> { new EventResult("EFFECT\t0\tVampire") } },
                new Event (1, "NAME_0 finds the ornamental dagger!"){ conditions = new List<EventCondition>{ new EventCondition("CHANCE\t10"), new EventCondition("DOES NOT HAS EFFECT\t0\tornamental dagger") }, results = new List<EventResult> { new EventResult ("EFFECT\t0\tornamental dagger") } },
                new Event (1, "NAME_0 holds the ornamental dagger into the air. Lightning strikes the dagger, and NAME_0 officially goes God Mode!"){ conditions = new List<EventCondition>{ new EventCondition("DOES NOT HAS EFFECT\t0\tGod Mode"), new EventCondition("HAS EFFECT\t0\tornamental dagger") }, results = new List<EventResult> { new EventResult ("EFFECT\t0\tGod Mode"), new EventResult("HEAL\t0\t999999") } },
                new Event (1, "NAME_0 wanders into Slender's Woods..."){ conditions = new List<EventCondition>{ new EventCondition("DOES NOT HAS EFFECT\t0\tSlenders Woods") }, results = new List<EventResult> { new EventResult ("EFFECT\t0\tSlenders Woods") } },
                new Event (1, "NAME_0 has contracted Horny Syndrome ;) ;) ;)"){ conditions = new List<EventCondition>{ new EventCondition("DOES NOT HAS EFFECT\t0\tHorny Syndrome") }, results = new List<EventResult> { new EventResult ("EFFECT\t0\tHorny Syndrome") } },
                new Event (1, "NAME_0 found some Gold Hellfire Newt Absinthe!"){ conditions = new List<EventCondition>{ new EventCondition("DOES NOT HAS EFFECT\t0\tGold Hellfire Newt Absinthe") }, results = new List<EventResult> { new EventResult ("EFFECT\t0\tGold Hellfire Newt Absinthe") } },


                new Event (1, "NAME_0 eats a Dragon Berry. They're not feeling so well..."){ conditions = new List<EventCondition>{ new EventCondition ("CHANCE\t25"), new EventCondition("DOES NOT HAS EFFECT\t0\tDragon Berry"), new EventCondition("DOES NOT HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("EFFECT\t0\tDragon Berry") } },
                new Event (1, "The dragon berry in NAME_0's body awakens, transforming them into a fully-fledged dragon!!"){ conditions = new List<EventCondition>{ new EventCondition("DOES NOT HAS EFFECT\t0\tDragon!!!"), new EventCondition("HAS EFFECT\t0\tDragon Berry") }, results = new List<EventResult> { new EventResult ("EFFECT\t0\tDragon!!!"), new EventResult("REMOVE EFFECT\t0\tDragon Berry"), new EventResult("HEAL\t0\t3"), new EventResult ("NAME\tNAME_0 the dragon") } },
                #endregion

                #region Cures
                new Event (1, "NAME_0 falls into The Sludge, and is cured of Bad Syndrome!"){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tBad Syndrome") }, results = new List<EventResult> { new EventResult ("REMOVE EFFECT\t0\tBad Syndrome") } },
                new Event (1, "NAME_0 escapes Slender's Woods!"){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tSlenders Woods") }, results = new List<EventResult> { new EventResult ("REMOVE EFFECT\t0\tSlenders Woods") } },
                new Event (2, "NAME_1 bonks NAME_0, and is cured of Horny Syndrome!"){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tHorny Syndrome") }, results = new List<EventResult> { new EventResult ("REMOVE EFFECT\t0\tHorny Syndrome") } },
                #endregion

                #region Effects
                new Event (2, "NAME_0 succumbs to Bad Syndrome..."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tBad Syndrome") }, results = new List<EventResult> { new EventResult ("DEATH\t0") } },
                new Event (2, "NAME_0 succumbs to Horny Syndrome..."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tHorny Syndrome") }, results = new List<EventResult> { new EventResult ("DEATH\t0") } },
                new Event (2, "NAME_0 has died of dysentery."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDysentery") }, results = new List<EventResult> { new EventResult ("DEATH\t0") } },
                new Event (2, "Slenderman hangs NAME_0 from a tree like a Christmas ornament."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tSlenders Woods") }, results = new List<EventResult> { new EventResult ("DEATH\t0") } },
                new Event (2, "Slenderman hangs NAME_0 from a tree like a Christmas ornament."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tSlenders Woods") }, results = new List<EventResult> { new EventResult ("DEATH\t0") } },
                new Event (2, "Slenderman hangs NAME_0 from a tree like a Christmas ornament."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tSlenders Woods") }, results = new List<EventResult> { new EventResult ("DEATH\t0") } },
                new Event (2, "NAME_0 stabs NAME_1 with the ornamental dagger, and steals their life force."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tornamental dagger") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("HEAL\t0\t1") } },
                new Event (2, "NAME_0 uses their vampiric abillities to suck the blood from NAME_1's body."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tVampire") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("HEAL\t0\t1") } },
                new Event (2, "NAME_0 uses their vampiric abillities to turn NAME_1 into a vampire!"){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tVampire") }, results = new List<EventResult> { new EventResult ("EFFECT\t1\tVampire") } },
                new Event (2, "NAME_0, the vampire that they are, burns in the sun."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tVampire") }, results = new List<EventResult> { new EventResult ("DEATH\t0") } },
                new Event (2, "NAME_0 licks NAME_1. NAME_1 is creeped out."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tHorny Syndrome"), new EventCondition("DOES NOT HAS EFFECT\t1\tHorny Syndrome") } },
                new Event (2, "NAME_0 licks NAME_1. NAME_1 is into it."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tHorny Syndrome"), new EventCondition("HAS EFFECT\t1\tHorny Syndrome") } },
                new Event (2, "NAME_0 says Bleh!"){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tVampire") } },
                new Event (1, "NAME_0 says \"WAKA WAKA AWOOGA AWOOOGA NOW THAT'S A DAME\"!"){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tHorny Syndrom") } },
                new Event (1, "NAME_0's jaw drops and they begin panting rapidly."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tHorny Syndrom") } },
                new Event (1, "NAME_0 says OWO."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tHorny Syndrom") } },
                new Event (2, "NAME_0's eyes pop out of theirs skull when seeing NAME_1."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tHorny Syndrom") } },
                new Event (2, "NAME_0 counts for fun."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tVampire") } },
                new Event (2, "NAME_0 takes a small dose of Gold Hellfire Newt Absinthe. It's lethal."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tGold Hellfire Newt Absinthe") }, results = new List<EventResult> { new EventResult ("DEATH\t0") } },
                new Event (1, "NAME_0 takes a large dose of Gold Hellfire Newt Absinthe. It's pretty wild."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tGold Hellfire Newt Absinthe") } },
                new Event (2, "NAME_1 steals NAME_0's Gold Hellfire Newt Absinthe."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tGold Hellfire Newt Absinthe") }, results = new List<EventResult> (){ new EventResult ("REMOVE EFFECT\t0\tGold Hellfire Newt Absinthe"), new EventResult("EFFECT\t1\tGold Hellfire Newt Absinthe") } },
                new Event (1, "NAME_0 takes a medium dose of Gold Hellfire Newt Absinthe. It's the perfect dose, and NAME_0 becomes enlightened."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tGold Hellfire Newt Absinthe") }, results = new List<EventResult> { new EventResult ("HEAL\t0\t1") } },

                #region DRAGON STUFF
                #region YEA SO SHHH
                new Event (2, "NAME_0 swoops down, and kills NAME_1."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1") } },
                new Event (3, "NAME_0 swoops down, and kills NAME_1 and NAME_2."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2") } },
                new Event (4, "NAME_0 swoops down, and kills NAME_1, NAME_2, and NAME_3."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2"), new EventResult("DEATH\t3") } },
                new Event (4, "NAME_0 Unleashes a blazing fire, burning NAME_1, NAME_2, and NAME_3."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2"), new EventResult("DEATH\t3") } },
                new Event (5, "NAME_0 Unleashes a blazing fire, burning NAME_1, NAME_2, NAME_3, and NAME_4."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2"), new EventResult("DEATH\t3"), new EventResult("DEATH\t4") } },
                #endregion
                #region YEA SO SHHH
                new Event (2, "NAME_0 swoops down, and kills NAME_1."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1") } },
                new Event (3, "NAME_0 swoops down, and kills NAME_1 and NAME_2."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2") } },
                new Event (4, "NAME_0 swoops down, and kills NAME_1, NAME_2, and NAME_3."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2"), new EventResult("DEATH\t3") } },
                new Event (4, "NAME_0 Unleashes a blazing fire, burning NAME_1, NAME_2, and NAME_3."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2"), new EventResult("DEATH\t3") } },
                new Event (5, "NAME_0 Unleashes a blazing fire, burning NAME_1, NAME_2, NAME_3, and NAME_4."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2"), new EventResult("DEATH\t3"), new EventResult("DEATH\t4") } },
                #endregion
                #region YEA SO SHHH
                new Event (2, "NAME_0 swoops down, and kills NAME_1."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1") } },
                new Event (3, "NAME_0 swoops down, and kills NAME_1 and NAME_2."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2") } },
                new Event (4, "NAME_0 swoops down, and kills NAME_1, NAME_2, and NAME_3."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2"), new EventResult("DEATH\t3") } },
                new Event (4, "NAME_0 Unleashes a blazing fire, burning NAME_1, NAME_2, and NAME_3."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2"), new EventResult("DEATH\t3") } },
                new Event (5, "NAME_0 Unleashes a blazing fire, burning NAME_1, NAME_2, NAME_3, and NAME_4."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2"), new EventResult("DEATH\t3"), new EventResult("DEATH\t4") } },
                #endregion
                #region YEA SO SHHH
                new Event (2, "NAME_0 swoops down, and kills NAME_1."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1") } },
                new Event (3, "NAME_0 swoops down, and kills NAME_1 and NAME_2."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2") } },
                new Event (4, "NAME_0 swoops down, and kills NAME_1, NAME_2, and NAME_3."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2"), new EventResult("DEATH\t3") } },
                new Event (4, "NAME_0 Unleashes a blazing fire, burning NAME_1, NAME_2, and NAME_3."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2"), new EventResult("DEATH\t3") } },
                new Event (5, "NAME_0 Unleashes a blazing fire, burning NAME_1, NAME_2, NAME_3, and NAME_4."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2"), new EventResult("DEATH\t3"), new EventResult("DEATH\t4") } },
                #endregion
                #region YEA SO SHHH
                new Event (2, "NAME_0 swoops down, and kills NAME_1."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1") } },
                new Event (3, "NAME_0 swoops down, and kills NAME_1 and NAME_2."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2") } },
                new Event (4, "NAME_0 swoops down, and kills NAME_1, NAME_2, and NAME_3."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2"), new EventResult("DEATH\t3") } },
                new Event (4, "NAME_0 Unleashes a blazing fire, burning NAME_1, NAME_2, and NAME_3."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2"), new EventResult("DEATH\t3") } },
                new Event (5, "NAME_0 Unleashes a blazing fire, burning NAME_1, NAME_2, NAME_3, and NAME_4."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("DEATH\t1"), new EventResult("DEATH\t2"), new EventResult("DEATH\t3"), new EventResult("DEATH\t4") } },
                #endregion

                new Event (1, "NAME_0 emits a terrible roar!"){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") } },
                new Event (2, "NAME_0 emits a terrible roar! NAME_1 comments on NAME_0's breath."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") } },
                
                new Event (2, "NAME_1 throws a mint into NAME_0's mouth, causing them to turn back into a human... mostly."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("REMOVE EFFECT\t0\tDragon!!!") } },

                new Event (1, "NAME_0 layed an egg!"){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("EFFECT\t0\tDragon Egg") } },
                //new Event (1, "NAME_0 layed an egg!"){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tDragon!!!") }, results = new List<EventResult> { new EventResult ("EFFECT\t0\tDragon Egg") } },
                #endregion
                
                #endregion


                #region Godmode Death
                new Event (3, "NAME_0 has been stabbed by NAME_1 while trying to save NAME_2. Their death has been deemed heroic."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tGod Mode") }, results = new List<EventResult> { new EventResult ("INSTANT DEATH\t0") } },
                new Event (3, "NAME_0 has been stabbed by NAME_1 while trying to save NAME_2. Their death has been deemed heroic."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tGod Mode") }, results = new List<EventResult> { new EventResult ("INSTANT DEATH\t0") } },
                new Event (3, "NAME_0 has been stabbed by NAME_1 while trying to save NAME_2. Their death has been deemed heroic."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tGod Mode") }, results = new List<EventResult> { new EventResult ("INSTANT DEATH\t0") } },
                new Event (2, "NAME_0 has been stabbed by NAME_1 while trying to save a passing animal. Their death has been deemed heroic."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tGod Mode") }, results = new List<EventResult> { new EventResult ("INSTANT DEATH\t0") } },
                new Event (2, "NAME_0 has been stabbed by NAME_1 while trying to save a passing animal. Their death has been deemed heroic."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tGod Mode") }, results = new List<EventResult> { new EventResult ("INSTANT DEATH\t0") } },
                new Event (2, "NAME_0 has been stabbed by NAME_1 while trying to save a passing animal. Their death has been deemed heroic."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tGod Mode") }, results = new List<EventResult> { new EventResult ("INSTANT DEATH\t0") } },
                #endregion

                #endregion

                #region Items
                //Snake Bread (cures bad syndrome)
                //Dinner Sandwich (stat boost)
                #endregion

                #region Character Specific
                new Event (1, "NAME_0 says Hot Cha!") { conditions = new List<EventCondition> { new EventCondition ("NAME\t0\tRefrigerator") } },
                new Event (1, "NAME_0 holds the Superspampinator up high!") { conditions = new List<EventCondition> { new EventCondition ("HAS EFFECT\t0\tThe Superspampinator") } },
                new Event (2, "NAME_1 steals NAME_0's Superspampinator."){ conditions = new List<EventCondition>{ new EventCondition("HAS EFFECT\t0\tSuperspampinator") }, results = new List<EventResult> (){ new EventResult ("REMOVE EFFECT\t0\tSuperspampinator"), new EventResult("EFFECT\t1\tSuperspampinator") } },

                new Event (2, "NAME_0 uses the Superspampinator on NAME_1!"){ results = new List<EventResult>{ new EventResult("DEATH\t1"), new EventResult("DEATH\t1"), new EventResult("DEATH\t1"), new EventResult("DEATH\t1"), new EventResult("DEATH\t1") } },
                #endregion
            };

            characters.Shuffle();
            //DisplayAllCharacterNames(characters, true);

            for (int i = characters.Count; i > 0;)
            {
                List<Event> usableEvents = new List<Event>();

                foreach (Event n in allEvents)
                {
                    if (i >= n.charactersToUse)
                    {
                        bool canBeUsed = true;

                        foreach (EventCondition t in n.conditions)
                        {
                            switch (t.type)
                            {
                                case EventConditionType.HasEffect:
                                    bool hasEffect = false;
                                    foreach (Effect e in characters[i - 1].effects)
                                    {
                                        if (e.name == t.data)
                                        {
                                            hasEffect = true;
                                        }
                                    }
                                    if (!hasEffect)
                                    {
                                        canBeUsed = false;
                                    }
                                    break;
                                case EventConditionType.DoesNotHasEffect:
                                    foreach (Effect e in characters[i - 1].effects)
                                    {
                                        if (e.name == t.data)
                                        {
                                            canBeUsed = false;
                                        }
                                    }
                                    break;
                                case EventConditionType.Name:
                                    if (characters[i - 1].name == t.data == false)
                                    {
                                        canBeUsed = false;
                                    }
                                    break;
                                case EventConditionType.Chance:
                                    Random rnd = new Random();
                                    if (GetRandInt(0, 100, ref rnd, 3) > int.Parse(t.data))
                                    {
                                        canBeUsed = false;
                                    }
                                    break;
                            }
                        }


                        if (canBeUsed)
                        {
                            for (int t = 0; t < n.conditions.Count + 1; t++)
                            {
                                usableEvents.Add(n);
                            }
                        }
                    }
                }

                //Random rng = new Random();
                //Event eventChosen = usableEvents[GetRandInt(0, usableEvents.Count - 1, ref rng, i)];

                usableEvents.Shuffle();
                Event eventChosen = usableEvents[0];

                List<Character> charactersIncluded = new List<Character>();

                string output = eventChosen.text.Trim();

                for (int n = 0; n < eventChosen.charactersToUse; n++)
                {
                    i--;
                    charactersIncluded.Add(characters[i]);
                    output = output.Replace(("NAME_" + n).Trim(), characters[i].name);
                }

                Console.WriteLine(output);

                if (eventChosen.results != null)
                {
                    bool toBeLogged = false;

                    foreach (EventResult n in eventChosen.results)
                    {
                        Character targetCharacter = charactersIncluded[n.target];
                        switch (n.type)
                        {
                            case EventResultType.Death:

                                targetCharacter.health--;
                                if (targetCharacter.health <= 0)
                                {
                                    deathsFound.Add(targetCharacter.name);
                                    characters.Remove(targetCharacter);
                                    toBeLogged = true;
                                }
                                else
                                {
                                    Console.WriteLine("...but " + targetCharacter.name + " lived!");
                                }

                                break;
                            case EventResultType.InstantDeath:
                                deathsFound.Add(targetCharacter.name);
                                characters.Remove(targetCharacter);
                                toBeLogged = true;
                                break;
                            case EventResultType.Effect:
                                targetCharacter.effects.Add(new Effect(n.data));
                                break;
                            case EventResultType.CureEffect:
                                for (int t = targetCharacter.effects.Count - 1; t >= 0; t--)
                                {
                                    if (targetCharacter.effects[t].name == n.data)
                                    {
                                        targetCharacter.effects.RemoveAt(t);
                                    }
                                }
                                break;
                            case EventResultType.HealthUp:
                                targetCharacter.health += int.Parse(n.data);
                                Console.WriteLine(targetCharacter.name + " has gained some extra health!");
                                break;

                            case EventResultType.NewPlayer:
                                Character newChar = new Character();
                                string newCharName = n.data;
                                int counter = 0;
                                foreach (Character t in charactersIncluded)
                                {
                                    newCharName = newCharName.Replace("NAME_" + counter, t.name);
                                    counter++;
                                }
                                newChar.Initialize(newCharName.Trim());
                                characters.Add(newChar);
                                Console.WriteLine(newCharName + " has entered the arena!");
                                break;
                            case EventResultType.Name:
                                
                                string newName = n.data;
                                int loopCounter = 0;
                                foreach (Character t in charactersIncluded)
                                {
                                    newName = newName.Replace("NAME_" + loopCounter, t.name);
                                    loopCounter++;
                                }

                                targetCharacter.name = newName;
                                break;
                        }
                    }

                    if (toBeLogged)
                    {
                        LogText(output);
                    }
                }
            }

            deaths = deathsFound;
        }

        static void GameOver(Character winner/*, List<string> finalDefeated*/)
        {
            //CannonCeremony(finalDefeated);

            #region Ending Ceremony

            Console.Clear();
            Console.WriteLine("As the dust settles around the battlefield, it seems only one player remains...");
            Console.WriteLine("");
            Console.WriteLine("\t" + winner.name + " wins!!!");
            Console.WriteLine("");
            DisplayFullLog();

            #endregion
        }

        static List<string> fullLog = new List<string>();

        static void LogText(string textToLog)
        {
            fullLog.Add(textToLog);
        }

        static void DisplayFullLog()
        {
            foreach (string i in fullLog)
            {
                Console.WriteLine(i);
            }
        }

        static int GetRandInt(int min, int max, ref Random rnd, int seed)
        {
            int num = rnd.Next(min, max);

            for (int i = 0; i < seed; i++)
            {
                num = rnd.Next(min, max);
            }
            return num;
        }

    }


    class Item
    {
        public string name;

        public Item(string name)
        {
            this.name = name;
        }
    }

    static class Extensions
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

    enum Location
    {
        Cornucopia,
        N,
        NE,
        E,
        SE,
        S,
        SW,
        W,
        NW
    }

    class Event
    {
        List<Location> possibleLocations = new List<Location>
        {
            Location.Cornucopia,
            Location.N ,
            Location.NE ,
            Location.E ,
            Location.SE ,
            Location.S ,
            Location.SW ,
            Location.W,
            Location.NW
        };

        public int charactersToUse;
        public string text;

        public List<EventResult> results = new List<EventResult>();
        public List<EventCondition> conditions = new List<EventCondition>();

        public Event(int charactersToUse, string text)
        {
            this.charactersToUse = charactersToUse;
            this.text = text;
        }
    }

    class EventCondition
    {
        public EventConditionType type;
        public int target;
        public string data;

        public EventCondition(string input)
        {
            string[] splitLine = input.Split('\t');

            switch (splitLine[0].Trim().ToUpper())
            {
                case "HAS EFFECT":
                case "EFFECT":
                    type = EventConditionType.HasEffect;
                    target = int.Parse(splitLine[1]);
                    data = splitLine[2].Trim();
                    break;
                case "DOES NOT HAS EFFECT":
                    type = EventConditionType.DoesNotHasEffect;
                    target = int.Parse(splitLine[1]);
                    data = splitLine[2].Trim();
                    break;
                case "NAME":
                    type = EventConditionType.Name;
                    target = int.Parse(splitLine[1]);
                    data = splitLine[2].Trim();
                    break;
                case "CHANCE":
                case "RNG":
                    type = EventConditionType.Chance;
                    data = splitLine[1].Trim();
                    break;
            }
        }
    }

    enum EventConditionType
    {
        HasEffect,
        DoesNotHasEffect,
        Name,
        Chance
    }

    enum EventResultType
    {
        Death,
        InstantDeath,
        Effect,
        CureEffect,
        HealthUp,
        NewPlayer,
        Name
    }

    class EventResult
    {
        public EventResultType type;
        public int target;
        public string data;

        public EventResult(string input)
        {
            string[] splitLine = input.Split('\t');

            switch (splitLine[0].Trim().ToUpper())
            {
                case "KILL":
                case "DEFEAT":
                case "DEATH":
                    type = EventResultType.Death;
                    target = int.Parse(splitLine[1]);
                    break;
                case "INSTANT KILL":
                case "INSTAKILL":
                case "INSTA-KILL":
                case "INSTANT DEFEAT":
                case "INSTANT DEATH":
                    type = EventResultType.InstantDeath;
                    target = int.Parse(splitLine[1]);
                    break;
                case "EFFECT":
                case "SICKNESS":
                case "STATUS EFFECT":
                    type = EventResultType.Effect;
                    target = int.Parse(splitLine[1]);
                    data = splitLine[2].Trim();
                    break;
                case "CURE EFFECT":
                case "EFFECTNT":
                case "REMOVE EFFECT":
                    type = EventResultType.CureEffect;
                    target = int.Parse(splitLine[1]);
                    data = splitLine[2].Trim();
                    break;
                case "HEAL":
                case "HEALTH":
                case "HEALTH UP":
                    type = EventResultType.HealthUp;
                    target = int.Parse(splitLine[1]);
                    data = splitLine[2];
                    break;
                case "NEW PLAYER":
                case "ADD PLAYER":
                case "PLAYER":
                    type = EventResultType.NewPlayer;
                    //target = int.Parse(splitLine[1]);
                    data = splitLine[1];
                    break;
                case "NAME":
                case "NEW NAME":
                case "ALTER NAME":
                case "CHANGE NAME":
                    type = EventResultType.Name;
                    data = splitLine[1];
                    break;
            }
        }
    }

    class Effect
    {
        public string name;

        public Effect(string name)
        {
            this.name = name;
        }
    }

    class Character
    {
        public string name;

        public int health = 1;
        public float speed = 5;
        public float damage = 5;
        public float defense = 5;

        public List<Effect> effects = new List<Effect>();

        public Location location = Location.Cornucopia;

        public void Initialize(string name)
        {
            Random rnd = new Random();
            speed = rnd.Next(8, 12);
            damage = rnd.Next(4, 6);
            defense = rnd.Next(4, 6);

            this.name = name;
        }
    }
}
