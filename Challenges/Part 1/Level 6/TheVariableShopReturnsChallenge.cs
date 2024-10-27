using Challenges;

namespace ChallengesPart1Level6;

public class TheVariableShopReturnsChallenge() : Challenge("The Variable Shop Returns")
{
    public override void Run(object[]? parameters = null)
    {
        byte byteIs1byte = 1;
        byteIs1byte = 2;
        short shortIs2bytes = 2;
        shortIs2bytes = 3;
        int intIs4bytes = 4;
        intIs4bytes = 5;
        long longIs8bytes = 8;
        longIs8bytes = 9;
        sbyte sByteIs1byte = 1;
        sByteIs1byte = 2;
        ushort uShortIs2bytes = 2;
        uShortIs2bytes = 3;
        uint uIntIs4bytes = 4;
        uIntIs4bytes = 5;
        ulong uLongIs8bytes = 8;
        uLongIs8bytes = 9;
        char character = 'a';
        character = 'b';
        string helloWorld = "Hello, World!";
        helloWorld = "Hello, Universe!";
        float floatIs4Bytes = 4.0f;
        floatIs4Bytes = 5.0f;
        double doubleIs8bytes = 8.0;
        doubleIs8bytes = 9.0;
        decimal decimalIs16Bytes = 16.0m;
        decimalIs16Bytes = 17.0m;
        bool boolIs1Byte = true;
        boolIs1Byte = false;

        object[] objects = [byteIs1byte, shortIs2bytes, intIs4bytes, longIs8bytes, sByteIs1byte, uShortIs2bytes, uIntIs4bytes,
                            uLongIs8bytes, character, helloWorld, floatIs4Bytes, doubleIs8bytes, decimalIs16Bytes, boolIs1Byte];

        foreach (var obj in objects)
        {
            Console.WriteLine(obj);
        }
    }
}
