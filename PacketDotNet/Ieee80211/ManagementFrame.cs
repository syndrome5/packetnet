﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using MiscUtil.Conversion;
using PacketDotNet.Utils;

namespace PacketDotNet
{
    namespace Ieee80211
    {
        /// <summary>
        /// Format of a CTS or an ACK frame
        /// </summary>
        public abstract class ManagementFrame : MacFrame
        {
            /// <summary>
            /// DestinationAddress
            /// </summary>
            public PhysicalAddress DestinationAddress {get; set;}

            /// <summary>
            /// SourceAddress
            /// </summary>
            public PhysicalAddress SourceAddress {get; set;}

            /// <summary>
            /// BssID
            /// </summary>
            public PhysicalAddress BssId {get; set;}


            /// <summary>
            /// Frame control bytes are the first two bytes of the frame
            /// </summary>
            public UInt16 SequenceControlBytes
            {
                get
                {
                    return EndianBitConverter.Little.ToUInt16(header.Bytes,
                                                          (header.Offset + MacFields.Address1Position + (MacFields.AddressLength * 3)));
                }

                set
                {
                    EndianBitConverter.Little.CopyBytes(value,
                                                     header.Bytes,
                                                     (header.Offset + MacFields.Address1Position + (MacFields.AddressLength * 3)));
                }
            }

            /// <summary>
            /// Sequence control field
            /// </summary>
            public SequenceControlField SequenceControl {get; set;}
        } 
    }

}
