using BookCave.Data;
using BookCave.Data.EntityModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System;

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

        public static void SeedData()
        {
            Random rnd = new Random();
            var db = new DataContext();
            var books = new List<Book>()
            {
                new Book{
                    title="The hobbit",
                    author="J.R.R. Tolkien",
                    genre="Adventure",
                    rating=5,
                    description="Tolkien intended The Hobbit as a “fairy-story” and wrote it in a tone suited to addressing children although he said later that the book was not specifically written for children but had rather been created out of his interest in mythology and legend. Many of the initial reviews refer to the work as a fairy story. However, according to Jack Zipes writing in “The Oxford Companion to Fairy Tales”, Bilbo is an atypical character for a fairy tale.The work is much longer than Tolkien’s ideal proposed in his essay On Fairy-Stories. Many fairy tale motifs, such as the repetition of similar events seen in the dwarves’ arrival at Bilbo’s and Beorn’s homes, and folklore themes, such as trolls turning to stone, are to be found in the story.",
                    cost=9.89,
                    image="https://www.candlesbook.com/wp-content/uploads/book-cover-art-print-the-hobbit-1.jpg",
                    copiesSold = rnd.Next(1,200)
                },
                new Book{
                    title="The Silmarillion",
                    author="J.R.R. Tolkien",
                    genre="Fantasy",
                    rating=4,
                    description="The story of the creation of the world and of the First Age, this is the ancient drama to which the characters in The Lord of the Rings look back and in whose events some of them, such as Elrond and Galadriel, took part. The three Silmarils were jewels created by Fëanor, most gifted of the Elves. Within them was imprisoned the Light of the Two Trees of Valinor before the Trees themselves were destroyed by Morgoth, the first Dark Lord.",
                    cost=13.49,
                    image="https://images.gr-assets.com/books/1336502583l/7332.jpg",
                    copiesSold = rnd.Next(1,200)
                },
                 new Book{
                    title="The spire",
                    author="William Golding",
                    genre="Novel",
                    rating=3.5,
                    description="The Spire is a 1964 novel by the English author William Golding.A dark and powerful portrait of one man's will, it deals with the construction of the 404-foot high spire loosely based on Salisbury Cathedral; the vision of the fictional Dean Jocelin. In this novel, William Golding utilises stream of consciousness writing with an omniscient but increasingly fallible narrator.",
                    cost=12.39,
                    image="http://t2.gstatic.com/images?q=tbn:ANd9GcRAxpY1cn5HdcP2UvcZcuIA2_Gzopy-TEx26Uljm6O--cOt2Etj",
                    copiesSold = rnd.Next(1,200)
                },
                 new Book{
                    title="The Resurection",
                    author="Leo Tolstoy",
                    genre="Novel",
                    rating=4,
                    description="Resurrection (1899) is the last of Tolstoy's major novels. It tells the story of a nobleman's attempt to redeem the suffering his youthful philandering inflicted on a peasant girl who ends up a prisoner in Siberia. Tolstoy's vision of redemption, achieved through loving forgiveness and his condemnation of violence, dominate the novel. An intimate, psychological tale of guilt, anger, and forgiveness, Resurrection is at the same time a panoramic description of social life in Russia at the end of the nineteenth century, reflecting its author's outrage at the social injustices of the world in which he lived.",
                    cost=15.29,
                    image="http://t3.gstatic.com/images?q=tbn:ANd9GcSQ7EeRonqA-YVtgPDG27fw8iq2uPupn6G7ruWa_RGR1bgXcQ9m",
                    copiesSold = rnd.Next(1,200)
                },
                 new Book{
                    title="The Perennial Philosophy",
                    author="Aldous Huxley",
                    genre="Philosophy",
                    rating=3.5,
                    description="The Perennial Philosophy is defined by its author as The metaphysic that recognizes a divine Reality substantial to the world of things and lives and minds. With great wit and stunning intellect, Aldous Huxley examines the spiritual beliefs of various religious traditions and explains them in terms that are personally meaningful.",
                    cost=8.99,
                    image="http://t0.gstatic.com/images?q=tbn:ANd9GcTN0Alibuti08Un9Q2fUwNeiCTRJbw4pU_Bzri7iKKXy3xh9sKP",
                    copiesSold = rnd.Next(1,200)
                },
                 new Book{
                    title="Tender Is the Night",
                    author="F. Scott Fitzgerald",
                    genre="Novel",
                    rating=3.5,
                    description="Set on the French Riviera in the late 1920s, Tender Is the Night is the tragic romance of the young actress Rosemary Hoyt and the stylish American couple Dick and Nicole Diver. A brilliant young psychiatrist at the time of his marriage, Dick is both husband and doctor to Nicole, whose wealth goads him into a lifestyle not his own, and whose growing strength highlights Dick's harrowing demise. A profound study of the romantic concept of character, Tender Is the Night is lyrical, expansive, and hauntingly evocative.",
                    cost=13.29,
                    image="http://t0.gstatic.com/images?q=tbn:ANd9GcSWezZuIxWyWbgoYY2flPTgRVyIVR3ZlM9lbNavGC4b06qXSZTK",
                    copiesSold = rnd.Next(1,200)
                },
                 new Book{
                    title="Mannasiðir Gillz",
                    author="Gillzenegger",
                    genre="Humor",
                    rating=5,
                    description="Ógeðslega fkn fyndin bók marr",
                    cost=999.99,
                    image="https://cdn.mbl.is/frimg/1/1/14/1011483.jpg",
                    copiesSold = rnd.Next(1,200)
                },
                new Book{
                    title="On the Road",
                    author="Jack Kerouac",
                    genre="Novel",
                    rating=3.5,
                    description="When Jack Kerouac’s On the Road first appeared in 1957, readers instantly felt the beat of a new literary rhythm. A fictionalised account of his own journeys across America with his friend Neal Cassady, Kerouac’s beatnik odyssey captured the soul of a generation and changed the landscape of American fiction for ever.",
                    cost=21.39,
                    image="https://i.pinimg.com/564x/7a/24/61/7a246195a2309aff7b21ae284fd2c9f0.jpg",
                    copiesSold = rnd.Next(1,200)
                },
                new Book{
                    title="Where the Wild Things Are",
                    author="Maurice Sendak",
                    genre="Adventure",
                    rating=4.5,
                    description="One night Max puts on his wolf suit and makes mischief of one kind and another, so his mother calls him 'Wild Thing' and sends him to bed without his supper. That night a forest begins to grow in Max's room and an ocean rushes by with a boat to take Max to the place where the wild things are. Max tames the wild things and crowns himself as their king, and then the wild rumpus begins. But when Max has sent the monsters to bed, and everything is quiet, he starts to feel lonely and realises it is time to sail home to the place where someone loves him best of all.",
                    cost=19.99,
                    image="http://t1.gstatic.com/images?q=tbn:ANd9GcR_0cnPpR0bWQ1i9hdsNMxLOWhXPTw2IK7aoMfZ5zSX5nZ1gu5y",
                    copiesSold = rnd.Next(1,200)
                },
                new Book{
                    title="Charlottes web",
                    author="E.B. White",
                    genre="Adventure",
                    rating=4.5,
                    description="This beloved book by E. B. White, author of Stuart Little and The Trumpet of the Swan, is a classic of children's literature that is just about perfect. This high-quality paperback features vibrant illustrations colorized by Rosemary Wells! Some Pig. Humble. Radiant. These are the words in Charlotte's Web, high up in Zuckerman's barn. Charlotte's spiderweb tells of her feelings for a little pig named Wilbur, who simply wants a friend. They also express the love of a girl named Fern, who saved Wilbur's life when he was born the runt of his litter.",
                    cost=19.99,
                    image="http://t0.gstatic.com/images?q=tbn:ANd9GcQgrAdGHen5K9TkGhFI3jMUSr44Dq0qIfnnH9bj6c8_qCJYzSl1",
                    copiesSold = rnd.Next(1,200)
                },
            };
            db.AddRange(books);
            db.SaveChanges();
        }
    }
}