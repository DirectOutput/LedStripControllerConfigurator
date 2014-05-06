using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace LedStripController_Configurator
{
    public class HexFile
    {
        public enum HexFileRecordType
        {
            DataRecord = 0,
            EndOfFileRecord = 1,
            ExtendedSegmentAddressRecord = 2,
            StartSegmentAddressRecord = 3,
            ExtendedLinearAddressRecord = 4,
            StartLinearAddressRecord = 5
        }

        private string _Filename = "";
        public string Filename
        {
            get { return this._Filename; }
        }

        private List<HexFileLine> _HexFileLines;
        public List<HexFileLine> HexFileLines
        {
            get { return this._HexFileLines; }
        }


        public byte[] GetBinaryData()
        {
            int MaxAdress = -1;
            int AdressOffset = 0;
            bool DoneFlag = false;
            foreach (HexFileLine L in HexFileLines)
            {
                switch (L.RecordType)
                {
                    case HexFileRecordType.DataRecord:
                        if(L.Address+L.NumBytes+AdressOffset>MaxAdress) {
                            MaxAdress=L.Address + L.NumBytes + AdressOffset;
                        }
                        break;
                    case HexFileRecordType.EndOfFileRecord:
                        DoneFlag = true;
                        break;
                    case HexFileRecordType.ExtendedSegmentAddressRecord:
                        AdressOffset = L.Address;
                        break;
                    default:
                        throw new Exception("Unsupported record type");
                        
                }
                if (DoneFlag) break;
            }

            if (MaxAdress < 0 || !DoneFlag)
            {
                throw new Exception("Could not determine binary size or end record is missing.");
            }


            byte[] Data = new byte[MaxAdress];
            AdressOffset = 0;
            DoneFlag = false;
            foreach (HexFileLine L in HexFileLines)
            {
                switch (L.RecordType)
                {
                    case HexFileRecordType.DataRecord:
                        L.Data.CopyTo(Data, L.Address + AdressOffset);
                        break;
                    case HexFileRecordType.EndOfFileRecord:
                        DoneFlag = true;
                        break;
                    case HexFileRecordType.ExtendedSegmentAddressRecord:
                        AdressOffset = L.Address;
                        break;
                    default:
                        throw new Exception("Unsupported record type");
                }
                if (DoneFlag) break;
            }

            return Data;

        }

        // Konstruktor
        public HexFile()
        {
            this._HexFileLines = new List<HexFileLine>();
        }

        public void LoadFile(string vsFilename)
        {
            string sLine;
            FileStream fs;
            StreamReader sr;

            if (!System.IO.File.Exists(vsFilename))
                throw new ArgumentException(String.Format("File '{0}' does not exist.", vsFilename));
            this._Filename = vsFilename;

            // Datei öffnen
            try
            {
                fs = new FileStream(vsFilename, FileMode.Open);
                sr = new StreamReader(fs);
            }
            catch
            {
                throw new Exception(string.Format("Could not open file '{0}'", vsFilename));
            }

            // Zeilen einlesen
            try
            {
                while (!sr.EndOfStream)
                {
                    sLine = sr.ReadLine();
                    //Trace.TraceInformation(this.GetType().Name + "." + MethodInfo.GetCurrentMethod().Name.ToString() + "(): "
                    //   + String.Format("Less HexLine {0}: '{1}'", this.HexFileLines.Count, sLine));

                    this._HexFileLines.Add(new HexFileLine(sLine));
                    Thread.Sleep(0);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                sr.Close();
                fs.Close();
            }
        }
    }
}
