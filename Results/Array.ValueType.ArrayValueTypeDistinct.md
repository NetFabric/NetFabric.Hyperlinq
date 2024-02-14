## Array.ValueType.ArrayValueTypeDistinct

### Source
[ArrayValueTypeDistinct.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeDistinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- StructLinq.BCL: [0.28.2](https://www.nuget.org/packages/StructLinq/0.28.2)
- NetFabric.Hyperlinq: [3.0.0-beta48](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta48)
- System.Linq.Async: [6.0.1](https://www.nuget.org/packages/System.Linq.Async/6.0.1)
- Faslinq: [1.0.5](https://www.nuget.org/packages/Faslinq/1.0.5)

### Results:
```

BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.3996/22H2/2022Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK 9.0.100-preview.1.24101.2
  [Host]     : .NET 6.0.26 (6.0.2623.60508), X64 RyuJIT AVX2
  Job-THTHEP : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  Job-OQLBIM : .NET 9.0.0 (9.0.24.8009), X64 RyuJIT AVX2


```
| Method                   | Runtime  | Duplicates | Count | Mean      | Error     | StdDev    | Median    | Ratio        | RatioSD | Gen0    | Allocated | Alloc Ratio   |
|------------------------- |--------- |----------- |------ |----------:|----------:|----------:|----------:|-------------:|--------:|--------:|----------:|--------------:|
| ForLoop                  | .NET 8.0 | 4          | 100   | 11.157 μs | 0.0955 μs | 0.1061 μs | 11.146 μs |     baseline |         | 12.8937 |   26976 B |               |
| ForeachLoop              | .NET 8.0 | 4          | 100   | 12.138 μs | 0.0966 μs | 0.0754 μs | 12.127 μs | 1.09x slower |   0.01x | 12.8937 |   26976 B |   1.000x more |
| Linq                     | .NET 8.0 | 4          | 100   | 13.240 μs | 0.2603 μs | 0.3975 μs | 13.108 μs | 1.18x slower |   0.03x | 12.8174 |   26848 B |   1.005x less |
| LinqFasterer             | .NET 8.0 | 4          | 100   | 13.820 μs | 0.2632 μs | 0.3329 μs | 13.711 μs | 1.24x slower |   0.03x | 22.7203 |   47544 B |   1.762x more |
| LinqAF                   | .NET 8.0 | 4          | 100   | 73.842 μs | 1.1697 μs | 0.9768 μs | 73.693 μs | 6.61x slower |   0.12x | 20.0195 |   42088 B |   1.560x more |
| StructLinq               | .NET 8.0 | 4          | 100   | 11.027 μs | 0.1957 μs | 0.2176 μs | 10.931 μs | 1.01x faster |   0.02x |  0.0153 |      56 B | 481.714x less |
| StructLinq_ValueDelegate | .NET 8.0 | 4          | 100   |  3.312 μs | 0.0511 μs | 0.0547 μs |  3.306 μs | 3.37x faster |   0.06x |       - |         - |            NA |
| Hyperlinq                | .NET 8.0 | 4          | 100   | 11.045 μs | 0.2168 μs | 0.1810 μs | 11.006 μs | 1.01x faster |   0.02x |       - |         - |            NA |
|                          |          |            |       |           |           |           |           |              |         |         |           |               |
| ForLoop                  | .NET 9.0 | 4          | 100   | 11.959 μs | 0.1634 μs | 0.1816 μs | 11.949 μs |     baseline |         | 12.8937 |   26976 B |               |
| ForeachLoop              | .NET 9.0 | 4          | 100   | 12.328 μs | 0.2445 μs | 0.6651 μs | 12.051 μs | 1.03x slower |   0.06x | 12.8937 |   26976 B |   1.000x more |
| Linq                     | .NET 9.0 | 4          | 100   | 13.357 μs | 0.1718 μs | 0.1434 μs | 13.341 μs | 1.12x slower |   0.02x | 12.8174 |   26848 B |   1.005x less |
| LinqFasterer             | .NET 9.0 | 4          | 100   | 14.259 μs | 0.2599 μs | 0.4414 μs | 14.160 μs | 1.19x slower |   0.04x | 22.7203 |   47544 B |   1.762x more |
| LinqAF                   | .NET 9.0 | 4          | 100   | 74.702 μs | 1.0986 μs | 0.9174 μs | 74.468 μs | 6.26x slower |   0.13x | 19.8975 |   41936 B |   1.555x more |
| StructLinq               | .NET 9.0 | 4          | 100   | 11.040 μs | 0.2166 μs | 0.2739 μs | 10.956 μs | 1.08x faster |   0.03x |  0.0153 |      56 B | 481.714x less |
| StructLinq_ValueDelegate | .NET 9.0 | 4          | 100   |  3.437 μs | 0.0674 μs | 0.1107 μs |  3.395 μs | 3.49x faster |   0.12x |       - |         - |            NA |
| Hyperlinq                | .NET 9.0 | 4          | 100   | 10.913 μs | 0.1772 μs | 0.1480 μs | 10.878 μs | 1.09x faster |   0.03x |       - |         - |            NA |
