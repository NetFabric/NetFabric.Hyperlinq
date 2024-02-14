## List.ValueType.ListValueTypeToArray

### Source
[ListValueTypeToArray.cs](../LinqBenchmarks/List/ValueType/ListValueTypeToArray.cs)

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
| Method                   | Runtime  | Count | Mean     | Error   | StdDev   | Median   | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |---------:|--------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
| List_ToArray             | .NET 8.0 | 100   | 414.3 ns | 8.29 ns | 22.41 ns | 405.7 ns |     baseline |         | 3.0670 |   6.27 KB |             |
| Linq                     | .NET 8.0 | 100   | 407.5 ns | 4.42 ns |  3.69 ns | 406.0 ns | 1.03x faster |   0.07x | 3.0670 |   6.27 KB |  1.00x more |
| LinqFasterer             | .NET 8.0 | 100   | 410.0 ns | 6.71 ns |  5.95 ns | 408.9 ns | 1.02x faster |   0.06x | 3.0670 |   6.27 KB |  1.00x more |
| LinqAF                   | .NET 8.0 | 100   | 421.2 ns | 8.30 ns | 14.54 ns | 417.2 ns | 1.01x slower |   0.08x | 3.0670 |   6.27 KB |  1.00x more |
| StructLinq               | .NET 8.0 | 100   | 409.0 ns | 8.07 ns |  9.61 ns | 408.0 ns | 1.01x faster |   0.06x | 3.0861 |   6.31 KB |  1.01x more |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 327.9 ns | 3.32 ns |  4.08 ns | 327.5 ns | 1.26x faster |   0.07x | 3.0580 |   6.27 KB |  1.00x more |
| Hyperlinq                | .NET 8.0 | 100   | 408.7 ns | 8.25 ns | 19.44 ns | 401.5 ns | 1.02x faster |   0.05x | 3.0670 |   6.27 KB |  1.00x more |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   | 399.6 ns | 4.17 ns |  3.48 ns | 399.5 ns | 1.05x faster |   0.07x | 3.0670 |   6.27 KB |  1.00x more |
|                          |          |       |          |         |          |          |              |         |        |           |             |
| List_ToArray             | .NET 9.0 | 100   | 397.1 ns | 5.34 ns |  4.17 ns | 396.3 ns |     baseline |         | 3.0670 |   6.27 KB |             |
| Linq                     | .NET 9.0 | 100   | 426.9 ns | 8.75 ns | 25.25 ns | 414.0 ns | 1.06x slower |   0.07x | 3.0670 |   6.27 KB |  1.00x more |
| LinqFasterer             | .NET 9.0 | 100   | 407.3 ns | 8.14 ns | 18.88 ns | 399.0 ns | 1.03x slower |   0.05x | 3.0670 |   6.27 KB |  1.00x more |
| LinqAF                   | .NET 9.0 | 100   | 419.3 ns | 8.04 ns | 21.46 ns | 408.6 ns | 1.08x slower |   0.07x | 3.0670 |   6.27 KB |  1.00x more |
| StructLinq               | .NET 9.0 | 100   | 406.1 ns | 8.52 ns | 24.44 ns | 394.7 ns | 1.03x slower |   0.06x | 3.0861 |   6.31 KB |  1.01x more |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 331.2 ns | 6.29 ns | 15.55 ns | 324.2 ns | 1.21x faster |   0.03x | 3.0580 |   6.27 KB |  1.00x more |
| Hyperlinq                | .NET 9.0 | 100   | 402.5 ns | 7.64 ns | 17.40 ns | 394.8 ns | 1.02x slower |   0.05x | 3.0670 |   6.27 KB |  1.00x more |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   | 399.9 ns | 7.87 ns |  9.37 ns | 397.4 ns | 1.00x faster |   0.02x | 3.0670 |   6.27 KB |  1.00x more |
