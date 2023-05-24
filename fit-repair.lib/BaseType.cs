public enum BaseType
{
    Sint8BaseType = 1,
    Uint8BaseType = 2,
    Sint16BaseType = 3,
    Uint16BaseType = 4,
    Sint32BaseType = 5,
    Uint32BaseType = 6,
    StringBaseType = 7,
    Float32BaseType = 8,
    Float64BaseType = 9,
    Uint8ZBaseType = 10,
    Uint16ZBaseType = 11,
    Uint32ZBaseType = 12,
    ByteBaseType = 13,
    Sint64BaseType = 14,
    Uint64BaseType = 15,
    Uint64ZBaseType = 16

    /*
        0	0	0x00	enum	0xFF	1	
        1	0	0x01	sint8	0x7F	1	2’s complement format
        2	0	0x02	uint8	0xFF	1	
        3	1	0x83	sint16	0x7FFF	2	2’s complement format
        4	1	0x84	uint16	0xFFFF	2	
        5	1	0x85	sint32	0x7FFFFFFF	4	2’s complement format
        6	1	0x86	uint32	0xFFFFFFFF	4	
        7	0	0x07	string	0x00	1	Null terminated string encoded in UTF-8 format
        8	1	0x88	float32	0xFFFFFFFF	4	
        9	1	0x89	float64	0xFFFFFFFFFFFFFFFF	8	
        10	0	0x0A	uint8z	0x00	1	
        11	1	0x8B	uint16z	0x0000	2	
        12	1	0x8C	uint32z	0x00000000	4	
        13	0	0x0D	byte	0xFF	1	Array of bytes. Field is invalid if all bytes are invalid.
        14	1	0x8E	sint64	0x7FFFFFFFFFFFFFFF	8	2’s complement format
        15	1	0x8F	uint64	0xFFFFFFFFFFFFFFFF	8	
        16	1	0x90	uint64z	0x0000000000000000	8	
    */
}