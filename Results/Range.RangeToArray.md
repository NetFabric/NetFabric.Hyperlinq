## Range.RangeToArray

### Source
[RangeToArray.cs](../LinqBenchmarks/Range/RangeToArray.cs)

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
|          Method |  Runtime | Start | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|---------------- |--------- |------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
|         ForLoop | .NET 6.0 |     0 |   100 |  76.28 ns | 0.807 ns | 0.716 ns |     baseline |         | 0.2027 |     424 B |             |
|            Linq | .NET 6.0 |     0 |   100 |  79.64 ns | 1.206 ns | 1.525 ns | 1.05x slower |   0.02x | 0.2218 |     464 B |  1.09x more |
|      LinqFaster | .NET 6.0 |     0 |   100 |  64.55 ns | 0.392 ns | 0.367 ns | 1.18x faster |   0.01x | 0.2027 |     424 B |  1.00x more |
| LinqFaster_SIMD | .NET 6.0 |     0 |   100 |  34.40 ns | 0.715 ns | 0.930 ns | 2.22x faster |   0.08x | 0.2027 |     424 B |  1.00x more |
|          LinqAF | .NET 6.0 |     0 |   100 | 200.17 ns | 1.912 ns | 1.597 ns | 2.62x slower |   0.03x | 0.2027 |     424 B |  1.00x more |
|      StructLinq | .NET 6.0 |     0 |   100 |  76.61 ns | 1.535 ns | 1.828 ns | 1.01x slower |   0.03x | 0.2027 |     424 B |  1.00x more |
|       Hyperlinq | .NET 6.0 |     0 |   100 |  38.60 ns | 0.396 ns | 0.351 ns | 1.98x faster |   0.02x | 0.2027 |     424 B |  1.00x more |
|                 |          |       |       |           |          |          |              |         |        |           |             |
|         ForLoop | .NET 8.0 |     0 |   100 |  83.27 ns | 0.478 ns | 0.531 ns |     baseline |         | 0.2027 |     424 B |             |
|            Linq | .NET 8.0 |     0 |   100 |  39.73 ns | 0.332 ns | 0.369 ns | 2.10x faster |   0.02x | 0.2218 |     464 B |  1.09x more |
|      LinqFaster | .NET 8.0 |     0 |   100 |  62.65 ns | 0.285 ns | 0.253 ns | 1.33x faster |   0.01x | 0.2027 |     424 B |  1.00x more |
| LinqFaster_SIMD | .NET 8.0 |     0 |   100 |  39.11 ns | 0.660 ns | 0.678 ns | 2.13x faster |   0.03x | 0.2027 |     424 B |  1.00x more |
|          LinqAF | .NET 8.0 |     0 |   100 | 122.38 ns | 2.362 ns | 2.094 ns | 1.47x slower |   0.03x | 0.2027 |     424 B |  1.00x more |
|      StructLinq | .NET 8.0 |     0 |   100 |  65.12 ns | 0.662 ns | 0.517 ns | 1.28x faster |   0.01x | 0.2027 |     424 B |  1.00x more |
|       Hyperlinq | .NET 8.0 |     0 |   100 |  43.50 ns | 0.928 ns | 0.953 ns | 1.92x faster |   0.04x | 0.2027 |     424 B |  1.00x more |
