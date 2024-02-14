## Array.Int32.ArrayInt32WhereCount

### Source
[ArrayInt32WhereCount.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereCount.cs)

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
| ForLoop                  | .NET 8.0 | 100   |  66.19 ns | 0.662 ns | 0.553 ns |  66.18 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |  66.25 ns | 0.620 ns | 0.484 ns |  66.26 ns | 1.00x slower |   0.01x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   | 172.06 ns | 1.690 ns | 1.878 ns | 171.41 ns | 2.61x slower |   0.04x | 0.0153 |      32 B |          NA |
| LinqFaster               | .NET 8.0 | 100   |  95.95 ns | 1.456 ns | 1.137 ns |  95.86 ns | 1.45x slower |   0.02x |      - |         - |          NA |
| LinqFasterer             | .NET 8.0 | 100   | 100.06 ns | 2.024 ns | 2.409 ns |  99.11 ns | 1.51x slower |   0.04x |      - |         - |          NA |
| LinqAF                   | .NET 8.0 | 100   | 191.49 ns | 3.551 ns | 5.528 ns | 189.49 ns | 2.93x slower |   0.09x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   | 162.08 ns | 2.827 ns | 3.471 ns | 161.17 ns | 2.44x slower |   0.06x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |  83.70 ns | 1.082 ns | 0.845 ns |  83.57 ns | 1.26x slower |   0.01x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   | 136.17 ns | 0.448 ns | 0.397 ns | 136.16 ns | 2.06x slower |   0.01x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |  60.54 ns | 0.814 ns | 0.761 ns |  60.13 ns | 1.09x faster |   0.01x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   | 155.42 ns | 1.805 ns | 1.507 ns | 155.12 ns | 2.35x slower |   0.04x | 0.2027 |     424 B |          NA |
|                          |          |       |           |          |          |           |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |  66.27 ns | 0.498 ns | 0.389 ns |  66.23 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |  66.84 ns | 1.324 ns | 1.174 ns |  66.30 ns | 1.01x slower |   0.01x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   | 219.91 ns | 4.362 ns | 8.192 ns | 216.33 ns | 3.36x slower |   0.16x | 0.0153 |      32 B |          NA |
| LinqFaster               | .NET 9.0 | 100   |  96.20 ns | 1.559 ns | 1.302 ns |  96.74 ns | 1.45x slower |   0.02x |      - |         - |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 108.18 ns | 1.974 ns | 2.424 ns | 107.46 ns | 1.63x slower |   0.04x |      - |         - |          NA |
| LinqAF                   | .NET 9.0 | 100   | 199.61 ns | 3.274 ns | 3.770 ns | 198.71 ns | 3.02x slower |   0.07x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   | 148.29 ns | 1.926 ns | 1.608 ns | 147.76 ns | 2.23x slower |   0.02x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |  82.76 ns | 1.622 ns | 2.109 ns |  81.88 ns | 1.26x slower |   0.03x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   | 111.40 ns | 1.443 ns | 1.126 ns | 111.11 ns | 1.68x slower |   0.02x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |  61.39 ns | 1.246 ns | 1.530 ns |  60.68 ns | 1.07x faster |   0.03x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   | 141.65 ns | 1.830 ns | 1.528 ns | 141.41 ns | 2.14x slower |   0.02x | 0.2027 |     424 B |          NA |
