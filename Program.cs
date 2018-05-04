using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using BookCave.Data;
using BookCave.Data.EntityModels;

namespace BookCave
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            //SeedData();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        public static void SeedData() {

            var db = new DataContext();
            
            var authors = new List<Author>() {
                new Author {
                    authorName = "John Steinbeck",
                    image = "https://upload.wikimedia.org/wikipedia/commons/e/e7/John_Steinbeck_1962.jpg"
                },
                new Author {
                    authorName = "George Orwell",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7e/George_Orwell_press_photo.jpg/440px-George_Orwell_press_photo.jpg"
                },
                new Author {
                    authorName = "James Joyce",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1e/Revolutionary_Joyce_Better_Contrast.jpg/440px-Revolutionary_Joyce_Better_Contrast.jpg"
                },
                new Author {
                    authorName = "Vladimir Nabokov",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/Vladimir_Nabokov_1973.jpg/460px-Vladimir_Nabokov_1973.jpg"
                },
                new Author {
                    authorName = "Joseph Heller",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7b/Joseph_Heller1986_crop.jpg/440px-Joseph_Heller1986_crop.jpg"
                },
                new Author {
                    authorName = "J.D. Salinger",
                    image = "https://upload.wikimedia.org/wikipedia/en/8/8c/JD_Salinger.jpg"
                },
                new Author {
                    authorName = "Toni Morrison",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/04/Toni_Morrison_2008-2.jpg/440px-Toni_Morrison_2008-2.jpg"
                },
                new Author {
                    authorName = "William Folkner",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/6/6d/Carl_Van_Vechten_-_William_Faulkner.jpg/440px-Carl_Van_Vechten_-_William_Faulkner.jpg"
                },
                new Author {
                    authorName = "Harper Lee",
                    image = "https://upload.wikimedia.org/wikipedia/commons/5/5f/HarperLee_2007Nov05.jpg"
                },
                new Author {
                    authorName = "J.R.R. Tolkien",
                    image = "https://www.biography.com/.image/ar_1:1%2Cc_fill%2Ccs_srgb%2Cg_face%2Cq_auto:good%2Cw_300/MTE5NTU2MzE2Mzg4MzYxNzM5/jrr-tolkien-9508428-1-402.jpg"
                },
                new Author {
                    authorName = "Gabriel García Márquez",
                    image = "https://upload.wikimedia.org/wikipedia/commons/0/0f/Gabriel_Garcia_Marquez.jpg"
                },
                new Author {
                    authorName = "Aldous Huxley",
                    image = "https://upload.wikimedia.org/wikipedia/commons/e/e9/Aldous_Huxley_psychical_researcher.png"
                },
                new Author {
                    authorName = "Virginia Woolf",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0b/George_Charles_Beresford_-_Virginia_Woolf_in_1902_-_Restoration.jpg/440px-George_Charles_Beresford_-_Virginia_Woolf_in_1902_-_Restoration.jpg"
                },
                new Author {
                    authorName = "Ralph Ellison",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1c/Ralph_Ellison_photo_portrait_seated.jpg/440px-Ralph_Ellison_photo_portrait_seated.jpg"
                },
                new Author {
                    authorName = "Margaret Mitchell",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/7e/Margaret_Mitchell_NYWTS.jpg/440px-Margaret_Mitchell_NYWTS.jpg"
                },
                new Author {
                    authorName = "Charlotte Bronte",
                    image = "https://upload.wikimedia.org/wikipedia/commons/3/3a/CBRichmond.png"
                },
                new Author {
                    authorName = "Jack Kerouac",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/82/Kerouac_by_Palumbo_2.png/440px-Kerouac_by_Palumbo_2.png"
                },
                new Author {
                    authorName = "Jane Austen",
                    image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTHGstztOpN826VsBqCoI07Bb3F8TOEHLpmIOy8acEwuggVepeV"
                },
                new Author {
                    authorName = "William Golding",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f9/William_Golding_1983.jpg/440px-William_Golding_1983.jpg"
                },
                new Author {
                    authorName = "George Eliot",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/81/George_Eliot_at_30_by_Fran%C3%A7ois_D%27Albert_Durade.jpg/440px-George_Eliot_at_30_by_Fran%C3%A7ois_D%27Albert_Durade.jpg"
                },
                new Author {
                    authorName = "Leo Tolstoy",
                    image = "https://upload.wikimedia.org/wikipedia/commons/c/c6/L.N.Tolstoy_Prokudin-Gorsky.jpg"
                },
                new Author {
                    authorName = "E.M. Forster",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d4/E._M._Forster_von_Dora_Carrington%2C_1924-25.jpg/400px-E._M._Forster_von_Dora_Carrington%2C_1924-25.jpg"
                },
                new Author {
                    authorName = "Marcel Proust",
                    image = "https://upload.wikimedia.org/wikipedia/commons/a/a5/Marcel_Proust_1900-2.jpg"
                },
                new Author {
                    authorName = "Emily Bronte",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/fc/Emily_Bront%C3%AB_by_Patrick_Branwell_Bront%C3%AB_restored.jpg/440px-Emily_Bront%C3%AB_by_Patrick_Branwell_Bront%C3%AB_restored.jpg"
                },
                new Author {
                    authorName = "William Golding",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f9/William_Golding_1983.jpg/440px-William_Golding_1983.jpg"
                },
                new Author {
                    authorName = "A. A. Milne",
                    image = "https://thecaptivereader.files.wordpress.com/2012/07/a-a-milne.jpg"
                },
                new Author {
                    authorName = "James Joyce",
                    image = "https://i.scdn.co/image/c1fcea27a0803e912feebe004d480943ef88b9e2"
                },
                new Author {
                    authorName = "Salman Rushdie",
                    image = "https://i.guim.co.uk/img/static/sys-images/Observer/Columnist/Columnists/2015/9/2/1441221590151/salman-rushdie-008.jpg?w=300&q=55&auto=format&usm=12&fit=max&s=778d6906e54d989f2f606f567d5b65f8"
                },
                new Author {
                    authorName = "Alice Walker",
                    image = "https://thenewpress.com/sites/default/files/author_photos/walker_alice_ana_elena.jpg"
                },
                new Author {
                    authorName = "C. S. Lewis",
                    image = "https://naqyr37xcg93tizq734pqsx1-wpengine.netdna-ssl.com/wp-content/uploads/2017/08/CS-Lewis-Quotes.jpg"
                }
            };
            db.AddRange(authors);
            db.SaveChanges();
        }
    }
}
