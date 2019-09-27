using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace FA_quiz_nonMVC
{
    class Program
    {
        public enum Category
        {
            [Description("1. Substance taken in larger amount and for longer period than intended")]
            largerAmt = 1,
            [Description("2. Persistent desire or repeated unsuccessful attempts to quit")]
            cantQuit,
            [Description("3. Much time/activity to obtain, use, recover")]
            timeSpent,
            [Description("4. Important social, occupational, or recreational activities given up or reduced")]
            reducedActivities,
            [Description("5. Use continues despite knowledge of adverse consequences (e.g., emotional problems, physical problems)")]
            emotionalProblems,
            [Description("6. Tolerance (marked increase in amount; marked decrease in effect)")]
            tolerance,
            [Description("7.Characteristic withdrawal symptoms; substance taken to relieve withdrawal")]
            withdrawal,
            [Description("8. Continued use despite social or interpersonal problems")]
            socialProblems,
            [Description("9. Failure to fulfill major role obligation (e.g., work, school, home)")]
            roleFail,
            [Description("10. Use in physically hazardous situations")]
            hazardousSituations,
            [Description("11. Craving, or a strong desire or urge to use")]
            craving,
            [Description("12. Use causes clinically significant impairment or distress")]
            clinicalImpairment
        };

        public enum Frequency
        {
            [Description("1. Never")]
            Never = 1,
            [Description("2. Less than monthly")]
            LessThanMonthly,
            [Description("3. Once a month")]
            OnceAMonth,
            [Description("4. Two to three times a month")]
            _2to3TimesaMonth,
            [Description("5. Once a week")]
            OnceAWeek,
            [Description("6. Two to three times a week")]
            _2to3TimesAWeek,
            [Description("7. Four to six times a week")]
            _4to6TimesAWeek,
            [Description("8. Every day")]
            EveryDay
        };

        public static string GetDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DescriptionAttribute attribute
                    = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))
                        as DescriptionAttribute;

            return attribute == null ? value.ToString() : attribute.Description;
        }

        static int finalScore = 0;

        static void Main(string[] args)
        {
        //// Potential Answers
        //var AnswerOptions = new List<string> {
        //        " 1. Never",
        //        " 2. Less than monthly",
        //        " 3: Once a month",
        //        " 4: 2-3 times a month",
        //        " 5: Once a week",
        //        " 6: 2-3 times a week",
        //        " 7: 4-6 times a week",
        //        " 8: every day\n"
        //    };

            var QuestionCollection = new List<Question>();

            var q1 = new Question("When I started to eat certain foods, I ate much more than planned.", Category.largerAmt, Frequency._4to6TimesAWeek);
            var q2 = new Question("I continued to eat certain foods even though I was no longer hungry.", Category.largerAmt, Frequency._4to6TimesAWeek);
            var q3 = new Question("I ate to the point where I felt physically ill.", Category.largerAmt, Frequency._2to3TimesaMonth);

            var q4 = new Question("I worried a lot about cutting down on certain types of food, but I ate them anyways.", Category.cantQuit, Frequency._4to6TimesAWeek);
            var q25 = new Question("I really wanted to cut down on or stop eating certain kinds of foods, but I just couldn’t.", Category.cantQuit, Frequency._4to6TimesAWeek);
            var q31 = new Question("I tried to cut down on or not eat certain kinds of food, but I wasn’t successful.", Category.cantQuit, Frequency.OnceAWeek);
            var q32 = new Question("I tried and failed to cut down on or stop eating certain foods.", Category.cantQuit, Frequency.OnceAWeek);

            var q5 = new Question("I spent a lot of time feeling sluggish or tired from overeating.", Category.timeSpent, Frequency.OnceAWeek);
            var q6 = new Question("I spent a lot of time eating certain foods throughout the day.", Category.timeSpent, Frequency._4to6TimesAWeek);
            var q7 = new Question("When certain foods were not available, I went out of my way to get them. For example, I went to the store to get certain foods even though I had other things to eat at home.", Category.timeSpent, Frequency.OnceAWeek);

            var q8 = new Question("I ate certain foods so often or in such large amounts that I stopped doing other important things. These things may have been working or spending time with family or friends.", Category.reducedActivities, Frequency.OnceAMonth);
            var q10 = new Question("I avoided work, school or social activities because I was afraid I would overeat there.", Category.reducedActivities, Frequency.LessThanMonthly);
            var q18 = new Question("I felt so bad about overeating that I didn’t do other important things. These things may have been working or spending time with family or friends.", Category.reducedActivities, Frequency.OnceAMonth);
            var q20 = new Question("I avoided work, school or social functions because I could not eat certain foods there.", Category.reducedActivities, Frequency.OnceAMonth);

            var q22 = new Question("I kept eating in the same way even though my eating caused emotional problems.", Category.emotionalProblems, Frequency._2to3TimesaMonth);
            var q23 = new Question("I kept eating the same way even though my eating caused physical problems.", Category.emotionalProblems, Frequency.OnceAWeek);

            var q24 = new Question("Eating the same amount of food did not give me as much enjoyment as it used to.", Category.tolerance, Frequency.OnceAWeek);
            var q26 = new Question("I needed to eat more and more to get the feelings I wanted from eating. This included reducing negative emotions like sadness or increasing pleasure.", Category.tolerance, Frequency.OnceAWeek);


            var q11 = new Question("When I cut down on or stopped eating certain foods, I felt irritable, nervous or sad.", Category.withdrawal, Frequency._2to3TimesaMonth);
            var q12 = new Question("If I had physical symptoms because I hadn’t eaten certain foods, I would eat those foods to feel better.", Category.withdrawal, Frequency.OnceAWeek);
            var q13 = new Question("If I had emotional problems because I hadn’t eaten certain foods, I would eat those foods to feel better.", Category.withdrawal, Frequency._2to3TimesaMonth);
            var q14 = new Question("When I cut down on or stopped eating certain foods, I had physical symptoms. For example, I had headaches or fatigue.", Category.withdrawal, Frequency._2to3TimesaMonth);
            var q15 = new Question("When I cut down or stopped eating certain foods, I had strong cravings for them.", Category.withdrawal, Frequency._2to3TimesAWeek);

            var q9 = new Question("I had problems with my family or friends because of how much I overate.", Category.socialProblems, Frequency.LessThanMonthly);
            var q21 = new Question("I avoided social situations because people wouldn’t approve of how much I ate.", Category.socialProblems, Frequency.OnceAMonth);
            var q35 = new Question("My friends or family were worried about how much I overate.", Category.socialProblems, Frequency.LessThanMonthly);

            var q19 = new Question("I ate to the point where I felt physically ill.", Category.roleFail, Frequency.LessThanMonthly);
            var q27 = new Question("I didn’t do well at work or school because I was eating too much.", Category.roleFail, Frequency.LessThanMonthly);

            var q28 = new Question("I kept eating certain foods even though I knew it was physically dangerous. For example, I kept eating sweets even though I had diabetes. Or I kept eating fatty foods despite having heart disease.", Category.hazardousSituations, Frequency._2to3TimesaMonth);
            var q33 = new Question("I was so distracted by eating that I could have been hurt (e.g., when driving a car, crossing the street, operating machinery).", Category.hazardousSituations, Frequency.LessThanMonthly);
            var q34 = new Question("I was so distracted by thinking about food that I could have been hurt (e.g., when driving a car, crossing the street, operating machinery).", Category.hazardousSituations, Frequency.OnceAMonth);

            var q29 = new Question("I had such strong urges to eat certain foods that I couldn’t think of anything else.", Category.craving, Frequency._2to3TimesaMonth);
            var q30 = new Question("I had such intense cravings for certain foods that I felt like I had to eat them right away.", Category.craving, Frequency.OnceAWeek);

            var q16 = new Question("My eating behavior caused me a lot of distress.", Category.clinicalImpairment, Frequency.OnceAWeek);
            var q17 = new Question("I had significant problems in my life because of food and eating. These may have been problems with my daily routine, work, school, friends, family, or health.", Category.clinicalImpairment, Frequency.OnceAWeek);

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
            //  for (int j = 0; j < QuestionCollection.Count; j++)  

            int count = 1;

            foreach (var question in QuestionCollection)
            {
                var qcat = question.Category;
                
                //Display question with number
                Console.WriteLine("\n" + "Question " + (count) +". " + question.Content);

                //Display answers
                foreach (Enum thingy in Frequency.GetValues(typeof(Frequency)))
                {
                   Console.WriteLine(GetDescription(thingy));  
                }

                //Get user's answer
                var answer = int.Parse(Console.ReadLine());

                //Compare answer to threshold
                if (answer >= (int)question.Frequency) 
                {
                    categories12[(int)question.Frequency] = true;
                }

                count++;

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
            }
            else if ((finalScore >= 2) && (finalScore < 4))
            {
                Console.WriteLine("Mild Food Addiction = 2 or 3 symptoms and clinical significance.");
            }
            else if ((finalScore >= 4) && (finalScore <= 5))
            {
                Console.WriteLine("Moderate Food Addiction = 4 or 5 symptoms and clinical significance");
            }
            else if (finalScore > 5)
            {
                Console.WriteLine("Severe Food Addiction = 6 or more symptoms and clinical significance");
            }

            Console.ReadLine();
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
            /// <summary>
            /// TODO - fix these lazy var names!
            /// </summary>
            public string Content;
            public Category Category;
            public Frequency Frequency;

            public Question(string content, Category category, Frequency freq)
            {
                Content = content;
                Category = category;
                Frequency = freq;
            }
        }

    }
}