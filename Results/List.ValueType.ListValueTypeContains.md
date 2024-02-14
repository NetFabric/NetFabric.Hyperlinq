## List.ValueType.ListValueTypeContains

### Source
[ListValueTypeContains.cs](../LinqBenchmarks/List/ValueType/ListValueTypeContains.cs)

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
| ForLoop                  | .NET 8.0 | 100   | 240.02 ns | 2.986 ns | 2.493 ns | 238.90 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   | 299.52 ns | 5.567 ns | 6.187 ns | 297.74 ns | 1.25x slower |   0.03x |      - |         - |          NA |
| List_Exists              | .NET 8.0 | 100   | 305.09 ns | 2.976 ns | 2.485 ns | 305.18 ns | 1.27x slower |   0.01x | 0.0305 |      64 B |          NA |
| Linq                     | .NET 8.0 | 100   |  51.73 ns | 0.806 ns | 0.896 ns |  51.44 ns | 4.62x faster |   0.10x |      - |         - |          NA |
| LinqFaster               | .NET 8.0 | 100   |  54.03 ns | 0.987 ns | 1.829 ns |  53.16 ns | 4.44x faster |   0.18x |      - |         - |          NA |
| LinqFasterer             | .NET 8.0 | 100   | 450.51 ns | 5.874 ns | 4.905 ns | 451.01 ns | 1.88x slower |   0.03x | 3.0670 |    6424 B |          NA |
| LinqAF                   | .NET 8.0 | 100   |  51.21 ns | 0.927 ns | 0.992 ns |  50.88 ns | 4.67x faster |   0.10x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   | 281.98 ns | 2.921 ns | 2.439 ns | 280.72 ns | 1.17x slower |   0.02x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 276.51 ns | 3.045 ns | 2.543 ns | 275.25 ns | 1.15x slower |   0.02x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   |  61.71 ns | 0.526 ns | 0.466 ns |  61.51 ns | 3.89x faster |   0.04x | 0.0153 |      32 B |          NA |
| Faslinq                  | .NET 8.0 | 100   | 316.18 ns | 3.296 ns | 3.237 ns | 315.83 ns | 1.32x slower |   0.02x | 0.0305 |      64 B |          NA |
|                          |          |       |           |          |          |           |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   | 242.50 ns | 2.087 ns | 2.320 ns | 241.68 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   | 303.15 ns | 2.141 ns | 1.788 ns | 302.81 ns | 1.25x slower |   0.01x |      - |         - |          NA |
| List_Exists              | .NET 9.0 | 100   | 311.04 ns | 6.013 ns | 7.819 ns | 308.54 ns | 1.28x slower |   0.04x | 0.0305 |      64 B |          NA |
| Linq                     | .NET 9.0 | 100   | 115.71 ns | 2.062 ns | 3.718 ns | 114.69 ns | 2.08x faster |   0.06x |      - |         - |          NA |
| LinqFaster               | .NET 9.0 | 100   | 117.80 ns | 2.378 ns | 5.965 ns | 114.61 ns | 2.06x faster |   0.11x |      - |         - |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 507.39 ns | 8.868 ns | 6.924 ns | 503.51 ns | 2.09x slower |   0.03x | 3.0670 |    6424 B |          NA |
| LinqAF                   | .NET 9.0 | 100   | 115.65 ns | 2.326 ns | 5.572 ns | 112.42 ns | 2.13x faster |   0.08x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   | 229.13 ns | 4.522 ns | 6.190 ns | 226.25 ns | 1.05x faster |   0.03x | 0.0191 |      40 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 264.37 ns | 2.750 ns | 2.438 ns | 263.33 ns | 1.09x slower |   0.01x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   | 116.89 ns | 0.698 ns | 0.583 ns | 116.75 ns | 2.08x faster |   0.02x | 0.0153 |      32 B |          NA |
| Faslinq                  | .NET 9.0 | 100   | 307.24 ns | 3.475 ns | 2.902 ns | 305.75 ns | 1.27x slower |   0.02x | 0.0305 |      64 B |          NA |
