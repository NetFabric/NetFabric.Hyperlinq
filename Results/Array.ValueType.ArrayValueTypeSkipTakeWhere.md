## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

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
| Method                   | Runtime  | Skip | Count | Mean        | Error     | StdDev    | Median      | Ratio         | RatioSD | Gen0    | Allocated | Alloc Ratio |
|------------------------- |--------- |----- |------ |------------:|----------:|----------:|------------:|--------------:|--------:|--------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 1000 | 100   |    91.40 ns |  1.863 ns |  1.829 ns |    90.43 ns |      baseline |         |       - |         - |          NA |
| Linq                     | .NET 8.0 | 1000 | 100   |   934.25 ns | 18.517 ns | 44.721 ns |   909.84 ns | 10.38x slower |   0.68x |  0.1526 |     320 B |          NA |
| LinqFaster               | .NET 8.0 | 1000 | 100   | 1,653.23 ns | 29.023 ns | 64.915 ns | 1,623.78 ns | 18.21x slower |   1.02x | 10.7803 |   22560 B |          NA |
| LinqFasterer             | .NET 8.0 | 1000 | 100   | 1,101.42 ns | 18.186 ns | 14.199 ns | 1,097.03 ns | 12.03x slower |   0.36x |  4.6501 |    9744 B |          NA |
| LinqAF                   | .NET 8.0 | 1000 | 100   | 1,831.29 ns | 18.269 ns | 14.263 ns | 1,832.50 ns | 20.00x slower |   0.45x |       - |         - |          NA |
| StructLinq               | .NET 8.0 | 1000 | 100   |   257.36 ns |  4.978 ns |  4.413 ns |   256.19 ns |  2.82x slower |   0.08x |  0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 1000 | 100   |   126.53 ns |  1.305 ns |  1.157 ns |   126.34 ns |  1.38x slower |   0.04x |       - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 1000 | 100   |   276.42 ns |  2.350 ns |  1.962 ns |   276.11 ns |  3.02x slower |   0.07x |       - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 1000 | 100   |   107.60 ns |  1.418 ns |  1.184 ns |   107.23 ns |  1.18x slower |   0.03x |       - |         - |          NA |
|                          |          |      |       |             |           |           |             |               |         |         |           |             |
| ForLoop                  | .NET 9.0 | 1000 | 100   |   143.47 ns |  2.281 ns |  2.022 ns |   143.26 ns |      baseline |         |       - |         - |          NA |
| Linq                     | .NET 9.0 | 1000 | 100   | 1,049.73 ns |  8.708 ns |  7.271 ns | 1,048.85 ns |  7.31x slower |   0.10x |  0.1526 |     320 B |          NA |
| LinqFaster               | .NET 9.0 | 1000 | 100   | 1,630.98 ns | 19.612 ns | 20.984 ns | 1,628.58 ns | 11.37x slower |   0.24x | 10.7803 |   22560 B |          NA |
| LinqFasterer             | .NET 9.0 | 1000 | 100   | 1,101.94 ns | 17.394 ns | 13.580 ns | 1,097.89 ns |  7.67x slower |   0.13x |  4.6501 |    9744 B |          NA |
| LinqAF                   | .NET 9.0 | 1000 | 100   | 1,832.61 ns | 14.433 ns | 12.052 ns | 1,831.29 ns | 12.76x slower |   0.19x |       - |         - |          NA |
| StructLinq               | .NET 9.0 | 1000 | 100   |   219.47 ns |  1.358 ns |  1.334 ns |   219.62 ns |  1.53x slower |   0.02x |  0.0458 |      96 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 1000 | 100   |   108.21 ns |  2.144 ns |  3.975 ns |   106.30 ns |  1.33x faster |   0.03x |       - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 1000 | 100   |   241.94 ns |  2.668 ns |  3.176 ns |   240.76 ns |  1.69x slower |   0.03x |       - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 1000 | 100   |    95.83 ns |  1.885 ns |  2.095 ns |    95.19 ns |  1.49x faster |   0.05x |       - |         - |          NA |
