using System;
using System.Collections.Generic;
using System.Linq;

namespace FA_quiz_nonMVC
{
    class Program
    {
        static int finalScore = 0;
        static void Main(string[] args)
        {
            //initialize the stuff we are going to need 
            var AnswerOptions = new List<string> {
                " 1. Never",
                " 2. Less than monthly",
                " 3: Once a month",
                " 4: 2-3 times a month",
                " 5: Once a week",
                " 6: 2-3 times a week",
                " 7: 4-6 times a week",
                " 8: every day\n"
            };

            //init a List of booleans for calculating the final score later
            var Score = new List<CategoryScore>();

            var QuestionCollection = new List<Question>();

            var q1 = new Question("When I started to eat certain foods, I ate much more than planned.", 1, 6);
            var q2 = new Question("I continued to eat certain foods even though I was no longer hungry.", 1, 6);
            var q3 = new Question("I ate to the point where I felt physically ill.", 1, 4);

            var q4 = new Question("I worried a lot about cutting down on certain types of food, but I ate them anyways.", 2, 6);
            var q25 = new Question("I really wanted to cut down on or stop eating certain kinds of foods, but I just couldn’t.", 2, 6);
            var q31 = new Question("I tried to cut down on or not eat certain kinds of food, but I wasn’t successful.", 2, 5);
            var q32 = new Question("I tried and failed to cut down on or stop eating certain foods.", 2, 5);
            var q5 = new Question("I spent a lot of time feeling sluggish or tired from overeating.", 2, 5);

            var q6 = new Question("I spent a lot of time eating certain foods throughout the day.", 3, 6);

            var q7= new Question("When certain foods were not available, I went out of my way to get them. For example, I went to the store to get certain foods even though I had other things to eat at home.", 3, 5);
            var q8 = new Question("I ate certain foods so often or in such large amounts that I stopped doing other important things. These things may have been working or spending time with family or friends.", 3, 3);
           
            var q10 = new Question("I had problems with my family or friends because of how much I overate.", 4, 2);

            var q9 = new Question("I had problems with my family or friends because of how much I overate.", 8, 2);

            QuestionCollection.Add(q1);
            QuestionCollection.Add(q2);
            QuestionCollection.Add(q3);
            QuestionCollection.Add(q4);

            //final score will be the number of trues in here
            bool[] categories12 = new bool[12];

            foreach (var item in categories12)
            {
                Console.WriteLine("Before cat12" + item);

            }

            // Show the user a question and the range of answers
            // get user's answer, compare to threshold, update CategoryScore
            for (int j = 0; j < QuestionCollection.Count; j++)
            {
                var qcat = QuestionCollection[j].Category;

                //Display question
                Console.WriteLine("\n" + QuestionCollection[j].Content);

                //Display answers
                foreach (var opt in AnswerOptions)
                {
                    Console.WriteLine(opt);
                }
                
                //Get user's answer
                var answer = int.Parse(Console.ReadLine());

                //Compare answer to threshold
                if (answer >= QuestionCollection[j].Threshold)
                {
                    categories12[qcat] = true;
                }
            }



            foreach (var item in categories12)
            {
                if (item == true)
                {
                    finalScore++;
                }
            }

            

            Console.WriteLine("\nFinal: {0}", finalScore);
        }

        class CategoryScore
        {
            public int Category;
            public bool Significant;

            public CategoryScore(int category, bool signif)
            {
                Category = category;
                Significant = signif;
            }

        }

        class Question
        {
            public string Content;
            public int Category;
            public int Threshold;

            public Question(string content, int category, int threshold)
            {
                Content = content;
                Category = category;
                Threshold = threshold;
            }
        }

    }
}
