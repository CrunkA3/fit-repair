
namespace fit_repair.tests;

public class UnitTest1
{
    [Fact]
    public async void TestReadRecords()
    {
        using FileStream reader = new("activity.fit", FileMode.Open, FileAccess.Read);
        var parser = FitParser.Create(reader);
        var fitFile = await parser.Read();

        //FileId
        Assert.IsType<FileIdMessage>(fitFile.DataMessages[0]);
        var fileIdMessage = (FileIdMessage)fitFile.DataMessages[0];
        Assert.Equal(FileType.Activity, fileIdMessage.GetFileType());
        Assert.Equal((ushort)255, fileIdMessage.GetManufacturer());
        Assert.Equal((ushort)0, fileIdMessage.GetProduct());
        Assert.Equal(new DateTime(995749880, DateTimeKind.Utc), fileIdMessage.GetTimeCreated());
        Assert.Equal((uint?)1457061125, fileIdMessage.GetSerialNumber());
        Assert.Null(fileIdMessage.GetProductName());

    }
}