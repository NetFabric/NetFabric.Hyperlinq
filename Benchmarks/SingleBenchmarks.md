## SingleBenchmarks

### Source
[SingleBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SingleBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21253.7
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                         Method |                Categories |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array | 12.650 ns | 0.0619 ns | 0.0579 ns | 12.631 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_Array |                     Array | 13.997 ns | 0.0338 ns | 0.0282 ns | 13.997 ns |  1.11 |    0.00 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value | 25.430 ns | 0.0973 ns | 0.0863 ns | 25.441 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value | 16.824 ns | 0.0445 ns | 0.0372 ns | 16.827 ns |  0.66 |    0.00 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value | 28.575 ns | 0.1370 ns | 0.1281 ns | 28.622 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Collection_Value |          Collection_Value | 19.161 ns | 0.0675 ns | 0.0632 ns | 19.128 ns |  0.67 |    0.00 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|                Linq_List_Value |                List_Value |  8.521 ns | 0.0541 ns | 0.0480 ns |  8.511 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_List_Value |                List_Value | 21.722 ns | 0.0978 ns | 0.0867 ns | 21.724 ns |  2.55 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value | 74.208 ns | 0.1987 ns | 0.1551 ns | 74.239 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference | 25.550 ns | 0.1125 ns | 0.1052 ns | 25.546 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference | 20.445 ns | 0.1046 ns | 0.0979 ns | 20.438 ns |  0.80 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference | 27.198 ns | 0.5710 ns | 0.9849 ns | 26.621 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Collection_Reference |      Collection_Reference | 20.031 ns | 0.4175 ns | 1.0003 ns | 19.390 ns |  0.76 |    0.04 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|            Linq_List_Reference |            List_Reference |  8.611 ns | 0.0424 ns | 0.0376 ns |  8.615 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_List_Reference |            List_Reference | 21.548 ns | 0.2435 ns | 0.2034 ns | 21.548 ns |  2.50 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference | 73.466 ns | 0.3094 ns | 0.2743 ns | 73.398 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
