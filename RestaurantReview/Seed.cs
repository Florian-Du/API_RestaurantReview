using RestaurantReview.Data;
using RestaurantReview.Models;
using System.Security.Cryptography;
using System.Text;

namespace RestaurantReview
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            Random random = new Random();
            SHA256 sha256 = SHA256.Create();
            if (!dataContext.Restaurants.Any())
            {
                var Restaurants = new List<Restaurant>() {
                    new Restaurant()
                    {
                        Id = Guid.NewGuid(),
                        Name = "BurgerKing",
                        Description = "FastFood pour devenir le boss",
                        Address = "60 rue du Burger",
                        PostalCode = "12345",
                        City = "BurgersTown",
                        Country = "BurgersLand",

                        Comments = new List<Comment>()
                        {
                            new Comment()
                            {
                                Id = Guid.NewGuid(),
                                Title = "Trop boonnnn",
                                Description = "Premiere foiss pour moi a burgersTown eet je me sentais obliger de manger les burgers dee burgerKing et je ne suis pas dessus !!!!",
                                User = new User()
                                {
                                    Id = Guid.NewGuid(),
                                    UserName = "Burgers4Life69",
                                    UserEmail = "Burgers4Life69@gmail.com",
                                    Password = "Burgers4Life69",
                                    Salt = new byte[32],
                                },


                                Responses = new List<Response>()
                                {
                                    new Response()
                                    {
                                        Id = Guid.NewGuid(),
                                        Title = "Trop d'accord",
                                        Description = "Jee suis carrement d'accord avec toi Burgers4Life69, surtout les burgers au poulet",
                                        User = new User()
                                        {
                                            Id = Guid.NewGuid(),
                                            UserName = "AmoureuxDuPoulet64",
                                            UserEmail = "AmoureuxDuPoulet64@gmail.com",
                                            Password = "AmoureuxDuPoulet64",
                                            Salt = new byte[32],
                                        },
                                    },

                                    new Response()
                                    {
                                        Id = Guid.NewGuid(),
                                        Title = "Pas d'accord",
                                        Description = "Je suis pas d'accord avec vous lee mien etait froid",
                                        User = new User()
                                        {
                                            Id = Guid.NewGuid(),
                                            UserName = "MecAigri",
                                            UserEmail = "MecAigri@orange.fr",
                                            Password = "MecAigri",
                                            Salt = new byte[32],
                                        },
                                    }
                                }
                            }
                        },

                        Notes = new List<Note>()
                        {
                            new Note()
                            {
                                Id = Guid.NewGuid(),
                                Value = random.Next(1,6),
                                User = new User()
                                        {
                                            Id = Guid.NewGuid(),
                                            UserName = "MecAigri",
                                            UserEmail = "MecAigri@orange.fr",
                                            Password = "MecAigri",
                                            Salt = new byte[32],
                                        },
                            },
                            new Note()
                            {
                                Id = Guid.NewGuid(),
                                Value = random.Next(1,6),
                                User = new User()
                                {
                                    Id = Guid.NewGuid(),
                                    UserName = "HappyCoder123",
                                    UserEmail = "happy.coder@example.com",
                                    Password = "SecurePass123",
                                    Salt = new byte[32],
                                },
                            },
                            new Note()
                            {
                                Id = Guid.NewGuid(),
                                Value = random.Next(1,6),
                                User = new User()
                                {
                                    Id = Guid.NewGuid(),
                                    UserName = "TechGeek99",
                                    UserEmail = "tech.geek@example.com",
                                    Password = "GeekyPass",
                                    Salt = new byte[32],
                                }
                            },
                            new Note()
                            {
                                Id = Guid.NewGuid(),
                                Value = random.Next(1,6),
                                User = new User()
                                {
                                    Id = Guid.NewGuid(),
                                    UserName = "AdventureExplorer",
                                    UserEmail = "explorer@email.com",
                                    Password = "SecretExplorerPass",
                                    Salt = new byte[32],
                                }
                            },
                            new Note()
                            {
                                Id = Guid.NewGuid(),
                                Value = random.Next(1,6),
                                User = new User()
                                {
                                    Id = Guid.NewGuid(),
                                    UserName = "CoffeeLover",
                                    UserEmail = "coffee_lover@gmail.com",
                                    Password = "CaffeineBuzz",
                                    Salt = new byte[32],
                                }
                            },
                            new Note()
                            {
                                Id = Guid.NewGuid(),
                                Value = random.Next(1,6),
                                User = new User()
                                {
                                    Id = Guid.NewGuid(),
                                    UserName = "MusicMaestro",
                                    UserEmail = "music.maestro@example.com",
                                    Password = "Melody123",
                                    Salt = new byte[32],
                                }
                            },

                        }
                    },

                    new Restaurant()
                    {
                        Id = Guid.NewGuid(),
                        Name = "SushiShop",
                        Description = "Les meilleurs sushi que t'a jamais goûtés",
                        Address = "120 rue du sushi",
                        PostalCode = "99999",
                        City = "SushiTown",
                        Country = "SushiLand",

                        Comments = new List<Comment>()
                        {
                            new Comment()
                            {
                                Id = Guid.NewGuid(),
                                Title = "Pas ouf",
                                Description = "Vraiment pas ouf les sushi ",
                                User = new User()
                                {
                                    Id = Guid.NewGuid(),
                                    UserName = "Rageux42",
                                    UserEmail = "Rageux42@gmail.com",
                                    Password = "Rageux42",
                                    Salt = new byte[32],
                                },


                                Responses = new List<Response>()
                                {
                                    new Response()
                                    {
                                        Id = Guid.NewGuid(),
                                        Title = "Sale Rageux",
                                        Description = "T'est qu'un rageux le maitre sushi fait les meilleurs sushi",
                                        User = new User()
                                        {
                                            Id = Guid.NewGuid(),
                                            UserName = "SushiLove",
                                            UserEmail = "SushiLove@gmail.com",
                                            Password = "SushiLove",
                                            Salt = new byte[32],
                                        },
                                    },

                                    new Response()
                                    {
                                        Id = Guid.NewGuid(),
                                        Title = "C'etait trop bon",
                                        Description = "Revoit tes classique c'etait trop bon mec",
                                        User = new User()
                                        {
                                            Id = Guid.NewGuid(),
                                            UserName = "Sushi4Life",
                                            UserEmail = "Sushi4Life@orange.fr",
                                            Password = "Sushi4Life",
                                            Salt = new byte[32],
                                        },
                                    }
                                }
                            }
                        },

                        Notes = new List<Note>()
                        {

                            new Note()
                            {
                                Id = Guid.NewGuid(),
                                Value = random.Next(1,6),
                                User = new User()
                                {
                                    Id = Guid.NewGuid(),
                                    UserName = "Bookworm85",
                                    UserEmail = "book.reader@example.com",
                                    Password = "PageTurner789",
                                    Salt = new byte[32],
                                },
                            },
                            new Note()
                            {
                                Id = Guid.NewGuid(),
                                Value = random.Next(1,6),
                                User = new User()
                                {
                                    Id = Guid.NewGuid(),
                                    UserName = "GamerMaster",
                                    UserEmail = "gamer.master@example.com",
                                    Password = "GameOn2023",
                                    Salt = new byte[32],
                                },
                            },
                            new Note()
                            {
                                Id = Guid.NewGuid(),
                                Value = random.Next(1,6),
                                User = new User()
                                {
                                    Id = Guid.NewGuid(),
                                    UserName = "FitnessFanatic",
                                    UserEmail = "fitness.fanatic@example.com",
                                    Password = "HealthyLife123",
                                    Salt = new byte[32],
                                },
                            },
                            new Note()
                            {
                                Id = Guid.NewGuid(),
                                Value = random.Next(1,6),
                                User = new User()
                                {
                                    Id = Guid.NewGuid(),
                                    UserName = "NatureExplorer",
                                    UserEmail = "nature.lover@example.com",
                                    Password = "ExploreNature",
                                    Salt = new byte[32],
                                },
                            },
                            new Note()
                            {
                                Id = Guid.NewGuid(),
                                Value = random.Next(1,6),
                                User = new User()
                                {
                                    Id = Guid.NewGuid(),
                                    UserName = "FoodieKing",
                                    UserEmail = "foodie.king@example.com",
                                    Password = "TastyEats456",
                                    Salt = new byte[32],
                                },
                            },
                            new Note()
                            {
                                Id = Guid.NewGuid(),
                                Value = random.Next(1,6),
                                User = new User()
                                {
                                    Id = Guid.NewGuid(),
                                    UserName = "ArtisticSoul",
                                    UserEmail = "artistic.soul@example.com",
                                    Password = "CreativeMind789",
                                    Salt = new byte[32],
                                },
                            },
                            new Note()
                            {
                                Id = Guid.NewGuid(),
                                Value = random.Next(1,6),
                                User = new User()
                                {
                                    Id = Guid.NewGuid(),
                                    UserName = "TravelEnthusiast",
                                    UserEmail = "traveler@example.com",
                                    Password = "ExploreWorld123",
                                    Salt = new byte[32],
                                },
                            },
                            new Note()
                            {
                                Id = Guid.NewGuid(),
                                Value = random.Next(1,6),
                                User = new User()
                                {
                                    Id = Guid.NewGuid(),
                                    UserName = "TechInnovator",
                                    UserEmail = "innovator@email.com",
                                    Password = "TechRevolution",
                                    Salt = new byte[32],
                                },
                            },
                            new Note()
                            {
                                Id = Guid.NewGuid(),
                                Value = random.Next(1,6),
                                User = new User()
                                {
                                    Id = Guid.NewGuid(),
                                    UserName = "Fashionista123",
                                    UserEmail = "fashionista@example.com",
                                    Password = "StyleIcon456",
                                    Salt = new byte[32],
                                },
                            },
                            new Note()
                            {
                                Id = Guid.NewGuid(),
                                Value = random.Next(1,6),
                                User = new User()
                                {
                                    Id = Guid.NewGuid(),
                                    UserName = "PetLover77",
                                    UserEmail = "pet.lover@example.com",
                                    Password = "FurryFriends789",
                                    Salt = new byte[32],
                                },
                            },
                        }
                    }
                };

                dataContext.Restaurants.AddRange(Restaurants);
                dataContext.SaveChanges();
            }
        }
    }
}
