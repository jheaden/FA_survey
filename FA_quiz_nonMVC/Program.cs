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
            // Potential Answers
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

            var QuestionCollection = new List<Question>();

            // content, category, threshold
            var q1 = new Question("When I started to eat certain foods, I ate much more than planned.", 1, 6);
            var q2 = new Question("I continued to eat certain foods even though I was no longer hungry.", 1, 6);
            var q3 = new Question("I ate to the point where I felt physically ill.", 1, 4);

            var q4 = new Question("I worried a lot about cutting down on certain types of food, but I ate them anyways.", 2, 6);
            var q25 = new Question("I really wanted to cut down on or stop eating certain kinds of foods, but I just couldn’t.", 2, 6);
            var q31 = new Question("I tried to cut down on or not eat certain kinds of food, but I wasn’t successful.", 2, 5);
            var q32 = new Question("I tried and failed to cut down on or stop eating certain foods.", 2, 5);
            var q5 = new Question("I spent a lot of time feeling sluggish or tired from overeating.", 2, 5);

            var q6 = new Question("I spent a lot of time eating certain foods throughout the day.", 3, 6);

            var q7 = new Question("When certain foods were not available, I went out of my way to get them. For example, I went to the store to get certain foods even though I had other things to eat at home.", 3, 5);
            var q8 = new Question("I ate certain foods so often or in such large amounts that I stopped doing other important things. These things may have been working or spending time with family or friends.", 3, 3);

            var q10 = new Question("I avoided work, school or social activities because I was afraid I would overeat there.", 4, 2);
            var q18 = new Question("I felt so bad about overeating that I didn’t do other important things. These things may have been working or spending time with family or friends.", 4, 3);
            var q20 = new Question("I avoided work, school or social functions because I could not eat certain foods there.", 4, 3);

            var q22 = new Question("I kept eating in the same way even though my eating caused emotional problems.", 5, 4);
            var q23 = new Question("I kept eating the same way even though my eating caused physical problems.", 5, 5);

            var q24 = new Question("Eating the same amount of food did not give me as much enjoyment as it used to.", 6, 5);
            var q26 = new Question("I needed to eat more and more to get the feelings I wanted from eating. This included reducing negative emotions like sadness or increasing pleasure.", 6, 5);

            var q13 = new Question("If I had emotional problems because I hadn’t eaten certain foods, I would eat those foods to feel better.", 7, 4);
            var q11 = new Question("When I cut down on or stopped eating certain foods, I felt irritable, nervous or sad.", 7, 4);
            var q12 = new Question("If I had physical symptoms because I hadn’t eaten certain foods, I would eat those foods to feel better.", 7, 5);
            var q14 = new Question("When I cut down on or stopped eating certain foods, I had physical symptoms. For example, I had headaches or fatigue.", 7, 4);
            var q15 = new Question("When I cut down or stopped eating certain foods, I had strong cravings for them.", 7, 6);

            var q9 = new Question("I had problems with my family or friends because of how much I overate.", 8, 2);
            var q35 = new Question("My friends or family were worried about how much I overate.", 8, 2);
            var q21 = new Question("I avoided social situations because people wouldn’t approve of how much I ate.", 8, 3);

            var q19 = new Question("I ate to the point where I felt physically ill.", 9, 2);
            var q27 = new Question("I didn’t do well at work or school because I was eating too much.", 9, 2);

            var q28 = new Question("I kept eating certain foods even though I knew it was physically dangerous. For example, I kept eating sweets even though I had diabetes. Or I kept eating fatty foods despite having heart disease.", 10, 4);
            var q33 = new Question("I was so distracted by eating that I could have been hurt (e.g., when driving a car, crossing the street, operating machinery).", 10, 2);
            var q34 = new Question("I was so distracted by thinking about food that I could have been hurt (e.g., when driving a car, crossing the street, operating machinery).", 10, 3);

            var q29 = new Question("I had such strong urges to eat certain foods that I couldn’t think of anything else.", 11, 4);
            var q30 = new Question("I had such intense cravings for certain foods that I felt like I had to eat them right away.", 11, 5);

            var q16 = new Question("My eating behavior caused me a lot of distress.", 12, 5);
            var q17 = new Question("I had significant problems in my life because of food and eating. These may have been problems with my daily routine, work, school, friends, family, or health.", 12, 5);

            QuestionCollection.Add(q1);
            QuestionCollection.Add(q2);
            QuestionCollection.Add(q3);
            QuestionCollection.Add(q4);
            QuestionCollection.Add(q5);
            QuestionCollection.Add(q6);
            QuestionCollection.Add(q7);
            QuestionCollection.Add(q8);
            QuestionCollection.Add(q9);
            QuestionCollection.Add(q10);
            QuestionCollection.Add(q11);
            QuestionCollection.Add(q12);
            QuestionCollection.Add(q13);
            QuestionCollection.Add(q14);
            QuestionCollection.Add(q15);
            QuestionCollection.Add(q16);
            QuestionCollection.Add(q17);
            QuestionCollection.Add(q18);
            QuestionCollection.Add(q19);
            QuestionCollection.Add(q20);
            QuestionCollection.Add(q21);
            QuestionCollection.Add(q22);
            QuestionCollection.Add(q23);
            QuestionCollection.Add(q24);
            QuestionCollection.Add(q25);
            QuestionCollection.Add(q26);
            QuestionCollection.Add(q27);
            QuestionCollection.Add(q28);
            QuestionCollection.Add(q29);
            QuestionCollection.Add(q20);
            QuestionCollection.Add(q31);
            QuestionCollection.Add(q32);
            QuestionCollection.Add(q33);
            QuestionCollection.Add(q34);
            QuestionCollection.Add(q35);

            //final score will be the number of trues in here
            bool[] categories12 = new bool[13];

            // Show the user a question and the range of answers
            // get user's answer, compare to threshold, update CategoryScore
            for (int j = 0; j < QuestionCollection.Count; j++)
            {
                var qcat = QuestionCollection[j].Category;

                //Display question with number
                Console.WriteLine("\n" + "Question " + (j+1) +". " + QuestionCollection[j].Content);

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

            //calculate and display diagnosis
            if (finalScore <= 1)
            {
                Console.WriteLine("No Food Addiction = 1 or fewer symptoms. Does not meet criteria for clinical significance.");
            } else if ((finalScore >= 2) && (finalScore < 4))   {
                Console.WriteLine("Mild Food Addiction = 2 or 3 symptoms and clinical significance.");
            } else if ((finalScore >= 4) && (finalScore < 5))   {
                Console.WriteLine("Moderate Food Addiction = 4 or 5 symptoms and clinical significance");
            } else if ((finalScore > 5) && (finalScore < 13))     {
                Console.WriteLine("Severe Food Addiction = 6 or more symptoms and clinical significance");
            } else {
                Console.WriteLine("Something is wrong.");
            }
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
