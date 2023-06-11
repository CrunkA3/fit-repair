using System.Collections.ObjectModel;
using System.Text;

namespace FitRepair;

public class DataMessage
{
    internal DataMessage(int localMessageType)
    {
        LocalMessageType = localMessageType;
    }

    public int LocalMessageType { get; private init; }

    private readonly List<DataField> _dataFields = new();
    private readonly List<DeveloperDataField> _developerDataFields = new();


    public ReadOnlyCollection<DataField> DataFields => _dataFields.AsReadOnly();
    public ReadOnlyCollection<DeveloperDataField> DeveloperDataFields => _developerDataFields.AsReadOnly();


    internal void AddDataField(DataField dataField) => _dataFields.Add(dataField);
    internal void AddDeveloperDataField(DeveloperDataField developerDataField) => _developerDataFields.Add(developerDataField);


    public DataField GetDataField(byte fieldNumber)
    {
        return _dataFields.First(m => m.FieldDefinition.Number.Equals(fieldNumber));
    }
    public bool TryGetDataField(byte fieldNumber, out DataField dataField)
    {
        try
        {
            dataField = _dataFields.First(m => m.FieldDefinition.Number.Equals(fieldNumber));
            return true;
        }
        catch (Exception)
        {
            dataField = new();
            return false;
        }

    }

    public byte GetValueByte(byte fieldNumber)
    {
        return GetDataField(fieldNumber).ContentBytes[0];
    }
    public byte? GetValueOrDefaultByte(byte fieldNumber)
    {
        try
        {
            return GetValueByte(fieldNumber);
        }
        catch (Exception)
        {
            return default;
        }
    }

    public ushort GetValueUshort(byte fieldNumber)
    {
        return BitConverter.ToUInt16(GetDataField(fieldNumber).ContentBytes);
    }
    public ushort? GetValueOrDefaultUshort(byte fieldNumber)
    {
        try
        {
            return GetValueUshort(fieldNumber);
        }
        catch (Exception)
        {
            return default;
        }
    }



    public float GetValueFloat(byte fieldNumber)
    {
        return BitConverter.ToSingle(GetDataField(fieldNumber).ContentBytes);
    }
    public float? GetValueOrDefaultFloat(byte fieldNumber)
    {
        try
        {
            return GetValueFloat(fieldNumber);
        }
        catch (Exception)
        {
            return default;
        }
    }

    public uint GetValueUint(byte fieldNumber)
    {
        return BitConverter.ToUInt32(GetDataField(fieldNumber).ContentBytes);
    }
    public uint? GetValueOrDefaultUint(byte fieldNumber)
    {
        try
        {
            return GetValueUint(fieldNumber);
        }
        catch (Exception)
        {
            return default;
        }
    }

    public DateTime GetValueDateTime(byte fieldNumber)
    {
        return new DateTime(GetValueUint(fieldNumber), DateTimeKind.Utc);
    }
    public DateTime? GetValueOrDefaultDateTime(byte fieldNumber)
    {
        try
        {
            return GetValueDateTime(fieldNumber);
        }
        catch (Exception)
        {
            return default;
        }
    }

    public byte[] GetValueBytes(byte fieldNumber)
    {
        return GetDataField(fieldNumber).ContentBytes;
    }
    public byte[]? GetValueOrDefaultBytes(byte fieldNumber)
    {
        try
        {
            return GetValueBytes(fieldNumber);
        }
        catch (Exception)
        {
            return default;
        }
    }

    public string GetValueString(byte fieldNumber)
    {
        return Encoding.UTF8.GetString(GetDataField(fieldNumber).ContentBytes);
    }
    public string? GetValueOrDefaultString(byte fieldNumber)
    {
        try
        {
            return GetValueString(fieldNumber);
        }
        catch (Exception)
        {
            return default;
        }
    }
}