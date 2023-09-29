## Range.Range

### Source
[Range.cs](../LinqBenchmarks/Range/Range.cs)

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
|          Method |  Runtime | Start | Count |      Mean |    Error |   StdDev |    Median |         Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|---------------- |--------- |------ |------ |----------:|---------:|---------:|----------:|--------------:|--------:|-------:|----------:|------------:|
|         ForLoop | .NET 6.0 |     0 |   100 |  32.92 ns | 0.427 ns | 0.379 ns |  32.79 ns |      baseline |         |      - |         - |          NA |
|            Linq | .NET 6.0 |     0 |   100 | 387.46 ns | 7.295 ns | 6.824 ns | 385.81 ns | 11.77x slower |   0.27x | 0.0191 |      40 B |          NA |
|      LinqFaster | .NET 6.0 |     0 |   100 | 110.18 ns | 1.857 ns | 2.064 ns | 109.88 ns |  3.35x slower |   0.08x | 0.2027 |     424 B |          NA |
| LinqFaster_SIMD | .NET 6.0 |     0 |   100 |  80.16 ns | 0.745 ns | 0.581 ns |  80.11 ns |  2.44x slower |   0.02x | 0.2027 |     424 B |          NA |
|          LinqAF | .NET 6.0 |     0 |   100 | 163.35 ns | 0.552 ns | 0.431 ns | 163.31 ns |  4.96x slower |   0.07x |      - |         - |          NA |
|      StructLinq | .NET 6.0 |     0 |   100 |  34.50 ns | 0.637 ns | 0.759 ns |  34.19 ns |  1.05x slower |   0.03x |      - |         - |          NA |
|       Hyperlinq | .NET 6.0 |     0 |   100 |  41.25 ns | 0.792 ns | 0.740 ns |  40.92 ns |  1.25x slower |   0.01x |      - |         - |          NA |
|                 |          |       |       |           |          |          |           |               |         |        |           |             |
|         ForLoop | .NET 8.0 |     0 |   100 |  33.49 ns | 0.306 ns | 0.271 ns |  33.46 ns |      baseline |         |      - |         - |          NA |
|            Linq | .NET 8.0 |     0 |   100 | 193.44 ns | 2.509 ns | 2.347 ns | 192.24 ns |  5.78x slower |   0.09x | 0.0191 |      40 B |          NA |
|      LinqFaster | .NET 8.0 |     0 |   100 | 107.67 ns | 2.138 ns | 2.625 ns | 106.49 ns |  3.22x slower |   0.09x | 0.2027 |     424 B |          NA |
| LinqFaster_SIMD | .NET 8.0 |     0 |   100 |  76.62 ns | 0.485 ns | 0.379 ns |  76.52 ns |  2.29x slower |   0.02x | 0.2027 |     424 B |          NA |
|          LinqAF | .NET 8.0 |     0 |   100 |  50.75 ns | 0.981 ns | 1.310 ns |  50.26 ns |  1.53x slower |   0.05x |      - |         - |          NA |
|      StructLinq | .NET 8.0 |     0 |   100 |  35.01 ns | 0.662 ns | 1.177 ns |  34.44 ns |  1.06x slower |   0.04x |      - |         - |          NA |
|       Hyperlinq | .NET 8.0 |     0 |   100 |  41.54 ns | 0.864 ns | 0.995 ns |  41.12 ns |  1.24x slower |   0.04x |      - |         - |          NA |
