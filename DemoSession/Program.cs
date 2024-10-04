string example = "aBCaBN";

int counteforNumber = 0;
int counteforCaptial = 0;
int countForLower = 0;
int countForSpecial=0;

for (int i = 0; i < example.Length; i++)
{
    if(example[i]>='A' && example[i]<='Z')
    {
        counteforCaptial++;
    }
    else if(example[i]>='a' && example[i]<='z')
    {
        countForLower++;    
    }
    else if (example[i]>='0' && example[i]<='9')
    {
        counteforNumber++;
    }
    else
    {
        countForSpecial++;
    }
}

Console.WriteLine($" this is the new {counteforCaptial}");
Console.WriteLine(countForLower); 
Console.WriteLine(countForSpecial);
Console.WriteLine(counteforNumber);
