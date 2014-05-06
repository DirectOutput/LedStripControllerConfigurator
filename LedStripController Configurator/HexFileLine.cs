using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LedStripController_Configurator
{
    public class HexFileLine
    {
        // Anzahl der Datenbytes
        private int _NumBytes = 0;
        public int NumBytes
        {
            get { return this._NumBytes; }
        }
        // Recordtyp der Daten
        private HexFile.HexFileRecordType _RecordType = HexFile.HexFileRecordType.DataRecord;
        public HexFile.HexFileRecordType RecordType
        {
            get { return this._RecordType; }
        }
        // Zieladresse der Daten
        private System.UInt16 _Address = 0;
        public System.UInt16 Address
        {
            get { return this._Address; }
        }
        // Liste mit Daten
        private System.Byte[] _Data;
        public System.Byte[] Data
        {
            get { return this._Data; }
        }
        // Checksum
        private System.Byte _Checksum;
        public System.Byte Checksum
        {
            get { return this._Checksum; }
        }

        private const int DataOffset = 9;

        // Konstruktor
        // vsLine enthält aus Datei gelesene Textzeile
        public HexFileLine(string vsLine)
        {
            int i;

            if (vsLine.Length < 9)
                throw new Exception("Line to short");
            if (vsLine[0] != ':')
                throw new Exception("Line does not start with :");
            // Anzahl Bytes
            this._NumBytes = Convert.ToByte(vsLine.Substring(1, 2), 16);
            // Adresse
            this._Address = Convert.ToUInt16(vsLine.Substring(3, 4), 16);
            // Recordtype
            i = Convert.ToByte(vsLine.Substring(7, 2), 16);
            if (Enum.IsDefined(this._RecordType.GetType(), i))
                this._RecordType = (HexFile.HexFileRecordType)i;
            else
                throw new Exception("Unknow record type");

            switch (this._RecordType)
            {
                case HexFile.HexFileRecordType.DataRecord:
                    // Datenbytes einlesen
                    this._Data = new System.Byte[this._NumBytes];
                    for (i = 0; i < this._NumBytes; i++)
                        this._Data[i] = Convert.ToByte(vsLine.Substring(HexFileLine.DataOffset + i * 2, 2), 16);
                    // Checksum einlesen
                    this._Checksum = Convert.ToByte(vsLine.Substring(HexFileLine.DataOffset + this._NumBytes * 2, 2), 16);
                    // TODO: Checksum prüfen
                    break;
                case HexFile.HexFileRecordType.EndOfFileRecord:
                    break;
                case HexFile.HexFileRecordType.ExtendedSegmentAddressRecord:
                    this._Address = (System.UInt16)(Convert.ToUInt16(vsLine.Substring(HexFileLine.DataOffset, 4), 16) * 16);
                    break;
                default:
                    throw new Exception(string.Format("Recordtype '0X{0:X2}' is not supported", this._RecordType));
            }
        }
    }
}
