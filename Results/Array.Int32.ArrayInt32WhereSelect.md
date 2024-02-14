## Array.Int32.ArrayInt32WhereSelect

### Source
[ArrayInt32WhereSelect.cs](../LinqBenchmarks/Array/Int32/ArrayInt32WhereSelect.cs)

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
| ForLoop                  | .NET 8.0 | 100   |  66.54 ns | 0.982 ns | 0.870 ns |  66.17 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |  67.47 ns | 0.636 ns | 0.497 ns |  67.41 ns | 1.02x slower |   0.01x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   | 222.99 ns | 1.089 ns | 0.909 ns | 223.04 ns | 3.36x slower |   0.04x | 0.0496 |     104 B |          NA |
| LinqFaster               | .NET 8.0 | 100   | 190.61 ns | 2.924 ns | 3.591 ns | 189.13 ns | 2.87x slower |   0.06x | 0.3173 |     664 B |          NA |
| LinqFasterer             | .NET 8.0 | 100   | 526.11 ns | 2.865 ns | 2.237 ns | 525.33 ns | 7.92x slower |   0.09x | 0.4129 |     864 B |          NA |
| LinqAF                   | .NET 8.0 | 100   | 178.47 ns | 3.525 ns | 5.167 ns | 176.12 ns | 2.68x slower |   0.09x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   | 172.70 ns | 3.105 ns | 2.592 ns | 171.49 ns | 2.60x slower |   0.04x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |  88.08 ns | 1.488 ns | 2.567 ns |  87.19 ns | 1.33x slower |   0.06x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   | 155.87 ns | 3.109 ns | 4.458 ns | 153.83 ns | 2.34x slower |   0.06x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |  77.92 ns | 1.579 ns | 2.161 ns |  77.12 ns | 1.17x slower |   0.03x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   | 244.73 ns | 4.842 ns | 9.890 ns | 239.15 ns | 3.73x slower |   0.20x | 0.2027 |     424 B |          NA |
|                          |          |       |           |          |          |           |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |  66.70 ns | 0.912 ns | 1.154 ns |  66.28 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |  66.20 ns | 1.054 ns | 0.880 ns |  66.02 ns | 1.01x faster |   0.02x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   | 237.61 ns | 2.099 ns | 1.861 ns | 237.25 ns | 3.55x slower |   0.08x | 0.0496 |     104 B |          NA |
| LinqFaster               | .NET 9.0 | 100   | 219.67 ns | 4.263 ns | 9.268 ns | 214.88 ns | 3.33x slower |   0.18x | 0.3173 |     664 B |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 518.69 ns | 4.883 ns | 4.078 ns | 517.27 ns | 7.73x slower |   0.11x | 0.4129 |     864 B |          NA |
| LinqAF                   | .NET 9.0 | 100   | 159.66 ns | 1.613 ns | 1.347 ns | 159.47 ns | 2.38x slower |   0.04x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   | 169.53 ns | 1.914 ns | 2.204 ns | 169.14 ns | 2.54x slower |   0.06x | 0.0305 |      64 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |  83.36 ns | 1.099 ns | 0.858 ns |  83.13 ns | 1.24x slower |   0.03x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   | 113.91 ns | 0.644 ns | 0.538 ns | 113.95 ns | 1.70x slower |   0.04x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |  88.90 ns | 1.738 ns | 1.860 ns |  87.78 ns | 1.33x slower |   0.04x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   | 209.17 ns | 3.158 ns | 2.466 ns | 208.23 ns | 3.11x slower |   0.06x | 0.2027 |     424 B |          NA |
