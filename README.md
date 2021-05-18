# BloomFilter.NetCore

[![Build Status](https://travis-ci.org/vla/BloomFilter.NetCore.svg?branch=master)](https://travis-ci.org/vla/BloomFilter.NetCore)

Library  Bloom filters in C#


Packages & Status
---

Package  | NuGet         |
-------- | :------------ |
|**BloomFilter.NetCore**|[![NuGet package](https://buildstats.info/nuget/BloomFilter.NetCore)](https://www.nuget.org/packages/BloomFilter.NetCore)
|**BloomFilter.Redis.NetCore**|[![NuGet package](https://buildstats.info/nuget/BloomFilter.Redis.NetCore)](https://www.nuget.org/packages/BloomFilter.Redis.NetCore)


Usage
---

In Memory
```cs
    public class Demo
    {
        static Filter<string> bf = FilterBuilder.Build<string>(10000000, 0.01);
        
        public void Sample()
        {
            bf.Add("Value");
            Console.WriteLine(bf.Contains("Value"));
        }
    }
 
```

Use Redis
```cs
    public class Demo
    {
        static Filter<string> bf = FilterRedisBuilder.Build<string>("localhost", "InstanceName", 5000000, 0.001);

        public void Sample()
        {
            bf.Add("Value");
            Console.WriteLine(bf.Contains("Value"));
        }
    }
```



Benchmark
---

``` ini

ExpectedElements 1000000
ErrRate 1%

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 7 5800X, 1 CPU, 16 logical and 8 physical cores
.NET Core SDK=5.0.203
  [Host]     : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT
  DefaultJob : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT


```



| Method | DataSize |               Method |        Mean |     Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------- |--------- |--------------------- |------------:|----------:|----------:|-------:|------:|------:|----------:|
|    **Add** |       **64** |          **LCGWithFNV1** |    **71.46 ns** |  **0.562 ns** |  **0.469 ns** | **0.0033** |     **-** |     **-** |      **56 B** |
|    **Add** |       **64** |         **LCGWithFNV1a** |    **71.46 ns** |  **0.515 ns** |  **0.456 ns** | **0.0033** |     **-** |     **-** |      **56 B** |
|    **Add** |       **64** |      **LCGModifiedFNV1** |    **73.68 ns** |  **0.237 ns** |  **0.210 ns** | **0.0033** |     **-** |     **-** |      **56 B** |
|    **Add** |       **64** |          **RNGWithFNV1** |   **376.15 ns** |  **3.480 ns** |  **3.085 ns** | **0.0200** |     **-** |     **-** |     **336 B** |
|    **Add** |       **64** |         **RNGWithFNV1a** |   **358.71 ns** |  **1.896 ns** |  **1.773 ns** | **0.0200** |     **-** |     **-** |     **336 B** |
|    **Add** |       **64** |      **RNGModifiedFNV1** |   **380.91 ns** |  **3.113 ns** |  **2.759 ns** | **0.0200** |     **-** |     **-** |     **336 B** |
|    **Add** |       **64** |                **CRC32** |   **849.82 ns** |  **8.669 ns** |  **8.109 ns** | **0.0057** |     **-** |     **-** |      **96 B** |
|    **Add** |       **64** |               **CRC32u** | **1,126.47 ns** | **16.772 ns** | **14.006 ns** | **0.0057** |     **-** |     **-** |      **96 B** |
|    **Add** |       **64** |              **Adler32** |   **292.85 ns** |  **5.753 ns** |  **7.276 ns** | **0.0057** |     **-** |     **-** |      **96 B** |
|    **Add** |       **64** |              **Murmur2** |   **317.99 ns** |  **2.378 ns** |  **2.224 ns** | **0.0086** |     **-** |     **-** |     **144 B** |
|    **Add** |       **64** |              **Murmur3** |   **224.56 ns** |  **0.938 ns** |  **0.831 ns** | **0.0033** |     **-** |     **-** |      **56 B** |
|    **Add** |       **64** | **Murmu(...)acher [25]** |    **79.59 ns** |  **0.367 ns** |  **0.343 ns** | **0.0033** |     **-** |     **-** |      **56 B** |
|    **Add** |       **64** |                 **SHA1** | **2,063.04 ns** | **13.598 ns** | **12.720 ns** | **0.0572** |     **-** |     **-** |     **960 B** |
|    **Add** |       **64** |               **SHA256** |   **935.44 ns** |  **4.658 ns** |  **4.129 ns** | **0.0391** |     **-** |     **-** |     **664 B** |
|    **Add** |       **64** |               **SHA384** |   **974.55 ns** |  **2.792 ns** |  **2.475 ns** | **0.0305** |     **-** |     **-** |     **528 B** |
|    **Add** |       **64** |               **SHA512** |   **908.09 ns** |  **3.034 ns** |  **2.838 ns** | **0.0353** |     **-** |     **-** |     **592 B** |
