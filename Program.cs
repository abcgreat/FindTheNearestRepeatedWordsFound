using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindTheNearestRepeatedWordsFound
{
    public class FoundValue
    {
        public string word;
        public int distance;
        public int count;
    }

    class Program
    {
        static void Main(string[] args)
        {
            string testString = "All work and no play is no work no fun and no play";
            FoundValue theNearestRepeatedWordsFound = FindTheNearestRepeatedWordsFound(testString);
            Console.WriteLine(theNearestRepeatedWordsFound.word + ", " + theNearestRepeatedWordsFound.distance);

            Console.ReadKey();
        }

        static public FoundValue FindTheNearestRepeatedWordsFound(string sentence)
        {
            FoundValue theWord;

            IDictionary<string, FoundValue> theWords = new Dictionary<string, FoundValue>();

            int count = 0;

            string[] words = sentence.Split(' ');

            foreach (string eachWord in words)
            {
                FoundValue tmpWord = new FoundValue();
                tmpWord.word = eachWord;
                tmpWord.count = count;

                if (theWords.ContainsKey(eachWord))
                {
                    FoundValue foundWord = theWords[eachWord];
                    //foundWord.distance = count - foundWord.count;
                    if (theWords[eachWord].distance == 0)
                    { // this is added.
                        theWords[eachWord].distance = count - foundWord.count;
                    }
                    else //if (theWords[eachWord].distance != 0)
                    {
                        theWords[eachWord].distance = Math.Min(theWords[eachWord].distance, count - foundWord.count);
                    }
                    theWords[eachWord].count = count;
                    //theWords.Add(eachWord, tmpWord); // a big mistake here.
                }
                else
                {
                    tmpWord.distance = 0;
                    theWords.Add(eachWord, tmpWord); // 0 means no repeat
                }
                count++;
            }
            
            theWord = new FoundValue();

            for (int i = 0; i < theWords.Count - 1; i++)
            {
                int min = theWords.Count;

                FoundValue eachWord = theWords.ElementAt(i).Value;

                if (eachWord.distance > 1 && eachWord.distance < min)
                {
                    min = eachWord.distance;
                    theWord = eachWord;
                }
            }
            
            return theWord;
        }


}


}
