namespace FitRepair;

public class FitFile
{
    public FitFileHeader Header { get; private init; }
    public List<DataMessage> DataMessages { get; private init; }

    internal FitFile(FitFileHeader header, List<DataMessage> dataMessages)
    {
        Header = header;
        DataMessages = dataMessages;
    }

}