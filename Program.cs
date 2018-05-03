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

            var books = new List<Book>() {
                new Book{
                    title="The Great Gatsby",
                    author="F. Scott Fitzgerald",
                    genre="Fiction",
                    rating=4,
                    description="In my younger and more vulnerable years my father gave me some advice that I've been turning over in my mind ever since.",
                    cost=10.99
                },
                new Book{
                    title="The Grapes of Wrath",
                    author="John Steinbeck",
                    genre="Fiction",
                    rating=4,
                    description="To the red country and part of the gray country of Oklahoma, the last rains came gently, and they did not cut the scarred earth.",
                    cost=9.89
                },
                 new Book{
                    title="Nineteen Eighty-Four",
                    author="George Orwell",
                    genre="Science Fiction",
                    rating=4.5,
                    description="It was a bright cold day in April, and the clocks were striking thirteen.",
                    cost=13.49
                },
                new Book{
                    title="Ulysses",
                    author="James Joyce",
                    genre="Fiction",
                    rating=2.5,
                    description="Stately, plump Buck Mulligan came from the stairhead, bearing a bowl of lather on which a mirror and a razor lay crossed.",
                    cost=10
                },
                new Book{
                    title="Lolita",
                    author="Vladimir Nabokov",
                    genre="Romance",
                    rating=4,
                    description="Lolita, light of my life, fire of my loins. My sin, my soul. Lo-lee-ta: the tip of the tongue taking a trip of three steps down the palette to tap, at three, on the teeth.",
                    cost=16
                },
                new Book{
                    title="Catch-22",
                    author="Joseph Heller",
                    genre="Historical fiction",
                    rating=4,
                    description="It was love at first sight.",
                    cost=8.55
                },
                new Book{
                    title="The catcher in the Rye",
                    author="J. D. Salinger",
                    genre="Novel",
                    rating=3.5,
                    description="If you really want to hear about it, the first thing you'll probably want to know is where I was born, and what my lousy childhood was like, and how my parents were occupied and all before they...",
                    cost=14.99
                },
                 new Book{
                    title="Beloved",
                    author="Toni Morrison",
                    genre="Novel",
                    rating=4,
                    description="124 was spiteful. Full of baby's venom. The women in the house knew it and so did the children.",
                    cost=11.49
                },
                 new Book{
                    title="The Sound and the Fury",
                    author="William Faulkner",
                    genre="Novel",
                    rating=3.5,
                    description="Through the fence, between the curling flower spaces, I could see them hitting.",
                    cost=12.99
                },
                 new Book{
                    title="To Kill a Mockingbird",
                    author="Harper Lee",
                    genre="Historical Fiction",
                    rating=4.5,
                    description="When he was nearly thirteen, my brother Jem got his arm badly broken at the elbow.",
                    cost=999.99
                },
                 new Book{
                    title="The Lord of the Rings",
                    author="J.R.R. Tolkien",
                    genre="Fantasy/Adventure",
                    rating=4.5,
                    description="When Mr. Bilbo Baggins of Bag End announced that he would shortly be celebrating his eleventy-first birthday with a party of special magnificence, there was much talk and excitement in Hobbiton.",
                    cost=999.99
                },
                new Book{
                    title="One Hundred Years of Solitude",
                    author="Gabriel García Márquez",
                    genre="Fantasy",
                    rating=4.5,
                    description="Many years later, as he faced the firing squad, Colonel Aureliano Buendía was to remember that distant afternoon when his father took him to discover ice.Muchos años después, frente al pelotón de...",
                    cost=999.99
                },
                new Book{
                    title="Brave New World",
                    author="Aldous Huxley",
                    genre="Science Fiction",
                    rating=4,
                    description="A squat grey building of only thirty-four stories.",
                    cost=999.99
                },
                new Book{
                    title="To the Lighthouse",
                    author="Virginia Woolf",
                    genre="Fiction",
                    rating=3.5,
                    description="Yes, of course, if it's fine tomorrow,said Mrs. Ramsay.But you'll have to be up with the lark,she added.",
                    cost=999.99
                },
                new Book{
                    title="Invisible Man",
                    author="Ralph Ellison",
                    genre="Historical Fiction",
                    rating=4,
                    description="I am an invisible man. No, I am not a spook like those who haunted Edgar Allan Poe; nor am I one of your Hollywood-movie ectoplasms. I am a man of substance, of flesh and bone, fiber and liquids—...",
                    cost=999.99
                },
                new Book{
                    title="Gone with the Wind",
                    author="Margaret Mitchell",
                    genre="Historical Fiction/Romance",
                    rating=4.5,
                    description="Scarlett O'Hara was not beautiful, but men seldom realized it when caught by her charm, as the Tarleton twins were.",
                    cost=999.99
                },
                new Book{
                    title="Jane Eyre",
                    author="Charlotte Brontë",
                    genre="Romance",
                    rating=4,
                    description="There was no possibility of taking a walk that day. We had been wandering, indeed, in the leafless shrubbery an hour in the morning; but since dinner (Mrs. Reed, when there was no company, dined...",
                    cost=999.99
                },
                new Book{
                    title="On the Road",
                    author="Jack Kerouac",
                    genre="Adventure",
                    rating=3.5,
                    description="I first met Dean not long after my wife and I split up.",
                    cost=999.99
                },
                new Book{
                    title="Pride and Prejudice",
                    author="Jane Austen",
                    genre="Romance/Historical Fiction",
                    rating=4,
                    description="It is a truth universally acknowledged, that a single man in possession of a good fortune, must be in want of a wife.",
                    cost=999.99
                },
                new Book{
                    title="Lord of the Flies",
                    author="William Golding",
                    genre="Adventure/Horror",
                    rating=4,
                    description="The boy with fair hair lowered himself down the last few feet of rock and began to pick his way toward the lagoon.",
                }
            };
            db.AddRange(books);
            db.SaveChanges();
        }
    }
}
