## Array.ValueType.ArrayValueTypeContains

### Source
[ArrayValueTypeContains.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeContains.cs)

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
| Method                   | Runtime  | Count | Mean      | Error    | StdDev   | Median    | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|---------:|---------:|----------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   | 188.71 ns | 1.368 ns | 1.212 ns | 188.07 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   | 189.11 ns | 3.809 ns | 4.534 ns | 186.48 ns | 1.00x slower |   0.03x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   |  53.41 ns | 1.086 ns | 1.931 ns |  52.45 ns | 3.54x faster |   0.13x |      - |         - |          NA |
| LinqFaster               | .NET 8.0 | 100   |  60.65 ns | 0.528 ns | 0.412 ns |  60.64 ns | 3.11x faster |   0.03x |      - |         - |          NA |
| LinqFasterer             | .NET 8.0 | 100   |  51.73 ns | 0.944 ns | 1.470 ns |  51.06 ns | 3.66x faster |   0.10x |      - |         - |          NA |
| LinqAF                   | .NET 8.0 | 100   |  55.20 ns | 0.788 ns | 0.658 ns |  54.88 ns | 3.42x faster |   0.05x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   | 273.60 ns | 1.059 ns | 0.827 ns | 273.75 ns | 1.45x slower |   0.01x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 270.47 ns | 1.972 ns | 1.845 ns | 270.51 ns | 1.43x slower |   0.02x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   |  59.06 ns | 0.356 ns | 0.297 ns |  59.00 ns | 3.19x faster |   0.03x | 0.0153 |      32 B |          NA |
| Faslinq                  | .NET 8.0 | 100   | 300.23 ns | 3.906 ns | 3.462 ns | 299.41 ns | 1.59x slower |   0.02x | 0.0305 |      64 B |          NA |
|                          |          |       |           |          |          |           |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   | 192.53 ns | 1.055 ns | 1.037 ns | 192.13 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   | 199.17 ns | 3.926 ns | 4.822 ns | 197.15 ns | 1.04x slower |   0.03x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   | 113.78 ns | 0.945 ns | 0.789 ns | 113.54 ns | 1.69x faster |   0.01x |      - |         - |          NA |
| LinqFaster               | .NET 9.0 | 100   |  67.13 ns | 0.537 ns | 0.448 ns |  66.97 ns | 2.87x faster |   0.02x |      - |         - |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 115.92 ns | 2.335 ns | 5.077 ns | 112.89 ns | 1.67x faster |   0.07x |      - |         - |          NA |
| LinqAF                   | .NET 9.0 | 100   | 117.50 ns | 2.247 ns | 1.992 ns | 116.92 ns | 1.64x faster |   0.03x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   | 273.32 ns | 4.386 ns | 8.345 ns | 270.60 ns | 1.43x slower |   0.04x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 244.82 ns | 2.150 ns | 1.906 ns | 244.17 ns | 1.27x slower |   0.01x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   | 118.60 ns | 2.095 ns | 1.960 ns | 117.64 ns | 1.62x faster |   0.03x | 0.0153 |      32 B |          NA |
| Faslinq                  | .NET 9.0 | 100   | 313.39 ns | 2.762 ns | 2.306 ns | 313.05 ns | 1.63x slower |   0.02x | 0.0305 |      64 B |          NA |
