## SingleBenchmarks

### Source
[SingleBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SingleBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.5.21301.5
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1055 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  Job-UNTOJZ : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|                         Method |                Categories |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |----------:|----------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array | 12.526 ns | 0.0206 ns | 0.0172 ns | 12.529 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_Array |                     Array | 14.608 ns | 0.0273 ns | 0.0228 ns | 14.603 ns |  1.17 |    0.00 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value | 27.451 ns | 0.5681 ns | 0.9174 ns | 26.928 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value | 16.618 ns | 0.0609 ns | 0.0540 ns | 16.613 ns |  0.59 |    0.02 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value | 27.694 ns | 0.5846 ns | 1.0690 ns | 27.020 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_Collection_Value |          Collection_Value | 19.865 ns | 0.0745 ns | 0.0697 ns | 19.860 ns |  0.68 |    0.01 |      - |     - |     - |         - |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|                Linq_List_Value |                List_Value |  8.626 ns | 0.0731 ns | 0.0684 ns |  8.596 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|           Hyperlinq_List_Value |                List_Value | 21.742 ns | 0.1679 ns | 0.1488 ns | 21.691 ns |  2.52 |    0.03 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value | 75.792 ns | 0.5077 ns | 0.4749 ns | 75.774 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference | 26.768 ns | 0.2276 ns | 0.2018 ns | 26.724 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference | 22.935 ns | 0.4758 ns | 0.7266 ns | 23.214 ns |  0.84 |    0.03 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference | 28.074 ns | 0.5883 ns | 1.1334 ns | 27.380 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Collection_Reference |      Collection_Reference | 18.836 ns | 0.4056 ns | 0.3596 ns | 18.713 ns |  0.68 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
|            Linq_List_Reference |            List_Reference |  8.563 ns | 0.0461 ns | 0.0408 ns |  8.560 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       Hyperlinq_List_Reference |            List_Reference | 24.796 ns | 0.5120 ns | 0.5478 ns | 24.930 ns |  2.89 |    0.08 | 0.0153 |     - |     - |      32 B |
|                                |                           |           |           |           |           |       |         |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference | 79.490 ns | 0.3291 ns | 0.2917 ns | 79.473 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
