## List.Int32.ListInt32ToArray

### Source
[ListInt32ToArray.cs](../LinqBenchmarks/List/Int32/ListInt32ToArray.cs)

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
| Method                   | Runtime  | Count | Mean     | Error    | StdDev   | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |---------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
| List_ToArray             | .NET 8.0 | 100   | 31.89 ns | 0.449 ns | 0.375 ns |     baseline |         | 0.2027 |     424 B |             |
| Linq                     | .NET 8.0 | 100   | 38.78 ns | 0.752 ns | 0.628 ns | 1.22x slower |   0.02x | 0.2027 |     424 B |  1.00x more |
| LinqFasterer             | .NET 8.0 | 100   | 36.21 ns | 0.767 ns | 1.323 ns | 1.16x slower |   0.05x | 0.2027 |     424 B |  1.00x more |
| LinqAF                   | .NET 8.0 | 100   | 39.93 ns | 0.826 ns | 1.044 ns | 1.26x slower |   0.05x | 0.2027 |     424 B |  1.00x more |
| StructLinq               | .NET 8.0 | 100   | 92.09 ns | 1.266 ns | 1.300 ns | 2.89x slower |   0.05x | 0.2180 |     456 B |  1.08x more |
| StructLinq_ValueDelegate | .NET 8.0 | 100   | 73.02 ns | 1.285 ns | 1.670 ns | 2.29x slower |   0.08x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq                | .NET 8.0 | 100   | 29.86 ns | 0.432 ns | 0.591 ns | 1.07x faster |   0.03x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   | 31.79 ns | 0.318 ns | 0.249 ns | 1.00x faster |   0.01x | 0.2027 |     424 B |  1.00x more |
|                          |          |       |          |          |          |              |         |        |           |             |
| List_ToArray             | .NET 9.0 | 100   | 34.16 ns | 0.734 ns | 0.901 ns |     baseline |         | 0.2027 |     424 B |             |
| Linq                     | .NET 9.0 | 100   | 39.85 ns | 0.814 ns | 0.680 ns | 1.17x slower |   0.03x | 0.2027 |     424 B |  1.00x more |
| LinqFasterer             | .NET 9.0 | 100   | 40.78 ns | 0.818 ns | 1.321 ns | 1.21x slower |   0.05x | 0.2027 |     424 B |  1.00x more |
| LinqAF                   | .NET 9.0 | 100   | 43.07 ns | 0.919 ns | 2.037 ns | 1.28x slower |   0.06x | 0.2027 |     424 B |  1.00x more |
| StructLinq               | .NET 9.0 | 100   | 90.59 ns | 0.599 ns | 0.531 ns | 2.65x slower |   0.08x | 0.2179 |     456 B |  1.08x more |
| StructLinq_ValueDelegate | .NET 9.0 | 100   | 72.74 ns | 1.256 ns | 0.981 ns | 2.14x slower |   0.05x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq                | .NET 9.0 | 100   | 32.74 ns | 0.485 ns | 0.539 ns | 1.04x faster |   0.04x | 0.2027 |     424 B |  1.00x more |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   | 32.46 ns | 0.386 ns | 0.322 ns | 1.05x faster |   0.04x | 0.2027 |     424 B |  1.00x more |
