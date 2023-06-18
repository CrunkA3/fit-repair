using FitRepair.Extensions;
using FitRepair.Sports;
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

    public ReadOnlyCollection<Sport> GetValueSports(byte fieldNumber)
    {
        var sportsByte0 = (Sport0)GetDataField(fieldNumber).ContentBytes[0];
        var sportsByte1 = (Sport1)GetDataField(fieldNumber).ContentBytes[1];
        var sportsByte2 = (Sport2)GetDataField(fieldNumber).ContentBytes[2];
        var sportsByte3 = (Sport3)GetDataField(fieldNumber).ContentBytes[3];
        var sportsByte4 = (Sport4)GetDataField(fieldNumber).ContentBytes[4];
        var sportsByte5 = (Sport5)GetDataField(fieldNumber).ContentBytes[5];
        var sportsByte6 = (Sport6)GetDataField(fieldNumber).ContentBytes[6];

        var sports = new List<Sport>();

        sports.AddIf(sportsByte0, Sport0.Generic, Sport.Generic);
        sports.AddIf(sportsByte0, Sport0.Running, Sport.Running);
        sports.AddIf(sportsByte0, Sport0.Cycling, Sport.Cycling);
        sports.AddIf(sportsByte0, Sport0.Transition, Sport.Transition);
        sports.AddIf(sportsByte0, Sport0.FitnessEquipment, Sport.FitnessEquipment);
        sports.AddIf(sportsByte0, Sport0.Swimming, Sport.Swimming);
        sports.AddIf(sportsByte0, Sport0.Basketball, Sport.Basketball);
        sports.AddIf(sportsByte0, Sport0.Soccer, Sport.Soccer);

        sports.AddIf(sportsByte1, Sport1.Tennis, Sport.Tennis);
        sports.AddIf(sportsByte1, Sport1.AmericanFootball, Sport.AmericanFootball);
        sports.AddIf(sportsByte1, Sport1.Training, Sport.Training);
        sports.AddIf(sportsByte1, Sport1.Walking, Sport.Walking);
        sports.AddIf(sportsByte1, Sport1.CrossCountrySkiing, Sport.CrossCountrySkiing);
        sports.AddIf(sportsByte1, Sport1.AlpineSkiing, Sport.AlpineSkiing);
        sports.AddIf(sportsByte1, Sport1.Snowboarding, Sport.Snowboarding);
        sports.AddIf(sportsByte1, Sport1.Rowing, Sport.Rowing);

        sports.AddIf(sportsByte2, Sport2.Mountaineering, Sport.Mountaineering);
        sports.AddIf(sportsByte2, Sport2.Hiking, Sport.Hiking);
        sports.AddIf(sportsByte2, Sport2.Multisport, Sport.Multisport);
        sports.AddIf(sportsByte2, Sport2.Paddling, Sport.Paddling);
        sports.AddIf(sportsByte2, Sport2.Flying, Sport.Flying);
        sports.AddIf(sportsByte2, Sport2.EBiking, Sport.EBiking);
        sports.AddIf(sportsByte2, Sport2.Motorcycling, Sport.Motorcycling);
        sports.AddIf(sportsByte2, Sport2.Boating, Sport.Boating);

        sports.AddIf(sportsByte3, Sport3.Driving, Sport.Driving);
        sports.AddIf(sportsByte3, Sport3.Golf, Sport.Golf);
        sports.AddIf(sportsByte3, Sport3.HangGliding, Sport.HangGliding);
        sports.AddIf(sportsByte3, Sport3.HorsebackRiding, Sport.HorsebackRiding);
        sports.AddIf(sportsByte3, Sport3.Hunting, Sport.Hunting);
        sports.AddIf(sportsByte3, Sport3.Fishing, Sport.Fishing);
        sports.AddIf(sportsByte3, Sport3.InlineSkating, Sport.InlineSkating);
        sports.AddIf(sportsByte3, Sport3.RockClimbing, Sport.RockClimbing);

        sports.AddIf(sportsByte4, Sport4.Sailing, Sport.Sailing);
        sports.AddIf(sportsByte4, Sport4.IceSkating, Sport.IceSkating);
        sports.AddIf(sportsByte4, Sport4.SkyDiving, Sport.SkyDiving);
        sports.AddIf(sportsByte4, Sport4.Snowshoeing, Sport.Snowshoeing);
        sports.AddIf(sportsByte4, Sport4.Snowmobiling, Sport.Snowmobiling);
        sports.AddIf(sportsByte4, Sport4.StandUpPaddleboarding, Sport.StandUpPaddleboarding);
        sports.AddIf(sportsByte4, Sport4.Surfing, Sport.Surfing);
        sports.AddIf(sportsByte4, Sport4.Wakeboarding, Sport.Wakeboarding);

        sports.AddIf(sportsByte5, Sport5.WaterSkiing, Sport.Sailing);
        sports.AddIf(sportsByte5, Sport5.Kayaking, Sport.IceSkating);
        sports.AddIf(sportsByte5, Sport5.Rafting, Sport.SkyDiving);
        sports.AddIf(sportsByte5, Sport5.Windsurfing, Sport.Snowshoeing);
        sports.AddIf(sportsByte5, Sport5.Kitesurfing, Sport.Snowmobiling);
        sports.AddIf(sportsByte5, Sport5.Tactical, Sport.StandUpPaddleboarding);
        sports.AddIf(sportsByte5, Sport5.Jumpmaster, Sport.Surfing);
        sports.AddIf(sportsByte5, Sport5.Boxing, Sport.Wakeboarding);

        sports.AddIf(sportsByte6, Sport6.FloorClimbing, Sport.FloorClimbing);
        sports.TrimExcess();

        return sports.AsReadOnly();
    }
    public ReadOnlyCollection<Sport> GetValueOrDefaultSports(byte fieldNumber)
    {
        try
        {
            return GetValueSports(fieldNumber);
        }
        catch (Exception)
        {
            return Array.Empty<Sport>().AsReadOnly();
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

    public DateTime GetValueDateTime(byte fieldNumber, DateTimeKind dateTimeKind)
    {
        return new DateTime(GetValueUint(fieldNumber), dateTimeKind);
    }
    public DateTime GetValueDateTime(byte fieldNumber)
    {
        return GetValueDateTime(fieldNumber, DateTimeKind.Utc);
    }
    public DateTime? GetValueOrDefaultDateTime(byte fieldNumber, DateTimeKind dateTimeKind)
    {
        try
        {
            return GetValueDateTime(fieldNumber, dateTimeKind);
        }
        catch (Exception)
        {
            return default;
        }
    }
    public DateTime? GetValueOrDefaultDateTime(byte fieldNumber)
    {
        return GetValueOrDefaultDateTime(fieldNumber, DateTimeKind.Utc);
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