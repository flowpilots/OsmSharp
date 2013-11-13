﻿// OsmSharp - OpenStreetMap (OSM) SDK
// Copyright (C) 2013 Abelshausen Ben
// 
// This file is part of OsmSharp.
// 
// OsmSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// OsmSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with OsmSharp. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProtoBuf;

namespace OsmSharp.Routing.CH.Serialization.Sorted.v2
{
    /// <summary>
    /// Represents an index of all CH blocks.
    /// </summary>
    [ProtoContract]
    public class CHBlockIndex
    {
        /// <summary>
        /// Holds all relative block locations in the file.
        /// </summary>
        [ProtoMember(1)]
        public int[] LocationIndex { get; set; }
    }

    /// <summary>
    /// Represents a block containing sorted nodes and their respective arcs.
    /// </summary>
    [ProtoContract]
    public class CHBlock
    {
        /// <summary>
        /// The lower index of the arcs associated with this vertex.
        /// </summary>
        [ProtoMember(1, Options = global::ProtoBuf.MemberSerializationOptions.Packed)]
        public ushort[] VertexArcIndex { get; set; }

        /// <summary>
        /// The number of arcs associated with this vertex.
        /// </summary>
        [ProtoMember(2, Options = global::ProtoBuf.MemberSerializationOptions.Packed)]
        public ushort[] VertexArcCount { get; set; }

        /// <summary>
        /// Holds the vertex latitude.
        /// </summary>
        [ProtoMember(3, Options = global::ProtoBuf.MemberSerializationOptions.Packed)]
        public float[] VertexLatitude { get; set; }

        /// <summary>
        /// Holds the vertex longitude.
        /// </summary>
        [ProtoMember(4, Options = global::ProtoBuf.MemberSerializationOptions.Packed)]
        public float[] VertexLongitude { get; set; }
        
        /// <summary>
        /// The id of the target-vertex when not in this block.
        /// </summary>
        [ProtoMember(5, Options = global::ProtoBuf.MemberSerializationOptions.Packed)]
        public uint[] ArcTargetId { get; set; }

        /// <summary>
        /// The weight of this arc.
        /// </summary>
        [ProtoMember(6, Options = global::ProtoBuf.MemberSerializationOptions.Packed)]
        public float[] ArcWeight { get; set; }

        /// <summary>
        /// Holds the id of the external shortcut vertex.
        /// </summary>
        [ProtoMember(7, Options = global::ProtoBuf.MemberSerializationOptions.Packed)]
        public uint[] ArcShortcutId { get; set; }

        /// <summary>
        /// Holds the direction(s) of this arc (0=bidirectional, 1=forward, 2=backward)
        /// </summary>
        [ProtoMember(8, Options = global::ProtoBuf.MemberSerializationOptions.Packed)]
        public byte[] ArcDirection { get; set; }

        /// <summary>
        /// Holds the tags id associated with this arc.
        /// </summary>
        [ProtoMember(9, Options = global::ProtoBuf.MemberSerializationOptions.Packed)]
        public uint[] ArcTagsId { get; set; }

        /// <summary>
        /// Calculates the block id for the given vertex id using the block size.
        /// </summary>
        /// <param name="vertexId"></param>
        /// <param name="blockSize"></param>
        /// <returns></returns>
        public static uint CalculateId(uint vertexId, uint blockSize)
        {
            return (((vertexId - 1) / blockSize) * (uint)blockSize) + 1;
        }
    }

    /// <summary>
    /// Represents an index of all CH regions.
    /// </summary>
    [ProtoContract]
    public class CHVertexRegionIndex
    {
        /// <summary>
        /// Holds all region ids.
        /// </summary>
        [ProtoMember(1, Options = global::ProtoBuf.MemberSerializationOptions.Packed)]
        public ulong[] RegionIds { get; set; }

        /// <summary>
        /// Holds all relative region locations in the file.
        /// </summary>
        [ProtoMember(2, Options = global::ProtoBuf.MemberSerializationOptions.Packed)]
        public int[] LocationIndex { get; set; }
    }

    /// <summary>
    /// Represents a region containing a list of vertices.
    /// </summary>
    [ProtoContract]
    public class CHVertexRegion
    {
        /// <summary>
        /// The list of vertices in this region.
        /// </summary>
        [ProtoMember(1, Options = global::ProtoBuf.MemberSerializationOptions.Packed)]
        public uint[] Vertices { get; set; }
    }
}