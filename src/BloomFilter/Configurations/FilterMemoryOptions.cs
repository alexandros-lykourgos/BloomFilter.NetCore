﻿using System.Collections;

namespace BloomFilter.Configurations;

public class FilterMemoryOptions
{
    /// <summary>
    /// The Name
    /// </summary>
    public string Name { get; set; } = BloomFilterConstValue.DefaultInMemoryName;

    /// <summary>
    /// The expected elements
    /// </summary>
    public long ExpectedElements { get; set; } = 1000000;

    /// <summary>
    /// The error rate
    /// </summary>
    public double ErrorRate { get; set; } = 0.01;

    /// <summary>
    /// The Hash Method
    /// </summary>
    public HashMethod Method { get; set; } = HashMethod.Murmur3;

    /// <summary>
    /// Sets the bit value
    /// </summary>
    public BitArray Bits { get; set; } = default!;

    /// <summary>
    /// Sets more the bit value
    /// </summary>
    public BitArray? BitsMore { get; set; }

    /// <summary>
    /// Sets the bit value
    /// </summary>
    public byte[] Bytes { get; set; } = default!;

    /// <summary>
    /// Sets more the bit value
    /// </summary>
    public byte[]? BytesMore { get; set; }
}