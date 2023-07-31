int x = 36;
int y = 7;

while (x != y)
{
    if (x > y)
    {
        x -= y;
    }
    else
    {
        y -= x;
    }
}
Console.WriteLine((x));