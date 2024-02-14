## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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
| Method                   | Runtime  | Count | Mean      | Error    | StdDev   | Ratio        | RatioSD | Gen0   | Allocated | Alloc Ratio |
|------------------------- |--------- |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|------------:|
| ForLoop                  | .NET 8.0 | 100   |  43.11 ns | 0.889 ns | 1.303 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 8.0 | 100   |  42.56 ns | 0.631 ns | 0.559 ns | 1.02x faster |   0.04x |      - |         - |          NA |
| Linq                     | .NET 8.0 | 100   | 227.58 ns | 3.760 ns | 4.023 ns | 5.29x slower |   0.15x | 0.0153 |      32 B |          NA |
| LinqFaster               | .NET 8.0 | 100   | 135.68 ns | 2.542 ns | 2.253 ns | 3.14x slower |   0.13x |      - |         - |          NA |
| LinqFasterer             | .NET 8.0 | 100   | 132.64 ns | 2.047 ns | 1.709 ns | 3.06x slower |   0.12x |      - |         - |          NA |
| LinqAF                   | .NET 8.0 | 100   | 243.16 ns | 1.735 ns | 1.448 ns | 5.61x slower |   0.21x |      - |         - |          NA |
| StructLinq               | .NET 8.0 | 100   | 178.06 ns | 3.271 ns | 3.766 ns | 4.15x slower |   0.14x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 8.0 | 100   |  83.61 ns | 0.451 ns | 0.400 ns | 1.93x slower |   0.07x |      - |         - |          NA |
| Hyperlinq                | .NET 8.0 | 100   | 122.32 ns | 1.175 ns | 1.099 ns | 2.83x slower |   0.10x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 8.0 | 100   |  42.91 ns | 0.739 ns | 0.821 ns | 1.00x faster |   0.03x |      - |         - |          NA |
| Faslinq                  | .NET 8.0 | 100   | 278.56 ns | 4.840 ns | 4.291 ns | 6.44x slower |   0.26x | 0.2027 |     424 B |          NA |
|                          |          |       |           |          |          |              |         |        |           |             |
| ForLoop                  | .NET 9.0 | 100   |  43.12 ns | 0.816 ns | 1.386 ns |     baseline |         |      - |         - |          NA |
| ForeachLoop              | .NET 9.0 | 100   |  42.53 ns | 0.566 ns | 0.502 ns | 1.03x faster |   0.04x |      - |         - |          NA |
| Linq                     | .NET 9.0 | 100   | 224.89 ns | 2.228 ns | 1.860 ns | 5.14x slower |   0.21x | 0.0153 |      32 B |          NA |
| LinqFaster               | .NET 9.0 | 100   | 135.08 ns | 2.248 ns | 1.877 ns | 3.09x slower |   0.11x |      - |         - |          NA |
| LinqFasterer             | .NET 9.0 | 100   | 177.80 ns | 2.865 ns | 3.185 ns | 4.11x slower |   0.14x |      - |         - |          NA |
| LinqAF                   | .NET 9.0 | 100   | 288.77 ns | 1.272 ns | 0.993 ns | 6.59x slower |   0.27x |      - |         - |          NA |
| StructLinq               | .NET 9.0 | 100   | 179.01 ns | 3.595 ns | 3.362 ns | 4.11x slower |   0.14x | 0.0153 |      32 B |          NA |
| StructLinq_ValueDelegate | .NET 9.0 | 100   |  51.88 ns | 0.871 ns | 1.132 ns | 1.20x slower |   0.05x |      - |         - |          NA |
| Hyperlinq                | .NET 9.0 | 100   | 100.63 ns | 1.271 ns | 1.127 ns | 2.31x slower |   0.10x |      - |         - |          NA |
| Hyperlinq_ValueDelegate  | .NET 9.0 | 100   |  43.44 ns | 0.902 ns | 0.753 ns | 1.01x faster |   0.04x |      - |         - |          NA |
| Faslinq                  | .NET 9.0 | 100   | 255.68 ns | 5.115 ns | 7.497 ns | 5.91x slower |   0.28x | 0.2027 |     424 B |          NA |
