using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iccProfilerViewer.Model
{
    public class IccProfile
    {
        private byte[] fileContent;

        private ICollection<TagStructures> tagStructures;

        public IccProfile(byte[] fileContent)
        {
            this.fileContent = fileContent;

            tagStructures = Enumerable.Range(0, (int)TagCount.Value).Select(z => new TagStructures(GetArrayRangeByIndex(fileContent, 132 + z * 12, 143 + z * 12).ToArray())).ToList();
        }

        public ArraySegment<byte> CmmType
        {
            get
            {
                return GetArrayRangeByIndex(fileContent, 4, 7);
            }
        }

        public ProfileVersionNumber ProfileVersion
        {
            get
            {
                return new ProfileVersionNumber(GetArrayRangeByIndex(fileContent, 8, 11).ToArray());
            }
        }

        public ArraySegment<byte> ProfileClass
        {
            get
            {
                return GetArrayRangeByIndex(fileContent, 12, 15);
            }
        }

        public ArraySegment<byte> ColorSpaceOfData
        {
            get
            {
                return GetArrayRangeByIndex(fileContent, 16, 19);
            }
        }

        public ArraySegment<byte> ProfileConnectionSpace
        {
            get
            {
                return GetArrayRangeByIndex(fileContent, 20, 23);
            }
        }

        public ProfileDateTime DateAndTimeCreated
        {
            get
            {
                return new ProfileDateTime(GetArrayRangeByIndex(fileContent, 24, 35).ToArray());
            }
        }

        public ArraySegment<byte> PrimaryPlatform
        {
            get
            {
                return GetArrayRangeByIndex(fileContent, 40, 43);
            }
        }

        public ArraySegment<byte> OptionsFlags
        {
            get
            {
                return GetArrayRangeByIndex(fileContent, 44, 47);
            }
        }

        public ArraySegment<byte> DeviceManufacture
        {
            get
            {
                return GetArrayRangeByIndex(fileContent, 48, 51);
            }
        }

        public ArraySegment<byte> DeviceModel
        {
            get
            {
                return GetArrayRangeByIndex(fileContent, 51, 55);
            }
        }

        public ArraySegment<byte> DeviceAttributes
        {
            get
            {
                return GetArrayRangeByIndex(fileContent, 56, 63);
            }
        }

        public ArraySegment<byte> RenderIntent
        {
            get
            {
                return GetArrayRangeByIndex(fileContent, 64, 67);
            }
        }

        public XYZNumber XYZValue
        {
            get
            {
                return new XYZNumber(GetArrayRangeByIndex(fileContent, 68, 79).ToArray());
            }
        }

        public ArraySegment<byte> CreatorProfile
        {
            get
            {
                return GetArrayRangeByIndex(fileContent, 80, 83);
            }
        }

        public ArraySegment<byte> Reserved
        {
            get
            {
                return GetArrayRangeByIndex(fileContent, 84, 127);
            }
        }

        public UInt32Number TagCount
        {
            get
            {
                return new UInt32Number(GetArrayRangeByIndex(fileContent, 128, 131).ToArray());
            }
        }

        public IEnumerable<TagStructures> TagStructures
        {
            get
            {
                return tagStructures;
            }
        }

        private ArraySegment<byte> GetArrayRangeByIndex(byte[] array, int from, int to)
        {
            Debug.Assert(from < to, "index from can not be great then from");
            return new ArraySegment<byte>(fileContent, from, to - from + 1);
        }
    }
}