using Challenges;

namespace ChallengesPart1Level6;

public class TheVariableShopChallenge() : Challenge("The Variable Shop")
{
    public override void Run(object[]? parameters = null)
    {
        byte byteIs1byte = 1;
        short shortIs2bytes = 2;
        int intIs4bytes = 4;
        long longIs8bytes = 8;
        sbyte sByteIs1byte = 1;
        ushort uShortIs2bytes = 2;
        uint uIntIs4bytes = 4;
        ulong uLongIs8bytes = 8;
        char character = 'a';
        string helloWorld = "Hello, World!";
        float floatIs4Bytes = 4.0f;
        double doubleIs8bytes = 8.0;
        decimal decimalIs16Bytes = 16.0m;
        bool boolIs1Byte = true;

        object[] objects = [byteIs1byte, shortIs2bytes, intIs4bytes, longIs8bytes, sByteIs1byte, uShortIs2bytes, uIntIs4bytes,
                            uLongIs8bytes, character, helloWorld, floatIs4Bytes, doubleIs8bytes, decimalIs16Bytes, boolIs1Byte];

        foreach (var obj in objects)
        {
            Console.WriteLine(obj);
        }
    }
}
