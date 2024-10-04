using System.Collections;

SortedList sortedList = new SortedList();
sortedList.Add(4, "four");
sortedList.Add(1, "One");
sortedList.Add(3, "Three");

foreach (DictionaryEntry d in sortedList)
{
    Console.WriteLine(d.Key + " " + d.Value);
}