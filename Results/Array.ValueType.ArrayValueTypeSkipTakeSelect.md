## Array.ValueType.ArrayValueTypeSkipTakeSelect

### Source
[ArrayValueTypeSkipTakeSelect.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeSelect.cs)

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
| Method                   | Runtime  | Skip | Count | Mean       | Error    | StdDev   | Median     | Ratio         | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |----- |------ |-----------:|---------:|---------:|-----------:|--------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 1000 | 100   |   122.7 ns |  1.55 ns |  1.29 ns |   122.1 ns |      baseline |         |      - |         - |          NA |
| Linq                     | .NET 8.0 | 1000 | 100   | 1,286.1 ns | 16.76 ns | 13.99 ns | 1,279.3 ns | 10.48x slower |   0.19x | 0.1526 |     320 B |          NA |
| LinqFaster               | .NET 8.0 | 1000 | 100   | 1,608.9 ns | 30.26 ns | 77.01 ns | 1,579.5 ns | 13.26x slower |   0.74x | 9.2010 |   19272 B |          NA |
| LinqFasterer             | .NET 8.0 | 1000 | 100   | 1,599.5 ns | 31.14 ns | 54.53 ns | 1,579.1 ns | 12.90x slower |   0.47x | 6.1531 |   12880 B |          NA |
| LinqAF                   | .NET 8.0 | 1000 | 100   | 2,436.5 ns | 27.40 ns | 24.29 ns | 2,426.1 ns | 19.87x slower |   0.24x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 1000 | 100   |   293.0 ns |  3.42 ns |  2.67 ns |   292.4 ns |  2.39x slower |   0.04x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 | 100   |   113.8 ns |  1.91 ns |  1.59 ns |   113.1 ns |  1.08x faster |   0.02x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 1000 | 100   |   288.1 ns |  4.66 ns |  3.89 ns |   287.6 ns |  2.35x slower |   0.04x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 1000 | 100   |   101.2 ns |  1.46 ns |  1.22 ns |   100.8 ns |  1.21x faster |   0.02x |      - |         - |          NA |
|                          |          |      |       |            |          |          |            |               |         |        |           |             |
| ForLoop                  | .NET 9.0 | 1000 | 100   |   123.9 ns |  1.53 ns |  1.20 ns |   123.9 ns |      baseline |         |      - |         - |          NA |
| Linq                     | .NET 9.0 | 1000 | 100   | 1,196.7 ns |  8.43 ns |  6.59 ns | 1,195.2 ns |  9.66x slower |   0.11x | 0.1526 |     320 B |          NA |
| LinqFaster               | .NET 9.0 | 1000 | 100   | 1,598.6 ns | 30.75 ns | 65.53 ns | 1,572.3 ns | 12.85x slower |   0.45x | 9.2010 |   19272 B |          NA |
| LinqFasterer             | .NET 9.0 | 1000 | 100   | 1,514.9 ns | 26.58 ns | 29.54 ns | 1,505.5 ns | 12.27x slower |   0.24x | 6.1531 |   12880 B |          NA |
| LinqAF                   | .NET 9.0 | 1000 | 100   | 2,494.6 ns | 49.12 ns | 77.91 ns | 2,473.1 ns | 19.85x slower |   0.77x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 1000 | 100   |   254.7 ns |  4.22 ns |  3.29 ns |   253.2 ns |  2.05x slower |   0.04x | 0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 1000 | 100   |   164.6 ns |  2.18 ns |  2.42 ns |   163.4 ns |  1.33x slower |   0.02x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 1000 | 100   |   300.5 ns |  3.58 ns |  2.99 ns |   299.9 ns |  2.42x slower |   0.03x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 1000 | 100   |   108.9 ns |  2.15 ns |  1.90 ns |   108.3 ns |  1.14x faster |   0.02x |      - |         - |          NA |
