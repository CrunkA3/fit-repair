using System.Collections.ObjectModel;

public class DataMessage
{
    internal DataMessage(int localMessageType)
    {
        LocalMessageType = localMessageType;
    }

    public int LocalMessageType { get; private init; }

    private List<DataField> _dataFields = new();
    private List<DeveloperDataField> _developerDataFields = new();

    
    public ReadOnlyCollection<DataField> DataFields => _dataFields.AsReadOnly();
    public ReadOnlyCollection<DeveloperDataField> DeveloperDataFields => _developerDataFields.AsReadOnly();


    internal void AddDataField(DataField dataField) => _dataFields.Add(dataField);
    internal void AddDeveloperDataField(DeveloperDataField developerDataField) => _developerDataFields.Add(developerDataField);
}