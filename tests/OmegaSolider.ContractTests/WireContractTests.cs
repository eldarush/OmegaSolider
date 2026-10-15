using Google.Protobuf;
using Google.Protobuf.Reflection;
using OmegaSolider.Messages;
using Xunit;

public class WireContractTests
{
    [Fact]
    public void ExistingFieldNumbersAndTypesRemainCompatible()
    {
        string[] names = ["soldier_id", "name", "rank", "age", "favorite_food", "favorite_tv_show", "shoe_size", "height", "weight", "lucky_number", "hobby", "origin_planet", "favorite_technology", "favorite_team", "favorite_commander", "favorite_woman", "favorite_coding_language", "glow_intensity", "comedic_buff", "processed_at_unix_ms"];
        Assert.Equal(12, OmegaSolider.Messages.OmegaSolider.Descriptor.Fields.InFieldNumberOrder().Count);
        Assert.Equal(20, FireflyExpert.Descriptor.Fields.InFieldNumberOrder().Count);
        for (var number = 1; number <= names.Length; number++)
        {
            var field = FireflyExpert.Descriptor.FindFieldByNumber(number);
            Assert.Equal(names[number - 1], field.Name);
            var expectedType = number is 4 or 10 or 18 ? FieldType.Int32 : number == 20 ? FieldType.Int64 : number is 7 or 8 or 9 ? FieldType.Float : FieldType.String;
            Assert.Equal(expectedType, field.FieldType);
            if (number <= 12)
            {
                var inputField = OmegaSolider.Messages.OmegaSolider.Descriptor.FindFieldByNumber(number);
                Assert.Equal(field.Name, inputField.Name);
                Assert.Equal(field.FieldType, inputField.FieldType);
            }
        }
    }

    [Fact]
    public void UnknownFieldsSurviveOldReaderRoundTrip()
    {
        var expert = new FireflyExpert { SoldierId = "wire", FavoriteTechnology = "future", ProcessedAtUnixMs = 1234 };
        var oldReader = OmegaSolider.Messages.OmegaSolider.Parser.ParseFrom(expert.ToByteArray());
        Assert.Equal(expert, FireflyExpert.Parser.ParseFrom(oldReader.ToByteArray()));
    }
}
