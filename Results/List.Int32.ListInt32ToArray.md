## List.Int32.ListInt32ToArray

### Source
[ListInt32ToArray.cs](../LinqBenchmarks/List/Int32/ListInt32ToArray.cs)

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
|                   Method |  Runtime | Count |     Mean |    Error |   StdDev |   Median |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |---------:|---------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
|             List_ToArray | .NET 6.0 |   100 | 30.62 ns | 0.398 ns | 0.373 ns | 30.80 ns |     baseline |         | 0.2027 |     424 B |             |
|                     Linq | .NET 6.0 |   100 | 44.15 ns | 0.951 ns | 2.184 ns | 43.25 ns | 1.44x slower |   0.08x | 0.2027 |     424 B |  1.00x more |
|             LinqFasterer | .NET 6.0 |   100 | 35.90 ns | 0.384 ns | 0.321 ns | 36.00 ns | 1.17x slower |   0.02x | 0.2027 |     424 B |  1.00x more |
|                   LinqAF | .NET 6.0 |   100 | 39.33 ns | 0.392 ns | 0.385 ns | 39.40 ns | 1.29x slower |   0.03x | 0.2027 |     424 B |  1.00x more |
|               StructLinq | .NET 6.0 |   100 | 90.35 ns | 1.874 ns | 3.080 ns | 89.06 ns | 2.96x slower |   0.12x | 0.2180 |     456 B |  1.08x more |
| StructLinq_ValueDelegate | .NET 6.0 |   100 | 79.07 ns | 1.338 ns | 1.045 ns | 78.61 ns | 2.59x slower |   0.03x | 0.2027 |     424 B |  1.00x more |
|                Hyperlinq | .NET 6.0 |   100 | 33.21 ns | 0.434 ns | 0.339 ns | 33.21 ns | 1.09x slower |   0.02x | 0.2027 |     424 B |  1.00x more |
|  Hyperlinq_ValueDelegate | .NET 6.0 |   100 | 33.78 ns | 0.725 ns | 0.805 ns | 33.87 ns | 1.10x slower |   0.03x | 0.2027 |     424 B |  1.00x more |
|                          |          |       |          |          |          |          |              |         |        |           |             |
|             List_ToArray | .NET 8.0 |   100 | 31.50 ns | 0.380 ns | 0.407 ns | 31.39 ns |     baseline |         | 0.2027 |     424 B |             |
|                     Linq | .NET 8.0 |   100 | 38.12 ns | 0.620 ns | 0.714 ns | 37.90 ns | 1.21x slower |   0.03x | 0.2027 |     424 B |  1.00x more |
|             LinqFasterer | .NET 8.0 |   100 | 34.68 ns | 0.171 ns | 0.133 ns | 34.70 ns | 1.10x slower |   0.02x | 0.2027 |     424 B |  1.00x more |
|                   LinqAF | .NET 8.0 |   100 | 40.40 ns | 1.084 ns | 3.092 ns | 38.72 ns | 1.27x slower |   0.09x | 0.2027 |     424 B |  1.00x more |
|               StructLinq | .NET 8.0 |   100 | 89.64 ns | 1.423 ns | 1.582 ns | 89.04 ns | 2.85x slower |   0.07x | 0.2180 |     456 B |  1.08x more |
| StructLinq_ValueDelegate | .NET 8.0 |   100 | 71.85 ns | 1.373 ns | 1.686 ns | 71.30 ns | 2.29x slower |   0.07x | 0.2027 |     424 B |  1.00x more |
|                Hyperlinq | .NET 8.0 |   100 | 29.58 ns | 0.240 ns | 0.200 ns | 29.51 ns | 1.07x faster |   0.02x | 0.2027 |     424 B |  1.00x more |
|  Hyperlinq_ValueDelegate | .NET 8.0 |   100 | 29.43 ns | 0.174 ns | 0.146 ns | 29.50 ns | 1.07x faster |   0.02x | 0.2027 |     424 B |  1.00x more |
