namespace fit_repair.tests;

public class UnitTest1
{
    [Fact]
    public async void TestReadRecords()
    {
        using FileStream reader = new("activity.fit", FileMode.Open, FileAccess.Read);
        var parser = FitParser.Create(reader);
        await parser.Read();
    }
}