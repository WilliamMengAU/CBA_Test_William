# CBA_Test_ConsoleApp
Solution 1 for CBA

#### Design Ideas: ####
- Using Reflection. Define a list of functions in the CountingMethods class, then use reflection to find which one should be called for the rule.
- The interface ICountingMethods to restrict the rules functions must to be implemented.
- The the rules is defined in RulesDefine.json file, can be easily add, stop(disable), remove and reconfigured without restarting the application (if no new rule type be added).
- The StartCharsList is List<List<char>>, it supports multi chars match. StartCharsList[i] match word[i].
- The FollowingWordsStartCharsList is List<StartCharsList>, it supports multi following words match. 
  FollowingWordsStartCharsList[i] match word[i+1].

#### Using Example: ####
    "Press Q key to Exit.\r\nPress any key do another counting.";
    "The contents of InputTextFile.txt and RulesDefine.json can be replaced before you press any key to do a new counting task.";


#### Requirement: ####

- Run counting rules;
- easily add, stop ...;
- ...


#### Implementation: ####

The solution must conform to the below requirements:

- C#/ Visiual Studio 2017+;
- 

#### Data structrue: ####
Example Rule define:

    {
      "RuleName": "Counting rule 4",
      "RuleTypeName": "count_of_sequence_of_words_starting_with_chars_list",
      "Enable": true,
      "StartCharsList": [
        [ "c", "C" ]
      ],
      "FollowingWordsStartCharsList": [
        [
          [ "a", "A" ]
        ]
      ],
      "OutputFileName": "count_of_sequence_of_words_starting_with_c_and_a.txt"
    }



#### Submission ####




#### Hints ####
* 

