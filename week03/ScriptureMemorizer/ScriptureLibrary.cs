using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    public class ScriptureLibrary
    {

        private List<Scripture> _scriptures; // list that can hold scripure objects
        private Random _random;

        public ScriptureLibrary()
        {
            _scriptures = new List<Scripture>(); // create empty array
            _random = new Random();
        }

        public void Add(Reference reference, string text)
        {
            Scripture scripture = new Scripture(reference, text); // turn input into a Scripture object
            _scriptures.Add(scripture); // add scripture object to list of scriptures
        }

        public void DefaultVerses()
        {
            // I used AI to generate verse references

            // --- Bible ---
            Add(new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life.");

            Add(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths.");

            Add(new Reference("James", 1, 5),
                "If any of you lack wisdom, let him ask of God, that giveth to all men liberally, " +
                "and upbraideth not; and it shall be given him.");

            Add(new Reference("Philippians", 4, 13),
                "I can do all things through Christ which strengtheneth me.");

            Add(new Reference("Romans", 8, 28),
                "And we know that all things work together for good to them that love God, " +
                "to them who are the called according to his purpose.");

            Add(new Reference("Isaiah", 1, 18),
                "Come now, and let us reason together, saith the Lord: though your sins be as scarlet, " +
                "they shall be as white as snow; though they be red like crimson, they shall be as wool.");

            Add(new Reference("Psalms", 23, 1, 3),
                "The Lord is my shepherd; I shall not want. He maketh me to lie down in green pastures: " +
                "he leadeth me beside the still waters. He restoreth my soul: he leadeth me in the paths of righteousness for his name's sake.");

            Add(new Reference("Matthew", 5, 14, 16),
                "Ye are the light of the world. A city that is set on an hill cannot be hid. " +
                "Neither do men light a candle, and put it under a bushel, but on a candlestick; and it giveth light unto all that are in the house. " +
                "Let your light so shine before men, that they may see your good works, and glorify your Father which is in heaven.");

            Add(new Reference("2 Timothy", 1, 7),
                "For God hath not given us the spirit of fear; but of power, and of love, and of a sound mind.");

            Add(new Reference("John", 14, 27),
                "Peace I leave with you, my peace I give unto you: not as the world giveth, give I unto you. " +
                "Let not your heart be troubled, neither let it be afraid.");

            // --- Book of Mormon ---
            Add(new Reference("2 Nephi", 2, 25),
                "Adam fell that men might be; and men are, that they might have joy.");

            Add(new Reference("Mosiah", 2, 17),
                "When ye are in the service of your fellow beings ye are only in the service of your God.");

            Add(new Reference("Alma", 32, 21),
                "Faith is not to have a perfect knowledge of things; therefore if ye have faith ye hope for things which are not seen, which are true.");

            Add(new Reference("Ether", 12, 27),
                "My grace is sufficient for all men that humble themselves before me; for if they humble themselves before me, and have faith in me, " +
                "then will I make weak things become strong unto them.");

            Add(new Reference("Moroni", 7, 47),
                "Charity is the pure love of Christ, and it endureth forever; and whoso is found possessed of it at the last day, it shall be well with him.");

            Add(new Reference("Mosiah", 18, 8, 9),
                "As ye are desirous to come into the fold of God, and to be called his people, and are willing to bear one another's burdens, that they may be light; " +
                "Yea, and are willing to mourn with those that mourn; yea, and comfort those that stand in need of comfort, " +
                "and to stand as witnesses of God at all times and in all things, and in all places that ye may be in, even until death.");

            Add(new Reference("3 Nephi", 12, 48),
                "Therefore I would that ye should be perfect even as I, or your Father who is in heaven is perfect.");

            Add(new Reference("Mosiah", 4, 9),
                "Believe in God; believe that he is, and that he created all things, both in heaven and in earth; " +
                "believe that he has all wisdom, and all power, both in heaven and in earth; " +
                "believe that man doth not comprehend all the things which the Lord can comprehend.");

            Add(new Reference("Helaman", 5, 12),
                "Remember, remember that it is upon the rock of our Redeemer, who is Christ, the Son of God, " +
                "that ye must build your foundation; that when the devil shall send forth his mighty winds, yea, " +
                "his shafts in the whirlwind, yea, when all his hail and his mighty storm shall beat upon you, " +
                "it shall have no power over you to drag you down to the gulf of misery and endless wo, " +
                "because of the rock upon which ye are built, which is a sure foundation, a foundation whereon if men build they cannot fall.");

            Add(new Reference("Moroni", 10, 4, 5),
                "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; " +
                "and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost. " +
                "And by the power of the Holy Ghost ye may know the truth of all things.");
        }

        public Scripture GetRandomScripture()
        {
            int idx = _random.Next(_scriptures.Count); // random number less than count of scripture objects in array
            return _scriptures[idx];
        }
    }
}
