## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- StructLinq.BCL: [0.28.1](https://www.nuget.org/packages/StructLinq/0.28.1)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
``` ini

BenchmarkDotNet=v0.13.5, OS=Windows 10 (10.0.19045.3516/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=8.0.100-rc.1.23463.5
  [Host]     : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2
  Job-VLSRZF : .NET 6.0.22 (6.0.2223.42425), X64 RyuJIT AVX2
  Job-CRYVOQ : .NET 8.0.0 (8.0.23.41904), X64 RyuJIT AVX2


```
|                   Method |  Runtime | Duplicates | Count |        Mean |     Error |    StdDev |      Median |         Ratio | RatioSD |    Gen0 | Allocated |     Alloc Ratio |
|------------------------- |--------- |----------- |------ |------------:|----------:|----------:|------------:|--------------:|--------:|--------:|----------:|----------------:|
|                  ForLoop | .NET 6.0 |          4 |   100 | 13,426.9 ns | 105.24 ns |  87.88 ns | 13,392.7 ns |      baseline |         | 12.8174 |   26976 B |                 |
|              ForeachLoop | .NET 6.0 |          4 |   100 | 13,728.9 ns | 246.25 ns | 192.25 ns | 13,657.2 ns |  1.02x slower |   0.02x | 12.8174 |   26976 B |     1.000x more |
|                     Linq | .NET 6.0 |          4 |   100 | 16,294.3 ns | 136.25 ns | 151.44 ns | 16,258.8 ns |  1.22x slower |   0.01x | 12.8174 |   26912 B |     1.002x less |
|               LinqFaster | .NET 6.0 |          4 |   100 |  2,738.2 ns |  29.91 ns |  24.98 ns |  2,731.9 ns |  4.90x faster |   0.05x |  0.0114 |      24 B | 1,124.000x less |
|             LinqFasterer | .NET 6.0 |          4 |   100 | 15,864.7 ns | 315.05 ns | 451.83 ns | 15,666.3 ns |  1.18x slower |   0.04x | 34.8816 |   73168 B |     2.712x more |
|                   LinqAF | .NET 6.0 |          4 |   100 | 39,193.8 ns | 352.54 ns | 275.24 ns | 39,161.7 ns |  2.92x slower |   0.03x | 20.9351 |   43856 B |     1.626x more |
|               StructLinq | .NET 6.0 |          4 |   100 | 14,030.2 ns |  65.75 ns |  64.58 ns | 14,011.5 ns |  1.05x slower |   0.01x |  0.0305 |      64 B |   421.500x less |
| StructLinq_ValueDelegate | .NET 6.0 |          4 |   100 |  4,740.2 ns |  86.10 ns |  71.90 ns |  4,724.3 ns |  2.83x faster |   0.05x |       - |         - |              NA |
|                Hyperlinq | .NET 6.0 |          4 |   100 | 13,028.5 ns | 209.65 ns | 215.29 ns | 12,982.2 ns |  1.03x faster |   0.02x |       - |         - |              NA |
|                          |          |            |       |             |           |           |             |               |         |         |           |                 |
|                  ForLoop | .NET 8.0 |          4 |   100 | 11,656.4 ns |  92.53 ns |  77.27 ns | 11,644.8 ns |      baseline |         | 12.8937 |   26976 B |                 |
|              ForeachLoop | .NET 8.0 |          4 |   100 | 11,889.9 ns |  94.37 ns |  73.68 ns | 11,877.6 ns |  1.02x slower |   0.01x | 12.8784 |   26976 B |     1.000x more |
|                     Linq | .NET 8.0 |          4 |   100 | 12,712.2 ns | 244.25 ns | 190.70 ns | 12,670.2 ns |  1.09x slower |   0.02x | 12.8174 |   26912 B |     1.002x less |
|               LinqFaster | .NET 8.0 |          4 |   100 |    879.5 ns |   6.14 ns |   5.45 ns |    878.3 ns | 13.25x faster |   0.13x |  0.0114 |      24 B | 1,124.000x less |
|             LinqFasterer | .NET 8.0 |          4 |   100 | 15,198.3 ns | 301.43 ns | 698.62 ns | 14,780.6 ns |  1.32x slower |   0.06x | 34.8816 |   73168 B |     2.712x more |
|                   LinqAF | .NET 8.0 |          4 |   100 | 31,245.1 ns | 264.80 ns | 221.12 ns | 31,182.5 ns |  2.68x slower |   0.03x | 21.8506 |   45760 B |     1.696x more |
|               StructLinq | .NET 8.0 |          4 |   100 | 10,348.0 ns |  70.75 ns |  55.23 ns | 10,331.9 ns |  1.13x faster |   0.01x |  0.0305 |      64 B |   421.500x less |
| StructLinq_ValueDelegate | .NET 8.0 |          4 |   100 |  3,147.8 ns |  19.87 ns |  17.61 ns |  3,145.7 ns |  3.71x faster |   0.03x |       - |         - |              NA |
|                Hyperlinq | .NET 8.0 |          4 |   100 | 10,471.6 ns |  45.41 ns |  35.45 ns | 10,475.1 ns |  1.11x faster |   0.01x |       - |         - |              NA |
