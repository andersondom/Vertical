
int i;

int b = 8, a = 32;

for (i = 0; i <= 10; i++)

{

    if ((a / b * 2)== 2)

    {

        Console.WriteLine( i + " ");

        continue;

    }

    else if (i != 4)

        Console.WriteLine(i + " ");

    else

        break;

}

Console.ReadLine();