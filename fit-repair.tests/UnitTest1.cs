namespace fit_repair.tests;

public class UnitTest1
{


    [Fact]
    public async void TestReadHeader()
    {
        using FileStream reader = new("clean.fit", FileMode.Open, FileAccess.Read);
        var parser = FitParser.Create(reader);

        var header = await parser.ReadHeaderAsync();
        Assert.Equal(14, header.HeaderSize);
        Assert.Equal(16, header.ProtocolVersion);
        Assert.Equal(2201, header.ProfileVersion);
        Assert.Equal(68052, header.DataSize);

        Assert.Equal(".FIT", header.DataType);
    }


    [Fact]
    public async void TestReadRecords()
    {
        using FileStream reader = new("clean.fit", FileMode.Open, FileAccess.Read);
        var parser = FitParser.Create(reader);

        var header = await parser.ReadHeaderAsync();

        parser.ReadRecords();

    }
}